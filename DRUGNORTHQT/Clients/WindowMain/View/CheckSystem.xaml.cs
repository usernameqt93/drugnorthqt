using System.Collections.Generic;
using System.Windows;

namespace WindowMain.View {
  /// <summary>
  /// Interaction logic for CheckSystem.xaml
  /// </summary>
  public partial class CheckSystem:Window {
	public CheckSystem(Dictionary<string,object> dicData) {
	  InitializeComponent();
	  this.DataContext=new ViewModels.CheckSystem_ViewModel(this,dicData);
	}
  }
}
