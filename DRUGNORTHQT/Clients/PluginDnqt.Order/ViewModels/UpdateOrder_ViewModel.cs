using DNQTDataAccessLayer.DALNew;
using log4net;
using PluginDnqt.Order.Models;
using PluginDnqt.Order.Views;
using QT.Framework.LoadingPopup.View;
using QT.Framework.ToolCommon.Helpers;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;

namespace PluginDnqt.Order.ViewModels {
  class UpdateOrder_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal UpdateOrder _mainUserControl;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private System.Windows.Forms.Timer TimerChanged = new System.Windows.Forms.Timer() {
	  Interval=CONST_INT_INTERVAL_TIMER
	};

	private const int CONST_INT_INTERVAL_TIMER = 50;

	private DAL_Product DALProduct = new DAL_Product();

	private DataTable DT_AllIdNameProduct = null;

	private DAL_Order DALOrder = new DAL_Order();
	internal System.Windows.Input.KeyEventArgs KeyEventDownNameProduct = null;
	internal System.Windows.Input.KeyEventArgs KeyEventDownSoLuong = null;
	internal System.Windows.Input.KeyEventArgs KeyEventDownDonGia = null;

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===

	#region Variables for loading

	private QT.Framework.ToolCommon.Models.ModelProgress MPProgress =
	  new QT.Framework.ToolCommon.Models.ModelProgress();
	public PopupLoading LoadingUC;

	private bool _blnHideMain = false;

	public bool BlnHideMain {
	  get { return _blnHideMain; }
	  set { _blnHideMain=value; OnPropertyChanged(nameof(BlnHideMain)); }
	}

	#endregion




	#region DataGrid Suggest Name Product

	private ModelRowGoiYNameProduct _selectedRowSuggest;

	public ModelRowGoiYNameProduct SelectedRowSuggest {
	  get { return this._selectedRowSuggest; }
	  set { _selectedRowSuggest=value; OnPropertyChanged(nameof(SelectedRowSuggest)); }
	}

	private ObservableCollection<ModelRowGoiYNameProduct> _lstGridSuggest = new ObservableCollection<ModelRowGoiYNameProduct>();
	private CollectionViewSource SuggestCollection = new CollectionViewSource();

	public ICollectionView LstGridSuggest {
	  get { return this.SuggestCollection.View; }
	}

	#endregion

	#region DataGrid Suggest DonGia

	private ModelRowDonGia _selectedRowDonGia;

	public ModelRowDonGia SelectedRowDonGia {
	  get { return this._selectedRowDonGia; }
	  set { _selectedRowDonGia=value; OnPropertyChanged(nameof(SelectedRowDonGia)); }
	}

	private ObservableCollection<ModelRowDonGia> _lstGridDonGia = new ObservableCollection<ModelRowDonGia>();
	private CollectionViewSource DonGiaCollection = new CollectionViewSource();

	public ICollectionView LstGridDonGia {
	  get { return this.DonGiaCollection.View; }
	}

	#endregion

	#region MainDataGrid 

	private ModelRowDetailOrder _selectedRow;

	public ModelRowDetailOrder SelectedRow {
	  get { return this._selectedRow; }
	  set { _selectedRow=value; OnPropertyChanged(nameof(SelectedRow)); }
	}

	private ObservableCollection<ModelRowDetailOrder> _lstGridMain = new ObservableCollection<ModelRowDetailOrder>();
	private CollectionViewSource MainCollection = new CollectionViewSource();

	public ICollectionView LstGridMain {
	  get { return this.MainCollection.View; }
	}

	#endregion

	#endregion

	#endregion

	#region === Handle ===

