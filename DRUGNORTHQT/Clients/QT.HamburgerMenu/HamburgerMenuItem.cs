using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace QT.HamburgerMenu {
  public class HamburgerMenuItem:ListBoxItem {
	static HamburgerMenuItem() {
	  DefaultStyleKeyProperty.OverrideMetadata(typeof(HamburgerMenuItem),new FrameworkPropertyMetadata(typeof(HamburgerMenuItem)));
	}

	public int ItemID {
	  get { return (int)GetValue(ItemIDProperty); }
	  set { SetValue(ItemIDProperty,value); }
	}

	public static readonly DependencyProperty ItemIDProperty =
		DependencyProperty.Register("ItemID",typeof(int),typeof(HamburgerMenuItem),new PropertyMetadata(0));

	public int ParentID {
	  get { return (int)GetValue(ParentIDProperty); }
	  set { SetValue(ParentIDProperty,value); }
	}

	public static readonly DependencyProperty LeverIDProperty =
		DependencyProperty.Register("Lever",typeof(int),typeof(HamburgerMenuItem),new PropertyMetadata(0));
	public int Lever {
	  get { return (int)GetValue(LeverIDProperty); }
	  set { SetValue(LeverIDProperty,value); }
	}

	public static readonly DependencyProperty ParentIDProperty =
		DependencyProperty.Register("ParentID",typeof(int),typeof(HamburgerMenuItem),new PropertyMetadata(0));
	public string Text {
	  get { return (string)GetValue(TextProperty); }
	  set { SetValue(TextProperty,value); }
	}

	public static readonly DependencyProperty TextProperty =
		DependencyProperty.Register("Text",typeof(string),typeof(HamburgerMenuItem),new PropertyMetadata(String.Empty));

	public new Object Tag {
	  get { return (Object)GetValue(TagProperty); }
	  set { SetValue(TagProperty,value); }
	}

	public new static readonly DependencyProperty TagProperty =
		DependencyProperty.Register("Tag",typeof(Object),typeof(HamburgerMenuItem),new PropertyMetadata(null));

	public ImageSource Icon {
	  get { return (ImageSource)GetValue(IconProperty); }
	  set { SetValue(IconProperty,value); }
	}

	public static readonly DependencyProperty IconProperty =
		DependencyProperty.Register("Icon",typeof(ImageSource),typeof(HamburgerMenuItem),new PropertyMetadata(null));

	public int WidthIcon {
	  get { return (int)GetValue(WidthIconProperty); }
	  set { SetValue(WidthIconProperty,value); }
	}

	public static readonly DependencyProperty WidthIconProperty =
		DependencyProperty.Register("WidthIcon",typeof(int),typeof(HamburgerMenuItem),new PropertyMetadata(0));
	public int HeightIcon {
	  get { return (int)GetValue(HeightIconProperty); }
	  set { SetValue(HeightIconProperty,value); }
	}

	public static readonly DependencyProperty HeightIconProperty =
		DependencyProperty.Register("HeightIcon",typeof(int),typeof(HamburgerMenuItem),new PropertyMetadata(0));

	public Brush SelectionIndicatorColor {
	  get { return (Brush)GetValue(SelectionIndicatorColorProperty); }
	  set { SetValue(SelectionIndicatorColorProperty,value); }
	}

	public static readonly DependencyProperty SelectionIndicatorColorProperty =
		DependencyProperty.Register("SelectionIndicatorColor",typeof(Brush),typeof(HamburgerMenuItem),new PropertyMetadata(Brushes.Blue));

	public ICommand SelectionCommand {
	  get { return (ICommand)GetValue(SelectionCommandProperty); }
	  set { SetValue(SelectionCommandProperty,value); }
	}

	public static readonly DependencyProperty SelectionCommandProperty =
		DependencyProperty.Register("SelectionCommand",typeof(ICommand),typeof(HamburgerMenuItem),new PropertyMetadata(null));

	public object SelectionCommandParameter {
	  get { return (object)GetValue(SelectionCommandParameterProperty); }
	  set { SetValue(SelectionCommandParameterProperty,value); }
	}

	// Using a DependencyProperty as the backing store for SelectionCommandParameter.  This enables animation, styling, binding, etc...
	public static readonly DependencyProperty SelectionCommandParameterProperty =
		DependencyProperty.Register("SelectionCommandParameter",typeof(object),typeof(HamburgerMenuItem),new PropertyMetadata(null));

  }
}
