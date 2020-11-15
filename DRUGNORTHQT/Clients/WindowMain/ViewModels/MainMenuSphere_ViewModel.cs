using log4net;
using QT.Framework.LoadingPopup.View;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.Framework.ToolCommon.Models;
using QT.HamburgerMenu;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using WindowMain.Model;
using WindowMain.View;

namespace WindowMain.ViewModels {
  public class MainMenuSphere_ViewModel:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	internal MainMenuSphere _mainUserControl;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> objInput);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicDataInPreviousUC = new Dictionary<string,object>();

	private List<HamburgerMenuItem> _lstMenu = new List<HamburgerMenuItem>();
	private int _software = 16;
	private double DoubleToSpinMenu = 0.0;
	private bool BlnStopSpinMenu = true;
	private bool BlnClickedMenu = false;

	private const string CONST_STR_USER_MANUAL = "Hướng dẫn sử dụng";

	private const string CONST_STR_COLOR_MENU_SELECTED = "Blue";

	private const int CONST_INT_SO_MILIGIAY_1_VONG = 20000;
	//private const int CONST_INT_SO_MILIGIAY_1_VONG = 800;
	private const int CONST_INT_SO_MILIGIAY_1_VONG_KHI_CHON = 800;
	private const int CONST_INT_SO_MILIGIAY_QUAY_1_LAN = 10;

	private System.Windows.Forms.Timer TimerTextChanged = new System.Windows.Forms.Timer() {
	  Interval=20
	};

	private readonly BLLPlugin _bllPlugin = new BLLPlugin(); 

	private bool BlnIsLoadingForm = true;

	#region === Những thuộc tính binding ===










	#region Variables for loading

	private ModelProgress MPProgress = new ModelProgress();
	public PopupLoading LoadingUC;

	private bool _blnHideMain = false;

	public bool BlnHideMain {
	  get { return _blnHideMain; }
	  set { _blnHideMain=value; OnPropertyChanged(nameof(BlnHideMain)); }
	}

	#endregion

	private ModelHamburgerMenu MMenuSelected;

	private ObservableCollection<ModelHamburgerMenu> _lstGridMain = new ObservableCollection<ModelHamburgerMenu>();

	public ObservableCollection<ModelHamburgerMenu> LstGridMain {
	  get { return _lstGridMain; }
	  set { _lstGridMain=value; OnPropertyChanged(nameof(LstGridMain)); }
	}

	private ObservableCollection<ModelHamburgerMenu> _lstGridSub = new ObservableCollection<ModelHamburgerMenu>();

	public ObservableCollection<ModelHamburgerMenu> LstGridSub {
	  get { return _lstGridSub; }
	  set { _lstGridSub=value; OnPropertyChanged(nameof(LstGridSub)); }
	}

	#endregion

	#endregion

	#region === Handle ===

	public MainMenuSphere_ViewModel(MainMenuSphere _viewMain,object objInput) {
	  _mainUserControl=_viewMain;

	  DicDataInPreviousUC = objInput as Dictionary<string,object>;
	  ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)DicDataInPreviousUC["DELEGATE_VOID_IN_OTHER_USERCONTROL"];

	  _lstMenu=DicDataInPreviousUC["List<HamburgerMenuItem>"] as List<HamburgerMenuItem>;
	  _software=(int)DicDataInPreviousUC["int"];
	  _mainUserControl.lblTitleBottom.Content=DicDataInPreviousUC["string"] as string;

	  LoadForm();

	  BlnIsLoadingForm=false;
	}

	#endregion

	#region === Các hàm chung ===

	private void ExcuteFromOtherUserControl(ref object obj) {

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
		_mainUserControl.stackPanelThongKeBenTrai.Visibility=System.Windows.Visibility.Collapsed;
		_mainUserControl.stackPanelThongKeBenPhai.Visibility=System.Windows.Visibility.Collapsed;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadData() {
	  try {
		var intdsfdsf = _mainUserControl.lstMain.Height;

		//Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
		//_mainUserControl.LogoIcon.Source=System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon
		//  (appIcon.Handle,System.Windows.Int32Rect.Empty
		//  ,BitmapSizeOptions.FromEmptyOptions());

		_bllPlugin.SetSourceToImageBySoftware(ref _mainUserControl.LogoIcon,_software);

		_bllPlugin.SetTitleBySoftware(ref _mainUserControl.lblTitleAbove,_software);

		LoadGridMainByListMenu(_lstMenu,0);

		//if(DicDataInPreviousUC.ContainsKey("stringHex6Char")) {
		//  string strHex6Char = DicDataInPreviousUC["stringHex6Char"] as string;
		//  _mainUserControl.ucInfoKhoiHoc.Str6CharHexColor=strHex6Char;
		//  _mainUserControl.ucInfoCauHoi.Str6CharHexColor=strHex6Char;
		//  _mainUserControl.ucInfoChuyenDe.Str6CharHexColor=strHex6Char;
		//  _mainUserControl.ucInfoDeGoc.Str6CharHexColor=strHex6Char;
		//  _mainUserControl.ucInfoMaTran.Str6CharHexColor=strHex6Char;
		//  _mainUserControl.ucInfoMonHoc.Str6CharHexColor=strHex6Char;
		//}

		_mainUserControl.ucInfoKhoiHoc.Str6CharHexColor="337BB6";
		_mainUserControl.ucInfoMonHoc.Str6CharHexColor="5BB85D";
		_mainUserControl.ucInfoChuyenDe.Str6CharHexColor="EFAD4F";

		_mainUserControl.ucInfoCauHoi.Str6CharHexColor="2BBBAD";
		_mainUserControl.ucInfoMaTran.Str6CharHexColor="33b5e5";
		_mainUserControl.ucInfoDeGoc.Str6CharHexColor="DA534F";

		if(_software==20) {
		  _mainUserControl.ucInfoKhoiHoc.Str6CharHexColor="2BBBAD";
		  _mainUserControl.ucInfoMonHoc.Str6CharHexColor="33b5e5";
		  _mainUserControl.ucInfoChuyenDe.Str6CharHexColor="DA534F";

		  _mainUserControl.ucInfoCauHoi.Str6CharHexColor="337BB6";
		  _mainUserControl.ucInfoMaTran.Str6CharHexColor="5BB85D";
		  _mainUserControl.ucInfoDeGoc.Str6CharHexColor="EFAD4F";
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void TaiThongTinTongSoLuongCacLoai(List<HamburgerMenuItem> lstMenu
	  ,Dictionary<string,object> dicSoLuong) {
	  try {

		var lstTupleControlAndKey = new List<BorderThongKe>();
		lstTupleControlAndKey.Add(_mainUserControl.ucInfoKhoiHoc);
		lstTupleControlAndKey.Add(_mainUserControl.ucInfoMonHoc);
		lstTupleControlAndKey.Add(_mainUserControl.ucInfoChuyenDe);
		lstTupleControlAndKey.Add(_mainUserControl.ucInfoCauHoi);
		lstTupleControlAndKey.Add(_mainUserControl.ucInfoMaTran);
		lstTupleControlAndKey.Add(_mainUserControl.ucInfoDeGoc);

		TaiSoLuongVaImageSourceTheoListControl(ref lstTupleControlAndKey,dicSoLuong,lstMenu);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void TaiSoLuongVaImageSourceTheoListControl(ref List<BorderThongKe> lstTupleControlAndKey
	  ,Dictionary<string,object> dicSoLuong,List<HamburgerMenuItem> lstMenu) {
	  try {
		foreach(var item in lstTupleControlAndKey) {
		  var ucBorder = item;
		  try {
			ucBorder.StrSoLuong=
				string.Format(CultureInfo.InvariantCulture,"{0:N0}",(int)dicSoLuong[ucBorder.Name]);
		  } catch(Exception e) {
			string str = e.Message;
		  }
		  _bllPlugin.SetImageSourceByTagBorderThongKe(ref ucBorder,lstMenu);
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadGridMainByListMenu(List<HamburgerMenuItem> lstMenu,
	  double doubleAngleAdd) {
	  try {
		LstGridMain.Clear();

		for(int i = 0;i < lstMenu.Count;i++) {

		  if(lstMenu[i].Text.Equals(CONST_STR_USER_MANUAL)) {
			#region Trường hợp menu hướng dẫn sử dụng
			var mitemUserManual = new ModelHamburgerMenu();
			_bllPlugin.GetItemUserManualFromListMenu(ref mitemUserManual,lstMenu[i],lstMenu);

			mitemUserManual.DoubleAngleToSpin=doubleAngleAdd;
			_bllPlugin.SetColorForMenuBySoftware(ref mitemUserManual,_software);

			LstGridMain.Add(mitemUserManual);  
			#endregion
			continue;
		  }

		  //Nếu là menu trợ giúp thì bỏ qua 
		  if(lstMenu[i].ParentID==0&&lstMenu[i].ItemID==7) {
			continue;
		  }

		  bool blnHaveOnlyOneInParent = true;
		  _bllPlugin.CheckHaveOneMenuInParent(ref blnHaveOnlyOneInParent,lstMenu[i],lstMenu);

		  //Nếu là menu con thì bỏ qua
		  if(lstMenu[i].ParentID!=0&&blnHaveOnlyOneInParent==false) {
			continue;
		  }

		  var mitem = new ModelHamburgerMenu();
		  mitem.Icon=lstMenu[i].Icon;
		  mitem.ItemID=lstMenu[i].ItemID;
		  mitem.ParentID=lstMenu[i].ParentID;
		  mitem.SelectionCommand=lstMenu[i].SelectionCommand;
		  mitem.SelectionCommandParameter=lstMenu[i].SelectionCommandParameter;
		  mitem.Text=lstMenu[i].Text;
		  mitem.StrTextOriginal=lstMenu[i].Text;

		  string strTextChange= lstMenu[i].Text;
		  _bllPlugin.ChangeTextForMenuSphere(ref strTextChange);
		  mitem.Text=strTextChange;

		  mitem.DoubleAngleToSpin=doubleAngleAdd;

		  _bllPlugin.SetColorForMenuBySoftware(ref mitem,_software);

		  LstGridMain.Add(mitem); 
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void StartTimer(int intInterval) {
	  TimerTextChanged=new System.Windows.Forms.Timer() { Interval=intInterval };
	  TimerTextChanged.Tick += new EventHandler(timerTextChanged_Tick);
	  TimerTextChanged.Start();
	}

	private void timerTextChanged_Tick(object sender,EventArgs e) {
	  if(BlnClickedMenu&&(MMenuSelected.DoubleAngleOnCircle>0.45*Math.PI)&&
		(MMenuSelected.DoubleAngleOnCircle<0.55*Math.PI)) {
		TimerTextChanged.Stop();

		//DoubleToSpinMenu-=MMenuSelected.DoubleAngleOnCircle-0.505*Math.PI;
		DoubleToSpinMenu-=MMenuSelected.DoubleAngleOnCircle-0.495*Math.PI;

		LoadGridSubByParentIdMenu(_lstMenu,MMenuSelected);

		LoadGridMainByListMenu(_lstMenu,DoubleToSpinMenu);

		if(BlnClickedMenu) {
		  ChangeColorSelectedMenu(CONST_STR_COLOR_MENU_SELECTED);
		}

		return;
	  }

	  double TwoPI = 2.0 * Math.PI;
	  if(DoubleToSpinMenu>TwoPI) {
		DoubleToSpinMenu-=TwoPI;
	  }

	  int intSoMiligiay1Vong = (BlnClickedMenu) ? 
		CONST_INT_SO_MILIGIAY_1_VONG_KHI_CHON : CONST_INT_SO_MILIGIAY_1_VONG;

	  bool blnQuayTheoKimDongHo = true;
	  if(MMenuSelected!=null) {
		blnQuayTheoKimDongHo = MMenuSelected.DoubleAngleOnCircle<0.47*Math.PI; 
	  }

	  if(blnQuayTheoKimDongHo) {
		DoubleToSpinMenu+=TwoPI/(intSoMiligiay1Vong/TimerTextChanged.Interval); 
	  } else {
		DoubleToSpinMenu-=TwoPI/(intSoMiligiay1Vong/TimerTextChanged.Interval);
	  }

	  LoadGridMainByListMenu(_lstMenu,DoubleToSpinMenu);

	  if(BlnClickedMenu) {
		ChangeColorSelectedMenu(CONST_STR_COLOR_MENU_SELECTED); 
	  }
	}

	private void ChangeColorSelectedMenu(string strColor) {
	  try {
		for(int i = 0;i < LstGridMain.Count;i++) {
		  if(LstGridMain[i].ItemID==MMenuSelected.ItemID) {
			LstGridMain[i].StrColor=strColor;
			MMenuSelected=LstGridMain[i];
			return;
		  }
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadGridSubByParentIdMenu(List<HamburgerMenuItem> lstMenu,ModelHamburgerMenu mMenuSelected) {
	  try {
		LstGridSub.Clear();

		var lstColor = typeof(Colors).GetProperties();
		int intCountColor = lstColor.Count();

		var lstIntRandom = new List<int>();
		for(int i = 0;i < lstMenu.Count;i++) {

		  if(lstMenu[i].ParentID!=mMenuSelected.ItemID) {
			continue;
		  }

		  var mitem = new ModelHamburgerMenu();
		  mitem.Icon=lstMenu[i].Icon;
		  mitem.ItemID=lstMenu[i].ItemID;
		  mitem.ParentID=lstMenu[i].ParentID;
		  mitem.SelectionCommand=lstMenu[i].SelectionCommand;
		  mitem.SelectionCommandParameter=lstMenu[i].SelectionCommandParameter;
		  mitem.Text=lstMenu[i].Text;
		  mitem.StrTextOriginal=lstMenu[i].Text;

		  mitem.IntHeightWidthButton=60;
		  mitem.IntHeightWidthImage=25;

		  int intRandomValue = 0;
		  _bllPlugin.GetValueRandomNotInList(ref intRandomValue,ref lstIntRandom,intCountColor);

		  mitem.StrColor=lstColor[intRandomValue].Name;
		  //mitem.StrColor="Blue";

		  string strTextChange = lstMenu[i].Text;
		  _bllPlugin.ChangeTextForMenuSphere(ref strTextChange);
		  mitem.Text=strTextChange;

		  //mitem.DoubleAngleToSpin+=doubleAngleAdd;
		  LstGridSub.Add(mitem);
		}

		_mainUserControl.lstMain22.Visibility=System.Windows.Visibility.Visible;
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	#region Loading tải thông tin số lượng (loading chưa quay tròn)

	private void TaiThongTinTongSoLuongCacLoai_DoWork(object arg1,DoWorkEventArgs arg2) {
	  _bllPlugin.StartBgWorkerDoWork(ref arg2,ref MPProgress,30,
		"CẬP NHẬT THÔNG TIN","Đang xử lý...");
	  //System.Threading.Thread.Sleep(300);
	  var dicSoLuong = new Dictionary<string,object>();

	 // List<int> lstSoLuongKhoiHoc = DALGrade.LstGetPages(1);
	 // dicSoLuong[nameof(_mainUserControl.ucInfoKhoiHoc)]=lstSoLuongKhoiHoc.Count;

	 // List<Subject> lstSubject = DALSubject.LOAD_SUBJECT_BASES();
	 // dicSoLuong[nameof(_mainUserControl.ucInfoMonHoc)]=lstSubject.Count;

	 // List<Thesis> lstThesisesDB = DALThesis.GET_ALL_HAVE_PARENT();
	 // dicSoLuong[nameof(_mainUserControl.ucInfoChuyenDe)]=lstThesisesDB.Count;

	 // int intSumQuestion = 0;
	 // try {
		//DataTable dtIdQuestion = null;
		//DALQuestion.GetDataTableListAllIdQuestion(ref dtIdQuestion);
		//if(dtIdQuestion!=null) {
		//  intSumQuestion=dtIdQuestion.Rows.Count;
		//}
	 // } catch(Exception e) {
		//string str = e.Message;
	 // }
	 // dicSoLuong[nameof(_mainUserControl.ucInfoCauHoi)]=intSumQuestion;

	 // BLLTools.IncreaseProgressWorker(ref MPProgress,10);

	 // {
		//int intSumHopLe = 0;
		//try {
		//  List<MaTranEntity> lstMatrixInDb = DALMatrixcs.LoadMatrixBySubjectId();
		//  intSumHopLe=lstMatrixInDb.Count(x => x.SubjectID!=0);
		//} catch(Exception e) {
		//  string str = e.Message;
		//}
		//dicSoLuong[nameof(_mainUserControl.ucInfoMaTran)]=intSumHopLe;
	 // }

	 // BLLTools.IncreaseProgressWorker(ref MPProgress,30);

	 // int intSumSoDeHopLe = 0;
	 // try {
		//List<DeGocEntity> iLstDeGoc = DALDeGoc.LoadDeGocBySubjectId();
		//var _encode = new System.Text.UTF8Encoding();
		//foreach(var degoc in iLstDeGoc) {
		//  //var degoc = item;
		//  //degoc.Decrypt();
		//  var sdecrip = _encode.GetString(degoc.ConfigExam,0,degoc.ConfigExam.Length);
		//  var varcrip = JsonConvert.DeserializeObject<IDictionary>(sdecrip);
		//  var type = varcrip["testType"].ToString();
		//  // chi quan ly de thi giay
		//  if(type=="1") {
		//	//lstDeGoc.Add(degoc);
		//	intSumSoDeHopLe++;
		//  }
		//}
	 // } catch(Exception e) {
		//string str = e.Message;
	 // }
	 // dicSoLuong[nameof(_mainUserControl.ucInfoDeGoc)]=intSumSoDeHopLe;

	  arg2.Result=dicSoLuong;
	}

	private void TaiThongTinTongSoLuongCacLoai_RunWorkerCompleted(object arg1,RunWorkerCompletedEventArgs arg2) {
	  try {
		TaiThongTinTongSoLuongCacLoai(_lstMenu,arg2.Result as Dictionary<string,object>);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }

	  _mainUserControl.gridPopup.Children.Clear();
	  BlnHideMain=false;

	}

	#endregion

	#region Function for open loading

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

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	#endregion

	#region === Command ===

	public ICommand ResumeSpinCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(BlnStopSpinMenu) {
			  return;
			}

			if(TimerTextChanged.Enabled) {
			  //TimerTextChanged.Stop();
			  return;
			}

			StartTimer(CONST_INT_SO_MILIGIAY_QUAY_1_LAN);
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand StopSpinCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(BlnClickedMenu) {
			  return;
			}

			if(BlnStopSpinMenu) {
			  return;
			}

			if(TimerTextChanged.Enabled) {
			  TimerTextChanged.Stop();
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

	public ICommand ChangeAngleCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(BlnClickedMenu) {
			  return;
			}

			if(BlnStopSpinMenu==true) {
			  BlnStopSpinMenu=false;
			  ResumeSpinCommand.Execute(null);
			  return;
			}

			BlnStopSpinMenu=true;
			TimerTextChanged.Stop();
			DoubleToSpinMenu = 0.0;
			LoadGridMainByListMenu(_lstMenu,0);
			//TimerTextChanged =new System.Windows.Forms.Timer() { Interval=CONST_INT_SO_MILIGIAY_QUAY_1_LAN };
			//TimerTextChanged.Tick += new EventHandler(timerTextChanged_Tick);
			//TimerTextChanged.Start();
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand AfterClickCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(p==null) {
			  return;
			}

			if(((ModelHamburgerMenu)p).Text.Equals(CONST_STR_USER_MANUAL)) {
			  return;
			}

			if(TimerTextChanged.Enabled) {
			  //ChangeAngleCommand.Execute(null);
			  TimerTextChanged.Stop();
			  //return;
			}

			BlnClickedMenu=true;
			BlnStopSpinMenu=false;

			MMenuSelected=(ModelHamburgerMenu)p;

			LstGridSub.Clear();
			_mainUserControl.lstMain22.Visibility=System.Windows.Visibility.Collapsed;

			StartTimer(CONST_INT_SO_MILIGIAY_QUAY_1_LAN);

			//LoadGridSubByParentIdMenu(_lstMenu,(ModelHamburgerMenu)p);
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand BorderThongKeClickCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(p==null) {
			  return;
			}

			var ucBorderThongKe = p as BorderThongKe;
			if(ucBorderThongKe.SelectionCommandParameter==null) {
			  return;
			}

			ucBorderThongKe.SelectionCommand.Execute(ucBorderThongKe.SelectionCommandParameter);
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

			if(!DicDataInPreviousUC.ContainsKey("intIsServer")||(_software!=16&&_software!=20)) {
			  return;
			}

			_mainUserControl.stackPanelThongKeBenTrai.Visibility=System.Windows.Visibility.Visible;
			_mainUserControl.stackPanelThongKeBenPhai.Visibility=System.Windows.Visibility.Visible;

			OpenLoadingPopup();

			BLLTools.SetupBgWorker(ref MPProgress,TaiThongTinTongSoLuongCacLoai_DoWork,
			  TaiThongTinTongSoLuongCacLoai_RunWorkerCompleted,Main_ProgressChanged,null);

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
