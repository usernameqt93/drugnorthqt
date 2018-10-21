namespace WindowStyle.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class WinStateBooleanI : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var _value = (WindowState)value;
            return _value == WindowState.Maximized;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var _value = (bool)value;
            return _value ? WindowState.Maximized : WindowState.Normal;
        }
    }
}
