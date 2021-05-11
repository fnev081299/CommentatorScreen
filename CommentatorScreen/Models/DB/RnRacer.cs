using System;

#nullable disable

namespace CommentatorScreen
{
    /// <summary>
    /// Rider/driver information
    /// Derived from .CAx files
    /// </summary>
    public partial class RnRacer
    {
        /// <summary>
        /// Category number as per race computer category screen
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Race Number
        /// </summary>
        public string Racenum { get; set; }

        /// <summary>
        /// Control Date
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// TRUE: registered
        /// </summary>
        public bool? Registered { get; set; }

        /// <summary>
        /// Class id number
        /// </summary>
        public int? Class { get; set; }

        /// <summary>
        /// Driver Name
        /// </summary>
        public string Driver { get; set; }

        /// <summary>
        /// Address Line 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address Line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Hometown
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State / contry code
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Social Security Number
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Car Name
        /// </summary>
        public string Carname { get; set; }

        /// <summary>
        /// Car Type
        /// </summary>
        public string Cartype { get; set; }

        /// <summary>
        /// Engine Size/Type
        /// </summary>
        public string Engine { get; set; }

        /// <summary>
        /// Points allowed
        /// </summary>
        public bool? Allowpoints { get; set; }

        /// <summary>
        /// Number of points
        /// </summary>
        public int? Points { get; set; }

        /// <summary>
        /// General Info Line 1
        /// </summary>
        public string Info1 { get; set; }

        /// <summary>
        /// General Info Line 2
        /// </summary>
        public string Info2 { get; set; }

        /// <summary>
        /// General Info Line 3
        /// </summary>
        public string Info3 { get; set; }

        /// <summary>
        /// Internal database serial number
        /// </summary>
        public int Id { get; set; }
    }
}