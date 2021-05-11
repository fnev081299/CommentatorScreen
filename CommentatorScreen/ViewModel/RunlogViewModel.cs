using Npgsql;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace CommentatorScreen
{
    /// <summary>
    /// View model for the run log
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class RunlogViewModel : INotifyPropertyChanged
    {
        #region Private properties

        /// <summary>
        /// List to hold all the runs of the run log
        /// </summary>
        private ObservableCollection<RnRunlog> runlog;

        /// <summary>
        /// The last searched text in the list
        /// </summary>
        private string lastSearchText;

        /// <summary>
        /// Current searched text
        /// </summary>
        private string searchText;

        #endregion Private properties

        #region Public Properties

        /// <summary>
        /// List to hold all the runs of the run log
        /// </summary>
        public ObservableCollection<RnRunlog> Runlog
        {
            get { return runlog; }
            private set
            {
                if (runlog == value)
                {
                    return;
                }

                // Update it
                runlog = value;

                // Match filtered runs
                FilteredRunlog = new ObservableCollection<RnRunlog>(runlog);
            }
        }

        /// <summary>
        /// A copy of <see cref="Runlog"/> which can be filtered
        /// </summary>
        public ObservableCollection<RnRunlog> FilteredRunlog { get; set; }

        /// <summary>
        /// Count the number of runs on screen
        /// </summary>
        public int RunlogCount { get { return FilteredRunlog.Count; } }

        /// <summary>
        /// DT that last run was added to the runlog
        /// </summary>
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        /// <summary>
        /// The textbox that is used to search the runlog
        /// </summary>
        public string SearchText
        {
            get { return searchText; }
            set
            {
                //Check the text has changed
                if (searchText == value)
                {
                    return;
                }

                // Update it
                searchText = value;

                //If the search text is empty
                if (string.IsNullOrEmpty(searchText))
                {
                    //Search to restore runlog
                    Search();
                }
            }
        }

        /// <summary>
        /// Flag to say is that runlog is refreshing
        /// </summary>
        public bool IsRefreshing { get; set; } = false;

        #endregion Public Properties

        #region Commands

        /// <summary>
        /// Command to update the data grid
        /// </summary>
        public ICommand RefreshRuns { get; set; }

        /// <summary>
        /// Command for searching the run log
        /// </summary>
        public ICommand SearchCommand { get; set; }

        #endregion Commands

        #region Events

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion Events

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunlogViewModel()
        {
            // Get the run log
            GetRunlog();

            // Set up the command
            RefreshRuns = new RelayCommand(GetRunlog);
            SearchCommand = new RelayCommand(Search);

            // Start a background thread for monitoring rn_runlog changes
            var ts = new ThreadStart(ListenForUpdates);
            var predictionsThread = new Thread(ts);
            predictionsThread.Start();
        }

        #endregion Constructor

        #region Functions

        /// <summary>
        /// Searches the run log and filters it
        /// </summary>
        public void Search()
        {
            // Dont search for the same text
            if ((string.IsNullOrEmpty(lastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(lastSearchText, SearchText))
            {
                return;
            }

            // Check there are some run logs to search and valid text
            if (runlog.Count <= 0 || runlog == null || string.IsNullOrEmpty(SearchText))
            {
                //Make filtered items the orginal list
                FilteredRunlog = new ObservableCollection<RnRunlog>(Runlog);

                lastSearchText = SearchText;

                return;
            }

            DataAccessProvider dataAccessProvider = new(new racenetdbContext());

            // Find runs that have a driver name / racenumber match
            // TODO: Change this to a db query
            FilteredRunlog = new ObservableCollection<RnRunlog>(dataAccessProvider.GetRunlogByRacenumber(SearchText));
            lastSearchText = SearchText;
        }

        /// <summary>
        /// Gets the runlog from the database
        /// </summary>
        /// <returns></returns>
        public void GetRunlog()
        {
            // Set flag
            IsRefreshing = true;

            try
            {
                // Open data access object
                using racenetdbContext db = new();
                DataAccessProvider dataAcessProvider = new(db);

                // Set the runlog last to the database
                Runlog = new ObservableCollection<RnRunlog>(dataAcessProvider.GetRunlog());

                // Update the time
                LastUpdated = DateTime.Now;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Reset flag
                IsRefreshing = false;
            }
        }

        /// <summary>
        /// Backgound thread for monitoring runlog changes
        /// </summary>
        public void ListenForUpdates()
        {
            // Open a connection to the DB
            using var conn = new NpgsqlConnection
                ("Server=127.0.0.1;Port=5432;Database=racenetdb_test;" +
                "UserId=postgres;Password=password");
            conn.Open();

            // For each runlogClient notification
            conn.Notification += (o, e) =>
            {
                // Call this method
                GetRunlog();
            };

            // Listen for this trigger
            using (var cmd = new NpgsqlCommand("LISTEN runlogClient", conn))
                cmd.ExecuteNonQuery();

            // Do forever
            while (true)
                conn.Wait();
        }

        #endregion Functions
    }
}