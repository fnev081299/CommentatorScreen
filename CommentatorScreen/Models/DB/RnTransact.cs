#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Log of database changes
    /// </summary>
    public partial class RnTransact
    {
        /// <summary>
        /// Internal database serial number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string Tablename { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Type of update
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Notes { get; set; }
    }
}