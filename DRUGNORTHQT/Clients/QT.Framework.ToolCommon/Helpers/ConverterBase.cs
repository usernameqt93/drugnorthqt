using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace QT.Framework.ToolCommon.Helpers {
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

  public class Null2BooleanConverter:IValueConverter {
	public object Convert(object value,Type targetType,object parameter,CultureInfo culture) {
	  return value != null;
	}

	public object ConvertBack(object value,Type targetType,object parameter,CultureInfo culture) {
	  throw new NotImplementedException();
	}
  }

  public class Interger2StringConverter:IValueConverter {
	public object Convert(object value,Type targetType,object parameter,CultureInfo culture) {
	  return value != null ? value.ToString() : "0";
	}

	public object ConvertBack(object value,Type targetType,object parameter,CultureInfo culture) {
	  decimal _result = 0;
	  decimal.TryParse(value.ToString(),out _result);
	  return _result;
	}
  }

}
