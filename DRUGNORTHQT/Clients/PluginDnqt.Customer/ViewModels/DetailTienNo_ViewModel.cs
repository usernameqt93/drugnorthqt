using DNQTDataAccessLayer.DALNew;
using log4net;
using PluginDnqt.Customer.Models;
using PluginDnqt.Customer.Views;
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

	private DataTable DT_AllIdNameProduct = null;

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
		//_mainUserControl.chkHienThiListDonGia.Visibility=Visibility.Collapsed;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		//ModelRowOrder mOrder = DicDataInPreviousUC["ModelRowOrder"] as ModelRowOrder;

		////var lstStringId = new List<string>();
		////lstStringId.Add(mOrder.StrId);

		////Exception exOutput = null;
		////DataTable DT_DetailOrderByListId = null;
		////DALOrder.GetDTDetailOrderByListIdOrder(ref DT_DetailOrderByListId,ref exOutput,lstStringId);
		////if(exOutput!=null) {
		////  Log4Net.Error(exOutput.Message);
		////  Log4Net.Error(exOutput.StackTrace);
		////  ShowException(exOutput);
		////  return;
		////}

		////if(DT_DetailOrderByListId==null) {
		////  QTMessageBox.ShowNotify(
		////	"Dữ liệu đơn hàng này tải không thành công, bạn vui lòng thao tác lại!"
		////	,"(DT_DetailOrderByListId==null)");
		////  return;
		////}

		////_bllPlugin.LoadGridChiTietDHByDataTable(ref _lstGridMain,DT_DetailOrderByListId,mOrder.StrId);

		//ModelRowOrder mOrder = DicDataInPreviousUC["ModelRowOrder"] as ModelRowOrder;
		//_lstGridMain.Clear();
		//foreach(var item in mOrder.LstGridDetailOrder) {
		//  _lstGridMain.Add(item);
		//}

		//_mainUserControl.grbSumGiaTriDH.Header=""+_mainUserControl.grbSumGiaTriDH.Tag.ToString()
		//  +$"({mOrder.StrSumKg} Kg)";
		//_mainUserControl.lblSumGiaTriDH.Content=mOrder.StrSumGiaTri;

		ModelRowCustomer mOrder = DicDataInPreviousUC["ModelRowCustomer"] as ModelRowCustomer;
		_lstGridMain.Clear();
		foreach(var item in mOrder.LstGridDetail) {
		  _lstGridMain.Add(item);
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void timerChanged_Tick(object sender,EventArgs e) {
	  TimerChanged.Stop();

	  //ChangeFocusToTextBoxNameProduct();

	  //LoadListProductGoiY();
	  int intSumRow = _lstGridMain.Count;
	  if(intSumRow>0) {
		SelectedRow=_lstGridMain[intSumRow-1];
		_mainUserControl.dgvMain.ScrollIntoView(SelectedRow);
	  }
	}

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dicInput) {

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
