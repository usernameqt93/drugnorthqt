using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using WindowMain.View;

namespace DrugNorthQT {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App:Application {

	private const int CONST_INT_SOFTWARE = 20201020;
	private const string CONST_STR_APP_NAME = "DrugNorthQT";
	private const string CONST_STR_TITLE = "Hệ thống quản lý ABC";
	private const string CONST_STR_PATH_DLL = @"DNQT\PlugIns";
	private const string CONST_STR_PATH_REGISTRY = @"SOFTWARE\Windset";
	private const string CONST_STR_KEY_REGISTRY = "Windsetdnqt";
	private const string CONST_STR_VALUE_REGISTRY = "1";

	private const string CONST_STR_VERSION = "2.2020.10.17";
	private const string CONST_STR_NGAY_UPDATE_GAN_NHAT = "17/10/2020";

	static MainWindow _frm;

	private void Application_Startup(object sender,StartupEventArgs e) {
	  var stringValue = readKey();
	  if(stringValue==CONST_STR_VALUE_REGISTRY) {
		//_frm = new Main();
		//_frm.Show();

		var bllStyle = new WindowStyle.BLLPlugin();
		bllStyle.ChangeColorInFileConfigStyle("#FF1B68B6","#FF3C72A2","#FF628EB5");
		//bllStyle.ChangeColorInFileConfigStyle("#FF058624","#FF058624","#FF3BB45A");

		var dic = new Dictionary<string,object>();
		GetDictionaryData(ref dic);
		_frm=new MainWindow(dic);
		//_frm.Icon=new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/intest.ico",UriKind.RelativeOrAbsolute));
		_frm.Show();
	  }
	}

	private void GetDictionaryData(ref Dictionary<string,object> dic) {

	  dic.Add("VersionAppExe",Assembly.GetExecutingAssembly().GetName().Version);
	  dic.Add("stringAppName",CONST_STR_APP_NAME);
	  dic.Add("stringTitle",CONST_STR_TITLE);
	  dic.Add("stringPath",CONST_STR_PATH_DLL);
	  // dic.Add("Tuple<int,string,string><_software,_version,_dateTime>",
	  //new Tuple<int,string,string>(CONST_INT_SOFTWARE,CONST_STR_VERSION,CONST_STR_NGAY_UPDATE_GAN_NHAT));

	  AddToDicInputFromFileConfig(ref dic);

	  dic.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
						new WindowMain.ViewModels.ViewModelMain.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromOtherUserControl));

	  dic.Add("Tuple<bool,string,string,int><checkSaveLoginInfo,userName,passUser,isServer>",new Tuple<bool,string,string,int>(
		DrugNorthQT.Properties.Settings.Default.checkSaveLoginInfo,
		DrugNorthQT.Properties.Settings.Default.userName,
		DrugNorthQT.Properties.Settings.Default.passUser,
		DrugNorthQT.Properties.Settings.Default.isServer
		));
	}

	private void AddToDicInputFromFileConfig(ref Dictionary<string,object> dic) {
	  string strVersion = Assembly.GetExecutingAssembly().GetName().Version+"";
	  string strNgayUpdateGanNhat = DateTime.Now.ToString("dd'/'MM'/'yyyy");

	  // if(ConfigurationManager.AppSettings["Version"] != null) {
	  //strVersion = ConfigurationManager.AppSettings["Version"];
	  // }

	  // if(ConfigurationManager.AppSettings["DateTime"] != null) {
	  //strNgayUpdateGanNhat = ConfigurationManager.AppSettings["DateTime"];
	  // }


	  dic.Add("Tuple<int,string,string><_software,_version,_dateTime>",
		new Tuple<int,string,string>(CONST_INT_SOFTWARE,strVersion,strNgayUpdateGanNhat));
	}

	private void ExcuteFromOtherUserControl(Dictionary<string,object> dic) {
	  DrugNorthQT.Properties.Settings.Default.userName=dic["stringUser"] as string;
	  DrugNorthQT.Properties.Settings.Default.passUser=dic["stringPass"] as string;
	  DrugNorthQT.Properties.Settings.Default.isServer=(int)dic["int"];
	  DrugNorthQT.Properties.Settings.Default.checkSaveLoginInfo=(bool)dic["bool"];
	  DrugNorthQT.Properties.Settings.Default.Save();
	}

	// signals to restore the window to its normal state
	private const int SW_SHOWNORMAL = 1;

	// create the mutex
	private const string MUTEXNAME = "FirstInstance";
	private readonly Mutex _mutex = new Mutex(true,MUTEXNAME);

	public App() {
	  if(!_mutex.WaitOne(TimeSpan.Zero)) {
		ShowExistingWindow();
		Shutdown();
	  }
	}

	[DllImport("User32.dll")]
	private static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("user32.dll")]
	private static extern bool ShowWindow(IntPtr hWnd,int nCmdShow);

	// shows the window of the single-instance that is already open
	private void ShowExistingWindow() {
	  var currentProcess = Process.GetCurrentProcess();
	  var processes = Process.GetProcessesByName(currentProcess.ProcessName);
	  foreach(var process in processes) {
		// the single-instance already open should have a MainWindowHandle
		if(process.MainWindowHandle!=IntPtr.Zero) {
		  // restores the window in case it was minimized
		  ShowWindow(process.MainWindowHandle,SW_SHOWNORMAL);

		  // brings the window to the foreground
		  SetForegroundWindow(process.MainWindowHandle);

		  return;
		}
	  }
	}

	private static string readKey() {
	  Microsoft.Win32.RegistryKey key;
	  key=Microsoft.Win32.Registry.LocalMachine.CreateSubKey(CONST_STR_PATH_REGISTRY);
	  string stringValue = (string)key.GetValue(CONST_STR_KEY_REGISTRY);
	  key.Close();
	  return stringValue;
	}

  }
}
