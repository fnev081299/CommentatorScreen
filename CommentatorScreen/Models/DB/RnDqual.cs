#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Disqualification reasons list.
    /// Derived from DQUAL.DAT
    /// </summary>
    public partial class RnDqual
    {
        /// <summary>
        /// Internal database serial number
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Disqualification index
        /// </summary>
        public string Dqindex { get; set; }
    }
}