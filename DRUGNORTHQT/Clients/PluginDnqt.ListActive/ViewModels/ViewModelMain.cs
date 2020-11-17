using log4net;
using PluginDnqt.ListActive.Views;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PluginDnqt.ListActive.ViewModels {
  class ViewModelMain:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal MainWindow _mainUserControl;

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===

	#endregion

	#endregion

	#region === Handle ===

	public ViewModelMain(MainWindow _viewMain,object objInput) {
	  _mainUserControl=_viewMain;
	  //MainCollection.Source=_lstGridMain;

	  LoadForm();

	  BlnIsLoadingForm=false;
	}

	#endregion

	#region === Các hàm chung ===

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dic) {

	}

	private void LoadForm() {
	  try {
		LoadControlDefault();

		LoadData();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadControlDefault() {
	  try {
		string strValueKey = "";
		BLLTools.GetValueFromFileConfig(ref strValueKey,"linkActive");
		_mainUserControl.webView.Navigate(strValueKey);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	#endregion

	#region === Command ===

	public ICommand LoadedCommand => new DelegateCommand(p => {
	  try {
		if(BlnIsLoadingForm) {

		}

		//TimerChanged=new System.Windows.Forms.Timer() { Interval=CONST_INT_INTERVAL_TIMER };
		//TimerChanged.Tick+=new EventHandler(timerChanged_Tick);
		//TimerChanged.Start();

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	#endregion

  }
}
