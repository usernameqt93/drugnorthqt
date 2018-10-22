using Login.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace DrugNorthQT {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App:Application {

	private const int CONST_INT_SOFTWARE = 20;
	private const string CONST_STR_APP_NAME = "Master Test";
	private const string CONST_STR_TITLE = "Hệ thống Master Test";
	private const string CONST_STR_PATH_DLL = @"Tes\PlugIns";
	private const string CONST_STR_PATH_REGISTRY = @"SOFTWARE\Windset";
	private const string CONST_STR_KEY_REGISTRY = "Windsetmt";
	private const string CONST_STR_VALUE_REGISTRY = "1";

	private const string CONST_STR_VERSION = "2.1.28.18";
	private const string CONST_STR_NGAY_UPDATE_GAN_NHAT = "25/08/2018";

	static MainWindow _frm;
	private void Application_Startup(object sender,StartupEventArgs e) {
	  var stringValue = readKey();
	  if(stringValue == CONST_STR_VALUE_REGISTRY) {
		//_frm = new Main();
		//_frm.Show();

		Dictionary<string,object> dic = new Dictionary<string,object>();
		GetDictionaryData(ref dic);
		_frm = new MainWindow(dic);
		_frm.Show();
	  }
	}

	private void GetDictionaryData(ref Dictionary<string,object> dic) {

	  dic.Add("VersionAppExe",Assembly.GetExecutingAssembly().GetName().Version);
	  dic.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
						new Login.ViewModels.ViewModelMain.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromOtherUserControl));

	  Dictionary<string,object> dicSubInput = new Dictionary<string,object>();
	  GetSubDictionaryInput(ref dicSubInput);
	  dic.Add("Dictionary<string,object>",dicSubInput);
	}

	private void GetSubDictionaryInput(ref Dictionary<string,object> dic) {
	  dic.Add("stringAppName",CONST_STR_APP_NAME);
	  dic.Add("stringTitle",CONST_STR_TITLE);
	  dic.Add("stringPath",CONST_STR_PATH_DLL);
	  dic.Add("intSoftware",CONST_INT_SOFTWARE);
	  dic.Add("stringVersion",CONST_STR_VERSION);
	  dic.Add("stringTimeUpdate",CONST_STR_NGAY_UPDATE_GAN_NHAT);

	  dic.Add("boolCheckSaveLogin",DrugNorthQT.Properties.Settings.Default.checkSaveLoginInfo);
	  dic.Add("stringUserName",DrugNorthQT.Properties.Settings.Default.userName);
	  dic.Add("stringPassword",DrugNorthQT.Properties.Settings.Default.passUser);
	  dic.Add("intisServer",DrugNorthQT.Properties.Settings.Default.isServer);

	}

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dic) {
	  DrugNorthQT.Properties.Settings.Default.userName = dic["stringUser"] as string;
	  DrugNorthQT.Properties.Settings.Default.passUser = dic["stringPass"] as string;
	  DrugNorthQT.Properties.Settings.Default.isServer = (int)dic["int"];
	  DrugNorthQT.Properties.Settings.Default.checkSaveLoginInfo = (bool)dic["bool"];
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
		if(process.MainWindowHandle != IntPtr.Zero) {
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
	  key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(CONST_STR_PATH_REGISTRY);
	  string stringValue = (string)key.GetValue(CONST_STR_KEY_REGISTRY);
	  key.Close();
	  return stringValue;
	}
  }
}
