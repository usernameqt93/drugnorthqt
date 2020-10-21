using System.Windows.Controls;

namespace PluginDnqt.Product.Views {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow:UserControl {
	public MainWindow() {
	  InitializeComponent();
	  this.DataContext=new ViewModels.ViewModelMain(this,null);
	}
  }
}
