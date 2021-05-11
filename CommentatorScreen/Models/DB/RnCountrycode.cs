#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Maps 2 letter codes from the driver files to
    /// their 3 letter ISO code and full country name
    /// </summary>
    public partial class RnCountrycode
    {
        /// <summary>
        /// Two character code
        /// </summary>
        public string Twochar { get; set; }

        /// <summary>
        /// Three character code
        /// </summary>
        public string Threechar { get; set; }

        /// <summary>
        /// Full country name
        /// </summary>
        public string Name { get; set; }
    }
}