using System.Windows.Controls;

namespace PluginDnqt.Customer.Views {
  /// <summary>
  /// Interaction logic for DetailTienNo.xaml
  /// </summary>
  public partial class DetailTienNo:UserControl {
	public DetailTienNo(object objInput) {
	  InitializeComponent();
	  this.DataContext=new ViewModels.DetailTienNo_ViewModel(this,objInput);
	}
  }
}
