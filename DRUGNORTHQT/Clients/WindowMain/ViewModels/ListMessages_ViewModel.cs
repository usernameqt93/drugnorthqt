using log4net;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WindowMain.Model;
using WindowMain.View;

namespace WindowMain.ViewModels {
  class ListMessages_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal ListMessages _mainUserControl;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private const int CONST_INT_PAGE_SIZE = 50;

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===

	private QT.Framework.ToolCommon.Models.ModelOneCombobox _mocPage = new QT.Framework.ToolCommon.Models.ModelOneCombobox();

	public QT.Framework.ToolCommon.Models.ModelOneCombobox MOCPage {
	  get { return _mocPage; }
	  set { _mocPage = value; OnPropertyChanged(nameof(MOCPage)); }
	}


	private bool _blnHideMain = false;

	public bool BlnHideMain {
	  get { return _blnHideMain; }
	  set { _blnHideMain = value; OnPropertyChanged(nameof(BlnHideMain)); }
	}



	#region MainDataGrid 

	private ModelMessage _selectedRow;

	public ModelMessage SelectedRow {
	  get { return this._selectedRow; }
	  set { _selectedRow=value; OnPropertyChanged(nameof(SelectedRow)); }
	}

	private ObservableCollection<ModelMessage> _lstGridMain = new ObservableCollection<ModelMessage>();
	private CollectionViewSource MainCollection = new CollectionViewSource();

	public ICollectionView LstGridMain {
	  get { return this.MainCollection.View; }
	}

	#endregion

	#endregion

	#endregion

	#region === Handle ===

	public ListMessages_ViewModel(ListMessages _viewMain,object objInput) {
	  _mainUserControl=_viewMain;
	  MainCollection.Source=_lstGridMain;

	  DicDataInPreviousUC = objInput as Dictionary<string,object>;
	  ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)DicDataInPreviousUC["DELEGATE_VOID_IN_OTHER_USERCONTROL"];

	  LoadForm();

	  BlnIsLoadingForm=false;
	}

	#endregion

	#region === Các hàm chung ===

	private void LoadForm() {
	  try {

		LoadData();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		_mainUserControl.chkShowMessageCoText.Content=_mainUserControl.chkShowMessageCoText.Tag.ToString()
		  +$"({(int)DicDataInPreviousUC["intCoText"]}/{(int)DicDataInPreviousUC["intAll"]} tin nhắn)";

		FilterCommand.Execute(null);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadComboboxPage(int intSumPage) {
	  try {
		MOCPage._lstCbo.Clear();
		for(int i = 0;i < intSumPage;i++) {
		  BLLTools.AddItemCbo(i,""+(i+1),null,ref MOCPage._lstCbo);
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

	private void ShowDetailFirstRow() {
	  try {
		if(_lstGridMain.Count>0) {
		  SelectedRow=_lstGridMain[0];
		  RowClickCommand.Execute(null);
		} else {
		  //_mainUserControl.imageMain.Source = null;
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> dicInput) {

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

			if(_mainUserControl.dataGridMain.Tag==null) {
			  return;
			}

			//var lstInput=_mainUserControl.dataGridMain.Tag as List<Tuple<Messages,string,string>>;

			//_bllPlugin.LoadGridMainByPage(ref _lstGridMain,
			//  MOCPage.MItemSelected.ID,CONST_INT_PAGE_SIZE,lstInput);

			//ShowDetailFirstRow();
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand RowClickCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(SelectedRow==null) {
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

	public ICommand BackToMainMenuCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(ExcuteInOtherUserControl!=null) {
			  var dic = new Dictionary<string,object>();
			  dic[nameof(BackToMainMenuCommand)]="";
			  ExcuteInOtherUserControl(ref dic);
			}
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand FilterCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			var lstIntType = new List<int>();
			if(_mainUserControl.chkKhac.IsChecked==true) {
			  lstIntType.Add(1);
			}
			if(_mainUserControl.chkVeKyThi.IsChecked==true) {
			  lstIntType.Add(2);
			}
			if(_mainUserControl.chkCauHoiDaDat.IsChecked==true) {
			  lstIntType.Add(3);
			}
			if(_mainUserControl.chkCauHoiChuaDat.IsChecked==true) {
			  lstIntType.Add(4);
			}

			//var lstTemp = new List<Tuple<Messages,string,string>>();
			//if(_mainUserControl.chkShowMessageCoText.IsChecked==true) {
			//  lstTemp=DicDataInPreviousUC["List<Tuple<Messages,string,string>>lstAllTupleMessagesCoText"]
			//  as List<Tuple<Messages,string,string>>;
			//} else {
			//  lstTemp=DicDataInPreviousUC["List<Tuple<Messages,string,string>>lstAllTupleMessages"]
			//  as List<Tuple<Messages,string,string>>;
			//}

			//var lstInput = new List<Tuple<Messages,string,string>>();
			//foreach(var item in lstTemp) {
			//  if(lstIntType.Contains(item.Item1.MessageType)) {
			//	lstInput.Add(item);
			//  }
			//}
			//_mainUserControl.dataGridMain.Tag=lstInput;
			//int intSumItem = lstInput.Count;
			//_mainUserControl.grbMain.Header=_mainUserControl.grbMain.Tag.ToString()
			//  +$"({intSumItem} tin nhắn)";

			//int intSumPage = 1;
			//BLLTools.GetSumPageBySumItem(ref intSumPage,intSumItem,CONST_INT_PAGE_SIZE);

			//LoadComboboxPage(intSumPage);

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
			ModalContentPresenter modelPresenter = (ModalContentPresenter)gridPresenter.FindName("modalPresenter");

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
