using System;

namespace QT.Framework.ToolCommon.Helpers {
  using System.Text.RegularExpressions;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Data;
  using System.Windows.Input;

  public class NumericBox:TextBox {
	private Regex regex = new Regex("^[0-9]+$");
	private double _value = 0;

	/// <summary>
	/// Giá trị
	/// </summary>
	public double Value {
	  get {
		double.TryParse(this.Text,out _value);
		return _value;
	  }
	}

	/// <summary>
	/// Identifies the Length dependency property.
	/// </summary>
	public static readonly DependencyProperty ValueProperty =
		 DependencyProperty.Register(
			  "Value",
			  typeof(int),
			  typeof(NumericBox),
			  new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.AffectsRender));

	#region Step
	/// <summary>
	/// Số lượng hàng
	/// </summary>
	public double Step {
	  get {
		return (double)GetValue(StepProperty);
	  }
	  set {
		SetValue(StepProperty,value);
	  }
	}

	public static readonly DependencyProperty StepProperty =
		DependencyProperty.Register("Step",typeof(double),typeof(NumericBox),
		new FrameworkPropertyMetadata(1.0,
			FrameworkPropertyMetadataOptions.AffectsRender) {
		  BindsTwoWayByDefault = true,
		  DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

	#endregion

	#region IsUnsigned
	/// <summary>
	/// Số dương
	/// </summary>
	public bool IsUnsigned {
	  get {
		return (bool)GetValue(IsUnsignedProperty);
	  }
	  set {
		SetValue(IsUnsignedProperty,value);
	  }
	}

	public static readonly DependencyProperty IsUnsignedProperty =
		DependencyProperty.Register("IsUnsigned",typeof(bool),typeof(NumericBox),
		new FrameworkPropertyMetadata(true,
			FrameworkPropertyMetadataOptions.AffectsRender) {
		  BindsTwoWayByDefault = true,
		  DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

	#endregion

	#region IsInterger
	/// <summary>
	/// Số dương
	/// </summary>
	public bool IsInterger {
	  get {
		return (bool)GetValue(IsUnsignedProperty);
	  }
	  set {
		SetValue(IsUnsignedProperty,value);
	  }
	}

	public static readonly DependencyProperty IsIntergerProperty =
		DependencyProperty.Register("IsInterger",typeof(bool),typeof(NumericBox),
		new FrameworkPropertyMetadata(true,
			FrameworkPropertyMetadataOptions.AffectsRender) {
		  BindsTwoWayByDefault = true,
		  DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

	#endregion

	#region Regex
	/// <summary>
	/// Số lượng hàng
	/// </summary>
	public string Regex {
	  get {
		return (string)GetValue(RegexProperty);
	  }
	  set {
		SetValue(RegexProperty,value);
		regex = new System.Text.RegularExpressions.Regex(value);
	  }
	}

	public static readonly DependencyProperty RegexProperty =
		DependencyProperty.Register("Regex",typeof(string),typeof(NumericBox),
		new FrameworkPropertyMetadata("^[0-9]+$",
			FrameworkPropertyMetadataOptions.AffectsRender) {
		  BindsTwoWayByDefault = true,
		  DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

	#endregion

	protected override void OnPreviewTextInput(TextCompositionEventArgs e) {
	  if(!regex.IsMatch(e.Text)) {
		if(!IsInterger && e.Text == "." && this.Text.IndexOf(".") == -1)
		  return;

		if(!IsUnsigned && e.Text == "-" && (this.Text.Length == 0 || (this.CaretIndex == 0 && this.Text.IndexOf("-") == -1)))
		  return;

		e.Handled = true;
		return;
	  }
	  //base.OnPreviewTextInput(e);
	}

	protected override void OnPreviewMouseWheel(MouseWheelEventArgs e) {
	  base.OnPreviewMouseWheel(e);
	  double.TryParse(this.Text,out _value);
	  if(e.Delta > 0) {
		this.Text = (_value + Step).ToString();
	  } else {
		if(_value > 0 || !IsUnsigned)
		  this.Text = (_value - Step).ToString();
	  }
	}
  }
}
