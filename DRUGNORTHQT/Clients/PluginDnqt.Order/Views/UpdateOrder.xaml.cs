using System.Windows.Controls;

namespace PluginDnqt.Order.Views {
  /// <summary>
  /// Interaction logic for UpdateOrder.xaml
  /// </summary>
  public partial class UpdateOrder:UserControl {
	public UpdateOrder(object objInput) {
	  InitializeComponent();
	  this.DataContext=new ViewModels.UpdateOrder_ViewModel(this,objInput);
	}

	private void txtName_PreviewKeyDown(object sender,System.Windows.Input.KeyEventArgs e) {

	}
  }
}
