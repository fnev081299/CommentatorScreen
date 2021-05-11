using System;
using System.Globalization;

namespace CommentatorScreen
{
    /// <summary>
    /// A value for converting the boolean lane to a string
    /// True is left, False is right
    /// </summary>
    public class LaneValueConverter : BaseValueConverter<LaneValueConverter>
    {
        /// <summary>
        /// Converts the boolean lane to a string
        /// </summary>
        /// <param name="value">Bool lane</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Lane as a string</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return 'L';
            }
            else
            {
                return 'R';
            }
        }

        /// <summary>
        /// Converts the string lane to a boolean
        /// </summary>
        /// <param name="value">Lane as a string</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Lane as bool</returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((char)value == 'R')
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}