using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowStyle {
  public class WindowCloseCommand:ICommand {

	public bool CanExecute(object parameter) {
	  return true;
	}

	public event EventHandler CanExecuteChanged { add { } remove { } }

	public void Execute(object parameter) {
	  var window = parameter as Window;

	  if(window==null) {
		return;
	  }

	  if(window.Name.Equals("windowMain")&&window.Title.Contains("Hệ thống")) {
		if(System.Windows.Forms.MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?"
		  ,"Thoát chương trình"
		  ,MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.Yes) {
		  return;
		}

		Process.GetCurrentProcess().Kill();
	  }

	  window.Close();

	  // if(window != null) {
	  ////window.Close();
	  ////System.Windows.Forms.Application.Restart();
	  //Process.GetCurrentProcess().Kill();
	  // }

	  //Application.Current.Shutdown();
	}
  }
}
