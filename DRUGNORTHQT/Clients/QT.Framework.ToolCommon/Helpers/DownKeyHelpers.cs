using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace QT.Framework.ToolCommon.Helpers {
  public static class DownKeyHelpers {
	public static ICommand GetDownKeyCommand(DependencyObject target) {
	  return (ICommand)target.GetValue(DownKeyCommandProperty);
	}

	public static void SetDownKeyCommand(DependencyObject target,ICommand value) {
	  target.SetValue(DownKeyCommandProperty,value);
	}

	public static readonly DependencyProperty DownKeyCommandProperty =
		DependencyProperty.RegisterAttached(
			"DownKeyCommand",
			typeof(ICommand),
			typeof(DownKeyHelpers),
			new PropertyMetadata(null,OnDownKeyCommandChanged));


	public static object GetDownKeyCommandParam(DependencyObject target) {
	  return (object)target.GetValue(DownKeyCommandParamProperty);
	}

	public static void SetDownKeyCommandParam(DependencyObject target,object value) {
	  target.SetValue(DownKeyCommandParamProperty,value);
	}

	public static readonly DependencyProperty DownKeyCommandParamProperty =
		DependencyProperty.RegisterAttached(
			"DownKeyCommandParam",
			typeof(object),
			typeof(DownKeyHelpers),
			new PropertyMetadata(null));

	static void OnDownKeyCommandChanged(DependencyObject target,DependencyPropertyChangedEventArgs e) {
	  ICommand command = (ICommand)e.NewValue;
	  Control control = (Control)target;
	  //control.KeyDown += (s,args) => {
	  control.KeyUp += (s,args) => {
		if(args.Key == Key.Down) {
		  // make sure the textbox binding updates its source first
		  BindingExpression b = control.GetBindingExpression(TextBox.TextProperty);
		  if(b != null) {
			b.UpdateSource();
		  }
		  object commandParameter = GetDownKeyCommandParam(target);
		  command.Execute(commandParameter);
		}
	  };
	}
  }
}