	public UpdateOrder_ViewModel(UpdateOrder _viewMain,object objInput) {
	  _mainUserControl=_viewMain;
	  MainCollection.Source=_lstGridMain;
	  SuggestCollection.Source=_lstGridSuggest;
	  DonGiaCollection.Source=_lstGridDonGia;

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

	private void LoadListProductGoiY() {
	  try {
		Exception exOutput = null;
		DT_AllIdNameProduct=null;
		DALProduct.GetDTAllIdProduct(ref DT_AllIdNameProduct,ref exOutput);
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
		}

		if(DT_AllIdNameProduct==null) {
		  QTMessageBox.ShowNotify("Danh sách vị thuốc tải không thành công, bạn vui lòng thao tác lại!"
			,"(DT_AllIdNameProduct==null)");
		  BackCommand.Execute(null);
		  return;
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		ModelRowOrder mOrder = DicDataInPreviousUC["ModelRowOrder"] as ModelRowOrder;

		var lstStringId = new List<string>();
		lstStringId.Add(mOrder.StrId);

		Exception exOutput = null;
		DataTable DT_DetailOrderByListId = null;
		DALOrder.GetDTDetailOrderByListIdOrder(ref DT_DetailOrderByListId,ref exOutput,lstStringId);
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
		}

		if(DT_DetailOrderByListId==null) {
		  QTMessageBox.ShowNotify(
			"Dữ liệu đơn hàng này tải không thành công, bạn vui lòng thao tác lại!"
			,"(DT_DetailOrderByListId==null)");
		  return;
		}

		_bllPlugin.LoadGridChiTietDHByDataTable(ref _lstGridMain,DT_DetailOrderByListId);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void KiemTraPhimF5F6F7VaFocus(ref bool blnPressF5F6F7,KeyEventArgs keyEventDown) {
	  try {
		if(keyEventDown.Key==Key.F5) {
		  ChangeFocusToTextBoxNameProduct();
		  return;
		}

		if(keyEventDown.Key==Key.F6) {
		  ChangeFocusToTextBoxSoLuong();
		  return;
		}

		if(keyEventDown.Key==Key.F7) {
		  ChangeFocusToTextBoxDonGia();
		  return;
		}

		blnPressF5F6F7=false;
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

	private void ChangeFocusToTextBoxNameProduct() {
	  try {
		_mainUserControl.txtName.Focus();
		_mainUserControl.txtName.SelectAll();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void SelectAndScrollGridSuggestNameProductByIndex(int intIndex) {
	  try {
		SelectedRowSuggest=_lstGridSuggest[intIndex];
		_mainUserControl.dgvGoiYNameProduct.ScrollIntoView(SelectedRowSuggest);
		HienThiNameProductTheoRowGoiY();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void HienThiNameProductTheoRowGoiY() {
	  try {
		string strName = SelectedRowSuggest.StrName;
		_mainUserControl.lblNameProduct.Content=strName;
		_mainUserControl.lblNameProduct.Tag=SelectedRowSuggest.StrId;
		_mainUserControl.lblNameProduct.ToolTip=strName+" "+SelectedRowSuggest.StrId;

		if(SelectedRowSuggest.DoubleWidthHeightIconOk==0) {
		  _mainUserControl.lblNameOkIcon.Visibility=Visibility.Collapsed;
		} else {
		  _mainUserControl.lblNameOkIcon.Visibility=Visibility.Visible;
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void timerChanged_Tick(object sender,EventArgs e) {
	  TimerChanged.Stop();

	 // if(DT_DetailOrderByListId==null) {
		//QTMessageBox.ShowNotify(
		//  "Dữ liệu đơn hàng này tải không thành công, bạn vui lòng thao tác lại!"
		//  ,"(DT_DetailOrderByListId==null)");
		//return;
	 // }

	  LoadListProductGoiY();
	}

	#region Function for loading

	private void OpenLoadingPopup() {
	  MPProgress=new QT.Framework.ToolCommon.Models.ModelProgress();

	  BlnHideMain=true;
	  _bllPlugin.ShowPopupLoading(ref LoadingUC,ref _mainUserControl.gridPopup);
	}

	private void Main_ProgressChanged(object arg1,ProgressChangedEventArgs arg2) {
	  if(arg2.ProgressPercentage==-1) {
		QTMessageBox.ShowNotify(arg2.UserState?.ToString());
		return;
	  }

	  _bllPlugin.ChangeInfoLoading(ref LoadingUC,MPProgress);
	}

	#endregion

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dicInput) {

	}

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	#endregion

	#region === Command ===

	public ICommand PrintOrderCommand => new DelegateCommand(p => {
	  try {
		if(_lstGridMain.Count==0) {
		  QTMessageBox.ShowNotify(
			"Bạn chưa thêm vị thuốc nào vào đơn hàng này, vui lòng thao tác lại!"
			,"(_lstGridMain.Count==0)");
		  return;
		}

		List<Tuple<string,int,string>> lstTupleMaxCharInColumn = null;
		DataTable dtReport = null;
		_bllPlugin.GetDataTableReportFromGridMain(ref dtReport,ref lstTupleMaxCharInColumn,_lstGridMain);

		var dicInput = new Dictionary<string,object>();
		dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
					  new PrintOrder_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromOtherUserControl));

		//var mBaiThiInput = DicDataInPreviousUC["SubjectInfo"] as SubjectInfo;
		//BLLTools.AddDeepModelToDictionary(ref dicInput,"ModelRowOrder",SelectedRow);

		//dicInput["string"]=_mainUserControl.lblFolderPath.Content.ToString();
		dicInput["ObservableCollection<ModelRowDetailOrder>"]=_lstGridMain;
		dicInput["DataTable"]=dtReport;
		dicInput["List<Tuple<string,int,string>>"]=lstTupleMaxCharInColumn;

		_mainUserControl.modalPresenter.Visibility=Visibility.Hidden;
		_mainUserControl.modelChildren.Visibility=Visibility.Visible;
		_mainUserControl.modelChildren.Margin=new Thickness(0);

		_mainUserControl.gridChildren.Children.Clear();

		var userControl = new PrintOrder(dicInput);
		_mainUserControl.gridChildren.Children.Add(userControl);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand KeyUpChangeNameCommand => new DelegateCommand(p => {
	  try {
		if(KeyEventDownNameProduct==null) {
		  return;
		}

		if(KeyEventDownNameProduct.Key==Key.Left||KeyEventDownNameProduct.Key==Key.Right) {
		  return;
		}

		if(KeyEventDownNameProduct.Key==Key.Enter) {
		  if(SelectedRowSuggest==null) {
			return;
		  }

		  HienThiNameProductTheoRowGoiY();

		  CloseSuggestNameProductCommand.Execute(null);
		  //ChangeFocusToTextBoxSoLuong();
		  return;
		}

		if(KeyEventDownNameProduct.Key==Key.Down) {
		  if(SelectedRowSuggest==null||_lstGridSuggest.Count<2) {
			return;
		  }

		  if(SelectedRowSuggest.Stt<_lstGridSuggest.Count) {
			SelectAndScrollGridSuggestNameProductByIndex(SelectedRowSuggest.Stt);
		  }

		  return;
		}

		if(KeyEventDownNameProduct.Key==Key.Up) {
		  if(SelectedRowSuggest==null||_lstGridSuggest.Count<2) {
			return;
		  }

		  if(SelectedRowSuggest.Stt>1) {
			SelectAndScrollGridSuggestNameProductByIndex(SelectedRowSuggest.Stt-2);
		  }

		  return;
		}

		bool blnPressF5F6F7 = true;
		KiemTraPhimF5F6F7VaFocus(ref blnPressF5F6F7,KeyEventDownNameProduct);
		if(blnPressF5F6F7) {
		  return;
		}

		//string strText = _mainUserControl.txtName.Text.TrimStart();
		string strText = _mainUserControl.txtName.Text.Trim();
		if(strText=="") {
		  _mainUserControl.lblNameProduct.Content=strText;
		  _mainUserControl.lblNameOkIcon.Visibility=Visibility.Collapsed;
		  _lstGridSuggest.Clear();
		  return;
		}

		_bllPlugin.LoadGridSuggestByDataTableByFilter(ref _lstGridSuggest,DT_AllIdNameProduct,strText);

		if(_lstGridSuggest.Count>0) {
		  SelectedRowSuggest=_lstGridSuggest[0];
		  HienThiNameProductTheoRowGoiY();
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand KeyUpChangeSoLuongCommand => new DelegateCommand(p => {
	  try {
		if(KeyEventDownSoLuong==null) {
		  return;
		}

		if(KeyEventDownSoLuong.Key==Key.Left||KeyEventDownSoLuong.Key==Key.Right) {
		  return;
		}

		string strText = _mainUserControl.txtSoLuong.Text.Trim();
		if(KeyEventDownSoLuong.Key==Key.Enter) {

		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(strText);
		  } catch(Exception e) {
			string str = e.Message;
			QTMessageBox.ShowNotify("Số lượng bạn nhập không hợp lệ, bạn vui lòng kiểm tra lại!");
			_mainUserControl.txtSoLuong.SelectAll();
			return;
		  }

		  ChangeFocusToTextBoxDonGia();
		  return;
		}

		bool blnPressF5F6F7 = true;
		KiemTraPhimF5F6F7VaFocus(ref blnPressF5F6F7,KeyEventDownSoLuong);
		if(blnPressF5F6F7) {
		  return;
		}

		{
		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(strText);
		  } catch(Exception e) {
			string str = e.Message;
		  }

		  _bllPlugin.HienThiLabelSoLuongByDecimal(ref _mainUserControl.lblSoLuong,objTemp);
		}

		ThanhTienPreviewMouseMoveCommand.Execute(null);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand KeyUpChangeDonGiaCommand => new DelegateCommand(p => {
	  try {
		if(KeyEventDownDonGia==null) {
		  return;
		}

		if(KeyEventDownDonGia.Key==Key.Left||KeyEventDownDonGia.Key==Key.Right) {
		  return;
		}

		string strText = _mainUserControl.txtDonGia.Text.Trim();
		if(KeyEventDownDonGia.Key==Key.Enter||KeyEventDownDonGia.Key==Key.N) {

		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(strText);
		  } catch(Exception e) {
			string str = e.Message;
			QTMessageBox.ShowNotify("Đơn giá bạn nhập không hợp lệ, bạn vui lòng kiểm tra lại!");
			_mainUserControl.txtDonGia.SelectAll();
			return;
		  }

		  if(KeyEventDownDonGia.Key==Key.N) {
			_mainUserControl.txtDonGia.Text=(objTemp*1000).ToString();

			_bllPlugin.HienThiLabelDonGiaByDecimal(ref _mainUserControl.lblDonGia,objTemp*1000);

			ThanhTienPreviewMouseMoveCommand.Execute(null);

			_mainUserControl.txtDonGia.SelectAll();
			return;
		  }
		  return;
		}

		bool blnPressF5F6F7 = true;
		KiemTraPhimF5F6F7VaFocus(ref blnPressF5F6F7,KeyEventDownDonGia);
		if(blnPressF5F6F7) {
		  return;
		}

		{
		  decimal objTemp = 0;
		  try {
			objTemp=Convert.ToDecimal(strText);
		  } catch(Exception e) {
			string str = e.Message;
		  }

		  _bllPlugin.HienThiLabelDonGiaByDecimal(ref _mainUserControl.lblDonGia,objTemp);

		}

		ThanhTienPreviewMouseMoveCommand.Execute(null);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ThanhTienPreviewMouseMoveCommand => new DelegateCommand(p => {
	  try {
		decimal decSoLuong = 0;
		if(_mainUserControl.lblSoLuong.Tag!=null) {
		  try {
			decSoLuong=(decimal)_mainUserControl.lblSoLuong.Tag;
		  } catch(Exception e) {
			string str = e.Message;
		  }
		}

		decimal decDonGia = 0;
		if(_mainUserControl.lblDonGia.Tag!=null) {
		  try {
			decDonGia=(decimal)_mainUserControl.lblDonGia.Tag;
		  } catch(Exception e) {
			string str = e.Message;
		  }
		}

		_bllPlugin.HienThiLabelDonGiaByDecimal(ref _mainUserControl.lblThanhTien,decSoLuong*decDonGia);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand CloseSuggestNameProductCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.txtName.Text=_mainUserControl.lblNameProduct.Content.ToString();
		_mainUserControl.gridGoiYNameProduct.Visibility=Visibility.Collapsed;
		ChangeFocusToTextBoxSoLuong();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand HienThiDonGiaDaSuDungCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.chkHienThiListDonGia.IsChecked!=true) {
		  return;
		}

		object objTemp = _mainUserControl.lblNameProduct.Tag;
		if(objTemp==null) {
		  return;
		}

		string strId = objTemp.ToString();
		if(strId=="") {
		  return;
		}

		_bllPlugin.LoadGridDonGiaByIdProduct(ref _lstGridDonGia,strId);

		if(_lstGridDonGia.Count>0) {
		  SelectedRowDonGia=_lstGridDonGia[_lstGridDonGia.Count-1];
		  _mainUserControl.dgvDonGia.ScrollIntoView(SelectedRowDonGia);
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand GotFocusNameProductCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.gridGoiYNameProduct.Visibility=Visibility.Visible;

		KeyEventDownNameProduct=new KeyEventArgs(Keyboard.PrimaryDevice,
	new HwndSource(0,0,0,0,0,"",IntPtr.Zero),0,Key.LeftCtrl);

		KeyUpChangeNameCommand.Execute(null);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand SelectNameProductGoiYCommand => new DelegateCommand(p => {
	  try {
		if(SelectedRowSuggest==null) {
		  return;
		}

		KeyEventDownNameProduct=new KeyEventArgs(Keyboard.PrimaryDevice,
	new HwndSource(0,0,0,0,0,"",IntPtr.Zero),0,Key.Enter);

		KeyUpChangeNameCommand.Execute(null);

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
