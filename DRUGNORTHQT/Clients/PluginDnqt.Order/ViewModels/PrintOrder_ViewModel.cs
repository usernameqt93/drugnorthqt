using Aspose.Words;
using DNQTDataAccessLayer.DALNew;
using DNQTWebBrowser.OrderReport;
using log4net;
using PluginDnqt.Order.Models;
using PluginDnqt.Order.Views;
using QT.Framework.LoadingPopup.View;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.Framework.ToolCommon.Models;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;

namespace PluginDnqt.Order.ViewModels {
  class PrintOrder_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal PrintOrder _mainUserControl;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private System.Windows.Forms.Timer TimerChanged = new System.Windows.Forms.Timer() {
	  Interval=CONST_INT_INTERVAL_TIMER
	};

	private const int CONST_INT_INTERVAL_TIMER = 50;

	private const string CONST_STR_TEMPLATE_FOLDER_NAME = "Template";
	private const string CONST_STR_ORDER_FOLDER_NAME = "Order";
	private const string CONST_STR_DUOI_FILE_TEMPLATE = ".dll";

	private DAL_Order DALOrder = new DAL_Order();
	private OrderDocument ODOrderDocument = new OrderDocument();

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();
	private readonly BLLTool _bllTool = new BLLTool();

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===

	private ModelOneCombobox _mocTypePaper = new ModelOneCombobox();

	public ModelOneCombobox MOCTypePaper {
	  get { return _mocTypePaper; }
	  set { _mocTypePaper=value; OnPropertyChanged(nameof(MOCTypePaper)); }
	}

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

