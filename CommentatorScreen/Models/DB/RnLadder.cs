#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Ladder pairings information
    /// Derived from LADDERS.RND & RNDx.RND
    /// </summary>
    public partial class RnLadder
    {
        /// <summary>
        /// Category number as per race computer category screen
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// Elimination Round number
        /// </summary>
        public int Elimrnd { get; set; }

        /// <summary>
        /// Order of pair within ladder
        /// </summary>
        public int Pair { get; set; }

        /// <summary>
        /// First race number
        /// </summary>
        public string Racenum1 { get; set; }

        /// <summary>
        /// Opponent
        /// </summary>
        public string Racenum2 { get; set; }

        /// <summary>
        /// Internal database serial number
        /// </summary>
        public int Id { get; set; }
    }
}