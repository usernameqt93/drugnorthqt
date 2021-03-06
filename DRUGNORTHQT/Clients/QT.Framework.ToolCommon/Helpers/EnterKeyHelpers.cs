﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace QT.Framework.ToolCommon.Helpers {
  public static class EnterKeyHelpers
    {
        public static ICommand GetEnterKeyCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(EnterKeyCommandProperty);
        }

        public static void SetEnterKeyCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(EnterKeyCommandProperty, value);
        }

        public static readonly DependencyProperty EnterKeyCommandProperty =
            DependencyProperty.RegisterAttached(
                "EnterKeyCommand",
                typeof(ICommand),
                typeof(EnterKeyHelpers),
                new PropertyMetadata(null, OnEnterKeyCommandChanged));


        public static object GetEnterKeyCommandParam(DependencyObject target)
        {
            return (object)target.GetValue(EnterKeyCommandParamProperty);
        }

        public static void SetEnterKeyCommandParam(DependencyObject target, object value)
        {
            target.SetValue(EnterKeyCommandParamProperty, value);
        }

        public static readonly DependencyProperty EnterKeyCommandParamProperty =
            DependencyProperty.RegisterAttached(
                "EnterKeyCommandParam",
                typeof(object),
                typeof(EnterKeyHelpers),
                new PropertyMetadata(null));

        static void OnEnterKeyCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = (ICommand)e.NewValue;
            Control control = (Control)target;
            control.KeyDown += (s, args) =>
            {
                if (args.Key == Key.Enter)
                {
                    // make sure the textbox binding updates its source first
                    BindingExpression b = control.GetBindingExpression(TextBox.TextProperty);
                    if (b != null)
                    {
                        b.UpdateSource();
                    }
                    object commandParameter = GetEnterKeyCommandParam(target);
                    command.Execute(commandParameter);
                }
            };
        }
  }

  public static class BackSpaceKeyHelpers {
	public static ICommand GetBackSpaceKeyCommand(DependencyObject target) {
	  return (ICommand)target.GetValue(BackSpaceKeyCommandProperty);
	}

	public static void SetBackSpaceKeyCommand(DependencyObject target,ICommand value) {
	  target.SetValue(BackSpaceKeyCommandProperty,value);
	}

	public static readonly DependencyProperty BackSpaceKeyCommandProperty =
		DependencyProperty.RegisterAttached(
			"BackSpaceKeyCommand",
			typeof(ICommand),
			typeof(BackSpaceKeyHelpers),
			new PropertyMetadata(null,OnBackSpaceKeyCommandChanged));


	public static object GetBackSpaceKeyCommandParam(DependencyObject target) {
	  return (object)target.GetValue(BackSpaceKeyCommandParamProperty);
	}

	public static void SetBackSpaceKeyCommandParam(DependencyObject target,object value) {
	  target.SetValue(BackSpaceKeyCommandParamProperty,value);
	}

	public static readonly DependencyProperty BackSpaceKeyCommandParamProperty =
		DependencyProperty.RegisterAttached(
			"BackSpaceKeyCommandParam",
			typeof(object),
			typeof(BackSpaceKeyHelpers),
			new PropertyMetadata(null));

	static void OnBackSpaceKeyCommandChanged(DependencyObject target,DependencyPropertyChangedEventArgs e) {
	  ICommand command = (ICommand)e.NewValue;
	  Control control = (Control)target;
	  control.KeyUp+=(s,args) =>
	  {
		if(args.Key==Key.Back||args.Key==Key.Delete) {
		  // make sure the textbox binding updates its source first
		  BindingExpression b = control.GetBindingExpression(TextBox.TextProperty);
		  if(b!=null) {
			b.UpdateSource();
		  }
		  object commandParameter = GetBackSpaceKeyCommandParam(target);
		  command.Execute(commandParameter);
		}
	  };
	}
  }

}
