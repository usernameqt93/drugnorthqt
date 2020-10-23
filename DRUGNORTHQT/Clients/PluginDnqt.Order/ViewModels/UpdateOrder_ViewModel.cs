using DNQTDataAccessLayer.DALNew;
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
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

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

	private DAL_Order DALOrder = new DAL_Order();

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

		//_mainUserControl.grbThongTinFolderAnh.Visibility=Visibility.Collapsed;
		//_mainUserControl.sliderPercent.Value=ConnectionSDK.MPluginData.TuplePercentSignPointSBDMaDeDapAn.Item2;

		//string strLoaiCauHinh = "(Cấu hình tương đối)";
		//if(ConnectionSDK.MPluginData.StrKieuChamThi
		//  ==ConnectionSDK.MPluginData.CONST_STR_CHAMNANGCAO_CH_CHINHXAC) {
		//  strLoaiCauHinh="(Cấu hình chính xác)";
		//}
		//_mainUserControl.grbMain.Header=_mainUserControl.grbMain.Tag.ToString()+strLoaiCauHinh;

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

		var lstStringId = new List<string>();
		lstStringId.Add(mOrder.StrId);

		Exception exDAL = null;
		DataTable DT_DetailOrderByListId = null;
		DALOrder.GetDTDetailOrderByListIdOrder(ref DT_DetailOrderByListId,ref exDAL,lstStringId);
		if(exDAL!=null) {
		  throw exDAL;
		}

		if(DT_DetailOrderByListId==null) {
		  QTMessageBox.ShowNotify(
			"Dữ liệu đơn hàng này tải không thành công, bạn vui lòng thao tác lại!"
			,"(DT_DetailOrderByListId==null)");
		  return;
		}

		_bllPlugin.LoadGridChiTietDHByDataTable(ref _lstGridMain,DT_DetailOrderByListId);

		//if(mBaiThi==null) {
		//  //_mainUserControl.lblSoCau.Content="0";
		//  //_mainUserControl.lblMucLamTron.Content="0";
		//  _mainUserControl.lblSoMaDe.Content="0";
		//} else {
		//  //_mainUserControl.lblSoCau.Content=""+mBaiThi.QuesCount;
		//  //_mainUserControl.lblMucLamTron.Content=""+mBaiThi.RoundRatio;
		//  _mainUserControl.lblSoMaDe.Content=""+mBaiThi.Exams.Count;
		//}

		//_mainUserControl.lblFolderPath.Content=DicDataInPreviousUC["string"] as string;

		//var lstInput = DicDataInPreviousUC["List<StudentInfo>"] as List<StudentInfo>;
		//_bllPlugin.LoadGridMainByListStudentInfo(ref _lstGridMain,lstInput);

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

	  //CapNhatPercentGridMainBySlider(new ModelLoaiCauHinh());
	  //ThayDoiPhanTramVaQuetTatCaCommand.Execute(null);
	}

	private void ExcuteFromChinhPhanTramSBDMaDeUC(ref Dictionary<string,object> dicInput) {
	 // string strKeyQuetLaiTheoCauHinhMoi = "List<ModelKhuVucCauHinh>";
	 // if(dicInput.ContainsKey(strKeyQuetLaiTheoCauHinhMoi)) {

		////var dicInput = new Dictionary<string,object>();

		////var mChamCoCauHinh = INV.Framework.ToolCommon.Helpers.Helpers.DeepCopy(SelectedRow.MChamCoCauHinh);
		////dicInput["ModelChamCoCauHinh"]=mChamCoCauHinh;

		//HienThiManHinhChinhCauHinhByDictionary(dicInput);

		//return;
	 // }

	 // // string strKeyQuetTatCaTheoPercent = "int.IntPercentChinh";
	 // // if(dicInput.ContainsKey(strKeyQuetTatCaTheoPercent)) {
	 // //int intPercent = (int)dicInput[strKeyQuetTatCaTheoPercent];
	 // //_mainUserControl.sliderPercent.Value=intPercent;
	 // //ThayDoiPhanTramVaQuetNhanhTatCaCommand.Execute(null);

	 // //return;
	 // // }

	 // var mStudentUpdated = dicInput["StudentInfo"] as StudentInfo;
	 // if(mStudentUpdated==null) {
		//return;
	 // }

	 // var tupleTemp = dicInput["Tuple<int,int,int>"] as Tuple<int,int,int>;
	 // SelectedRow.ExamImage.TupleThreePercent=tupleTemp;
	 // SelectedRow.ExamImage.Path=dicInput["string"] as string;

	 // string strFileName = "";
	 // _bllPlugin.GetFileNameFromTuple3Percent(ref strFileName,SelectedRow.ExamImage.Name,tupleTemp);
	 // SelectedRow.ExamImage.StrFileNameDisplay=strFileName;

	 // string strTextCauHinh = "Chưa cấu hình";
	 // string strToolTipCauHinh = "";
	 // // _bllPlugin.GetTextCauHinhDiemMocFromList(ref strTextCauHinh,ref strToolTipCauHinh
	 // //,mStudentUpdated.MChamCoCauHinh.MDapAnCH.LstCauHinh);
	 // strTextCauHinh="Đã cấu hình";
	 // //SelectedRow.MChamCoCauHinh=mStudentUpdated.MChamCoCauHinh;
	 // SelectedRow.MChamCoCauHinh.MSBDMaDeCH=mStudentUpdated.MChamCoCauHinh.MSBDMaDeCH;
	 // //SelectedRow.MChamCoCauHinh.StrCauHinhDiemMoc=strTextCauHinh;
	 // //SelectedRow.MChamCoCauHinh.StrTooltipCHDiemMoc=strToolTipCauHinh;

	 // SelectedRow.MChamCoCauHinh.MSBDMaDeCH.StrCauHinh=strTextCauHinh;
	 // SelectedRow.MChamCoCauHinh.MSBDMaDeCH.StrTooltipCH=strToolTipCauHinh;

	 // SelectedRow.MChamCoCauHinh.MJsonSBDMaDe.StrJsonCHListTuple=mStudentUpdated.MChamCoCauHinh.MJsonSBDMaDe.StrJsonCHListTuple;
	 // SelectedRow.MChamCoCauHinh.MJsonSBDMaDe.LstKhuVucCHUocLuong=mStudentUpdated.MChamCoCauHinh.MJsonSBDMaDe.LstKhuVucCHUocLuong;


	 // SelectedRow.StrJsonListTuple=mStudentUpdated.StrJsonListTuple;

	 // SelectedRow.ID=mStudentUpdated.ID;
	 // SelectedRow.ExamID=mStudentUpdated.ExamID;

	 // //SelectedRow.CheckMoreOneAvalue=mStudentUpdated.CheckMoreOneAvalue;
	 // //SelectedRow.NoCheckAvalue=mStudentUpdated.NoCheckAvalue;

	 // SelectedRow.StrErrorScan=mStudentUpdated.StrErrorScan;
	 // SelectedRow.DoubleGocNghieng=mStudentUpdated.DoubleGocNghieng;

	 // SelectedRow.StrGocNghiengDisplay=SelectedRow.StrGocNghieng;
	 // SelectedRow.BlnGocNghiengHopLeDisplay=SelectedRow.BlnGocNghiengHopLe;
	 // if(SelectedRow.BlnGocNghiengHopLeDisplay==false&&SelectedRow.StrGocNghiengDisplay=="") {
		//SelectedRow.StrGocNghiengDisplay="Lệch khung";
	 // }

	 // SelectedRow.MChamNangCao.BlnBoQuaPhieuThi=false;

	 // string strKeyQuetTatCaTheoPercent = "int.IntPercentChinh";
	 // if(dicInput.ContainsKey(strKeyQuetTatCaTheoPercent)) {
		//int intPercent = (int)dicInput[strKeyQuetTatCaTheoPercent];
		//_mainUserControl.sliderPercent.Value=intPercent;
		//ThayDoiPhanTramVaQuetNhanhTatCaCommand.Execute(null);

		//return;
	 // }

	  // if(!dicInput.ContainsKey(nameof(ThayDoiPhanTramVaQuetTatCaCommand))) {
	  //return;
	  // }

	  // if(SelectedRow.Stt>=_lstGridMain.Count) {
	  //return;
	  // }

	  // int intIndexTiepTheo = SelectedRow.Stt;
	  // SelectedRow=_lstGridMain[intIndexTiepTheo];
	  // //ChinhSuaPhanTramDiemAnhCommand.Execute(nameof(ThayDoiPhanTramVaQuetTatCaCommand));
	  // ChinhSuaPhanTramDiemAnhNhanhCommand.Execute(nameof(ThayDoiPhanTramVaQuetTatCaCommand));

	}

	#region Loading ThayDoiPhanTramVaQuetNhanhTatCaCommand (loading có quay tròn)

	//private void ThayDoiPhanTramVaQuetNhanhTatCaCommand_DoWork(object arg1,DoWorkEventArgs arg2) {
	//  var dicInput = arg2.Argument as Dictionary<string,object>;
	//  try {
	//	_bllPlugin.StartBgWorkerDoWork(ref arg2,ref MPProgress,10,
	//	  "QUÉT TẤT CẢ PHIẾU THI","Đang xử lý...");

	//	var lstOutput = new List<StudentInfo>();

	//	var lstCauHinh = dicInput["List<ModelKhuVucCauHinh>"] as List<ModelKhuVucCauHinh>;
	//	var lstTuple = dicInput["List<Tuple<string,Tuple<int,int,int>>>"] as List<Tuple<string,Tuple<int,int,int>>>;

	//	double doubleIncreasePercent = 0.1;
	//	BLLTools.GetIncreasePercent(ref doubleIncreasePercent,lstTuple.Count,MPProgress.DoublePercent,1);

	//	int intIndexIncrease = 0;
	//	foreach(var mrow in lstTuple) {

	//	  BLLTools.IncreaseProgressWorker(ref MPProgress,doubleIncreasePercent,
	//		"QUÉT ẢNH",$"Đang xử lý phiếu thi {++intIndexIncrease}/{lstTuple.Count} ...");

	//	  var mPhieuThi = new StudentInfo();

	//	  var tupleThreePercent = mrow.Item2;
	//	  mPhieuThi.ExamImage.TupleThreePercent=tupleThreePercent;
	//	  mPhieuThi.ExamImage.Path=mrow.Item1;

	//	  Exception exOutput = null;
	//	  _bllPlugin.GetThongTinSBDMaDePhieuThiCuaThiSinhFromFileImage(ref mPhieuThi,ref exOutput
	//		,lstCauHinh,ConnectionSDK.MPluginData.IntSoCauHoi);
	//	  if(exOutput!=null) {
	//		Log4Net.Error(exOutput.Message);
	//		Log4Net.Error(exOutput.StackTrace);
	//		//ShowException(exOutput);
	//	  }

	//	  lstOutput.Add(mPhieuThi);
	//	}

	//	dicInput["List<StudentInfo>"]=lstOutput;

	//  } catch(Exception ex) {
	//	//Log4Net.Error(ex.Message);
	//	//Log4Net.Error(ex.StackTrace);
	//	//ShowException(ex);
	//	dicInput["Exception"]=ex;
	//  }

	//  arg2.Result=dicInput;
	//}

	//private void ThayDoiPhanTramVaQuetNhanhTatCaCommand_RunWorkerCompleted(object arg1
	//  ,RunWorkerCompletedEventArgs arg2) {
	//  try {
	//	var dicInput = arg2.Result as Dictionary<string,object>;
	//	if(dicInput.ContainsKey(nameof(Exception))) {
	//	  throw (dicInput[nameof(Exception)] as Exception);
	//	}

	//	//var lstCauHinh = dicInput["List<ModelKhuVucCauHinh>"] as List<ModelKhuVucCauHinh>;
	//	var lstOutput = dicInput["List<StudentInfo>"] as List<StudentInfo>;
	//	for(int i = 0;i<_lstGridMain.Count;i++) {
	//	  var mrow = _lstGridMain[i];
	//	  //string strPathAnhGoc = SelectedRow.ExamImage.Path;
	//	  //dicInput["string"]=strPathAnhGoc;
	//	  var tupleThreePercent = mrow.ExamImage.TupleThreePercent;
	//	  //dicInput["Tuple<int,int,int>"]=tupleThreePercent;

	//	  // var mPhieuThi = new StudentInfo();
	//	  // mPhieuThi.ExamImage.TupleThreePercent=tupleThreePercent;
	//	  // mPhieuThi.ExamImage.Path=mrow.ExamImage.Path;

	//	  // Exception exOutput = null;
	//	  // _bllPlugin.GetThongTinPhieuThiCuaThiSinhFromFileImage(ref mPhieuThi,ref exOutput
	//	  //,lstCauHinh,IntSoCauHoi);
	//	  // if(exOutput!=null) {
	//	  //Log4Net.Error(exOutput.Message);
	//	  //Log4Net.Error(exOutput.StackTrace);
	//	  //ShowException(exOutput);
	//	  // }

	//	  var mPhieuThi = lstOutput[i];


	//	  // var tupleTemp = new Tuple<int,int,int>(
	//	  //tupleThreePercent.Item1,100,tupleThreePercent.Item3);
	//	  var tupleTemp = tupleThreePercent;

	//	  mrow.ExamImage.TupleThreePercent=tupleTemp;
	//	  //SelectedRow.ExamImage.Path=dicInput["string"] as string;

	//	  string strFileName = "";
	//	  _bllPlugin.GetFileNameFromTuple3Percent(ref strFileName,mrow.ExamImage.Name,tupleTemp);
	//	  mrow.ExamImage.StrFileNameDisplay=strFileName;

	//	  string strTextCauHinh = "Chưa cấu hình";
	//	  string strToolTipCauHinh = "";
	//	  // _bllPlugin.GetTextCauHinhDiemMocFromList(ref strTextCauHinh,ref strToolTipCauHinh
	//	  //,mStudentUpdated.MChamCoCauHinh.MDapAnCH.LstCauHinh);
	//	  strTextCauHinh="Đã cấu hình";
	//	  //SelectedRow.MChamCoCauHinh=mStudentUpdated.MChamCoCauHinh;
	//	  //mrow.MChamCoCauHinh.MSBDMaDeCH=mPhieuThi.MChamCoCauHinh.MSBDMaDeCH;
	//	  //SelectedRow.MChamCoCauHinh.StrCauHinhDiemMoc=strTextCauHinh;
	//	  //SelectedRow.MChamCoCauHinh.StrTooltipCHDiemMoc=strToolTipCauHinh;

	//	  mrow.MChamCoCauHinh.MSBDMaDeCH.StrCauHinh=strTextCauHinh;
	//	  mrow.MChamCoCauHinh.MSBDMaDeCH.StrTooltipCH=strToolTipCauHinh;

	//	  mrow.MChamCoCauHinh.MJsonSBDMaDe.StrJsonCHListTuple=mPhieuThi.MChamCoCauHinh.MJsonSBDMaDe.StrJsonCHListTuple;
	//	  mrow.MChamCoCauHinh.MJsonSBDMaDe.LstKhuVucCHUocLuong=mPhieuThi.MChamCoCauHinh.MJsonSBDMaDe.LstKhuVucCHUocLuong;

	//	  //mrow.Answers=mPhieuThi.Answers;
	//	  mrow.StrJsonListTuple=mPhieuThi.StrJsonListTuple;

	//	  mrow.ID=mPhieuThi.ID;
	//	  mrow.ExamID=mPhieuThi.ExamID;

	//	  //mrow.CheckMoreOneAvalue=mPhieuThi.CheckMoreOneAvalue;
	//	  //mrow.NoCheckAvalue=mPhieuThi.NoCheckAvalue;

	//	  mrow.StrErrorScan=mPhieuThi.StrErrorScan;
	//	  mrow.DoubleGocNghieng=mPhieuThi.DoubleGocNghieng;

	//	  mrow.StrGocNghiengDisplay=mrow.StrGocNghieng;
	//	  mrow.BlnGocNghiengHopLeDisplay=mrow.BlnGocNghiengHopLe;
	//	  if(mrow.BlnGocNghiengHopLeDisplay==false&&mrow.StrGocNghiengDisplay=="") {
	//		mrow.StrGocNghiengDisplay="Lệch khung";
	//	  }

	//	  //mrow.MChamNangCao.IntSoCauTo=mrow.InCorrectCount;
	//	  mrow.MChamNangCao.BlnBoQuaPhieuThi=false;

	//	  // int intSoCauKhongTo = 0;
	//	  // //intSoCauKhongTo = 0;
	//	  // _bllPlugin.GetSoLuongSplitByString(ref intSoCauKhongTo,mrow.NoCheckAvalue,',');
	//	  // mrow.MChamNangCao.IntSoCauKhongTo=intSoCauKhongTo;
	//	  // mrow.MChamNangCao.StrSoCauToHienThi=
	//	  //$"({mrow.InCorrectCount}/{mrow.InCorrectCount+intSoCauKhongTo})";

	//	}

	//  } catch(Exception ex) {
	//	Log4Net.Error(ex.Message);
	//	Log4Net.Error(ex.StackTrace);
	//	ShowException(ex);
	//  }

	//  _mainUserControl.gridPopup.Children.Clear();
	//  BlnHideMain=false;

	//  // if(!System.IO.File.Exists(strPathFileSave)) {
	//  //InvicoMessageBox.ShowNotify("Lưu dữ liệu không thành công!");
	//  //return;
	//  // }

	//  // InvicoMessageBox.ShowNotify("Lưu dữ liệu thành công!");

	//  // System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(strPathFileSave));

	//}

	#endregion

	#region Loading next chuyển sang bước tiếp theo (loading chưa quay tròn)

	//private void NextCommand_DoWork(object arg1,DoWorkEventArgs arg2) {
	//  _bllPlugin.StartBgWorkerDoWork(ref arg2,ref MPProgress,30,
	//	"SO SÁNH VỚI DỮ LIỆU EXCEL","Đang xử lý...");
	//  System.Threading.Thread.Sleep(300);
	//}

	//private void NextCommand_RunWorkerCompleted(object arg1,RunWorkerCompletedEventArgs arg2) {
	//  try {
	//	NextCommand_Method();
	//  } catch(Exception ex) {
	//	Log4Net.Error(ex.Message);
	//	Log4Net.Error(ex.StackTrace);
	//	ShowException(ex);
	//  }

	//  _mainUserControl.gridPopup.Children.Clear();
	//  BlnHideMain=false;

	//}

	#endregion

	//private void NextCommand_Method() {
	//  var lstInput = new List<StudentInfo>();
	//  foreach(var item in _lstGridMain) {
	//	lstInput.Add(item);
	//  }

	//  int intSoPhieuChuaQuet = 0;
	//  foreach(var item in lstInput) {
	//	if(item.ID==""&&item.ExamID=="") {
	//	  intSoPhieuChuaQuet++;
	//	}
	//  }
	//  if(intSoPhieuChuaQuet==lstInput.Count) {
	//	InvicoMessageBox.ShowNotify(
	//	  "Bạn vui lòng quét ít nhất 1 phiếu thi trước khi thực hiện thao tác này!");
	//	return;
	//  }

	//  var dicInput = new Dictionary<string,object>();
	//  dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
	//				new SoSanhCoCauHinhSBDMaDe_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromOtherUserControl));

	//  var mBaiThiInput = DicDataInPreviousUC["SubjectInfo"] as SubjectInfo;
	//  BLLTools.AddDeepModelToDictionary(ref dicInput,"SubjectInfo",mBaiThiInput);

	//  dicInput["string"]=_mainUserControl.lblFolderPath.Content.ToString();
	//  dicInput["List<StudentInfo>"]=lstInput;

	//  _mainUserControl.modalPresenter.Visibility=Visibility.Hidden;
	//  _mainUserControl.modelChildren.Visibility=Visibility.Visible;
	//  _mainUserControl.modelChildren.Margin=new Thickness(0);

	//  _mainUserControl.gridChildren.Children.Clear();

	//  var userControl = new SoSanhCoCauHinhSBDMaDe(dicInput);
	//  _mainUserControl.gridChildren.Children.Add(userControl);

	//}

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

	//private void CapNhatPercentGridMainBySlider(ModelLoaiCauHinh mLoaiCauHinh) {
	//  try {
	//	int intPercent = (int)_mainUserControl.sliderPercent.Value;
	//	foreach(var item in _lstGridMain) {
	//	  int intPhanTramDiemMoc = item.ExamImage.TupleThreePercent.Item1;
	//	  int intPhanTramDapAn = item.ExamImage.TupleThreePercent.Item3;
	//	  var tupleTemp = new Tuple<int,int,int>(intPhanTramDiemMoc,intPercent,intPhanTramDapAn);
	//	  item.ExamImage.TupleThreePercent=tupleTemp;

	//	  string strFileName = "";
	//	  _bllPlugin.GetFileNameFromTuple3Percent(ref strFileName,item.ExamImage.Name,tupleTemp);
	//	  item.ExamImage.StrFileNameDisplay=strFileName;

	//	  item.MChamCoCauHinh.MSBDMaDeCH=mLoaiCauHinh;
	//	}
	//  } catch(Exception ex) {
	//	Log4Net.Error(ex.Message);
	//	Log4Net.Error(ex.StackTrace);
	//	ShowException(ex);
	//  }
	//}

	private void HienThiManHinhChinhCauHinhByDictionary(Dictionary<string,object> dicInput) {
	  try {

		//ConnectionSDK.MPluginData.StrManHinhTruoc=nameof(KiemTraSBDMaDe_ViewModel);

		//dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
		//			  new ChinhSBDMaDeCoCauHinh_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromChinhPhanTramSBDMaDeUC));

		////var mSubjectSelected = DicDataInPreviousUC["SubjectInfo"] as SubjectInfo;
		////dicInput["int"]=mSubjectSelected.QuesCount;
		//dicInput["int"]=ConnectionSDK.MPluginData.IntSoCauHoi;

		//////BLLTools.AddDeepModelToDictionary(ref dicInput,"SubjectInfo",mSubjectSelected);

		////dicInput[nameof(LoadFromFileNoConfig_ViewModel)]="";
		//BLLTools.AddDeepModelToDictionary(ref dicInput,"StudentInfo",SelectedRow);

		////FormConfigModel MConfig = null;
		////BLLTools.AddDeepModelToDictionary(ref dicInput,"FormConfigModel",MConfig);

		//dicInput["string"]=SelectedRow.ExamImage.Path;
		//dicInput["Tuple<int,int,int>"]=SelectedRow.ExamImage.TupleThreePercent;

		////if(p!=null) {
		////  dicInput["intTongPhieuThi"]=_lstGridMain.Count;
		////  dicInput[nameof(ThayDoiPhanTramVaQuetTatCaCommand)]=SelectedRow.Stt;
		////}

		//_mainUserControl.modalPresenter.Visibility=Visibility.Hidden;
		//_mainUserControl.modelChildren.Visibility=Visibility.Visible;
		//_mainUserControl.modelChildren.Margin=new Thickness(0);

		//_mainUserControl.gridChildren.Children.Clear();

		//var userControl = new ChinhSBDMaDeCoCauHinh(dicInput);
		//_mainUserControl.gridChildren.Children.Add(userControl);

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
