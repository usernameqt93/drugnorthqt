using System.Windows.Controls;

namespace PluginDnqt.Order.Views {
  /// <summary>
  /// Interaction logic for UpdateDetailOrder.xaml
  /// </summary>
  public partial class UpdateDetailOrder:UserControl {
	public UpdateDetailOrder(object objInput) {
	  InitializeComponent();
	  this.DataContext=new ViewModels.UpdateDetailOrder_ViewModel(this,objInput);
	}
  }
}
