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
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PluginDnqt.Product.ViewModels {
  class ViewModelMain:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal MainWindow _mainUserControl;

	private const int CONST_INT_PAGE_SIZE = 50;

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();
	private readonly BLLTool _bllTool = new BLLTool();

	private bool BlnIsLoadingForm = true;

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
		_mainUserControl.rdb50Result.IsChecked=true;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {

		//var CouncilTemp = new INV.Framework.Mar.Entitys.Council();
		//DataTable dtTemp = CouncilTemp.Gets_Table();

		//int intSumPage = 1;
		//_bllTool.GetSumPageBySumItem(ref intSumPage,dtTemp.Rows.Count,CONST_INT_PAGE_SIZE);

		//MOCPage._lstCbo.Clear();
		//for(int i = 0;i<intSumPage;i++) {
		//  _bllTool.AddItemCbo(i,""+(i+1),null,ref MOCPage._lstCbo);
		//}

		//if(MOCPage._lstCbo.Count>0) {
		//  MOCPage.MItemSelected=MOCPage._lstCbo[0];
		//  if(BlnIsLoadingForm) {
		//	PageSelectionChangedCommand.Execute(null);
		//  }
		//}

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

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	#endregion

	#region === Command ===

	public ICommand PageSelectionChangedCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			BlnAllSelected=false;

			if(MOCPage.MItemSelected==null) {
			  return;
			}

			//_bllPlugin.LoadGridMainByPage(ref _lstGridMain,
			//  MOCPage.MItemSelected.ID,CONST_INT_PAGE_SIZE);
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
	});

	public ICommand ChkXacNhanCheckedChangedCommand => new DelegateCommand(p => {
	  try {
		if(_mainUserControl.chkXacNhan.IsChecked!=true) {
		  return;
		}

		string strSoKetQua = _mainUserControl.txtSoKetQua1Trang.Text.Trim();
		if(!Int32.TryParse(strSoKetQua,out int intResult)) {
		  QTMessageBox.ShowNotify("Dữ liệu bạn vừa nhập không hợp lệ, vui lòng thao tác lại!");
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  return;
		}

		if(intResult<10) {
		  QTMessageBox.ShowNotify("Dữ liệu bạn vừa nhập không được nhỏ hơn 10 , vui lòng thao tác lại!");
		  _mainUserControl.chkXacNhan.IsChecked=false;
		  return;
		}

		QTMessageBox.ShowNotify("ok");
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand LoadedCommand => new DelegateCommand(p => {
	  try {
		RadioButtonFilterCheckedCommand.Execute(null);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	#endregion

  }
}
