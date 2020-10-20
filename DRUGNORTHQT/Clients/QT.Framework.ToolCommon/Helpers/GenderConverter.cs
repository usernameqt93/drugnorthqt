using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace QT.Framework.ToolCommon.Helpers
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int _currentStep = 0, _inputStep = -1;
            int.TryParse(value?.ToString(), out _currentStep);
            int.TryParse(parameter?.ToString(), out _inputStep);

            return _inputStep == _currentStep;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int _currentStep = 0;
            int.TryParse(parameter?.ToString(), out _currentStep);
            return _currentStep;
        }

    }
}
