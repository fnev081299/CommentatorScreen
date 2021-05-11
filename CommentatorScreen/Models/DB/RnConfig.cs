#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Holds current information
    /// about the race computer
    /// </summary>
    public partial class RnConfig
    {
        /// <summary>
        /// Current category in use by the racecomputer
        /// </summary>
        public int CurrentCategory { get; set; }

        /// <summary>
        /// Current mode in use by the racecomputer
        /// </summary>
        public string Mode { get; set; }
    }
}