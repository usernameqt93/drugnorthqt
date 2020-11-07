using DNQTConstTable.ListTableDatabase;
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
  class ViewModelMain:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal MainWindow _mainUserControl;

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private bool BlnIsLoadingForm = true;

	private System.Windows.Forms.Timer TimerChanged = new System.Windows.Forms.Timer() {
	  Interval=CONST_INT_INTERVAL_TIMER
	};

	private const int CONST_INT_INTERVAL_TIMER = 50;

	private DAL_Customer DALCustomer = new DAL_Customer();

	private DataTable DT_AllIdCustomer = null;

	#region === Những thuộc tính binding ===

	private ModelOneCombobox _mocPage = new ModelOneCombobox();

	public ModelOneCombobox MOCPage {
	  get { return _mocPage; }
	  set { _mocPage=value; OnPropertyChanged(nameof(MOCPage)); }
	}


	#region MainDataGrid

	private ModelRowCustomer _selectedRow;

	public ModelRowCustomer SelectedRow {
	  get { return this._selectedRow; }
	  set { _selectedRow=value; OnPropertyChanged(nameof(SelectedRow)); }
	}

	private ObservableCollection<ModelRowCustomer> _lstGridMain = new ObservableCollection<ModelRowCustomer>();
	private CollectionViewSource MainCollection = new CollectionViewSource();

	public ICollectionView LstGridMain {
	  get { return this.MainCollection.View; }
	}

	#endregion

	private bool _blnAllSelected = false;

	public bool BlnAllSelected {
	  get { return _blnAllSelected; }
	  set { _blnAllSelected=value; OnPropertyChanged(nameof(BlnAllSelected)); }
	}






	#endregion

	#endregion

	#region === Handle ===

	public ViewModelMain(MainWindow _viewMain,object objInput) {
	  _mainUserControl=_viewMain;
	  MainCollection.Source=_lstGridMain;

	  LoadForm();

	  BlnIsLoadingForm=false;
	}

	#endregion

	#region === Các hàm chung ===

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dic) {

	}

	private void ExcuteFromDetailTienNoUC(ref Dictionary<string,object> dic) {
	  EditCommand.Execute(null);
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
		_mainUserControl.lblSoRow1Page.Content=$"({ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN} dữ liệu/ 1 trang)";
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

	private void timerChanged_Tick(object sender,EventArgs e) {
	  TimerChanged.Stop();

	  RadioButtonPhanLoaiCheckedCommand.Execute(null);
	}

	private void LoadComboboxPage(int intSumPage) {
	  try {
		MOCPage._lstCbo.Clear();
		for(int i = 0;i<intSumPage;i++) {
		  BLLTools.AddItemCbo(i,""+(i+1)+"/"+intSumPage,null,ref MOCPage._lstCbo);
		}

		if(MOCPage._lstCbo.Count>0) {
		  MOCPage.MItemSelected=MOCPage._lstCbo[0];
		  if(BlnIsLoadingForm) {
			PageSelectionChangedCommand.Execute(null);
		  }
		}
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

	public ICommand PageSelectionChangedCommand => new DelegateCommand(p => {
	  try {
		if(MOCPage.MItemSelected==null) {
		  return;
		}

		var lstStringId = new List<string>();
		_bllPlugin.GetListStringIdInDataTable(ref lstStringId
		  ,MOCPage.MItemSelected.ID,ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN,DT_AllIdCustomer
		  ,Table_BangKhachHang.Col_IdBangKhachHang.NAME);
		if(lstStringId.Count==0) {
		  QTMessageBox.ShowNotify(
			"Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
			,"(lstStringId.Count==0)");
		  return;
		}

		Exception exOutput = null;
		DataTable DT_AllDetailOrderByListIdOrder=null;
		DALCustomer.GetDTDetailTienNoByListIdKH(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
		}

		if(DT_AllDetailOrderByListIdOrder==null) {
		  QTMessageBox.ShowNotify(
			"Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
			,"(DT_AllDetailOrderByListIdOrder==null)");
		  return;
		}

		_bllPlugin.LoadGridMainByPage(ref _lstGridMain,
		  MOCPage.MItemSelected.ID,ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN,DT_AllIdCustomer);

		_bllPlugin.LoadGridMainByDataTableDetail(ref _lstGridMain,DT_AllDetailOrderByListIdOrder);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand EditCommand => new DelegateCommand(p => {
	  try {
		if(SelectedRow==null) {
		  return;
		}
		if(SelectedRow.MBC000.Str=="1"||SelectedRow.MBC001.Str=="--Không ghi vào--") {
		  QTMessageBox.ShowNotify("Dữ liệu này mặc định để hệ thống không hiển thị tên khách hàng khi in hóa đơn, bạn vui lòng chọn tên khách hàng khác!");
		  return;
		}

		var lstStringId = new List<string>();
		lstStringId.Add(SelectedRow.MBC000.Str);

		Exception exOutput = null;
		DataTable DT_DetailOrderByListId = null;
		DALCustomer.GetDTDetailTienNoByListIdKH(ref DT_DetailOrderByListId,ref exOutput,lstStringId);
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
		}

		if(DT_DetailOrderByListId==null) {
		  QTMessageBox.ShowNotify(
			"Dữ liệu tiền nợ khách hàng này tải không thành công, bạn vui lòng thao tác lại!"
			,"(DT_DetailOrderByListId==null)");
		  return;
		}

		_bllPlugin.LoadOneCustomerByTableDetail(SelectedRow,DT_DetailOrderByListId);

		_bllPlugin.LoadFormatGridDetail(SelectedRow);

		var dicInput = new Dictionary<string,object>();
		dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
					  new DetailTienNo_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromDetailTienNoUC));

		BLLTools.AddDeepModelToDictionary(ref dicInput,"ModelRowCustomer",SelectedRow);

		_mainUserControl.modalPresenter.Visibility=Visibility.Hidden;
		_mainUserControl.modelChildren.Visibility=Visibility.Visible;
		_mainUserControl.modelChildren.Margin=new Thickness(0);

		_mainUserControl.gridChildren.Children.Clear();

		var userControl = new DetailTienNo(dicInput);
		_mainUserControl.gridChildren.Children.Add(userControl);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand RadioButtonPhanLoaiCheckedCommand => new DelegateCommand(p => {
	  try {
		Exception exOutput = null;
		DT_AllIdCustomer=null;
		if(_mainUserControl.rdbTuADenZ.IsChecked==true) {
		  DALCustomer.GetDTAllIdCustomer(ref DT_AllIdCustomer,ref exOutput); 
		}
		if(_mainUserControl.rdbGiamDan.IsChecked==true) {
		  DALCustomer.GetDTAllIdCustomerSortByTienNo(ref DT_AllIdCustomer,ref exOutput);
		}
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
		}

		if(DT_AllIdCustomer==null) {
		  QTMessageBox.ShowNotify("Dữ liệu tải không thành công, bạn vui lòng thao tác lại!");
		  return;
		}

		int intSumId = DT_AllIdCustomer.Rows.Count;
		_mainUserControl.lblSumProduct.Content=""+intSumId;

		int intSoDong1Trang = ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN;
		int intSumPage = (intSumId%intSoDong1Trang==0)
		? (intSumId/intSoDong1Trang) : (intSumId/intSoDong1Trang+1);
		_mainUserControl.lblSumPage.Content=""+intSumPage;

		LoadComboboxPage(intSumPage);

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

	#endregion

  }
}
