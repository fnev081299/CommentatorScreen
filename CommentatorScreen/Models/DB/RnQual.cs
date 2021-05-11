#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Each round's qualifying information
    /// Derived from QUALx.RND
    /// </summary>
    public partial class RnQual
    {
        /// <summary>
        /// Category number as per race computer category screen
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Qualifying Round
        /// </summary>
        public int? Qualrnd { get; set; }

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
        /// Internal database serial number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Remarks
        /// (Disqualifications, fouls, etc)
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Run Number
        /// </summary>
        public int? Runid { get; set; }
    }
}