#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Track, event & lane info
    /// Derived from NTRACK.DAT
    /// </summary>
    public partial class RnTrackinfo
    {
        /// <summary>
        /// Name of the tracl
        /// </summary>
        public string Trackname { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        public string Eventname { get; set; }

        /// <summary>
        /// Left lane sponsor
        /// </summary>
        public string Leftlane { get; set; }

        /// <summary>
        /// Right lane sponsor
        /// </summary>
        public string Rightlane { get; set; }
    }
}