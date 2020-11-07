using DNQTDataAccessLayer.DALNew;
using log4net;
using PluginDnqt.Customer.Models;
using PluginDnqt.Customer.Views;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.Framework.ToolCommon.Models;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PluginDnqt.Customer.ViewModels {
  class DetailTienNo_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal DetailTienNo _mainUserControl;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private System.Windows.Forms.Timer TimerChanged = new System.Windows.Forms.Timer() {
	  Interval=CONST_INT_INTERVAL_TIMER
	};

	private const int CONST_INT_INTERVAL_TIMER = 50;

	private DAL_Product DALProduct = new DAL_Product();

	private DAL_Order DALOrder = new DAL_Order();

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===




	#region MainDataGrid 

	private ModelRowDetailTienNo _selectedRow;

	public ModelRowDetailTienNo SelectedRow {
	  get { return this._selectedRow; }
	  set { _selectedRow=value; OnPropertyChanged(nameof(SelectedRow)); }
	}

	private ObservableCollection<ModelRowDetailTienNo> _lstGridMain = new ObservableCollection<ModelRowDetailTienNo>();
	private CollectionViewSource MainCollection = new CollectionViewSource();

	public ICollectionView LstGridMain {
	  get { return this.MainCollection.View; }
	}

	#endregion

	#endregion

	#endregion

	#region === Handle ===

	public DetailTienNo_ViewModel(DetailTienNo _viewMain,object objInput) {
	  _mainUserControl=_viewMain;
	  MainCollection.Source=_lstGridMain;

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
		_mainUserControl.btnSave.Visibility=Visibility.Collapsed;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		ModelRowCustomer mrow = DicDataInPreviousUC["ModelRowCustomer"] as ModelRowCustomer;
		_lstGridMain.Clear();
		foreach(var item in mrow.LstGridDetail) {
		  _lstGridMain.Add(item);
		}

		_mainUserControl.lblName.Content=mrow.MBC001.Str;
		_mainUserControl.lblTienNo.Content=mrow.MBDTienNo.Str;

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ScrollToLastRowOnGrid() {
	  try {
		int intSumRow = _lstGridMain.Count;
		if(intSumRow>0) {
		  SelectedRow=_lstGridMain[intSumRow-1];
		  _mainUserControl.dgvMain.ScrollIntoView(SelectedRow);
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void HienThiChiTiet() {
	  try {
		string strTxtGhiChu = _mainUserControl.txtGhiChu.Text.Trim();
		string strGhiChuFull = "";
		if(strTxtGhiChu!="") {
		  string strVietHoa = "";
		  BLLTools.UpperTextStartByQuantity(ref strVietHoa,strTxtGhiChu,1);
		  strGhiChuFull="\nGhi chú: "+strVietHoa;
		}

		string strHienTai = _mainUserControl.lblTienNo.Content.ToString();
		string strCuThe = _mainUserControl.lblDonGia.Content.ToString();
		if(_mainUserControl.rdbSuaThanh.IsChecked==true) {
		  _mainUserControl.lblChiTiet.Content=$"Tiền nợ sửa thành {strCuThe} đ"+strGhiChuFull;
		  _mainUserControl.lblSauKhiThayDoi.Content=
		  $"Từ    {strHienTai}    thành    {strCuThe} đ";
		  return;
		}

		ModelRowCustomer mrow = DicDataInPreviousUC["ModelRowCustomer"] as ModelRowCustomer;

		decimal decDonGia = 0;
		_bllPlugin.GetDecimalFromObject(ref decDonGia,_mainUserControl.lblDonGia.Tag);
		if(_mainUserControl.rdbDaTra.IsChecked==true) {
		  decimal decHieu = mrow.MBDTienNo.Value-decDonGia;
		  if(decHieu<0) {
			QTMessageBox.ShowNotify("Bạn đang nhập số tiền lớn hơn tiền nợ hiện tại, vui lòng kiểm tra lại!");
			return;
		  }

		  string strHieu = (decHieu==0) ? "0" : decHieu.ToString("#,###.#");
		  _mainUserControl.lblChiTiet.Content=$"Khách hàng đã trả {strCuThe} đ"+strGhiChuFull;
		  _mainUserControl.lblSauKhiThayDoi.Content=
		  $"{strHienTai}   -   {strCuThe} đ   =   {strHieu} đ";
		  return;
		}

		if(_mainUserControl.rdbVayThem.IsChecked==true) {
		  decimal decTong = mrow.MBDTienNo.Value+decDonGia;
		  if(decDonGia<4000) {
			QTMessageBox.ShowNotify("Bạn đang nhập số tiền nhỏ hơn 4.000 đ, vui lòng kiểm tra lại!");
			return;
		  }

		  string strTong = (decTong==0) ? "0" : decTong.ToString("#,###.#");
		  _mainUserControl.lblChiTiet.Content=$"Khách hàng vay thêm {strCuThe} đ"+strGhiChuFull;
		  _mainUserControl.lblSauKhiThayDoi.Content=
		  $"{strHienTai}   +   {strCuThe} đ   =   {strTong} đ";
		  return;
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void timerChanged_Tick(object sender,EventArgs e) {
	  TimerChanged.Stop();

	  ScrollToLastRowOnGrid();
	  XacNhanCheckedChangedCommand.Execute(null);
	}

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dicInput) {

	}

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	#endregion

	#region === Command ===

	public ICommand EditCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.btnChange.Visibility=Visibility.Collapsed;
		_mainUserControl.btnSave.Visibility=Visibility.Visible;

		ScrollToLastRowOnGrid();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand XacNhanCheckedChangedCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.lblChiTiet.Content="";
		_mainUserControl.lblSauKhiThayDoi.Content="";

		_mainUserControl.stackPanelChiTiet.Visibility=Visibility.Collapsed;
		_mainUserControl.stackPanelThaoTac.IsEnabled=true;

		ScrollToLastRowOnGrid();

		if(_mainUserControl.chkXacNhan.IsChecked==false) {
		  return;
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

		HienThiChiTiet();

		if(_mainUserControl.lblChiTiet.Content.ToString().Trim()=="") {
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  _mainUserControl.txtDonGia.Focus();
		  _mainUserControl.txtDonGia.SelectAll();
		  return;
		}

		_mainUserControl.stackPanelChiTiet.Visibility=Visibility.Visible;
		_mainUserControl.stackPanelThaoTac.IsEnabled=false;

		ScrollToLastRowOnGrid();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	//public ICommand RadioButtonTuyChonCheckedCommand => new DelegateCommand(p => {
	//  try {
	//	{
	//	  string strText = _mainUserControl.txtDonGia.Text.Trim();
	//	  decimal objTemp = 0;
	//	  try {
	//		objTemp=Convert.ToDecimal(strText);
	//	  } catch(Exception e) {
	//		string str = e.Message;
	//	  }

	//	  _bllPlugin.HienThiLabelDonGiaByDecimal(ref _mainUserControl.lblDonGia,objTemp);
	//	}

	//	string strTxtGhiChu = _mainUserControl.txtGhiChu.Text.Trim();
	//	string strGhiChuFull = "";
	//	if(strTxtGhiChu!="") {
	//	  strGhiChuFull="\nGhi chú: "+strTxtGhiChu;
	//	}

	//	string strHienTai = _mainUserControl.lblTienNo.Content.ToString();
	//	string strCuThe = _mainUserControl.lblDonGia.Content.ToString();
	//	if(_mainUserControl.rdbSuaThanh.IsChecked==true) {
	//	  _mainUserControl.lblChiTiet.Content=$"Tiền nợ sửa thành {strCuThe} đ"+strGhiChuFull;
	//	  _mainUserControl.lblSauKhiThayDoi.Content=
	//	  $"Từ    {strHienTai}    thành    {strCuThe} đ";
	//	  return;
	//	}

	//	ModelRowCustomer mrow = DicDataInPreviousUC["ModelRowCustomer"] as ModelRowCustomer;

	//	decimal decDonGia = 0;
	//	_bllPlugin.GetDecimalFromObject(ref decDonGia,_mainUserControl.lblDonGia.Tag);
	//	if(_mainUserControl.rdbDaTra.IsChecked==true) {
	//	  decimal decHieu = mrow.MBDTienNo.Value-decDonGia;
	//	  if(decHieu<0) {
	//		QTMessageBox.ShowNotify("Bạn đang nhập số tiền lớn hơn tiền nợ hiện tại, vui lòng kiểm tra lại!");
	//		return;
	//	  }

	//	  string strHieu = (decHieu==0) ? "0" : decHieu.ToString("#,###.#");
	//	  _mainUserControl.lblChiTiet.Content=$"Khách hàng đã trả {strCuThe} đ"+strGhiChuFull;
	//	  _mainUserControl.lblSauKhiThayDoi.Content=
	//	  $"{strHienTai}   -   {strCuThe} đ   =   {strHieu} đ";
	//	  return;
	//	}

	//	if(_mainUserControl.rdbVayThem.IsChecked==true) {
	//	  decimal decTong = mrow.MBDTienNo.Value+decDonGia;
	//	  if(decDonGia<4000) {
	//		QTMessageBox.ShowNotify("Bạn đang nhập số tiền nhỏ hơn 4.000 đ, vui lòng kiểm tra lại!");
	//		return;
	//	  }

	//	  string strTong = (decTong==0) ? "0" : decTong.ToString("#,###.#");
	//	  _mainUserControl.lblChiTiet.Content=$"Khách hàng vay thêm {strCuThe} đ"+strGhiChuFull;
	//	  _mainUserControl.lblSauKhiThayDoi.Content=
	//	  $"{strHienTai}   +   {strCuThe} đ   =   {strTong} đ";
	//	  return;
	//	}
	//  } catch(Exception ex) {
	//	Log4Net.Error(ex.Message);
	//	Log4Net.Error(ex.StackTrace);
	//	ShowException(ex);
	//  }
	//});

	public ICommand SaveCommand => new DelegateCommand(p => {
	  try {
		string strMessage = "Bạn chắc chắn muốn thực hiện thao tác này?";
		//strMessage+="\n"+"Tổng giá đơn hàng sẽ giảm đi tương ứng!";
		//strMessage+="\n"+"Bạn chắc chắn muốn thực hiện thao tác này?";
		if(QTMessageBox.ShowConfirm(strMessage)!=MessageBoxResult.Yes) {
		  return;
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
