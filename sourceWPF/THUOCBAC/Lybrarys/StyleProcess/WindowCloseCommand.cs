using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WindowStyle {
  public class WindowCloseCommand:ICommand {

	public bool CanExecute(object parameter) {
	  return true;
	}

	public event EventHandler CanExecuteChanged;

	public void Execute(object parameter) {
	  var window = parameter as Window;

	  if(window==null) {
		return;
	  }

	  if(window.Name.Equals("windowMain")&&window.Title.Contains("Hệ thống")) {
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
