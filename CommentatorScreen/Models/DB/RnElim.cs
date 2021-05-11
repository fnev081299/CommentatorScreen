#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Runs from elimination rounds
    /// Derived from ELIMx.RND files
    /// </summary>
    public partial class RnElim
    {
        /// <summary>
        /// Category number as per race computer category screen
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Elimination Round number
        /// </summary>
        public int? Elimrnd { get; set; }

        /// <summary>
        /// Lane the run took place in
        /// FALSE: left, TRUE: right
        /// </summary>
        public bool? Lane { get; set; }

        /// <summary>
        /// Racenumber of the driver
        /// </summary>
        public string Racenum { get; set; }

        /// <summary>
        /// Time to react after the green light
        /// </summary>
        public decimal? Reaction { get; set; }

        /// <summary>
        /// Index of the run
        /// </summary>
        public decimal? Index { get; set; }

        /// <summary>
        /// Time to the finish line
        /// </summary>
        public decimal? Et { get; set; }

        /// <summary>
        /// Speed at the finish line
        /// </summary>
        public decimal? Speed { get; set; }

        /// <summary>
        /// Result
        /// Win / Lose
        /// </summary>
        public bool? Result { get; set; }

        /// <summary>
        /// Any remarks
        /// Redlight, breakout etc
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Internal database serial number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the run
        /// </summary>
        public int? Runid { get; set; }
    }
}