using Login.ViewModels;
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
using System.Windows.Shapes;

namespace Login.View {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow:Window {
	public MainWindow(Dictionary<string,object> dicInput) {
	  InitializeComponent();
	  this.DataContext = new ViewModelMain(this,dicInput);
	}
  }

 // public class RelayCommand<T>:ICommand {
	//private Action<object> execute;
	//private Action<object,IInputElement> executeWithTarget;
	//private Func<object,bool> canExecute;

	//public event EventHandler CanExecuteChanged {
	//  add { CommandManager.RequerySuggested += value; }
	//  remove { CommandManager.RequerySuggested -= value; }
	//}

	//public RelayCommand(Action<object> execute,Func<object,bool> canExecute = null) {
	//  this.execute = execute;
	//  this.canExecute = canExecute;
	//}

	//public RelayCommand(Action<object,IInputElement> execute,Func<object,bool> canExecute = null) {
	//  this.executeWithTarget = execute;
	//  this.canExecute = canExecute;
	//}

	//public bool CanExecute(object parameter) {
	//  return this.canExecute == null || this.canExecute(parameter);
	//}

	//public void Execute(object parameter) {
	//  this.execute(parameter);
	//}

	//public void Execute(object parameter,IInputElement target) {
	//  this.executeWithTarget(parameter,target);
	//}
 // }

}
