using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CommentatorScreen
{
    public class QualifyingViewModel : INotifyPropertyChanged
    {
        #region Public properties

        /// <summary>
        /// The selected category
        /// </summary>
        public RnCateg Category { get; set; }

        /// <summary>
        /// List of all the best qualifying attempts
        /// </summary>
        public ObservableCollection<QualifyingRun> QualifyingAttempts { get; set; }

        /// <summary>
        /// Flag for if the list is being refreshed
        /// </summary>
        public bool IsRefreshing { get; set; } = false;

        /// <summary>
        /// Flag to indicate that the qualifying list
        /// should be updated after every run
        /// False should be used so user can look at other categories
        /// without it focusing back on current category after new run
        /// </summary>
        public bool IsFocusedOnCategory { get; set; } = true;

        #endregion Public properties

        #region Commands

        /// <summary>
        /// Command for showing qualifying for the next category
        /// </summary>
        public ICommand NextCategory { get; set; }

        /// <summary>
        /// Command for showing qualifying for the prevouis category
        /// </summary>
        public ICommand PrevCategory { get; set; }

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
        /// Constructor
        /// </summary>
        /// <param name="category"></param>
        public QualifyingViewModel(RnCateg category)
        {
            // Set this category
            Category = category;

            // Display the qualifying
            GetQualifying();

            /// Setup the commands
            NextCategory = new RelayCommand(GetNextCategory);
            PrevCategory = new RelayCommand(GetPrevCategory);
        }

        #endregion Constructor

        #region Functions

        /// <summary>
        /// Sets the qualifying list to the list in the DB
        /// </summary>
        private void GetQualifying()
        {
            // Set the flag
            IsRefreshing = true;

            try
            {
                // Database access object
                using racenetdbContext db = new();
                DataAccessProvider dataAcessProvider = new(db);

                // Set the list
                QualifyingAttempts = new ObservableCollection<QualifyingRun>(dataAcessProvider.GetCurrentQualifying(Category.Id));

                racenetdbContext racenetdbContext = new();

                //QualifyingAttempts = new(qualifyingAttempts.OrderBy(q => q.Et).ToList());
            }
            catch (Exception e)
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
        /// Gets the qualifying list for the next category
        /// </summary>
        private void GetNextCategory()
        {
            // Check not already being refreshed
            if (!IsRefreshing)
            {
                IsRefreshing = true;

                try
                {
                    // Database access object
                    using racenetdbContext db = new();
                    DataAccessProvider dataAcessProvider = new(db);

                    // Get the next category id
                    int nextCategoryId = Category.Id + 1;

                    // After 24, reset to 1
                    if (Category.Id >= 24)
                    {
                        nextCategoryId = 1;
                    }

                    // Get the category
                    Category = dataAcessProvider.GetCategory(nextCategoryId);

                    // Display its qualifying
                    GetQualifying();
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
        }

        /// <summary>
        /// Gets the qualifying list for the prevouis category
        /// </summary>
        private void GetPrevCategory()
        {
            // Check not already being refreshed
            if (!IsRefreshing)
            {
                IsRefreshing = true;

                try
                {
                    // Database access object
                    using racenetdbContext db = new();
                    DataAccessProvider dataAcessProvider = new(db);

                    // Get the prev category id
                    int prevCategoryId = Category.Id - 1;

                    // At 0, reset to 24
                    if (Category.Id <= 1)
                    {
                        prevCategoryId = 24;
                    }

                    // Get the category
                    Category = dataAcessProvider.GetCategory(prevCategoryId);

                    // Display its qualifying
                    GetQualifying();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    // Reset
                    IsRefreshing = false;
                }
            }
        }

        #endregion Functions
    }
}