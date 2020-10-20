using System.Windows.Controls;
using WindowMain.ViewModels;

namespace WindowMain.View {
  /// <summary>
  /// Interaction logic for ListMessages.xaml
  /// </summary>
  public partial class ListMessages:UserControl {
	public ListMessages(object objInput) {
	  InitializeComponent();
	  this.DataContext=new ListMessages_ViewModel(this,objInput);
	}
  }
}
