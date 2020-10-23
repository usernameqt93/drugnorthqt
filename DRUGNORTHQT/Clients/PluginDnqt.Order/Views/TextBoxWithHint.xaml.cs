using System.Windows.Controls;

namespace PluginDnqt.Order.Views {
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
		_strHint=value;
		lblHint.Text=StrHint;
	  }
	}

  }
}
