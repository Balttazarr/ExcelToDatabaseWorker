using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFAutomation.Converters
{   
    public class DateConverter : IValueConverter
    {

        private const string _format = "dd-MM-yyyy";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;

            return date.ToString(_format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.ParseExact((string)value, _format, culture);
        }

    }
}
