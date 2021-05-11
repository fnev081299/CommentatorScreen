#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Object for each record in rn_class
    /// Represent subclasses within categories
    /// Derived from CATDIR\CATSxx files
    /// </summary>
    public partial class RnClass
    {
        /// <summary>
        /// Category number as per race computer category screen
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Id of the class
        /// </summary>
        public int? Classid { get; set; }

        /// <summary>
        /// Class name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default 1/8 Index
        /// </summary>
        public decimal? Index660 { get; set; }

        /// <summary>
        /// Default 1/4 Index
        /// </summary>
        public decimal? Index1320 { get; set; }

        /// <summary>
        /// Internal database serial number
        /// </summary>
        public int Id { get; set; }
    }
}