	public PrintOrder_ViewModel(PrintOrder _viewMain,object objInput) {
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

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		//ModelRowOrder mOrder = DicDataInPreviousUC["ModelRowOrder"] as ModelRowOrder;

		//var lstStringId = new List<string>();
		//lstStringId.Add(mOrder.StrId);

		//Exception exDAL = null;
		//DataTable DT_DetailOrderByListId = null;
		//DALOrder.GetDTDetailOrderByListIdOrder(ref DT_DetailOrderByListId,ref exDAL,lstStringId);
		//if(exDAL!=null) {
		//  throw exDAL;
		//}

		//if(DT_DetailOrderByListId==null) {
		//  QTMessageBox.ShowNotify(
		//	"Dữ liệu đơn hàng này tải không thành công, bạn vui lòng thao tác lại!"
		//	,"(DT_DetailOrderByListId==null)");
		//  return;
		//}

		//_bllPlugin.LoadGridChiTietDHByDataTable(ref _lstGridMain,DT_DetailOrderByListId);

		string strPath = System.Windows.Forms.Application.StartupPath
		  +$"\\{CONST_STR_TEMPLATE_FOLDER_NAME}\\"+CONST_STR_ORDER_FOLDER_NAME;
		string[] arrayPathFile = new string[0];
		arrayPathFile=System.IO.Directory.GetFiles(strPath);

		var lstTuplePathTemplate = new List<Tuple<string,string,string>>();
		foreach(var item in arrayPathFile) {
		  string strDuoiFile = Path.GetExtension(item).ToLower();
		  if(strDuoiFile!=CONST_STR_DUOI_FILE_TEMPLATE) {
			continue;
		  }

		  string strFileNameKoDuoi= Path.GetFileNameWithoutExtension(item);
		  lstTuplePathTemplate.Add(new Tuple<string, string, string>(item,strFileNameKoDuoi,strDuoiFile));
		}

		LoadComboboxTypePaper(lstTuplePathTemplate);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadComboboxTypePaper(List<Tuple<string,string,string>> lstTuplePathTemplate) {
	  try {
		MOCTypePaper._lstCbo.Clear();

		int intIndexIncrease = 0;
		foreach(var item in lstTuplePathTemplate) {
		  _bllTool.AddItemCbo(intIndexIncrease,""+(intIndexIncrease+1).ToString("000")+". "+item.Item2
			,item,ref MOCTypePaper._lstCbo);
		  intIndexIncrease++;
		}

		if(MOCTypePaper._lstCbo.Count>0) {
		  MOCTypePaper.MItemSelected=MOCTypePaper._lstCbo[0];
		  if(BlnIsLoadingForm) {
			TypePaperSelectionChangedCommand.Execute(null);
		  }
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void timerChanged_Tick(object sender,EventArgs e) {
	  TimerChanged.Stop();

	  //_mainUserControl.progressStep.IntStep=3;
	  //_bllPlugin.SetToolTipForProgressAllStep(ref _mainUserControl.progressStep);

	  //ShowPreviewCommand.Execute(null);
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

	public ICommand TypePaperSelectionChangedCommand => new DelegateCommand(p => {
	  try {
		if(MOCTypePaper.MItemSelected==null) {
		  return;
		}

		//string strSoKetQua = _mainUserControl.txtSoKetQua1Trang.Text.Trim();
		//if(!Int32.TryParse(strSoKetQua,out int intSoDong1Trang)) {
		//  QTMessageBox.ShowNotify("Số dòng trên 1 trang không hợp lệ, bạn vui lòng thao tác lại!");
		//  _mainUserControl.chkXacNhan.IsChecked=false;
		//  return;
		//}

		//var lstStringId = new List<string>();
		//_bllPlugin.GetListStringIdInDataTable(ref lstStringId
		//  ,MOCPage.MItemSelected.ID,intSoDong1Trang,DT_AllIdOrder,"MaDonHang");
		//if(lstStringId.Count==0) {
		//  QTMessageBox.ShowNotify(
		//	"Hiện tại không tìm thấy mã dữ liệu trên trang này, bạn vui lòng thao tác lại!"
		//	,"(lstStringId.Count==0)");
		//  return;
		//}

		//Exception exDAL = null;
		//DataTable DT_OrderByListId = null;
		//DALOrder.GetDTOrderByListId(ref DT_OrderByListId,ref exDAL,lstStringId);
		//if(exDAL!=null) {
		//  throw exDAL;
		//}

		//if(DT_OrderByListId==null) {
		//  QTMessageBox.ShowNotify(
		//	"Dữ liệu trang này tải không thành công, bạn vui lòng thao tác lại!"
		//	,"(DT_OrderByListId==null)");
		//  return;
		//}

		//_bllPlugin.LoadGridMainByDataTable(ref _lstGridMain,DT_OrderByListId);
		//_bllPlugin.LoadGridMainByPage(ref _lstGridMain,
		//  MOCPage.MItemSelected.ID,intSoDong1Trang,DT_AllIdOrder);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ShowPreviewCommand => new DelegateCommand(p => {
	  try {
		var dicInput = new Dictionary<string,object>();

		Exception exOutput = null;
		Document docOutput = null;
		ODOrderDocument.GetDocumentDetailOrderByDictionary(ref docOutput,ref exOutput,dicInput);
		if(exOutput!=null) {
		  throw exOutput;
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ABCCommand => new DelegateCommand(p => {
	  try {
		var fdvm = new OpenFileDialog();
		//fdvm.Filter="Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx";
		fdvm.Filter="Word Files(.docx)|*.docx| Word Files(.doc)| *.doc";

		if(fdvm.ShowDialog()!=DialogResult.OK) {
		  return;
		}

		string strPathFile = fdvm.FileName;
		QT.Framework.ToolCommon.BLLTools.CopyAndGetPathFileTemp(ref strPathFile);

		//{
		//  Exception exOutput = null;
		//  Document docOutput = null;
		//  ODOrderDocument.GetDocumentFromPathFile(ref docOutput,ref exOutput,strPathFile);
		//  if(exOutput!=null) {
		//	throw exOutput;
		//  }
		//}

		{
		  Exception exOutput = null;
		  ODOrderDocument.MMMMMMMMMMMMM(_mainUserControl.webView,ref exOutput
			,strPathFile,13,"Times New Roman");
		  if(exOutput!=null) {
			Log4Net.Error(exOutput.Message);
			Log4Net.Error(exOutput.StackTrace);
			ShowException(exOutput);
			return;
		  }
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand GGGHHHHCommand => new DelegateCommand(p => {
	  try {
		if(MOCTypePaper.MItemSelected==null) {
		  return;
		}

		//var fdvm = new OpenFileDialog();
		////fdvm.Filter="Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx";
		//fdvm.Filter="Word Files(.docx)|*.docx| Word Files(.doc)| *.doc";

		//if(fdvm.ShowDialog()!=DialogResult.OK) {
		//  return;
		//}

		//string strPathFile = fdvm.FileName;
		Tuple<string,string,string> tupleTypePaperSelected = null;
		tupleTypePaperSelected=MOCTypePaper.MItemSelected.ObjItem as Tuple<string,string,string>;
		string strPathFile = tupleTypePaperSelected.Item1;
		QT.Framework.ToolCommon.BLLTools.CopyAndGetPathFileTempByNewExtension(ref strPathFile,".doc");

		//{
		//  Exception exOutput = null;
		//  Document docOutput = null;
		//  ODOrderDocument.GetDocumentFromPathFile(ref docOutput,ref exOutput,strPathFile);
		//  if(exOutput!=null) {
		//	throw exOutput;
		//  }
		//}

		{
		  Exception exOutput = null;
		  ODOrderDocument.MMMMMMMMMMMMM(_mainUserControl.webView,ref exOutput
			,strPathFile,13,"Times New Roman");
		  if(exOutput!=null) {
			Log4Net.Error(exOutput.Message);
			Log4Net.Error(exOutput.StackTrace);
			ShowException(exOutput);
			return;
		  }
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
