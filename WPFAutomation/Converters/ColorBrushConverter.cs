﻿using System;
using System.Windows.Data;
using System.Windows.Media;

namespace WPFAutomation
{
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
