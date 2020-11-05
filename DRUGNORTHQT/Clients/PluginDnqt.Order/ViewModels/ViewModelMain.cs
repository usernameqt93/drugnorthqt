using DNQTDataAccessLayer.DALNew;
using log4net;
using PluginDnqt.Order.Models;
using PluginDnqt.Order.Views;
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

namespace PluginDnqt.Order.ViewModels {
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

	private DAL_Order DALOrder = new DAL_Order();

	private DataTable DT_AllIdNameProduct = null;
	private DataTable DT_AllIdOrder = null;
	private DataTable DT_AllDetailOrderByListIdOrder = null;

	#region === Những thuộc tính binding ===

	private ModelOneCombobox _mocPage = new ModelOneCombobox();

	public ModelOneCombobox MOCPage {
	  get { return _mocPage; }
	  set { _mocPage=value; OnPropertyChanged(nameof(MOCPage)); }
	}


	#region MainDataGrid

	private ModelRowOrder _selectedRow;

	public ModelRowOrder SelectedRow {
	  get { return this._selectedRow; }
	  set { _selectedRow=value; OnPropertyChanged(nameof(SelectedRow)); }
	}

	private ObservableCollection<ModelRowOrder> _lstGridMain = new ObservableCollection<ModelRowOrder>();
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

	private void ExcuteFromUpdateOrderUC(ref Dictionary<string,object> dic) {
	  string strKey = "DataTable";
	  if(dic.ContainsKey(strKey)) {
		DT_AllIdNameProduct=dic[strKey] as DataTable;
	  }

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
		_mainUserControl.rdbHienThiTatCa.IsChecked=true;
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

	private void ScrollToLastRowOnGrid() {
	  try {
		if(_lstGridMain.Count>0) {
		  SelectedRow=_lstGridMain[_lstGridMain.Count-1];
		  _mainUserControl.dgvMain.ScrollIntoView(SelectedRow);
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void timerChanged_Tick(object sender,EventArgs e) {
	  TimerChanged.Stop();

	  TimerChangedCommand.Execute(null);
	}

	private void LoadComboboxPage(int intSumPage) {
	  try {
		MOCPage._lstCbo.Clear();
		for(int i = 0;i<intSumPage;i++) {
		  BLLTools.AddItemCbo(i,""+(i+1)+"/"+intSumPage,null,ref MOCPage._lstCbo);
		}

		if(MOCPage._lstCbo.Count>0) {
		  //MOCPage.MItemSelected=MOCPage._lstCbo[0];
		  MOCPage.MItemSelected=MOCPage._lstCbo[MOCPage._lstCbo.Count-1];
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

	//public ICommand PageSelectionChangedCommand => new DelegateCommand(p => {
	//  try {
	//	if(MOCPage.MItemSelected==null) {
	//	  return;
	//	}

	//	var lstStringId = new List<string>();
	//	_bllPlugin.GetListStringIdInDataTable(ref lstStringId
	//	  ,MOCPage.MItemSelected.ID,ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN,DT_AllIdOrder,"MaDonHang");
	//	if(lstStringId.Count==0) {
	//	  QTMessageBox.ShowNotify(
	//		"Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
	//		,"(lstStringId.Count==0)");
	//	  return;
	//	}

	//	Exception exOutput = null;
	//	DataTable DT_OrderByListId = null;
	//	DALOrder.GetDTOrderByListId(ref DT_OrderByListId,ref exOutput,lstStringId);
	//	if(exOutput!=null) {
	//	  Log4Net.Error(exOutput.Message);
	//	  Log4Net.Error(exOutput.StackTrace);
	//	  ShowException(exOutput);
	//	  return;
	//	}

	//	if(DT_OrderByListId==null) {
	//	  QTMessageBox.ShowNotify(
	//		"Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
	//		,"(DT_OrderByListId==null)");
	//	  return;
	//	}

	//	_bllPlugin.LoadGridMainByDataTable(ref _lstGridMain,DT_OrderByListId);

	//	ScrollToLastRowOnGrid();
	//  } catch(Exception ex) {
	//	Log4Net.Error(ex.Message);
	//	Log4Net.Error(ex.StackTrace);
	//	ShowException(ex);
	//  }
	//});

	public ICommand PageSelectionChangedCommand => new DelegateCommand(p => {
	  try {
		if(MOCPage.MItemSelected==null) {
		  return;
		}

		var lstStringId = new List<string>();
		_bllPlugin.GetListStringIdInDataTable(ref lstStringId
		  ,MOCPage.MItemSelected.ID,ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN,DT_AllIdOrder,"MaDonHang");
		if(lstStringId.Count==0) {
		  QTMessageBox.ShowNotify(
			"Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
			,"(lstStringId.Count==0)");
		  return;
		}

		Exception exOutput = null;
		DT_AllDetailOrderByListIdOrder=null;
		DALOrder.GetDTDetailOrderByListIdOrder(ref DT_AllDetailOrderByListIdOrder,ref exOutput,lstStringId);
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

		_bllPlugin.LoadGridMainIdTenKHByPage(ref _lstGridMain
		  ,MOCPage.MItemSelected.ID,ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN,DT_AllIdOrder);

		_bllPlugin.LoadGridMainByDataTableDetail(ref _lstGridMain,DT_AllDetailOrderByListIdOrder);

		ScrollToLastRowOnGrid();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand TimerChangedCommand => new DelegateCommand(p => {
	  try {
		Exception exOutput = null;
		DT_AllIdOrder=null;
		DALOrder.GetDTAllIdOrder(ref DT_AllIdOrder,ref exOutput);
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
		}

		if(DT_AllIdOrder==null) {
		  QTMessageBox.ShowNotify("Dữ liệu tải không thành công, bạn vui lòng thao tác lại!");
		  return;
		}

		int intSumId = DT_AllIdOrder.Rows.Count;
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

	public ICommand EditCommand => new DelegateCommand(p => {
	  try {
		if(SelectedRow==null) {
		  return;
		}

		var lstStringId = new List<string>();
		lstStringId.Add(SelectedRow.StrId);

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

		_bllPlugin.LoadOneOrderByTableDetail(SelectedRow,DT_DetailOrderByListId);

		var dicInput = new Dictionary<string,object>();
		dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
					  new UpdateOrder_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromUpdateOrderUC));

		//var mBaiThiInput = DicDataInPreviousUC["SubjectInfo"] as SubjectInfo;
		BLLTools.AddDeepModelToDictionary(ref dicInput,"ModelRowOrder",SelectedRow);
		if(DT_AllIdNameProduct!=null) {
		  dicInput["DataTable"]=DT_AllIdNameProduct;
		}

		//dicInput["string"]=_mainUserControl.lblFolderPath.Content.ToString();
		//dicInput["List<StudentInfo>"]=lstInput;

		_mainUserControl.modalPresenter.Visibility=Visibility.Hidden;
		_mainUserControl.modelChildren.Visibility=Visibility.Visible;
		_mainUserControl.modelChildren.Margin=new Thickness(0);

		_mainUserControl.gridChildren.Children.Clear();

		var userControl = new UpdateOrder(dicInput);
		_mainUserControl.gridChildren.Children.Add(userControl);

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
