namespace CommentatorScreen
{
    /// <summary>
    /// Class for storing qualifying runs
    /// With driver file information included
    /// </summary>
    public class QualifyingRun
    {
        #region Properties

        /// <summary>
        /// Race Number
        /// </summary>
        public string Racenum { get; set; }

        /// <summary>
        /// Time to react
        /// </summary>
        public decimal? Reaction { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        public decimal? Index { get; set; }

        /// <summary>
        /// Time to finish
        /// </summary>
        public decimal? Et { get; set; }

        /// <summary>
        /// Speed at finish
        /// </summary>
        public decimal? Speed { get; set; }

        /// <summary>
        /// Name of the driver
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// Id of the category
        /// </summary>
        public int CategoryId { get; set; }

        #endregion Properties

        public QualifyingRun()
        { }
    }
}