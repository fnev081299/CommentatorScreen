using Npgsql;
using System;
using System.ComponentModel;
using System.Threading;

namespace CommentatorScreen
{
    /// <summary>
    /// View model for the main window
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Sets if the application is darkmode
        /// </summary>
        public bool IsDarkMode { get; set; }

        /// <summary>
        /// View model for current pair section
        /// </summary>
        public CurrentPairViewModel CurrentPairViewModel { get; set; }

        /// <summary>
        /// View model for runlog section
        /// </summary>
        public RunlogViewModel RunlogViewModel { get; set; }

        /// <summary>
        /// View model for qualifying section
        /// </summary>
        public QualifyingViewModel QualifyingViewModel { get; set; }

        /// <summary>
        /// View model for the run history section
        /// </summary>
        public RunHistoryViewModel RunHistoryViewModel { get; set; }

        /// <summary>
        /// Current category in use by the racecomputer
        /// </summary>
        public RnCateg CurrentCategory { get; set; }

        /// <summary>
        /// The current mode
        /// </summary>
        public string Mode { get; set; }

        #endregion Public Properties

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
        public MainWindowViewModel()
        {
            // Data access object
            DataAccessProvider dataAccessProvider = new(new racenetdbContext());

            // Get the current config
            GetConfig();

            // Create all the subsection view models
            RunlogViewModel = new RunlogViewModel();
            QualifyingViewModel = new QualifyingViewModel(CurrentCategory);
            RunHistoryViewModel = new RunHistoryViewModel(CurrentCategory.Id);

            // Start a background thread for monitoring rn_runlog changes
            var ts = new ThreadStart(ListenForUpdates);
            var predictionsThread = new Thread(ts);
            predictionsThread.Start();
        }

        #endregion Constructor

        #region Functions

        public void ListenForUpdates()
        {
            // Open a connection to the DB
             using var conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=racenetdb_test;UserId=postgres;Password=password");
            conn.Open();

            // For each runlogClient notification
            conn.Notification += (o, e) =>
            {
                // Call this method
                GetConfig();
            };

            // Listen for this trigger
            using (var cmd = new NpgsqlCommand("LISTEN configClient", conn))
                cmd.ExecuteNonQuery();

            // Do forever
            while (true)
                conn.Wait();
        }

        public void GetConfig()
        {
            try
            {
                // Open data access object
                using racenetdbContext db = new();
                DataAccessProvider dataAccessProvider = new(db);

                //Get the current category
                CurrentCategory = dataAccessProvider.GetCurrentCategory();

                // Get the current mode
                Mode = dataAccessProvider.GetMode();

                // Reset all the view models
                CurrentPairViewModel = new CurrentPairViewModel(CurrentCategory, Mode);

                // Checks if the qualifying category's id matches the active category id
                if (QualifyingViewModel == null || QualifyingViewModel.Category.Id == CurrentCategory.Id)
                {
                    QualifyingViewModel = new QualifyingViewModel(CurrentCategory);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Functions
    }
}