using HostViewer.Types;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WindowMain.ViewModels;

namespace WindowMain.View {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow:Window {

	//ICommand clickComand { get; set; }
	//readonly static BLLMain MainConfig = new BLLMain();
	private List<int> _lstMenuID = new List<int>();
	//private int selectedServer = 1;
	private static List<Dictionary<int,List<string>>> _lstSubMenuNames = new List<Dictionary<int,List<string>>>();
	private static List<Dictionary<int,List<AvailableArrayProcessor>>> _lstModules = new List<Dictionary<int,List<AvailableArrayProcessor>>>();

	public MainWindow(Dictionary<string,object> dicData) {

	  InitializeComponent();
	  this.DataContext = new ViewModelMain(this,dicData);
	  //DAO.GlobalDao.SetValue();
	  //var stt = DAO.GlobalDao.Testketnoi();
	  var timer = new DispatcherTimer(new TimeSpan(0,0,1),DispatcherPriority.Normal,delegate
	  {
		this.txtTime.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
	  },this.Dispatcher);
	  //this.txtData.Content = AppConfig.ToText((AppConfig.enum_Server)selectedServer);
	  this.txtData.Content =Environment.MachineName;
	  this.iconClock.Source = new BitmapImage(new Uri(@"/Assets/calendar.png",UriKind.Relative));
	  this.iconData.Source = new BitmapImage(new Uri(@"/Assets/data.png",UriKind.Relative));
	}

	private void Button_Click(object sender,RoutedEventArgs e) {
	  //(sender as Button).ContextMenu.IsEnabled = true;
	  //(sender as Button).ContextMenu.PlacementTarget = (sender as Button);
	  //(sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
	  //(sender as Button).ContextMenu.IsOpen = true;

	  btnAvatar.ContextMenu.IsEnabled = true;
	  btnAvatar.ContextMenu.PlacementTarget = txtHelloUser;
	  btnAvatar.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
	  btnAvatar.ContextMenu.IsOpen = !btnAvatar.ContextMenu.IsOpen;
	}

	//public event EventHandler CanExecuteChanged;
	//public bool CanExecute(object parameter) {
	//  return true;
	//}

	private void rDragMoveControl_PreviewMouseDown(object sender,MouseButtonEventArgs e) {
	  try {
		this.DragMove();
	  } catch(Exception ex) {
		string str = ex.Message;
	  }
	}

  }

  public class RelayCommand<T>:ICommand {
	private Action<object> execute;
	private Action<object,IInputElement> executeWithTarget;
	private Func<object,bool> canExecute;

	public event EventHandler CanExecuteChanged {
	  add { CommandManager.RequerySuggested += value; }
	  remove { CommandManager.RequerySuggested -= value; }
	}

	public RelayCommand(Action<object> execute,Func<object,bool> canExecute = null) {
	  this.execute = execute;
	  this.canExecute = canExecute;
	}

	public RelayCommand(Action<object,IInputElement> execute,Func<object,bool> canExecute = null) {
	  this.executeWithTarget = execute;
	  this.canExecute = canExecute;
	}

	public bool CanExecute(object parameter) {
	  return this.canExecute == null || this.canExecute(parameter);
	}

	public void Execute(object parameter) {
	  this.execute(parameter);
	}

	public void Execute(object parameter,IInputElement target) {
	  this.executeWithTarget(parameter,target);
	}
  }

}
