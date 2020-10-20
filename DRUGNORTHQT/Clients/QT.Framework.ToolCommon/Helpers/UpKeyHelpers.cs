using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace QT.Framework.ToolCommon.Helpers {
  public static class UpKeyHelpers {
	public static ICommand GetUpKeyCommand(DependencyObject target) {
	  return (ICommand)target.GetValue(UpKeyCommandProperty);
	}

	public static void SetUpKeyCommand(DependencyObject target,ICommand value) {
	  target.SetValue(UpKeyCommandProperty,value);
	}

	public static readonly DependencyProperty UpKeyCommandProperty =
		DependencyProperty.RegisterAttached(
			"UpKeyCommand",
			typeof(ICommand),
			typeof(UpKeyHelpers),
			new PropertyMetadata(null,OnUpKeyCommandChanged));


	public static object GetUpKeyCommandParam(DependencyObject target) {
	  return (object)target.GetValue(UpKeyCommandParamProperty);
	}

	public static void SetUpKeyCommandParam(DependencyObject target,object value) {
	  target.SetValue(UpKeyCommandParamProperty,value);
	}

	public static readonly DependencyProperty UpKeyCommandParamProperty =
		DependencyProperty.RegisterAttached(
			"UpKeyCommandParam",
			typeof(object),
			typeof(UpKeyHelpers),
			new PropertyMetadata(null));

	static void OnUpKeyCommandChanged(DependencyObject target,DependencyPropertyChangedEventArgs e) {
	  ICommand command = (ICommand)e.NewValue;
	  Control control = (Control)target;
	  //control.KeyDown += (s,args) => {
	  control.KeyUp += (s,args) => {
		if(args.Key == Key.Up) {
		  // make sure the textbox binding updates its source first
		  BindingExpression b = control.GetBindingExpression(TextBox.TextProperty);
		  if(b != null) {
			b.UpdateSource();
		  }
		  object commandParameter = GetUpKeyCommandParam(target);
		  command.Execute(commandParameter);
		}
	  };
	}
  }
}
