using System.Collections.ObjectModel;

namespace CommentatorScreen
{
    public class RunHistoryViewModel
    {
        /// <summary>
        /// Current left lane driver file
        /// </summary>
        public RnRacer CurrentLeftLaneDriver { get; set; }

        /// <summary>
        /// List of prevouis runs by the current driver in the left lane
        /// </summary>
        public ObservableCollection<RacerHistoryRun> CurrentLeftLaneHistory { get; set; }

        /// <summary>
        /// Current right lane driver file
        /// </summary>
        public RnRacer CurrentRightLaneDriver { get; set; }

        /// <summary>
        /// List of prevouis runs by the current driver in the right lane
        /// </summary>
        public ObservableCollection<RacerHistoryRun> CurrentRightLaneHistory { get; set; }

        /// <summary>
        /// Next left lane driver file
        /// </summary>
        public RnRacer NextLeftLaneDriver { get; set; }

        /// <summary>
        /// List of prevouis runs by the next driver in the left lane
        /// </summary>
        public ObservableCollection<RacerHistoryRun> NextLeftLaneHistory { get; set; }

        /// <summary>
        /// Next right lane driver file
        /// </summary>
        public RnRacer NextRightLaneDriver { get; set; }

        /// <summary>
        /// List of prevouis runs by the next driver in the right lane
        /// </summary>
        public ObservableCollection<RacerHistoryRun> NextRightLaneHistory { get; set; }

        public RunHistoryViewModel(int categoryid)
        {
            DataAccessProvider dataAccessProvider = new(new racenetdbContext());

            // Get racenumbers of current and next pair
            string[] currRacenumbers = dataAccessProvider.GetCurrentPairRacenumbers();
            string[] nxtRacenumbers = dataAccessProvider.GetNextPairRacenumbers();

            // Get driver files for the current drivers
            CurrentLeftLaneDriver = dataAccessProvider.GetDriverFile(categoryid, currRacenumbers[0]);
            CurrentRightLaneDriver = dataAccessProvider.GetDriverFile(categoryid, currRacenumbers[1]);

            // Get driver files for next drivers
            NextLeftLaneDriver = dataAccessProvider.GetDriverFile(categoryid, nxtRacenumbers[0]);
            NextRightLaneDriver = dataAccessProvider.GetDriverFile(categoryid, nxtRacenumbers[1]);

            // Get the run history for each lane and store
            CurrentLeftLaneHistory = new(dataAccessProvider.GetDriverHistory(categoryid, CurrentLeftLaneDriver.Racenum));
            CurrentRightLaneHistory = new(dataAccessProvider.GetDriverHistory(categoryid, CurrentRightLaneDriver.Racenum));

            NextLeftLaneHistory = new(dataAccessProvider.GetDriverHistory(categoryid, NextLeftLaneDriver.Racenum));
            NextRightLaneHistory = new(dataAccessProvider.GetDriverHistory(categoryid, NextRightLaneDriver.Racenum));
        }
    }
}