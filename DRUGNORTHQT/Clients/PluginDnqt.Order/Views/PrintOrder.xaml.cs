using System.Windows.Controls;

namespace PluginDnqt.Order.Views {
  /// <summary>
  /// Interaction logic for PrintOrder.xaml
  /// </summary>
  public partial class PrintOrder:UserControl {
	public PrintOrder(object objInput) {
	  InitializeComponent();
	  this.DataContext=new ViewModels.PrintOrder_ViewModel(this,objInput);
	}
  }
}
