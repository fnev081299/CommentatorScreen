using System;

#nullable disable

namespace CommentatorScreen
{
    public partial class RnRunlog
    {
        /// <summary>
        /// Id of the run
        /// </summary>
        public int Runid { get; set; }

        /// <summary>
        /// Time the run took place
        /// </summary>
        public DateTime? Time { get; set; }

        /// <summary>
        /// Id of the category the run was in
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Mode of the run,
        /// Qualfying, Time Trials, Eliminations
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Lane of the run
        /// True is left, right is false
        /// </summary>
        public bool Lane { get; set; }

        /// <summary>
        /// Id of the driver completing
        /// </summary>
        public string Racenum { get; set; }

        /// <summary>
        /// Dial in of the run
        /// </summary>
        public decimal? Index { get; set; }

        /// <summary>
        /// R.T of the run
        /// </summary>
        public decimal? Reaction { get; set; }

        /// <summary>
        /// Time to 60 feet
        /// </summary>
        public decimal? Et60 { get; set; }

        /// <summary>
        /// Time to 330 feet
        /// </summary>
        public decimal? Et330 { get; set; }

        /// <summary>
        /// Time to 594 feet
        /// </summary>
        public decimal? Et594 { get; set; }

        /// <summary>
        /// Time to 660 feet
        /// </summary>
        public decimal? Et660 { get; set; }

        /// <summary>
        /// Speed at 660 feet
        /// </summary>
        public decimal? Speed660 { get; set; }

        /// <summary>
        /// Time to 1000 feet
        /// </summary>
        public decimal? Et1000 { get; set; }

        /// <summary>
        /// Speed at 1000 feet
        /// </summary>
        public decimal? Speed1000 { get; set; }

        /// <summary>
        /// Time to 1320 feet
        /// </summary>
        public decimal? Et1320 { get; set; }

        /// <summary>
        /// Speed at 1320 feet
        /// </summary>
        public decimal? Speed1320 { get; set; }

        /// <summary>
        /// Result of the race
        ///
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Any remarks about the race
        /// Redlights, breakout, run teminated etc
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Time differance between the two cars finishing
        /// </summary>
        public decimal? Diff { get; set; }
    }
}