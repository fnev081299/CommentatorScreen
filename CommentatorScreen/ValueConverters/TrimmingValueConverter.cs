using System;
using System.Globalization;

namespace CommentatorScreen
{
    /// <summary>
    /// Converter for trimming strings
    /// </summary>
    public class TrimmingValueConverter : BaseValueConverter<TrimmingValueConverter>
    {
        /// <summary>
        /// Takes a string and trims it
        /// </summary>
        /// <param name="value">The target string</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Trimmed string</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check for nulls
            if (value == null)
            {
                return "";
            }

            //Return trimmed string
            return ((string)value).Trim();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}