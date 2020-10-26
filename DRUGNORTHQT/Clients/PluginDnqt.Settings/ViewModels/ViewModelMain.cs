using DNQTConstTable;
using log4net;
using PluginDnqt.Settings.Views;
using QT.Framework.ToolCommon.Helpers;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace PluginDnqt.Settings.ViewModels {
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
		_mainUserControl.gridMain.IsEnabled=false;

		_mainUserControl.btnLuuLai.Visibility=System.Windows.Visibility.Collapsed;
		_mainUserControl.btnThayDoi.Visibility=System.Windows.Visibility.Collapsed;

		_mainUserControl.btnThayDoi.Visibility=System.Windows.Visibility.Visible;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		_bllPlugin.ShowValueKeyOnTextbox(ref _mainUserControl.txtSoRowQuanLyViThuoc
		  ,KeyFileConfig.STR_KEY_SO_ROW_1PAGE_PLUGIN_PRODUCT.STR);
		_bllPlugin.ShowValueKeyOnTextbox(ref _mainUserControl.txtSoRowQuanLyDonHang
		  ,KeyFileConfig.STR_KEY_SO_ROW_1PAGE_PLUGIN_ORDER.STR);
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

	public ICommand SaveCommand => new DelegateCommand(p => {
	  try {
		if(QTMessageBox.ShowConfirm(
		  "Hệ thống sẽ quay lại màn hình đăng nhập để lưu thay đổi cài đặt hiển thị của bạn!"
		  +"\nBạn chắc chắn muốn thay đổi?")
		  !=System.Windows.MessageBoxResult.Yes) {
		  return;
		}

		_bllPlugin.ChangeValueOfKeyInFileConfig(KeyFileConfig.STR_KEY_SO_ROW_1PAGE_PLUGIN_PRODUCT.STR
		  ,_mainUserControl.txtSoRowQuanLyViThuoc.Text.Trim());

		_bllPlugin.ChangeValueOfKeyInFileConfig(KeyFileConfig.STR_KEY_SO_ROW_1PAGE_PLUGIN_ORDER.STR
		  ,_mainUserControl.txtSoRowQuanLyDonHang.Text.Trim());

		System.Windows.Forms.Application.Restart();
		Process.GetCurrentProcess().Kill();

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ChangeCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.gridMain.IsEnabled=true;

		_mainUserControl.btnLuuLai.Visibility=System.Windows.Visibility.Collapsed;
		_mainUserControl.btnThayDoi.Visibility=System.Windows.Visibility.Collapsed;

		_mainUserControl.btnLuuLai.Visibility=System.Windows.Visibility.Visible;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

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
