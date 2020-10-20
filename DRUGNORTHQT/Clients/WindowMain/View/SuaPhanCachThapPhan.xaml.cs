using System.Windows.Controls;

namespace WindowMain.View {
  /// <summary>
  /// Interaction logic for SuaPhanCachThapPhan.xaml
  /// </summary>
  public partial class SuaPhanCachThapPhan:UserControl {
	public SuaPhanCachThapPhan(object objInput) {
	  InitializeComponent();
	  this.DataContext=new ViewModels.SuaPhanCachThapPhan_ViewModel(this,objInput);
	}
  }
}
