#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// ET Slip Header information
    /// Derived From SLIP1.DAT
    /// </summary>
    public partial class RnEtslip
    {
        /// <summary>
        /// Line Number (0 for footer)
        /// </summary>
        public int? Line { get; set; }

        /// <summary>
        /// Text of the line
        /// </summary>
        public string Text { get; set; }
    }
}