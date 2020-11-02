using System;
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
	  try {
		(this.DataContext as ViewModels.UpdateOrder_ViewModel).KeyEventDownNameProduct=e;
	  } catch(Exception ex) {
		string str = ex.Message;
	  }
	}

	private void txtSoLuong_PreviewKeyDown(object sender,System.Windows.Input.KeyEventArgs e) {
	  try {
		(this.DataContext as ViewModels.UpdateOrder_ViewModel).KeyEventDownSoLuong=e;
	  } catch(Exception ex) {
		string str = ex.Message;
	  }
	}

	private void txtDonGia_PreviewKeyDown(object sender,System.Windows.Input.KeyEventArgs e) {
	  try {
		(this.DataContext as ViewModels.UpdateOrder_ViewModel).KeyEventDownDonGia=e;
	  } catch(Exception ex) {
		string str = ex.Message;
	  }
	}
  }
}
