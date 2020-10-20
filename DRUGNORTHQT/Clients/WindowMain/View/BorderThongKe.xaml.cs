using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WindowMain.View {
  /// <summary>
  /// Interaction logic for BorderThongKe.xaml
  /// </summary>
  public partial class BorderThongKe:UserControl {
	public BorderThongKe() {
	  InitializeComponent();
	}

	private string _strSoLuong="0";

	public string StrSoLuong {
	  get { return _strSoLuong; }
	  set {
		_strSoLuong=value;
		lblSoLuong.Content=StrSoLuong;
	  }
	}

	private string _strLoaiItem="Loại Item";

	public string StrLoaiItem {
	  get { return _strLoaiItem; }
	  set {
		_strLoaiItem=value;
		lblLoaiItem.Content=StrLoaiItem;
	  }
	}

	private string _strHienThiTraiPhai="Trai";

	public string StrHienThiTraiPhai {
	  get { return _strHienThiTraiPhai; }
	  set {
		_strHienThiTraiPhai=value;
		imageHienThiTrai.Visibility=Visibility.Collapsed;
		imageHienThiPhai.Visibility=Visibility.Collapsed;
		gradientStopStart.Offset=1;
		gradientStopEnd.Offset=1;

		if(StrHienThiTraiPhai=="Trai") {
		  imageHienThiTrai.Visibility=Visibility.Visible;
		  ucMain.HorizontalAlignment=HorizontalAlignment.Left;
		  gradientStopEnd.Offset=0;
		  return;
		}

		imageHienThiPhai.Visibility=Visibility.Visible;
		ucMain.HorizontalAlignment=HorizontalAlignment.Right;
		gradientStopStart.Offset=0;
	  }
	}

	private ImageSource _imageSourceHienThi = null ;

	public ImageSource ImageSourceHienThi {
	  get { return _imageSourceHienThi; }
	  set {
		_imageSourceHienThi=value;
		imageHienThiPhai.Source=ImageSourceHienThi;
	  }
	}

	//private Color _colorStart=new Color();

	//public Color ColorStart {
	//  get { return _colorStart; }
	//  set { _colorStart=value;
	//	gradientStopStart.Color=ColorStart;
	//  }
	//}

	//private Color _colorEnd=new Color();

	//public Color ColorEnd {
	//  get { return _colorEnd; }
	//  set { _colorEnd=value;
	//	gradientStopEnd.Color=ColorEnd;
	//  }
	//}

	private string _str6CharHexColor= "2281D1";

	public string Str6CharHexColor {
	  get { return _str6CharHexColor; }
	  set {
		_str6CharHexColor=value;
		gradientStopStart.Color=(Color)ColorConverter.ConvertFromString($"#FF{Str6CharHexColor}");
		gradientStopEnd.Color=(Color)ColorConverter.ConvertFromString($"#1A{Str6CharHexColor}");
	  }
	}

	private ICommand _SelectionCommand;

	public ICommand SelectionCommand {
	  get { return _SelectionCommand; }
	  set {
		_SelectionCommand=value;
		//OnPropertyChanged(nameof(SelectionCommand));
	  }
	}

	//public ICommand SelectionCommand {
	//  get { return (ICommand)GetValue(SelectionCommandProperty); }
	//  set { SetValue(SelectionCommandProperty,value); }
	//}

	//public static readonly DependencyProperty SelectionCommandProperty =
	//	DependencyProperty.Register("SelectionCommand",typeof(ICommand),typeof(BorderThongKe),new PropertyMetadata(null));

	public object SelectionCommandParameter {
	  get { return (object)GetValue(SelectionCommandParameterProperty); }
	  set { SetValue(SelectionCommandParameterProperty,value); }
	}

	// Using a DependencyProperty as the backing store for SelectionCommandParameter.  This enables animation, styling, binding, etc...
	public static readonly DependencyProperty SelectionCommandParameterProperty =
		DependencyProperty.Register("SelectionCommandParameter",typeof(object),typeof(BorderThongKe),new PropertyMetadata(null));

  }
}
