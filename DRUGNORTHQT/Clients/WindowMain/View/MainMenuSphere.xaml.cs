using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowMain.ViewModels;

namespace WindowMain.View {
  /// <summary>
  /// Interaction logic for MainMenuSphere.xaml
  /// </summary>
  public partial class MainMenuSphere:UserControl {
	public MainMenuSphere(object objInput) {
	  InitializeComponent();
	  this.DataContext = new MainMenuSphere_ViewModel(this,objInput);
	}
  }
}
