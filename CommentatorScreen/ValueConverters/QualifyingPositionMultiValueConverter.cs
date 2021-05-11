using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;

namespace CommentatorScreen
{
    /// <summary>
    /// Converter for finding the postion of qualifying run
    /// in a list of qualifying runs
    /// </summary>
    public class QualifyingPositionMultiValueConverter :
        BaseMultiValueConverter<QualifyingPositionMultiValueConverter>
    {
        /// <summary>
        /// Finds the postion of a qualifying run
        /// in the qualifying list
        /// </summary>
        /// <param name="values">
        /// [0] The current <see cref="RnQual"/>
        /// [1] The datagrid which has the item source of the qualifying list
        /// </param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object[] values, Type targetType,
            object parameter, CultureInfo culture)
        {
            //Convert the data grid
            DataGrid dg = values[1] as DataGrid;

            //Access its item source
            ObservableCollection<QualifyingRun> runs =
                (ObservableCollection<QualifyingRun>)dg.ItemsSource;

            //Find the index of the current row in the item source
            int i = runs.IndexOf((QualifyingRun)values[0]);

            //Return (+1)
            return (i + 1).ToString();
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}