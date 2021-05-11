using Npgsql;
using System;
using System.ComponentModel;
using System.Threading;

namespace CommentatorScreen
{
    /// <summary>
    /// View model for the activate run information section
    /// </summary>
    public class CurrentPairViewModel : INotifyPropertyChanged
    {
        #region Public properties

        /// <summary>
        /// Left lane sponsor image
        /// </summary>
        public int LeftLaneSponsor { get; set; }

        /// <summary>
        /// Right lane sponsor image
        /// </summary>
        public int RightLaneSponsor { get; set; }

        /// <summary>
        /// Current category being used by the race computer
        /// </summary>
        public RnCateg CurrentCategory { get; set; }

        /// <summary>
        /// All the incrementals for the current pair
        /// </summary>
        public CnnCurrentpair CurrentPair { get; set; }

        /// <summary>
        /// Driver information file for the left lane
        /// </summary>
        public RnRacer LeftDriver { get; set; }

        /// <summary>
        /// Driver information file for the left lane
        /// </summary>
        public RnRacer RightDriver { get; set; }

        /// <summary>
        /// Next Driver information file for the left lane
        /// </summary>
        public RnRacer LeftNextDriver { get; set; }

        /// <summary>
        /// Next Driver information file for the right lane
        /// </summary>
        public RnRacer RightNextDriver { get; set; }

        /// <summary>
        /// The mode of the current category
        /// </summary>
        public string Mode { get; set; }

        #endregion Public properties

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
        /// Constructor
        /// </summary>
        public CurrentPairViewModel(RnCateg categ, string mode)
        {
            // Set current category
            CurrentCategory = categ;

            // Set the mode
            Mode = mode;

            GetCurrentPair();

            // Start a background thread for monitoring cnn_prediction changes
            var ts = new ThreadStart(ListenForUpdates);
            var predictionsThread = new Thread(ts);
            predictionsThread.Start();
        }

        #endregion Constructor

        #region Functions

        public void GetCurrentPair()
        {
            try
            {
                // Open database access
                DataAccessProvider dataAccessProvider = new(new racenetdbContext());

                // Load the current pair
                CurrentPair = dataAccessProvider.GetCurrentPair();

                if (CurrentPair != null)
                {
                    // Get driver files
                    LeftDriver = dataAccessProvider.GetDriverFile
                        (CurrentCategory.Id, CurrentPair.Leftracenum);

                    RightDriver = dataAccessProvider.GetDriverFile
                        (CurrentCategory.Id, CurrentPair.Rightracenum);

                    LeftNextDriver = dataAccessProvider.GetDriverFile
                        (CurrentCategory.Id, CurrentPair.Leftnextracenum);

                    RightNextDriver = dataAccessProvider.GetDriverFile
                        (CurrentCategory.Id, CurrentPair.Rightnextracenum);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Backgound thread for monitoring prediction changes
        /// </summary>
        public void ListenForUpdates()
        {
            // Open a connection to the DB
            using var conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=racenetdb_test;UserId=postgres;Password=password");
            conn.Open();

            // For each runlogClient notification
            conn.Notification += (o, e) =>
            {
                // Call this method
                GetCurrentPair();
            };

            // Listen for this trigger
            using (var cmd = new NpgsqlCommand("LISTEN predictionsClient", conn))
                cmd.ExecuteNonQuery();

            // Do forever
            while (true)
                conn.Wait();
        }

        #endregion Functions
    }
}