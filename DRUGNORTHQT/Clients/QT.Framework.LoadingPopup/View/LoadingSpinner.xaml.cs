using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QT.Framework.LoadingPopup.View {
  /// <summary>
  /// Interaction logic for LoadingSpinner.xaml
  /// </summary>
  public partial class LoadingSpinner:UserControl {
	DispatcherTimer MainTimer = new DispatcherTimer();
	public LoadingSpinner() {
	  InitializeComponent();
	  Timer();
	  this.IsVisibleChanged += Loading_IsVisibleChanged;
	}

	private void Loading_IsVisibleChanged(object sender,DependencyPropertyChangedEventArgs e) {
	  if(MainTimer != null) {
		if((bool)e.NewValue)
		  MainTimer.Start();
		else
		  MainTimer.Stop();
	  }
	}

	static LoadingSpinner() {
	  ForegroundProperty.OverrideMetadata(typeof(LoadingSpinner),new FrameworkPropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF3399FF"))));

	}

	private void Timer() {
	  MainTimer.Interval = TimeSpan.FromTicks(10000);
	  MainTimer.Tick += MainTimer_Tick;
	  MainTimer.Start();
	}

	private void MainTimer_Tick(object sender,EventArgs e) {
	  (path1.RenderTransform as RotateTransform).Angle = ((path1.RenderTransform as RotateTransform).Angle + 7.2) % 360.0;
	  (path2.RenderTransform as RotateTransform).Angle = ((path2.RenderTransform as RotateTransform).Angle - 14.4) % 360.0;
	}


	#region IsStop
	public bool IsStop {
	  get {
		return (bool)GetValue(IsStopProperty);
	  }
	  set {
		SetValue(IsStopProperty,value);
		this.InvalidateVisual();
	  }
	}

	public static readonly DependencyProperty IsStopProperty =
		DependencyProperty.Register("IsStop",typeof(bool),typeof(LoadingSpinner),
		new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.AffectsRender));

	#endregion

	#region MaxValue

	public double MaxValue {
	  get {
		return (double)GetValue(MaxValueProperty);
	  }
	  set {
		SetValue(MaxValueProperty,value);
		this.InvalidateVisual();
	  }
	}

	public static readonly DependencyProperty MaxValueProperty =
		DependencyProperty.Register("MaxValue",typeof(double),typeof(LoadingSpinner),
		new FrameworkPropertyMetadata(100d,FrameworkPropertyMetadataOptions.AffectsRender));

	#endregion

	#region Value

	public double Value {
	  get {
		return (double)GetValue(ValueProperty);
	  }
	  set {
		SetValue(ValueProperty,value);
		this.InvalidateVisual();
	  }
	}

	public static readonly DependencyProperty ValueProperty =
		DependencyProperty.Register("Value",typeof(double),typeof(LoadingSpinner),
		new FrameworkPropertyMetadata(0d,FrameworkPropertyMetadataOptions.AffectsRender) {
		  BindsTwoWayByDefault = true,
		  DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

	#endregion

	#region String Value

	public string StrValue {
	  get {
		return (string)GetValue(StrValueProperty);
	  }
	  set {
		SetValue(StrValueProperty,value);
		this.InvalidateVisual();
	  }
	}

	public static readonly DependencyProperty StrValueProperty =
		DependencyProperty.Register("StrValue",typeof(string),typeof(LoadingSpinner),
		new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.AffectsRender) {
		  BindsTwoWayByDefault = true,
		  DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});

	#endregion


  }
}
