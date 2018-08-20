using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace PQTTool.Helpers {
 public class ConverterBase:IMultiValueConverter {
	public object Convert(object[] values,Type targetType,object parameter,System.Globalization.CultureInfo culture) {
	  return values.Clone();
	}

	public object[] ConvertBack(object value,Type[] targetTypes,object parameter,System.Globalization.CultureInfo culture) {
	  return null;
	}
  }

  public class Boolean2VisibilityConverter:IValueConverter {
	public object Convert(object value,Type targetType,object parameter,CultureInfo culture) {
	  return (bool)value ? Visibility.Visible : Visibility.Hidden;
	}

	public object ConvertBack(object value,Type targetType,object parameter,CultureInfo culture) {
	  return (Visibility)value == Visibility.Visible;
	}
  }

}
