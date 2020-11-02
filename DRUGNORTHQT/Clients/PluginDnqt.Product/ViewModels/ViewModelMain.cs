using DNQTDataAccessLayer.DALNew;
using log4net;
using PluginDnqt.Product.Models;
using PluginDnqt.Product.Views;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.Framework.ToolCommon.Models;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Data;
using System.Windows.Input;

namespace PluginDnqt.Product.ViewModels {
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

	private DAL_Product DALProduct = new DAL_Product();

	private DataTable DT_AllIdProduct = null;

	#region === Những thuộc tính binding ===

	private ModelOneCombobox _mocPage = new ModelOneCombobox();

	public ModelOneCombobox MOCPage {
	  get { return _mocPage; }
	  set { _mocPage=value; OnPropertyChanged(nameof(MOCPage)); }
	}


	#region MainDataGrid

	private ModelRowProduct _selectedRow;

	public ModelRowProduct SelectedRow {
	  get { return this._selectedRow; }
	  set { _selectedRow=value; OnPropertyChanged(nameof(SelectedRow)); }
	}

	private ObservableCollection<ModelRowProduct> _lstGridMain = new ObservableCollection<ModelRowProduct>();
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
		_mainUserControl.colSumOrder.Visibility=System.Windows.Visibility.Collapsed;
		_mainUserControl.colListOrder.Visibility=System.Windows.Visibility.Collapsed;
		_mainUserControl.chkShowSumOrder.IsChecked=false;

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

	  TimerChangedCommand.Execute(null);
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

		_bllPlugin.LoadGridMainByPage(ref _lstGridMain,
		  MOCPage.MItemSelected.ID,ConnectionSDK.INT_SO_ROW_1PAGE_PLUGIN,DT_AllIdProduct);

		ChkShowSumOrderChangedCommand.Execute(null);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ChkShowSumOrderChangedCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.colSumOrder.Visibility=System.Windows.Visibility.Collapsed;
		_mainUserControl.colListOrder.Visibility=System.Windows.Visibility.Collapsed;

		if(_mainUserControl.chkShowSumOrder.IsChecked==true) {
		  if(_lstGridMain.Count==0) {
			return;
		  }

		  _bllPlugin.ShowSumOrderOnGridMain(ref _lstGridMain);

		  _mainUserControl.colSumOrder.Visibility=System.Windows.Visibility.Visible;
		  _mainUserControl.colListOrder.Visibility=System.Windows.Visibility.Visible;
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand TimerChangedCommand => new DelegateCommand(p => {
	  try {
		Exception exOutput = null;
		DT_AllIdProduct=null;
		DALProduct.GetDTAllIdProduct(ref DT_AllIdProduct,ref exOutput);
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
		}

		if(DT_AllIdProduct==null) {
		  QTMessageBox.ShowNotify("Dữ liệu tải không thành công, bạn vui lòng thao tác lại!");
		  return;
		}

		int intSumId = DT_AllIdProduct.Rows.Count;
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
