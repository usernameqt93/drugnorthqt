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
	private readonly BLLTool _bllTool = new BLLTool();

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

	private ModelRowMain _selectedRow;

	public ModelRowMain SelectedRow {
	  get { return this._selectedRow; }
	  set { _selectedRow=value; OnPropertyChanged(nameof(SelectedRow)); }
	}

	private ObservableCollection<ModelRowMain> _lstGridMain = new ObservableCollection<ModelRowMain>();
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
		_mainUserControl.rdb100Result.IsChecked=true;
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

	  RadioButtonFilterCheckedCommand.Execute(null);
	}

	private void ThayDoiNutXacNhanTheoRdb() {
	  try {
		if(_mainUserControl.rdb50Result.IsChecked==true) {
		  ThietLapSoVaNutXacNhan(50,true);
		  return;
		}

		if(_mainUserControl.rdb100Result.IsChecked==true) {
		  ThietLapSoVaNutXacNhan(100,true);
		  return;
		}

		if(_mainUserControl.rdbTuyChonResult.IsChecked==true) {
		  ThietLapSoVaNutXacNhan(1000,false);
		  return;
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ThietLapSoVaNutXacNhan(int intSoKetQua,bool blnXacNhan) {
	  try {
		_mainUserControl.txtSoKetQua1Trang.Text=""+intSoKetQua;
		_mainUserControl.chkXacNhan.IsChecked=blnXacNhan;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadComboboxPage(int intSumPage) {
	  try {
		MOCPage._lstCbo.Clear();
		for(int i = 0;i<intSumPage;i++) {
		  _bllTool.AddItemCbo(i,""+(i+1)+"/"+intSumPage,null,ref MOCPage._lstCbo);
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

	public ICommand PageSelectionChangedCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(MOCPage.MItemSelected==null) {
			  return;
			}

			string strSoKetQua = _mainUserControl.txtSoKetQua1Trang.Text.Trim();
			if(!Int32.TryParse(strSoKetQua,out int intSoDong1Trang)) {
			  QTMessageBox.ShowNotify("Số dòng trên 1 trang không hợp lệ, bạn vui lòng thao tác lại!");
			  _mainUserControl.chkXacNhan.IsChecked=false;
			  return;
			}

			_bllPlugin.LoadGridMainByPage(ref _lstGridMain,
			  MOCPage.MItemSelected.ID,intSoDong1Trang,DT_AllIdProduct);
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand RadioButtonFilterCheckedCommand => new DelegateCommand(p => {
	  try {
		ThayDoiNutXacNhanTheoRdb();

		ChkXacNhanCheckedChangedCommand.Execute(null);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ChkXacNhanCheckedChangedCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.chkXacNhan.IsChecked!=true) {
		  return;
		}

		string strSoKetQua = _mainUserControl.txtSoKetQua1Trang.Text.Trim();
		if(!Int32.TryParse(strSoKetQua,out int intSoDong1Trang)) {
		  QTMessageBox.ShowNotify("Dữ liệu bạn vừa nhập không hợp lệ, vui lòng thao tác lại!");
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  return;
		}

		if(intSoDong1Trang<10) {
		  QTMessageBox.ShowNotify("Dữ liệu bạn vừa nhập không được nhỏ hơn 10 , vui lòng thao tác lại!");
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  return;
		}

		Exception exDAL = null;
		DT_AllIdProduct=null;
		DALProduct.GetDTAllIdProduct(ref DT_AllIdProduct,ref exDAL);
		if(exDAL!=null) {
		  throw exDAL;
		}

		if(DT_AllIdProduct==null) {
		  QTMessageBox.ShowNotify("Dữ liệu tải không thành công, bạn vui lòng thao tác lại!");
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  return;
		}

		int intSumId = DT_AllIdProduct.Rows.Count;
		_mainUserControl.lblSumProduct.Content=""+intSumId;

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
