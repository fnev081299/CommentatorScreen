namespace CommentatorScreen
{
    /// <summary>
    /// Object for storing a history run
    /// </summary>
    public class RacerHistoryRun
    {
        /// <summary>
        /// Index of the run
        /// </summary>
        public decimal? Index { get; set; }

        /// <summary>
        /// Time to react
        /// </summary>
        public decimal? Reaction { get; set; }

        /// <summary>
        /// Time to finish
        /// </summary>
        public decimal? ET { get; set; }

        /// <summary>
        /// Speed at finish
        /// </summary>
        public decimal? MPH { get; set; }

        /// <summary>
        /// Lane of the run
        /// </summary>
        public bool Lane { get; set; }

        /// <summary>
        /// Result of the run
        /// </summary>
        public string Result { get; set; }
    }
}