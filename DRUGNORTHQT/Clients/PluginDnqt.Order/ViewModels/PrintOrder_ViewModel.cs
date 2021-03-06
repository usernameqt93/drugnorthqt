﻿using Aspose.Words;
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
		ModelRowOrder mOrder = DicDataInPreviousUC["ModelRowOrder"] as ModelRowOrder;
		_mainUserControl.lblTenKH.Content=mOrder.StrNameKH;
		_mainUserControl.lblTongGiaDH.Content=mOrder.StrSumGiaTri;

		DateTime dtThoiGian = mOrder.DTimeViet;
		_mainUserControl.lblThoiGian.Content=
		  $"Ngày {dtThoiGian.ToString("dd")} tháng {dtThoiGian.ToString("MM")} năm {dtThoiGian.ToString("yyyy")}";

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
		  BLLTools.AddItemCbo(intIndexIncrease,""+(intIndexIncrease+1).ToString("000")+". "+item.Item2
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

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand ShowPreviewCommand => new DelegateCommand(p => {
	  try {
		if(MOCTypePaper.MItemSelected==null) {
		  return;
		}

		Tuple<string,string,string> tupleTypePaperSelected = null;
		tupleTypePaperSelected=MOCTypePaper.MItemSelected.ObjItem as Tuple<string,string,string>;
		if(tupleTypePaperSelected==null) {
		  QTMessageBox.ShowNotify("Đường dẫn template không hợp lệ","(tupleTypePaperSelected==null)");
		  return;
		}

		string strPathFile = tupleTypePaperSelected.Item1;
		QT.Framework.ToolCommon.BLLTools.CopyAndGetPathFileTempByNewExtension(ref strPathFile,".doc");

		var dicInput = new Dictionary<string,object>();
		dicInput["string.strPathFile"]=strPathFile;
		dicInput["double.doubleSize"]=13;
		dicInput["string.strFontName"]="Times New Roman";

		dicInput["string.lblTenKH"]=_mainUserControl.lblTenKH.Content;
		dicInput["string.lblSdtKH"]=_mainUserControl.lblSdtKH.Content;

		dicInput["double.sliderPercentSdt"]=_mainUserControl.sliderPercentSdt.Value;

		var lstDoublePercentColumn = new List<double>();
		lstDoublePercentColumn.Add(_mainUserControl.sliderPercentSTT.Value);
		lstDoublePercentColumn.Add(0);
		lstDoublePercentColumn.Add(_mainUserControl.sliderPercentSoLuong.Value);
		lstDoublePercentColumn.Add(_mainUserControl.sliderPercentDonVi.Value);
		lstDoublePercentColumn.Add(_mainUserControl.sliderPercentDonGia.Value);
		lstDoublePercentColumn.Add(_mainUserControl.sliderPercentThanhTien.Value);

		double doublePercentNameColumn = 100;
		foreach(var item in lstDoublePercentColumn) {
		  doublePercentNameColumn-=item;
		}
		lstDoublePercentColumn[1]=doublePercentNameColumn;
		dicInput["List<double>"]=lstDoublePercentColumn;

		dicInput["string.lblTongGiaDH"]=_mainUserControl.lblTongGiaDH.Content;
		dicInput["string.lblTienNoCu"]=_mainUserControl.lblTienNoCu.Content;
		dicInput["string.lblTongNoVaGiaDH"]=_mainUserControl.lblTongNoVaGiaDH.Content;

		dicInput["string.lblThoiGian"]=_mainUserControl.lblThoiGian.Content;
		dicInput["double.sliderPercentThoiGian"]=_mainUserControl.sliderPercentThoiGian.Value;

		DataTable dtTemp=DicDataInPreviousUC["DataTable"] as DataTable;
		dicInput["DataTable"]=dtTemp;
		//dicInput["DataTable"]=DicDataInPreviousUC["DataTable"] as DataTable;

		dicInput["List<Tuple<string,int,string>>"]=DicDataInPreviousUC["List<Tuple<string,int,string>>"]
		as List<Tuple<string,int,string>>;

		Exception exOutput = null;
		ODOrderDocument.ShowWebViewDetailOrderByDictionary(_mainUserControl.webView,ref exOutput,dicInput);
		if(exOutput!=null) {
		  Log4Net.Error(exOutput.Message);
		  Log4Net.Error(exOutput.StackTrace);
		  ShowException(exOutput);
		  return;
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

	public ICommand PrintCommand => new DelegateCommand(p => {
	  try {
		_mainUserControl.webView.Print();
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
