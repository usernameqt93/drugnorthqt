using System.Windows.Controls;

namespace WindowMain.View {
  /// <summary>
  /// Interaction logic for TextBoxWithHint.xaml
  /// </summary>
  public partial class TextBoxWithHint:UserControl {
	public TextBoxWithHint() {
	  InitializeComponent();
	}

	private string _strHint = "";

	public string StrHint {
	  get { return _strHint; }
	  set {
		_strHint = value;
		lblHint.Text=StrHint;
	  }
	}

	private string _strText = "";

	public string StrText {
	  get { return _strText; }
	  set {
		_strText = value;
		txtText.Text=StrText;
	  }
	}

  }
}
