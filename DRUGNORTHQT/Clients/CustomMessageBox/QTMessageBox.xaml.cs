using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace QT.MessageBox {
  /// <summary>
  /// Interaction logic for QTMessageBox.xaml
  /// </summary>
  public partial class QTMessageBox:Window {
	public QTMessageBox() {
	  InitializeComponent();
	}

	private static System.Windows.Forms.Timer TimerTextChanged = new System.Windows.Forms.Timer() {
	  Interval=3000
	};

	private const int INT_CONST_MILISECOND_CLOSE = 15000;

	private static void timerTextChanged_Tick(object sender,EventArgs e) {
	  if(_messageBox!=null) {
		_messageBox.Close();
	  }
	  TimerTextChanged.Stop();
	}

	static QTMessageBox _messageBox;
	static MessageBoxResult _result = MessageBoxResult.No;
	public static MessageBoxResult Show(string caption,string msg,CustomMessageBox.MessageBoxType type) {
	  switch(type) {
		case CustomMessageBox.MessageBoxType.ConfirmationWithYesNo:
		  return Show(caption,msg,MessageBoxButton.YesNo,
		  MessageBoxImage.Question);
		case CustomMessageBox.MessageBoxType.ConfirmationWithYesNoCancel:
		  return Show(caption,msg,MessageBoxButton.YesNoCancel,
		  MessageBoxImage.Question);
		case CustomMessageBox.MessageBoxType.Information:
		  return Show(caption,msg,MessageBoxButton.OK,
		  MessageBoxImage.Information);
		case CustomMessageBox.MessageBoxType.Error:
		  return Show(caption,msg,MessageBoxButton.OK,
		  MessageBoxImage.Error);
		case CustomMessageBox.MessageBoxType.Warning:
		  return Show(caption,msg,MessageBoxButton.OK,
		  MessageBoxImage.Warning);
		default:
		  return MessageBoxResult.No;
	  }
	}
	public static MessageBoxResult Show(string msg,CustomMessageBox.MessageBoxType type) {
	  return Show(string.Empty,msg,type);
	}
	public static MessageBoxResult Show(string msg) {
	  return Show(string.Empty,msg,
	  MessageBoxButton.OK,MessageBoxImage.None);
	}
	public static MessageBoxResult Show(string caption,string text) {
	  return Show(caption,text,
	  MessageBoxButton.OK,MessageBoxImage.None);
	}
	public static MessageBoxResult Show(string caption,string text,MessageBoxButton button) {
	  return Show(caption,text,button,
	  MessageBoxImage.None);
	}
	public static MessageBoxResult Show(string caption,string text,MessageBoxButton button,MessageBoxImage image) {
	  _messageBox=new QTMessageBox { txtMsg={ Text=text },MessageTitle={ Text=caption } };
	  SetVisibilityOfButtons(button);
	  SetImageOfMessageBox(image);

	  AutoCloseAfterMiliSecond(INT_CONST_MILISECOND_CLOSE);

	  _messageBox.ShowDialog();

	  TimerTextChanged.Stop();
	  return _result;
	}

	public static MessageBoxResult ShowNotify(string text,string strToolTipImage = "") {
	  _messageBox=new QTMessageBox {
		txtMsg={ Text=text },
		MessageTitle={ Text="Thông báo" },
		img={ ToolTip=strToolTipImage }
	  };
	  SetVisibilityOfButtons(MessageBoxButton.OK);
	  SetImageOfMessageBox(MessageBoxImage.Information);

	  AutoCloseAfterMiliSecond(INT_CONST_MILISECOND_CLOSE);

	  _messageBox.ShowDialog();

	  TimerTextChanged.Stop();
	  return _result;
	}

	private static void AutoCloseAfterMiliSecond(int intMiliSecond) {
	  //TimerTextChanged=new System.Windows.Forms.Timer() { Interval=intMiliSecond };
	  //TimerTextChanged.Tick += new EventHandler(timerTextChanged_Tick);
	  //TimerTextChanged.Start();
	}

	public static MessageBoxResult ShowWarning(string text) {
	  //_messageBox = new QTMessageBox { txtMsg = { Text = text },MessageTitle = { Text = "Cảnh báo" } };
	  //SetVisibilityOfButtons(MessageBoxButton.OK);
	  //SetImageOfMessageBox(MessageBoxImage.Warning);

	  //AutoCloseAfterMiliSecond(INT_CONST_MILISECOND_CLOSE);

	  //_messageBox.ShowDialog();

	  //TimerTextChanged.Stop();
	  //return _result;
	  return ShowNotify(text);
	}

	public static MessageBoxResult ShowError(string text) {
	  //_messageBox = new QTMessageBox { txtMsg = { Text = text },MessageTitle = { Text = "Lỗi" } };
	  //SetVisibilityOfButtons(MessageBoxButton.OK);
	  //SetImageOfMessageBox(MessageBoxImage.Error);

	  //AutoCloseAfterMiliSecond(INT_CONST_MILISECOND_CLOSE);

	  //_messageBox.ShowDialog();

	  //TimerTextChanged.Stop();
	  //return _result;
	  return ShowNotify(text);
	}

	public static MessageBoxResult ShowConfirm(string text) {
	  _messageBox=new QTMessageBox { txtMsg={ Text=text },MessageTitle={ Text="Xác nhận" } };
	  SetVisibilityOfButtons(MessageBoxButton.YesNo);
	  SetImageOfMessageBox(MessageBoxImage.Question);
	  _messageBox.ShowDialog();
	  return _result;
	}

	private static void SetVisibilityOfButtons(MessageBoxButton button) {
	  switch(button) {
		case MessageBoxButton.OK:
		  _messageBox.btnCancel.Visibility=Visibility.Collapsed;
		  _messageBox.btnNo.Visibility=Visibility.Collapsed;
		  _messageBox.btnYes.Visibility=Visibility.Collapsed;
		  _messageBox.btnOk.Focus();
		  break;
		case MessageBoxButton.OKCancel:
		  _messageBox.btnNo.Visibility=Visibility.Collapsed;
		  _messageBox.btnYes.Visibility=Visibility.Collapsed;
		  _messageBox.btnCancel.Focus();
		  break;
		case MessageBoxButton.YesNo:
		  _messageBox.btnOk.Visibility=Visibility.Collapsed;
		  _messageBox.btnCancel.Visibility=Visibility.Collapsed;
		  _messageBox.btnNo.Focus();
		  break;
		case MessageBoxButton.YesNoCancel:
		  _messageBox.btnOk.Visibility=Visibility.Collapsed;
		  _messageBox.btnCancel.Focus();
		  break;
		default:
		  break;
	  }
	}
	private static void SetImageOfMessageBox(MessageBoxImage image) {
	  switch(image) {
		case MessageBoxImage.Warning:
		  _messageBox.SetImage("Warning.png");
		  break;
		case MessageBoxImage.Question:
		  _messageBox.SetImage("Question.png");
		  break;
		case MessageBoxImage.Information:
		  _messageBox.SetImage("Information.png");
		  break;
		case MessageBoxImage.Error:
		  _messageBox.SetImage("Error.png");
		  break;
		default:
		  _messageBox.img.Visibility=Visibility.Collapsed;
		  break;
	  }
	}
	private void Button_Click(object sender,RoutedEventArgs e) {
	  if(sender==btnOk)
		_result=MessageBoxResult.OK;
	  else if(sender==btnYes)
		_result=MessageBoxResult.Yes;
	  else if(sender==btnNo)
		_result=MessageBoxResult.No;
	  else if(sender==btnCancel)
		_result=MessageBoxResult.Cancel;
	  else
		_result=MessageBoxResult.None;
	  _messageBox.Close();
	  _messageBox=null;
	}
	private void SetImage(string imageName) {
	  var url = string.Format("pack://application:,,,/QT.Framework.MessageBox;component/Resources/{0}",imageName);
	  Uri iconUri = new Uri(url,UriKind.RelativeOrAbsolute);
	  img.Source=new BitmapImage(iconUri);
	}

  }
}
