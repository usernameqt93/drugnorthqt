using DNQTDataAccessLayer.DALNew;
using log4net;
using PluginDnqt.Order.Models;
using PluginDnqt.Order.Views;
using QT.Framework.ToolCommon.Helpers;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PluginDnqt.Order.ViewModels {
  class UpdateDetailOrder_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal UpdateDetailOrder _mainUserControl;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private System.Windows.Forms.Timer TimerChanged = new System.Windows.Forms.Timer() {
	  Interval=CONST_INT_INTERVAL_TIMER
	};

	private const int CONST_INT_INTERVAL_TIMER = 50;

	private DAL_Order DALOrder = new DAL_Order();

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===

	#endregion

	#endregion

	#region === Handle ===

	public UpdateDetailOrder_ViewModel(UpdateDetailOrder _viewMain,object objInput) {
	  _mainUserControl=_viewMain;
	  DicDataInPreviousUC=objInput as Dictionary<string,object>;
	  ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)DicDataInPreviousUC["DELEGATE_VOID_IN_OTHER_USERCONTROL"];

	  LoadForm();

	  BlnIsLoadingForm=false;
	}

	#endregion

	#region === Các hàm chung ===

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
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ChangeFocusToTextBoxDonGia() {
	  try {
		_mainUserControl.txtDonGia.Focus();
		_mainUserControl.txtDonGia.SelectAll();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ChangeFocusToTextBoxSoLuong() {
	  try {
		_mainUserControl.txtSoLuong.Focus();
		_mainUserControl.txtSoLuong.SelectAll();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void timerChanged_Tick(object sender,EventArgs e) {
	  TimerChanged.Stop();

	  ModelRowDetailOrder mOrder = DicDataInPreviousUC["ModelRowDetailOrder"] as ModelRowDetailOrder;
	  _mainUserControl.lblNameProduct.Content=mOrder.StrNameDrug;
	  _mainUserControl.txtSoLuong.Text=""+mOrder.FloatSumKg;
	  _mainUserControl.txtDonGia.Text=(mOrder.DecimalDonGia).ToString("0.00").Replace(".00",string.Empty);

	  XacNhanCheckedChangedCommand.Execute(null);
	}

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dicInput) {

	}

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	#endregion

	#region === Command ===

	public ICommand XacNhanCheckedChangedCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.lblChonDeHienThi.Visibility=Visibility.Visible;
		_mainUserControl.stackPanelThaoTac.IsEnabled=true;
		_mainUserControl.stackPanelThanhTien.Visibility=Visibility.Collapsed;
		if(_mainUserControl.chkXacNhan.IsChecked==false) {
		  return;
		}

		{
		  string strText = _mainUserControl.txtSoLuong.Text.Trim();
		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(strText);
		  } catch(Exception e) {
			string str = e.Message;
		  }

		  _bllPlugin.HienThiLabelSoLuongByDecimal(ref _mainUserControl.lblSoLuong,objTemp);
		}

		{
		  string strText = _mainUserControl.txtDonGia.Text.Trim();
		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(strText);
		  } catch(Exception e) {
			string str = e.Message;
		  }

		  _bllPlugin.HienThiLabelDonGiaByDecimal(ref _mainUserControl.lblDonGia,objTemp);
		}

		ThanhTienPreviewMouseMoveCommand.Execute(null);

		decimal decSoLuong = 0;
		_bllPlugin.GetDecimalFromObject(ref decSoLuong,_mainUserControl.lblSoLuong.Tag);
		if(decSoLuong<=0) {
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  QTMessageBox.ShowNotify(
			"Số lượng đang bằng 0 hoặc không hợp lệ, bạn vui lòng kiểm tra lại!"
			,"(decSoLuong<=0)");
		  ChangeFocusToTextBoxSoLuong();
		  return;
		}

		decimal decDonGia = 0;
		_bllPlugin.GetDecimalFromObject(ref decDonGia,_mainUserControl.lblDonGia.Tag);
		if(decDonGia<=1000) {
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  QTMessageBox.ShowNotify(
			"Đơn giá đang nhỏ hơn 1000 hoặc không hợp lệ, bạn vui lòng kiểm tra lại!"
			,"(decDonGia<=1000)");
		  ChangeFocusToTextBoxDonGia();
		  return;
		}

		_mainUserControl.stackPanelThaoTac.IsEnabled=false;
		_mainUserControl.stackPanelThanhTien.Visibility=Visibility.Visible;
		_mainUserControl.lblChonDeHienThi.Visibility=Visibility.Collapsed;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ThanhTienPreviewMouseMoveCommand => new DelegateCommand(p => {
	  try {
		decimal decSoLuong = 0;
		_bllPlugin.GetDecimalFromObject(ref decSoLuong,_mainUserControl.lblSoLuong.Tag);

		decimal decDonGia = 0;
		_bllPlugin.GetDecimalFromObject(ref decDonGia,_mainUserControl.lblDonGia.Tag);

		_bllPlugin.HienThiLabelDonGiaByDecimal(ref _mainUserControl.lblThanhTien,decSoLuong*decDonGia);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand SaveCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.chkXacNhan.IsChecked==false) {
		  return;
		}

		decimal decSoLuong = 0;
		_bllPlugin.GetDecimalFromObject(ref decSoLuong,_mainUserControl.lblSoLuong.Tag);
		if(decSoLuong<=0) {
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  QTMessageBox.ShowNotify(
			"Số lượng đang bằng 0 hoặc không hợp lệ, bạn vui lòng kiểm tra lại!"
			,"(decSoLuong<=0)");
		  ChangeFocusToTextBoxSoLuong();
		  return;
		}

		decimal decDonGia = 0;
		_bllPlugin.GetDecimalFromObject(ref decDonGia,_mainUserControl.lblDonGia.Tag);
		if(decDonGia<=1000) {
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  QTMessageBox.ShowNotify(
			"Đơn giá đang nhỏ hơn 1000 hoặc không hợp lệ, bạn vui lòng kiểm tra lại!"
			,"(decDonGia<=1000)");
		  ChangeFocusToTextBoxDonGia();
		  return;
		}

		ModelRowDetailOrder mOrder = DicDataInPreviousUC["ModelRowDetailOrder"] as ModelRowDetailOrder;

		var dicInput = new Dictionary<string,object>();
		dicInput["string.strIdDetailOrder"]=mOrder.StrId;
		dicInput["decimal.decSoLuong"]=decSoLuong;
		dicInput["decimal.decDonGia"]=decDonGia;
		dicInput["decimal.decThanhTien"]=decDonGia*decSoLuong;

		{
		  var dicOutput = new Dictionary<string,object>();
		  Exception exOutput = null;
		  DALOrder.UpdateOrderDetail(ref dicOutput,ref exOutput,dicInput);
		  if(exOutput!=null) {
			Log4Net.Error(exOutput.Message);
			Log4Net.Error(exOutput.StackTrace);
			ShowException(exOutput);
			return;
		  }

		  string strKeyError = "string";
		  if(dicOutput.ContainsKey(strKeyError)) {
			QTMessageBox.ShowNotify(
			  "Cập nhật số lượng và đơn giá mới không thành công, bạn vui lòng thử lại!"
			  ,dicOutput[strKeyError] as string);
			return;
		  }
		}

		string strMessage = "THAO TÁC THÀNH CÔNG!";
		QTMessageBox.ShowNotify(strMessage);

		BackCommand.Execute(null);

		if(ExcuteInOtherUserControl!=null) {
		  var dicInput2 = new Dictionary<string,object>();

		  ExcuteInOtherUserControl(ref dicInput2);
		}

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

		TimerChanged=new System.Windows.Forms.Timer() { Interval=CONST_INT_INTERVAL_TIMER };
		TimerChanged.Tick+=new EventHandler(timerChanged_Tick);
		TimerChanged.Start();

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand BackCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.Height=0;
		System.Windows.Controls.Grid gridChildren = (System.Windows.Controls.Grid)_mainUserControl.Parent;
		ModalContentPresenter modelChildren = (ModalContentPresenter)gridChildren.Parent;
		System.Windows.Controls.Grid gridPresenter = (System.Windows.Controls.Grid)modelChildren.Parent;
		ModalContentPresenter modelPresenter = (ModalContentPresenter)gridPresenter.FindName("modalPresenter");

		modelChildren.Visibility=Visibility.Hidden;
		modelPresenter.Visibility=Visibility.Visible;

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	#endregion

  }
}
