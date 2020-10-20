using QT.MessageBox;
using log4net;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WindowMain.View;
using QT.Framework.ToolCommon.Helpers;

namespace WindowMain.ViewModels {
  class SuaPhanCachThapPhan_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal SuaPhanCachThapPhan _mainUserControl;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private const string CONST_STR_SAMPLE_FOLDER_NAME = "SampleFiles";
	private const string CONST_STR_SAMPLE_FILE_NAME = "HuongDanPhanCachThapPhan.jpg";

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===




	#endregion

	#endregion

	#region === Handle ===

	public SuaPhanCachThapPhan_ViewModel(SuaPhanCachThapPhan _viewMain,object objInput) {
	  _mainUserControl=_viewMain;
	  DicDataInPreviousUC=objInput as Dictionary<string,object>;
	  ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)DicDataInPreviousUC["DELEGATE_VOID_IN_OTHER_USERCONTROL"];

	  LoadForm();

	  BlnIsLoadingForm=false;
	}

	#endregion

	#region === Các hàm chung ===

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dicInput) {

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

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		string strHuongDan = "+ B1: Vào Control Panel";
		strHuongDan+="\n+ B2: Chọn Change date, time, or number formats để hiển thị cửa số Region";
		strHuongDan+="\n+ B3: Chọn Additional settings... để hiển thị cửa số Customize Format";
		strHuongDan+="\n+ B4: Chọn tab Numbers, thay đổi Decimal symbol phân cách phần thập phân bằng dấu chấm '.'";

		_mainUserControl.txtCacBuocHuongDan.Text=strHuongDan;

		_mainUserControl.grbMain.Tag=System.Windows.Forms.Application.StartupPath
			  +$"\\{CONST_STR_SAMPLE_FOLDER_NAME}\\"+CONST_STR_SAMPLE_FILE_NAME;
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

	public ICommand OpenImageCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			var ofd = new OpenFileDialog();
			ofd.Filter="Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

			if(ofd.ShowDialog()!=DialogResult.OK) {
			  return;
			}

			_mainUserControl.grbMain.Tag=ofd.FileName;

			HienThiImageTheoRadioButtonCommand.Execute(null);

		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand HienThiImageTheoRadioButtonCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(_mainUserControl.grbMain.Tag==null) {
			  QTMessageBox.ShowNotify(
				"Ảnh hướng dẫn minh họa không tồn tại, bạn vui lòng liên hệ bộ phận DVKH để được hỗ trợ!");
			  return;
			}

			var bitImage = new BitmapImage();
			bitImage.BeginInit();
			bitImage.UriSource=new Uri(_mainUserControl.grbMain.Tag.ToString());
			bitImage.EndInit();

			_mainUserControl.imageZoom.Source=null;
			_mainUserControl.imageScroll.Source=null;

			if(_mainUserControl.rdbHienThiKichThuocGoc.IsChecked==true) {
			  _mainUserControl.imageScroll.Source=bitImage;
			  return;
			}

			if(_mainUserControl.rdbHienThiVuaManHinh.IsChecked==true) {
			  _mainUserControl.imageZoom.Source=bitImage;
			  _mainUserControl.borderZoom.Reset();
			  return;
			}

		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ShowControlPanelCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			var cplPath = System.IO.Path.Combine(Environment.SystemDirectory,"control.exe");
			System.Diagnostics.Process.Start(cplPath,"/name Microsoft.RegionalAndLanguageOptions");
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand RestartApplicationCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			System.Windows.Forms.Application.Restart();
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand LoadedCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(BlnIsLoadingForm) {

			}

			HienThiImageTheoRadioButtonCommand.Execute(null);

			QTMessageBox.ShowNotify(
			  "Máy tính của bạn hiện chưa thiết lập phân cách phần thập phân bởi dấu chấm '.' xong, bạn vui lòng thiết lập theo hướng dẫn để tiếp tục sử dụng!");

			ShowControlPanelCommand.Execute(null);

		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand BackCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			_mainUserControl.Height=0;
			System.Windows.Controls.Grid gridChildren = (System.Windows.Controls.Grid)_mainUserControl.Parent;
			ModalContentPresenter modelChildren = (ModalContentPresenter)gridChildren.Parent;
			System.Windows.Controls.Grid gridPresenter = (System.Windows.Controls.Grid)modelChildren.Parent;
			//ModalContentPresenter modelPresenter = (ModalContentPresenter)gridPresenter.FindName("modalPresenter");
			ModalContentPresenter modelPresenter = (ModalContentPresenter)gridPresenter.FindName("modalPresenterBiggest");

			modelChildren.Visibility=Visibility.Hidden;
			modelPresenter.Visibility=Visibility.Visible;

		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	#endregion

  }
}
