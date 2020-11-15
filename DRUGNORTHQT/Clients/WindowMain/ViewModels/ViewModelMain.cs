using DNQTDataAccessLayer.DALNew;
using HostViewer.Types;
using log4net;
using QT.Framework.LoadingPopup.View;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Helpers;
using QT.Framework.ToolCommon.Models;
using QT.HamburgerMenu;
using QT.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WindowMain.Models;
using WindowMain.View;

namespace WindowMain.ViewModels {
  public class ViewModelMain:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	internal MainWindow _mainWindow;
	private int _software = 16;
	private string _version = "1.0.0.0";

	private Dictionary<string,object> DicLoginInfo = new Dictionary<string,object>();

	private string _dateTime = "";
	private DateTime DtPhienBan = new DateTime(2020,02,02);

	public HamburgerMenuItem controlSupervision;

	//private Version _versionAppExe = new Version();

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	//private readonly ListKeyConfig _mListKeyConfig = new ListKeyConfig();

	//public static User _user = new User();
	public static string _key = "";
	public static int _isServer = 0;
	private int _countDisconnect = 0;
	//private string _userText = "";
	//private string _passText = "";
	private ModelUsers _userLogin;
	private ModelUsers _usersUpdateProFile;
	private ModelChangePass _usersUpdatePass;
	private string _modalSelection;
	private string _selectedItem;
	private bool _isModal = false, _isProFile = false, _isChangePass = false, _isLogin = true, _isMain = false;
	private List<int> _lstMenuID = new List<int>();
	private static List<Dictionary<int,List<string>>> _lstSubMenuNames = new List<Dictionary<int,List<string>>>();
	private static List<Dictionary<int,List<AvailableArrayProcessor>>> _lstModules = new List<Dictionary<int,List<AvailableArrayProcessor>>>();
	private List<MenuModel> _lstMenuItems = new List<MenuModel>();

	private System.Windows.Forms.Timer TimerTextChanged = new System.Windows.Forms.Timer() {
	  Interval=3000
	};

	private Tuple<string,string> TupleIdNameAccount = new Tuple<string,string>("","");

	private Dictionary<string,object> DicData;
	private Tuple<bool,string,string,int> TupleSetting;
	private string StrPathLoadDll = "";
	private int intPressF1Count = 0;
	//private bool BlnDaLuuThongTinTrongRegistry = true;

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private string StrOldPassword;
	private DAL_Account DALAccount = new DAL_Account();

	#region === Những thuộc tính binding ===

	//private Client _licenseInfo = new Client();

	//public Client LicenseInfo {
	//  get { return _licenseInfo; }
	//  set { _licenseInfo = value; OnPropertyChanged("LicenseInfo"); }
	//}

	public bool ShowLogin {
	  get { return _isLogin; }
	  set {
		_isLogin = value;
		OnPropertyChanged("ShowLogin");
	  }
	}
	public bool ShowMain {
	  get { return _isMain; }
	  set {
		_isMain = value;
		OnPropertyChanged("ShowMain");
	  }
	}

	//public string UserText {
	//  get {
	//	return _userText;
	//  }
	//  set {
	//	_userText = value;
	//	OnPropertyChanged("UserText");
	//  }
	//}
	//public string PasswordText {
	//  get {
	//	return _passText;
	//  }
	//  set {
	//	_passText = value;
	//	OnPropertyChanged("PasswordText");
	//  }
	//}

	private List<ServerModel> _lstServer = new List<ServerModel>();
	/// <summary>
	/// Danh sách server
	/// </summary>
	public List<ServerModel> LstServer {
	  get { return _lstServer; }
	  set {
		_lstServer = value;
		OnPropertyChanged("LstServer");
	  }
	}

	private ServerModel _serverSelected;
	public ServerModel ServerSelected {
	  get {
		return _serverSelected;
	  }
	  set {
		_serverSelected = value;
		OnPropertyChanged("ServerSelected");
	  }
	}

	private bool _checkSavedAccount;
	private string StrStatusLicense = "TrialExpired";
	//private LicenseState EnumLicenseState;

	/// <summary>
	/// Trạng thái lưu thông tin tài khoản
	/// </summary>
	public bool CheckSavedAccount {
	  get {
		return _checkSavedAccount;
	  }
	  set {
		_checkSavedAccount = value;
		OnPropertyChanged("CheckSavedAccount");
	  }
	}

	public object SetUserProFile {
	  get {
		return this._usersUpdateProFile;
	  }
	  set {
		_usersUpdateProFile = value as ModelUsers;
		OnPropertyChanged("SetUserProFile");
	  }
	}
	public object SetUserPass {
	  get {
		return this._usersUpdatePass;
	  }
	  set {
		_usersUpdatePass = value as ModelChangePass;
		OnPropertyChanged("SetUserPass");
	  }
	}
	public object SetUserLogin {
	  get {
		return this._userLogin;
	  }
	  set {
		_userLogin = value as ModelUsers;
		OnPropertyChanged("SetUserLogin");
	  }
	}
	public string SelectedItem {
	  get { return _selectedItem; }
	  set {
		_selectedItem = value;
		OnPropertyChanged("SelectedItem");
	  }
	}
	public string ModalSelection {
	  get { return _modalSelection; }
	  set {
		_modalSelection = value;
		OnPropertyChanged("ModalSelection");
	  }
	}
	public bool IsTiling {
	  get { return _isModal; }
	  set {
		_isModal = value;
		OnPropertyChanged("IsTiling");
	  }
	}
	public bool ShowProFile {
	  get { return _isProFile; }
	  set {
		_isProFile = value;
		OnPropertyChanged("ShowProFile");
	  }
	}
	public bool ShowChangePass {
	  get { return _isChangePass; }
	  set {
		_isChangePass = value;
		OnPropertyChanged("ShowChangePass");
	  }
	}

	#region Variables for loading

	private ModelProgress MPProgress = new ModelProgress();
	public PopupLoading LoadingUC;

	private bool _blnHideMain = false;

	public bool BlnHideMain {
	  get { return _blnHideMain; }
	  set { _blnHideMain = value; OnPropertyChanged(nameof(BlnHideMain)); }
	}

	#endregion

	ICommand clickComand { get; set; }
	public ICommand LoginCommand { get; set; }
	public ICommand LogoutCommand { get; set; }
	public ICommand BackSpaceCommand { get; set; }

	#endregion

	#endregion

	#region === Handle ===

	public ViewModelMain(MainWindow _viewMain,Dictionary<string,object> dicData) {
	  _mainWindow = _viewMain;
	  _userLogin = new ModelUsers();
	  _usersUpdateProFile = new ModelUsers();
	  _usersUpdatePass = new ModelChangePass();
	  LoginCommand = new View.RelayCommand<object>(
		(p) => LoginAccount(_mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.Text
		,_mainWindow.ucLoginMaster.passBox.Password));
	  LogoutCommand = new View.RelayCommand<object>(
		(p) => LogOut(_mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.Text));
	  BackSpaceCommand = new View.RelayCommand<object>(
		(p) => PressBackSpace(_mainWindow.ucLoginMaster.passBox.Password));

	  DicData=dicData;
	  _viewMain.windowMain.Title=dicData["stringTitle"] as string;
	  StrPathLoadDll =dicData["stringPath"] as string;
	  var tuple = dicData["Tuple<int,string,string><_software,_version,_dateTime>"] as Tuple<int,string,string>;
	  _software=tuple.Item1;
	  _version=tuple.Item2;
	  _dateTime=tuple.Item3;
	  ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)dicData["DELEGATE_VOID_IN_OTHER_USERCONTROL"];

	  TupleSetting=dicData["Tuple<bool,string,string,int><checkSaveLoginInfo,userName,passUser,isServer>"] as Tuple<bool,string,string,int>;

	  LoadForm();
	}

	#endregion

	#region === Các hàm chung ===

	private bool CheckData(ModelUsers users) {
	  if(string.IsNullOrEmpty(users.Name) || string.IsNullOrEmpty(users.Surname)) {
		QTMessageBox.ShowNotify("Họ tên người dùng không được bỏ trống!");
		return false;
	  }

	  if(users.Name.Trim().Equals("") || users.Surname.Trim().Equals("")) {
		QTMessageBox.ShowNotify("Họ tên người dùng không được bỏ trống!");
		return false;
	  }

	  if(users.Surname.Length>20) {
		QTMessageBox.ShowNotify("Họ không được lớn hơn 20 kí tự!");
		return false;
	  }

	  if(users.Name.Length>20) {
		QTMessageBox.ShowNotify("Tên không được lớn hơn 20 kí tự!");
		return false;
	  }

	  var _regexSpecial = new Regex(@"[!@#$%^&*\(\)\-\+=~`><\?\?""/.,:;\'{}\[\]|\\]");
	  if(_regexSpecial.IsMatch(users.Name + users.Surname)) {
		QTMessageBox.ShowNotify("Họ tên người dùng không được chứa ký tự đặc biệt!");
		return false;
	  }

	  if(string.IsNullOrEmpty(users.DOB)) {
		QTMessageBox.ShowNotify("Thông tin ngày sinh không được bỏ trống!");
		return false;
	  }
	  string[] formats = { "d/MM/yyyy","dd/MM/yyyy" };
	  var dt = DateTime.Now;
	  var now = DateTime.Today;
	  var isValidFormat = DateTime.TryParseExact(users.DOB,formats,
		new CultureInfo("en-US"),DateTimeStyles.None,out dt);
	  if(!isValidFormat) {
		QTMessageBox.ShowNotify("Thông tin ngày sinh không đúng định dạng!");
		return false;
	  }

	  if(dt.Year > now.Year) {
		QTMessageBox.ShowNotify("Thông tin ngày sinh không hợp lệ!");
		return false;
	  }
	  var age = now.Year - dt.Year;
	  if(DateTime.Now.Month < dt.Month || (DateTime.Now.Month == dt.Month && DateTime.Now.Day < dt.Day))
		age--;

	  if(age < 6 || age > 60) {
		QTMessageBox.ShowNotify("Thông tin ngày sinh không hợp lệ!");
		return false;
	  }

	  var isValidInput = new Regex(@"^\d{9,11}$");
	  var strPhone = users.Tel;
	  if(!isValidInput.IsMatch(strPhone)) {
		QTMessageBox.ShowNotify("Thông tin số điện thoại không hợp lệ!");
		return false;
	  }

	  return true;
	}

	public void Execute(object parameter) {
	  try {
		var control = parameter as HamburgerMenuItem;

		//if(_licenseInfo.State == LicenseState.OK || _licenseInfo.State == LicenseState.InTrialPeriod) {
		if(StrStatusLicense.Equals("OK")|| StrStatusLicense.Equals("InTrialPeriod")) {
		  //Sản phẩm đã được kích hoạt hoặc đang trong t/g dùng thử. Tiếp tục cho sử dụng bình thường
		} else {
		  //Sản phẩm đã hết t/g sử dụng, hoặc key đc cấp và key phản hồi không khớp. Chặn sử dụng các chức năng khác, trừ chức năng đăng ký bản quyền
		  if(control.Text == "Trợ giúp" || control.Text == "Đăng ký bản quyền"
			|| control.Text == "Thông tin sản phẩm" || control.Text == "Hướng dẫn sử dụng") {
			//Cho phép thao tác
		  } else {
			return;
		  }
		}

		if(_software==19) {
		  if(control.Text.ToUpper().Equals(("Giám sát thi").ToUpper())) {
			controlSupervision = control;
		  }
		  if(!control.Text.ToUpper().Equals(("Giám sát thi").ToUpper()) && controlSupervision != null) {

			var tag = controlSupervision.Tag;

			var processor = tag as AvailableArrayProcessor;
			if(processor != null&&control.ParentID != 0) {
			  processor.Instance.Dispose();
			}

		  }
		}

		_mainWindow.ModuleName.Content = control.Text.ToUpper();
		if(control.ParentID != 0) {

		  //Trường hợp là menu Hướng dẫn sử dụng thì không clear grid nữa
		  if(control.ParentID==7&&control.Text.Equals("Hướng dẫn sử dụng")) {

		  } else {
			_mainWindow.contnet.Children.Clear();
		  }

		  if(_isServer==0) {
			OpenLoadingPopup();
		  } else {
			MPProgress=new ModelProgress();
		  }

		  BLLTools.SetupBgWorker(ref MPProgress,ClickCommand_DoWork,
			ClickCommand_RunWorkerCompleted,Main_ProgressChanged,control);

		} else {
		  foreach(var itm in _mainWindow.LstMenus.Content) {
			if(itm.ParentID == control.ItemID) {
			  itm.Visibility = itm.Visibility == Visibility.Collapsed ?
				Visibility.Visible : Visibility.Collapsed;
			} else if(itm.ParentID != 0 & itm.Lever != 0) {
			  itm.Visibility = Visibility.Collapsed;
			}
		  }
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	#region Loading khi chọn 1 menu (loading chưa quay tròn)

	private void ClickCommand_DoWork(object arg1,DoWorkEventArgs arg2) {
	  var control = arg2.Argument as HamburgerMenuItem;
	  _bllPlugin.StartBgWorkerDoWork(ref arg2,ref MPProgress,10,
		"HIỂN THỊ MÀN HÌNH","Đang tải dữ liệu...");
	  System.Threading.Thread.Sleep(300);
	  arg2.Result=arg2.Argument;
	}

	private void ClickCommand_RunWorkerCompleted(object arg1,RunWorkerCompletedEventArgs arg2) {
	  try {
		var control = arg2.Result as HamburgerMenuItem;

		var tag = control.Tag;
		var processor = tag as AvailableArrayProcessor;
		//_mainWindow.contnet.Children.Clear();
		IDictionary<string,object> dicData = new Dictionary<string,object>();

		dicData.Add("nameSubmenu",control.Text);

		dicData.Add("Dictionary<string,object>",DicLoginInfo);
		//dicData.Add("LicenseInfo",LicenseInfo);
		dicData.Add("select",control.TabIndex);
		dicData.Add("software",_software);
		dicData.Add("Version",_version);

		if(DicData.ContainsKey("VersionAppExe")) {
		  dicData.Add("VersionAppExe",DicData["VersionAppExe"] as Version);
		}

		AddStringKeyFromDicToDic(ref dicData,DicData,"BIDV");

		dicData.Add("DateTime",_dateTime);
		//dicData.Add("User",ViewModelMain._user);
		dicData.Add("Key",ViewModelMain._key);
		dicData.Add("isServer",ViewModelMain._isServer);
		dicData.Add("content",_mainWindow.contnet);
		dicData.Add("register","_ktIsregister");

		dicData.Add("mainWindow",_mainWindow.windowMain);

		//var config = new Config();
		//var tupleInfo = new Tuple<string,string>(config.TDPhongso,config.TDTenTruong);

		//dicData.Add("Tuple<string,string>",tupleInfo);

		if(processor != null) {
		  // processing...
		  processor.Instance.Process(dicData);
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }

	  _mainWindow.gridPopup.Children.Clear();
	  BlnHideMain=false;

	}

	#endregion

	private void AddStringKeyFromDicToDic(ref IDictionary<string,object> dicOutput,
	  Dictionary<string,object> dicInput,string strKey) {
	  if(dicInput.ContainsKey(strKey)) {
		dicOutput.Add(strKey,dicInput[strKey] as string);
	  }
	}

	public bool CanExecute(object parameter) {
	  return true;
	}

	private void RunCommand(byte status,string cmd = "shutdown -t 0 -r -f") {
	  switch(status) {
		case 1: {
			ExecuteCommand("@ECHO OFF");
			ExecuteCommand("ipconfig /flushdns");
		  }
		  break;
		case 2: {
			ExecuteCommand("@ECHO OFF");
			ExecuteCommand(cmd);
		  }
		  break;
		default: {
			ExecuteCommand("@ECHO OFF");
			ExecuteCommand(cmd);
		  }
		  break;
	  }
	}

	private static void ExecuteCommand(string command,bool stt = true) {
	  int exitCode;
	  ProcessStartInfo processInfo;
	  Process process;

	  processInfo = new ProcessStartInfo("cmd.exe","/c " + command);
	  processInfo.CreateNoWindow = true;
	  processInfo.UseShellExecute = false;
	  // *** Redirect the output ***
	  processInfo.RedirectStandardError = true;
	  processInfo.RedirectStandardOutput = true;

	  process = Process.Start(processInfo);
	  process.WaitForExit();

	  // *** Read the streams ***
	  // Warning: This approach can lead to deadlocks, see Edit #2

	  var output = process.StandardOutput.ReadToEnd();
	  var error = process.StandardError.ReadToEnd();

	  exitCode = process.ExitCode;
	  if(stt) {
		Console.WriteLine("output>> " + (String.IsNullOrEmpty(output) ? "OK" : output));
		Console.WriteLine("error>> " + (String.IsNullOrEmpty(error) ? "(none)" : error));
		Console.WriteLine("ExitCode: " + exitCode,"ExecuteCommand");
	  }
	  process.Close();
	}

	private bool CheckDataChangePass(ModelChangePass users) {

	  if(string.IsNullOrEmpty(users.OldPassword)) {
		QTMessageBox.ShowNotify("Bạn cần nhập mật khẩu cũ!");
		_mainWindow.ucChangePassword.TxtPassOld.Focus();
		return false;
	  }

	  if(string.IsNullOrEmpty(users.NewPassword)||users.NewPassword.Trim().Length<7) {
		QTMessageBox.ShowNotify("Mật khẩu mới phải từ 7 kí tự trở lên, bạn vui lòng thử lại!");
		_mainWindow.ucChangePassword.TxtPassNew.Focus();
		return false;
	  }

	  if(string.IsNullOrEmpty(users.AgainNewPassword)) {
		QTMessageBox.ShowNotify("Bạn cần nhập lại mật khẩu mới!");
		_mainWindow.ucChangePassword.TxtPassNewAgain.Focus();
		return false;
	  }

	  if(users.AgainNewPassword != users.NewPassword) {
		QTMessageBox.ShowNotify("Mật khẩu mới chưa khớp!");
		_mainWindow.ucChangePassword.TxtPassNewAgain.Focus();
		return false;
	  }

	  if(users.OldPassword != _mainWindow.ucLoginMaster.passBox.Password) {
		QTMessageBox.ShowNotify("Mật khẩu cũ không chính xác!");
		_mainWindow.ucChangePassword.TxtPassOld.Focus();
		return false;
	  }

	  if(users.AgainNewPassword.Equals(_mainWindow.ucLoginMaster.passBox.Password)) {
		QTMessageBox.ShowNotify("Mật khẩu mới không được trùng với mật khẩu cũ!");
		_mainWindow.ucChangePassword.TxtPassNew.Focus();
		return false;
	  }

	  return true;
	}

	/// <summary>
	/// Kiểm tra bản quyền - Phạm Quốc Tuấn
	/// </summary>
	private void CheckLicenseApp(ref string strInfoAppLicense,ref string strMessage) {
	  try {
		//string test = _licenseInfo.State.ToString();
		//StrStatusLicense="TrialExpired";
		StrStatusLicense="OK";
		//EnumLicenseState=_licenseInfo.State;

		string strAppName = "Master Test";
		if(DicData.ContainsKey("stringAppName")) {
		  strAppName=DicData["stringAppName"] as string;
		}
		//_mainWindow.lblInfoAppLicense.Content=
		//  "Bạn đang dùng \""+strAppName+"\" bản chưa đăng ký mã bản quyền";
		strInfoAppLicense="Bạn đang dùng \""+strAppName+"\" bản chưa đăng ký mã bản quyền";

		//if(EnumLicenseState == LicenseState.TrialExpired) {
		//  //Trường hợp này là key dùng thử đã hết t/g dùng thử.
		//  StrStatusLicense="TrialExpired";
		//  //InvicoMessageBox.ShowWarning("Bạn đã hết thời hạn dùng thử phần mềm!");
		//  strMessage="Bạn đã hết thời hạn dùng thử phần mềm!";
		//  return;
		//}

		//if(EnumLicenseState == LicenseState.ActivationExpired) {
		//  //Trường hợp này là key kích hoạt đã hết thời hạn sử dụng.
		//  StrStatusLicense="ActivationExpired";
		//  //InvicoMessageBox.ShowWarning("Bạn đã hết thời hạn sử dụng phần mềm!");
		//  strMessage="Bạn đã hết thời hạn sử dụng phần mềm!";
		//  return;
		//}

		//if(EnumLicenseState == LicenseState.ActivationNeeded) {
		//  //Mã đăng ký có tồn tại, có hợp lệ nhưng yêu cầu phải kích hoạt thủ công
		//  StrStatusLicense="ActivationNeeded";
		// // InvicoMessageBox.ShowWarning(
		//	//"Mã kích hoạt sản phẩm lỗi! Bạn cần kích hoạt lại sản phẩm để sử dụng!");
		//  strMessage="Mã kích hoạt sản phẩm lỗi! Bạn cần kích hoạt lại sản phẩm để sử dụng!";
		//  return;
		//}

		//if(EnumLicenseState == LicenseState.InTrialPeriod) {
		//  //Trường hợp này sản phẩm đang trong t/g dùng thử, cho tiếp tục sử dụng bình thường
		//  StrStatusLicense="InTrialPeriod";
		//  return;
		//}

		//if(EnumLicenseState == LicenseState.OK) {
		//  //Trường hợp này sản phẩm đã được kích hoạt, cho tiếp tục sử dụng bình thường
		//  StrStatusLicense="OK";
		//  //_mainWindow.lblInfoAppLicense.Content=(new Config()).TDTruong;
		//  strInfoAppLicense=(new Config()).TDTruong;
		//  return;
		//}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void OpenLoadingPopup() {
	  MPProgress=new ModelProgress();

	  BlnHideMain=true;
	  _bllPlugin.ShowPopupLoading(ref LoadingUC,ref _mainWindow.gridPopup);
	}

	private void Main_ProgressChanged(object arg1,ProgressChangedEventArgs arg2) {
	  if(arg2.ProgressPercentage == -1) {
		QTMessageBox.ShowNotify(arg2.UserState?.ToString());
		return;
	  }

	  _bllPlugin.ChangeInfoLoading(ref LoadingUC,MPProgress);
	}

	public void LoginAccount(string strUser,string strPass) {
	  try {
		string strDauThapPhan = "";
		string strDauFullName = "";
		string strToolTipThapPhan = "";
		BLLTools.GetInfoPhanThapPhan(ref strDauThapPhan,ref strDauFullName,ref strToolTipThapPhan);

		if(strDauThapPhan!=".") {
		  var dicInput = new Dictionary<string,object>();
		  dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
						new SuaPhanCachThapPhan_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromOtherUserControl));

		  _mainWindow.modalPresenterBiggest.Visibility=Visibility.Hidden;
		  _mainWindow.modelChildren.Visibility=Visibility.Visible;
		  _mainWindow.modelChildren.Margin=new Thickness(0);

		  _mainWindow.gridChildren.Children.Clear();

		  var userControl = new SuaPhanCachThapPhan(dicInput);
		  _mainWindow.gridChildren.Children.Add(userControl);

		  return;
		}

		if(strPass.Length==0||strUser.Trim().Equals("")) {
		  QTMessageBox.ShowNotify("Thông tin đăng nhập không đầy đủ!");
		  return;
		}

		if(string.IsNullOrEmpty((strUser+strPass).Trim())) {
		  QTMessageBox.ShowNotify("Thông tin đăng nhập không đầy đủ!");
		  return;
		}

		//_mainWindow.ucLoginMaster.btnLogin.Focus();
		_mainWindow.btnLogin.Focus();

		OpenLoadingPopup();

		BLLTools.SetupBgWorker(ref MPProgress,Login_DoWork,
		  Login_RunWorkerCompleted,Login_ProgressChanged,null);

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ExcuteFromOtherUserControl(ref Dictionary<string,object> obj) {

	}

	private void ExcuteFromOtherUserControl(Dictionary<string,object> obj) {

	}

	private void ExcuteFromListMessagesUC(ref Dictionary<string,object> dicInput) {
	  if(dicInput.ContainsKey(nameof(BackToMainMenuCommand))) {
		BackToMainMenuCommand.Execute(null);
		return;
	  }
	}

	private void ExcuteFromMainMenuSphereUC(ref Dictionary<string,object> obj) {
	  Execute(_mainWindow.LstMenus.Content[0].SelectionCommandParameter);
	}

	#region Loading đăng nhập (loading chưa quay tròn)

	private void Login_DoWork(object arg1,DoWorkEventArgs arg2) {
	  _bllPlugin.StartBgWorkerDoWork(ref arg2,ref MPProgress,10,
		"ĐĂNG NHẬP","Đang kết nối...");
	  System.Threading.Thread.Sleep(300);
	}

	private void Login_ProgressChanged(object arg1,ProgressChangedEventArgs arg2) {
	  if(arg2.ProgressPercentage == -1) {
		QTMessageBox.ShowNotify(arg2.UserState?.ToString());
		return;
	  }

	  _bllPlugin.ChangeInfoLoading(ref LoadingUC,MPProgress);

	}

	private void Login_RunWorkerCompleted(object arg1,RunWorkerCompletedEventArgs e) {
	  try {

		_version=$"{_software}.3.{DtPhienBan.ToString("yy.MM.dd")}";
		_dateTime=DtPhienBan.ToString("dd/MM/yyyy");

		string strAppName = "sản phẩm";
		if(DicData.ContainsKey("stringAppName")) {
		  strAppName=DicData["stringAppName"] as string;
		}

		//var key = "";
		var mes = "";
		var status = "notadminadmin";
		string strUser = _mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.Text.Trim();
		string strPass = _mainWindow.ucLoginMaster.passBox.Password.Trim();

		var dicInput = new Dictionary<string,object>();
		dicInput["string.strUserName"]=strUser;
		dicInput["string.strPassword"]=_bllPlugin.Base64Encode(strPass);

		DataTable dtOutput = null;
		{
		  Exception exOutput = null;
		  DALAccount.GetDtAccountGiaHanByUserPass(ref dtOutput,ref exOutput,dicInput);
		  if(exOutput!=null) {
			//Log4Net.Error(exOutput.Message);
			//Log4Net.Error(exOutput.StackTrace);
			//ShowException(exOutput);
			//return;
			throw exOutput;
		  }
		}
		if(dtOutput==null) {
		  //QTMessageBox.ShowNotify(
		  //  "Kiểm tra dữ liệu đăng nhập không thành công, bạn vui lòng thử lại!"
		  //  ,"(dtOutput==null)");
		  //return;
		  status="dtOutputNull";
		}
		if(dtOutput!=null) {
		  if(dtOutput.Rows.Count==0) {
			status="dangnhapsai";
		  }
		}

		string strPhienBanHanCuoi = "";
		if(dtOutput!=null) {
		  int intSumRow = dtOutput.Rows.Count;
		  if(intSumRow>0) {
			string strIdAccount = ""+dtOutput.Rows[intSumRow-1]["Id"].ToString();
			TupleIdNameAccount=new Tuple<string,string>(strIdAccount,strUser);

			try {
			  DateTime dtStart = (DateTime)dtOutput.Rows[intSumRow-1]["StartTimeUse"];
			  DateTime dtEnd = (DateTime)dtOutput.Rows[intSumRow-1]["EndTimeUse"];

			  strPhienBanHanCuoi=$"(Phiên bản {dtEnd.ToString("dd/MM/yyyy")})";
			  TimeSpan tsStart = DateTime.Now.Subtract(dtStart);
			  TimeSpan tsEnd = DateTime.Now.Subtract(dtEnd);
			  if(DateTime.Now<dtStart||DateTime.Now>dtEnd) {
				status="HetHan";
			  } else {
				status="ok";
			  }
			} catch(Exception etemp) {
			  string str = etemp.Message;
			  status="HetHan";
			}
		  }
		}

		string strMessageNotHaveIp = "";
		switch(status) {
		  case "ok":
			#region Trường hợp đăng nhập thành công

			{
			  string strMessage = "";
			  _bllPlugin.KiemTraValueHopLeInFileConfig(ref strMessage);
			  if(strMessage!="") {
				QTMessageBox.ShowNotify(strMessage);
			  }
			}

			//_bllPlugin.UpdateUserProfileLogin(ref _usersUpdateProFile,_user);
			//OnPropertyChanged(nameof(SetUserProFile));

			DicLoginInfo["DateTimePhienBanClientHienTai"]=DtPhienBan;

			//bool blnStopFunction = true;
			//_bllPlugin.KiemTraVaCapNhatPhienBan(ref blnStopFunction,DicLoginInfo,
			//  _mListKeyConfig.StrKeyKichHoatUpdateOnline);
			//if(blnStopFunction==true) {
			//  BlnHideMain=true;
			//  //_mainWindow.Hide();
			//  return;
			//}

			{
			  //check bản quyền sản phẩm
			  //CheckLicenseApp();
			  string strMessage = "";
			  string strInfoAppLicense = "";
			  CheckLicenseApp(ref strInfoAppLicense,ref strMessage);
			  _mainWindow.lblInfoAppLicense.Content=strInfoAppLicense;
			  if(strMessage!="") {
				QTMessageBox.ShowNotify(strMessage);
			  }
			}

			_countDisconnect = 0;

			string strUserText = "";
			string strPassBase64 = "";
			if(CheckSavedAccount) {
			  strUserText=strUser;
			  //strPassBase64=_bllPlugin.Base64Encode(_mainWindow.ucLoginMaster.passBox.Password.Trim());
			  strPassBase64=_bllPlugin.Base64Encode("");
			}

			SaveSettings(ref DicData,ref TupleSetting,strUserText,strPassBase64,
			  _serverSelected.IsServer,CheckSavedAccount);
			_isServer = _serverSelected.IsServer;

			//if(CheckSavedAccount) {
			//  SaveSettings(ref DicData,ref TupleSetting,_userText.Trim(),
			//	_bllPlugin.Base64Encode(_passText.Trim()),_serverSelected.IsServer,true);
			//  _isServer = _serverSelected.IsServer;
			//} else {
			//  SaveSettings(ref DicData,ref TupleSetting,string.Empty,string.Empty,
			//	_serverSelected.IsServer,false);
			//  _isServer = _serverSelected.IsServer;
			//}

			_bllPlugin.TryToRunUnikeyAsAdminIfNotRun();

			LoadMenuByPluginAndRuleUser();
			if(_lstMenuItems.Count==0) {
			  QTMessageBox.ShowNotify("Có lỗi trong quá trình tải file plugin, bạn vui lòng liên hệ bộ phận kĩ thuật để được hỗ trợ!"
				,"(_lstMenuItems.Count==0)");
			  break;
			}

			//DateTime dtLoginTimeGanNhat = (_isServer==0) ? DateTime.Now : _user.LoginTime;
			DateTime dtLoginTimeGanNhat = DateTime.Now;
			ShowInfoUserLogin(strUser,dtLoginTimeGanNhat);
			_mainWindow.txtHanCuoi.Content=strPhienBanHanCuoi;

			_isLogin = false;
			OnPropertyChanged(nameof(ShowLogin));
			_isMain = true;
			OnPropertyChanged(nameof(ShowMain));

			_mainWindow.windowMain.MinHeight=700;
			_mainWindow.windowMain.MinWidth=1024;

			MenuMouseEnterCommand.Execute(null);

			BackToMainMenuCommand.Execute(null);

			//Hide(); 
			#endregion

			break;
		  case "notadminadmin":
			QTMessageBox.ShowNotify("Tài khoản hoặc mật khẩu không đúng, bạn vui lòng thao tác lại!");
			break;
		  case "HetHan":
			QTMessageBox.ShowNotify("Bạn vui lòng kích hoạt mã gia hạn để tiếp tục sử dụng!");
			ShowCheckSystemDialogCommand.Execute(null);
			break;
		  case "dtOutputNull":
			QTMessageBox.ShowNotify("Kiểm tra dữ liệu đăng nhập không thành công, bạn vui lòng thử lại!");
			break;
		  case "dangnhapsai":
			QTMessageBox.ShowNotify("Tài khoản hoặc mật khẩu không đúng, bạn vui lòng thao tác lại!");
			break;
		  case "notok":
			//InvicoMessageBox.ShowNotify(mes);
			strMessageNotHaveIp = mes.Substring(0,(mes.Length>28) ? mes.Length-28 : mes.Length-1);
			QTMessageBox.ShowNotify(strMessageNotHaveIp);
			break;
		  case "logout":
			//InvicoMessageBox.ShowNotify(mes);
			strMessageNotHaveIp = mes.Substring(0,(mes.Length>28) ? mes.Length-28 : mes.Length-1);
			QTMessageBox.ShowNotify(strMessageNotHaveIp);
			//Application.Restart();
			break;
		  case "disconnect":
			//InvicoMessageBox.ShowNotify(mes);
			strMessageNotHaveIp = mes.Substring(0,(mes.Length>28) ? mes.Length-28 : mes.Length-1);
			QTMessageBox.ShowNotify(strMessageNotHaveIp);
			_countDisconnect++;
			break;
		  case "exits":
			RunCommand(2,mes);
			break;
		  case "error":
			QTMessageBox.ShowNotify(mes);
			break;
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }

	  _mainWindow.gridPopup.Children.Clear();
	  BlnHideMain=false;

	}

	#endregion

	private void ShowInfoUserLogin(string username,DateTime now) {
	  //_mainWindow.txtHelloUser.Content="Xin chào, "+username;
	  _mainWindow.txtHelloUser.Text="Xin chào, "+username;
	  _mainWindow.txtTimeLogin.Content="Thời gian đăng nhập: "+now.ToString("dd/MM/yyyy HH:mm:ss");
	}

	private void SaveSettings(ref Dictionary<string,object> dicData,
	  ref Tuple<bool,string,string,int> tupleSetting
	  ,string strUser,string strPass,int isServer,bool blnCheckSaveLogin) {
	  try {
		tupleSetting=new Tuple<bool,string,string,int>(
		blnCheckSaveLogin,strUser,strPass,isServer
		);
		dicData.Remove("Tuple<bool,string,string,int><checkSaveLoginInfo,userName,passUser,isServer>");
		dicData.Add("Tuple<bool,string,string,int><checkSaveLoginInfo,userName,passUser,isServer>",
		  tupleSetting);
		SaveSettingsToProperties(strUser,strPass,isServer,blnCheckSaveLogin);
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void SaveSettingsToProperties(string strUser,string strPass,
	  int isServer,bool blnCheckSaveLogin) {
	  try {
		if(ExcuteInOtherUserControl!=null) {
		  var dic = new Dictionary<string,object>();
		  dic.Add("stringUser",strUser);
		  dic.Add("stringPass",strPass);
		  dic.Add("int",isServer);
		  dic.Add("bool",blnCheckSaveLogin);

		  ExcuteInOtherUserControl(dic);
		}
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadMenuByPluginAndRuleUser() {
	  try {
		_lstMenuID.Clear();
		_lstSubMenuNames.Clear();
		_lstModules.Clear();
		_mainWindow.LstMenus.Content.Clear();
		_lstMenuItems.Clear();

		var lstRuleOfUser = new List<int>();

		if(_isServer == 0) {
		  for(int i = 0;i < 100;i++) {
			lstRuleOfUser.Add(i);
		  }
		} else {
		 // foreach(var rule in _user.LstRules) {
			//lstRuleOfUser.Add(rule.RuleID);
		 // }

		 // //Add thêm các rule trợ giúp, đăng ký bản quyền, xem thông tin sp
		 // for(int i = 87;i < 90;i++) {
			//lstRuleOfUser.Add(i);
		 // }

		 // //Thêm quyền quản lý môn chung nếu tài khoản thuộc nhóm superadmin
		 // if(_user.GroupID == 7) {
			////90 là quyền quản lý môn chung
			//lstRuleOfUser.Add(90);
			////91 là quyền quản lý key
			//lstRuleOfUser.Add(91);
			////92 là quyền quản lý câu hỏi đã xóa
			//lstRuleOfUser.Add(92);
		 // }


		  if(_software==19) {
			#region Fake rule 60 63 cho phan thong ke bao cao - PhamQuocTuan
			// if(!lstRuleOfUser.Contains(60)) {
			//lstRuleOfUser.Add(60);
			// }
			// if(!lstRuleOfUser.Contains(63)) {
			//lstRuleOfUser.Add(63);
			// }
			// lstRuleOfUser.Sort();
			#endregion
		  }
		}

		bool server = _isServer == 0 ? false : true;

		//string pathTemp = string.Empty;
		//if()

		_mainWindow.LstMenus.Content.Clear();
		_mainWindow.contnet.Children.Clear();
		clickComand = null;

		//MainConfig.LoadPlugins(lstRuleOfUser, ref _lstMenuItems, server, @"PlugIns");
		//_bllPlugin.LoadPlugins(lstRuleOfUser,ref _lstMenuItems,server,@"Tes\PlugIns");
		_bllPlugin.LoadPlugins(_software,lstRuleOfUser,ref _lstMenuItems,server,StrPathLoadDll);

		clickComand = new View.RelayCommand<object>(Execute,CanExecute);
		var k = 0;
		foreach(var menuItems in _lstMenuItems) {
		  if(menuItems.LstMenuChilds.Count <= 0) {
			continue;
		  }

		  if(menuItems.LstMenuChilds.Count == 1) {
			var itmSubMenu = new HamburgerMenuItem();
			var sourceSub = new BitmapImage();
			sourceSub.BeginInit();
			//sourceSub.UriSource = new Uri(BLLMain.LoadIcon(menuItems.ID),UriKind.Relative);
			sourceSub.UriSource = new Uri(@"/Assets/" + menuItems.LstMenuChilds[0].IconFileName,
			  UriKind.RelativeOrAbsolute);
			sourceSub.DecodePixelHeight = 32;
			sourceSub.DecodePixelWidth = 32;
			sourceSub.EndInit();
			itmSubMenu.Icon = sourceSub;
			//itmSubMenu.Text = menuItems.Name;
			itmSubMenu.Text = menuItems.LstMenuChilds[0].NameItem;

			if(itmSubMenu.Text.Equals("Quản lý tổ chức thi")) {
			  itmSubMenu.Text = "Tổ chức thi";
			}

			itmSubMenu.SelectionCommand = clickComand;
			//itmSubMenu.Tag = null;
			itmSubMenu.Tag = menuItems.LstMenuChilds[0].Tag;
			itmSubMenu.ParentID = menuItems.ID;
			//itmSubMenu.ItemID = menuItems.ID;
			itmSubMenu.Lever = 0;
			itmSubMenu.SelectionCommandParameter = itmSubMenu;
			_mainWindow.LstMenus.Content.Add(itmSubMenu);

			k++;
			continue;
		  }

		  {
			var itmMenu = new HamburgerMenuItem();
			var source = new BitmapImage();
			source.BeginInit();
			source.UriSource=new Uri(_bllPlugin.LoadIcon(menuItems.ID,_software),UriKind.Relative);
			source.DecodePixelHeight=32;
			source.DecodePixelWidth=32;
			source.EndInit();
			itmMenu.Icon=source;
			itmMenu.Text=menuItems.Name;
			itmMenu.SelectionCommand=clickComand;
			itmMenu.Tag=null;
			itmMenu.ItemID=menuItems.ID;
			itmMenu.Lever=0;
			itmMenu.SelectionCommandParameter=itmMenu;
			_mainWindow.LstMenus.Content.Add(itmMenu);
		  }

		  for(int i = 0;i < menuItems.LstMenuChilds.Count;i++) {
			//if(_user.GroupID == 7 && Convert.ToInt32(
			//  menuItems.LstMenuChilds[i].Tag.Instance.Attributes.Rules.Split('|')[0]) == 90) {
			//  menuItems.LstMenuChilds[i].NameItem = "Quản lý môn chung";
			//}

			var itmSubMenu = new HamburgerMenuItem();
			var sourceSub = new BitmapImage();
			sourceSub.BeginInit();
			sourceSub.UriSource = new Uri(@"/Assets/" + menuItems.LstMenuChilds[i].IconFileName,
			  UriKind.RelativeOrAbsolute);
			sourceSub.DecodePixelHeight = 22;
			sourceSub.DecodePixelWidth = 22;
			sourceSub.EndInit();
			itmSubMenu.Icon = sourceSub;
			itmSubMenu.Text = menuItems.LstMenuChilds[i].NameItem;
			itmSubMenu.SelectionCommand = clickComand;
			itmSubMenu.Tag = menuItems.LstMenuChilds[i].Tag;
			itmSubMenu.Visibility = Visibility.Collapsed;
			itmSubMenu.ParentID = menuItems.ID;
			itmSubMenu.TabIndex = i + 1;
			itmSubMenu.Lever = 1;
			itmSubMenu.SelectionCommandParameter = itmSubMenu;

			//Nếu người dùng đã đăng ký bản quyền thì không hiển thị menu đăng ký nữa
			//if(itmSubMenu.Text.Equals("Đăng ký bản quyền")&&EnumLicenseState == LicenseState.OK
			//  &&BlnDaLuuThongTinTrongRegistry==true) {
			//  continue;
			//}

			_mainWindow.LstMenus.Content.Add(itmSubMenu);
		  }
		  k++;
		}
		SetDefault();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void SetDefault() {
	  try {
		//var lstModules = _lstModules
		//  .Where(x => x.ContainsKey((int)AppConfig.enum_ParentFunction.BAOCAO)).ToList();
		//var processor = (lstModules.Count > 0)
		//  ? lstModules[0][(int)AppConfig.enum_ParentFunction.BAOCAO][0] as AvailableArrayProcessor : null;
		//_mainWindow.contnet.Children.Clear();

		//IDictionary<string,object> tam = new Dictionary<string,object>();
		//tam.Add("nameSubmenu","");
		//tam.Add("LicenseInfo",new Client());
		//tam.Add("select",0);
		//tam.Add("software",0);
		//tam.Add("Version","");
		//tam.Add("DateTime","");
		//tam.Add("User",new User());
		//tam.Add("Key","");
		//tam.Add("isServer",0);
		//tam.Add("content",_mainWindow.contnet);
		//tam.Add("register","_ktIsregister");

		//tam.Add("mainWindow",_mainWindow.windowMain);
		//if(processor != null) {
		//  processor.Instance.Process(tam);
		//} 
		// processing...
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	public void LogOut(string strUser) {
	  try {

		var dialogConfirm = QTMessageBox.ShowConfirm("Bạn có chắc chắn muốn đăng xuất?");
		if(dialogConfirm!=MessageBoxResult.Yes) {
		  return;
		}

		System.Windows.Forms.Application.Restart();
		Process.GetCurrentProcess().Kill();
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadForm() {
	  try {
		LoadControlDefault();

		string strThongTinPhienBan = $"{_software}.3.{DtPhienBan.ToString("yy.MM.dd")}";
		_mainWindow.ucLoginMaster.lblDangNhap.ToolTip=strThongTinPhienBan;

		//try {
		//  //var nfi = new NumberFormatInfo();
		//  //nfi.NumberFormat.NumberDecimalSeparator=".";

		//  System.Threading.Thread.CurrentThread.CurrentCulture=new CultureInfo("en-Us");
		//} catch(Exception ex) {
		//  string str = ex.Message;
		//}

		//_mainWindow.LstMenus.IsOpen=true;
		_bllPlugin.SetToolTipForLabelComputerName(ref _mainWindow.txtData);
		_mainWindow.txtData.ToolTip=$"({strThongTinPhienBan})\n"+_mainWindow.txtData.ToolTip.ToString();

		string strPathRegistry = "SOFTWARE\\AppTest\\InfoConfig";
		var arrayStringReg = strPathRegistry.Split('\\');
		if(arrayStringReg.Length==3) {
		  //InvicoMessageBox.ShowNotify("Server chưa thiết lập lưu thông tin bản quyền, bạn vui lòng liên hệ bộ phận DVKH để được hỗ trợ!");
		  //return;
		  string strJsonInReg = "";
		  _bllPlugin.LoadJsonFromRegistry(ref strJsonInReg,arrayStringReg);
		  if(strJsonInReg.Trim()=="") {
			//InvicoMessageBox.ShowNotify("Lưu thông tin bản quyền không thành công, bạn vui lòng thử lại!");
			//return;
			//BlnDaLuuThongTinTrongRegistry=false;
		  }

		}

		SetListServer();
		GetAccountOldInfo();

		//_licenseInfo = new Client(System.AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
		//OnPropertyChanged("LicenseInfo");

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void LoadControlDefault() {
	  try {
		//int intMaxHeight = 380;
		//int intMaxWidth = 710;
		//_mainWindow.windowMain.MinHeight=intMaxHeight;
		//_mainWindow.windowMain.MinWidth=intMaxWidth;

		//_mainWindow.windowMain.MaxHeight=intMaxHeight;
		//_mainWindow.windowMain.MaxWidth=intMaxWidth;
		//_mainWindow.windowMain.Style=Application.Current.FindResource("InvicoWindowNoResizeStyle") as Style;
		//_mainWindow.windowMain.Template=new System.Windows.Controls.ControlTemplate();

		_mainWindow.colBackground.Width=new GridLength(0);
		_mainWindow.borderLoginUC.Width=350;
		_mainWindow.borderLoginUC.Height=300;
		_mainWindow.btnLogin.Visibility=Visibility.Collapsed;
		_mainWindow.ucLoginMaster.btnLogin.Visibility=Visibility.Collapsed;

		if(_software == 16 || _software == 19 || _software == 26) {
		  _mainWindow.ucLoginMaster.btnLogin.Visibility=Visibility.Visible;
		  //_mainWindow.borderLoginUC.Height=340;
		  _mainWindow.borderLoginUC.Height=450;

		  // string strFolderName = "HelpI";
		  // string strImageName = "background.png";
		  // string strPathBackground = System.Windows.Forms.Application.StartupPath
		  // +$"\\{strFolderName}\\{strImageName}";
		  // if(System.IO.File.Exists(strPathBackground)) {
		  //_mainWindow.borderLoginUC.Width=700;
		  //_mainWindow.colBackground.Width=new GridLength(1,GridUnitType.Star);

		  //_mainWindow.imageBackground.ImageSource=new BitmapImage(new Uri(strPathBackground));
		  // }

		  string strFolderName = "HelpI";
		  string strImageName = "background.png";
		  string strPathBackground = System.Windows.Forms.Application.StartupPath
		  +$"\\{strFolderName}\\{strImageName}";
		  if(System.IO.File.Exists(strPathBackground)) {
			//_mainWindow.borderLoginUC.Width=700;
			//_mainWindow.colBackground.Width=new GridLength(1,GridUnitType.Star);

			_mainWindow.imageBackgroundApp.ImageSource=new BitmapImage(new Uri(strPathBackground));
		  } else {
			//_mainWindow.gridBackground.Background=new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
			string strHexColor = "#DAE8F1";
			_mainWindow.gridBackground.Background=new System.Windows.Media.SolidColorBrush(
			  (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(strHexColor));

		  }

		}

		_mainWindow.borderIconProduct.Visibility=Visibility.Collapsed;
		if(_software == 20 || _software ==21||_software==27||_software==20201020) {
		  //SSG
		  _mainWindow.borderIconProduct.Visibility=Visibility.Visible;
		  _mainWindow.btnLogin.Visibility=Visibility.Visible;

		  //_mainWindow.gridBackground.Background=new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
		  string strHexColor = "#DAE8F1";
		  _mainWindow.gridBackground.Background=new System.Windows.Media.SolidColorBrush(
			(System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(strHexColor));

		}

		//_mainWindow.gradientStopXanhDam.Color=
		//  ((System.Windows.Media.SolidColorBrush)_mainWindow.btnTempColorXanhDam.Background).Color;
		//_mainWindow.gradientStopXanhNhat.Color=
		//  ((System.Windows.Media.SolidColorBrush)_mainWindow.btnTempColorXanhNhat.Background).Color;
		//_mainWindow.gradientStopXanhNhatHon.Color=
		//  ((System.Windows.Media.SolidColorBrush)_mainWindow.btnTempColorXanhNhatHon.Background).Color;

		_mainWindow.gradientStopXanhDam.Color=System.Windows.Media.Colors.White;
		_mainWindow.gradientStopXanhNhat.Color=System.Windows.Media.Colors.White;
		_mainWindow.gradientStopXanhNhatHon.Color=System.Windows.Media.Colors.White;

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void ShowException(Exception ex) {
	  QTMessageBox.ShowNotify(ex.Message,ex.StackTrace);
	}

	private void PressBackSpace(string strPass) {
	  if(strPass.Equals(StrOldPassword)) {
		_mainWindow.ucLoginMaster.passBox.Password = "";
		StrOldPassword = "Password không thể trùng";
	  }
	}

	private void GetAccountOldInfo() {
	  try {
		//Thông tin userName
		if(TupleSetting.Item1) {
		  _mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.Text = TupleSetting.Item2;
		  _mainWindow.ucLoginMaster.passBox.Password = _bllPlugin.Base64Decode(TupleSetting.Item3);
		  StrOldPassword = _mainWindow.ucLoginMaster.passBox.Password;

		  int isServer = TupleSetting.Item4;
		  _checkSavedAccount = TupleSetting.Item1;

		  if(isServer == 1) {
			_serverSelected = _lstServer[1];
		  } else {
			_serverSelected = _lstServer[0];
		  }
		} else {
		  _mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.Text = "";
		  _mainWindow.ucLoginMaster.passBox.Password = "";
		  _serverSelected = _lstServer[0];
		  _checkSavedAccount = false;
		}
		OnPropertyChanged("UserText");
		OnPropertyChanged("PasswordText");
		OnPropertyChanged("ServerSelected");
		OnPropertyChanged("CheckSavedAccount");
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void SetListServer() {
	  try {

		var _local = new ServerModel();
		_local.ServerName = Environment.MachineName;
		_local.IsServer = 0;

		_lstServer.Add(_local);

		//if(_software!=26&&_software!=27) {
		//  var config = new Config();
		//  var _server = new ServerModel();
		//  _server.ServerName = config.TDPhongso;
		//  _server.IsServer = 1;

		//  _lstServer.Add(_server);
		//}

		OnPropertyChanged(nameof(LstServer));
	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	}

	private void timerTextChanged_Tick(object sender,EventArgs e) {
	  if(_mainWindow.LstMenus.IsOpen==true) {
		_mainWindow.LstMenus.IsOpen=false;
	  }
	  TimerTextChanged.Stop();
	}

	private void SetSelection(System.Windows.Controls.PasswordBox passwordBox,int start,int length) {
	  passwordBox.GetType().GetMethod("Select",BindingFlags.Instance | BindingFlags.NonPublic)
		.Invoke(passwordBox,new object[] { start,length });
	}

	#endregion

	#region === Command ===

	public ICommand MenuMouseLeaveCommand {
	  get {
		return new DelegateCommand(p => {
		  //TimerTextChanged=new System.Windows.Forms.Timer() { Interval=1000 };
		  //TimerTextChanged.Tick += new EventHandler(timerTextChanged_Tick);
		  //TimerTextChanged.Start();
		});
	  }
	}

	public ICommand MenuMouseEnterCommand {
	  get {
		return new DelegateCommand(p => {
		  TimerTextChanged.Stop();
		  if(_mainWindow.LstMenus.IsOpen==false) {
			_mainWindow.LstMenus.IsOpen=true;
		  }
		});
	  }
	}

	public ICommand BackToMainMenuCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			_mainWindow.ModuleName.Content = "...";

			_mainWindow.grdNotification.Visibility=Visibility.Collapsed;
			_mainWindow.grdNotification.Tag="";
			try {
			 // if(_mainWindow.grdNotification.Tag!=null) {
				//throw new Exception("");
			 // }

			 // var dicInput = new Dictionary<string,object>();
			 // dicInput["userId"]=_user.UserID;

			 // var dicSend = new Dictionary<string,object>();
			 // dicSend.Add("command",AppConfig.enum_OnReceive.COUNT_MESSAGE.ToString());
			 // dicSend.Add("info",dicInput);

			 // var jsonSend = JsonConvert.SerializeObject(dicSend);
			 // var strStatus = "";
			 // strStatus = Transferencia.Client.SendToServer(jsonSend,_user.UserID.ToString());
			 // var reviced = JsonConvert.DeserializeObject<IDictionary>(strStatus);
			 // var statusTemp = reviced["status"].ToString();
			 // if(statusTemp!="1") {
				//throw new Exception("");
			 // }

			 // _mainWindow.grdNotification.Visibility=Visibility.Visible;
			 // _mainWindow.grdNotification.Tag=strStatus;
			 // _mainWindow.txtNotificationQuantity.Text=reviced["CountMessages"].ToString();

			} catch(Exception e) {
			  string str = e.Message;
			}

			{
			  var dicInput = new Dictionary<string,object>();
			  dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
							new MainMenuSphere_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(
							  ExcuteFromMainMenuSphereUC));

			  dicInput.Add("List<HamburgerMenuItem>",_mainWindow.LstMenus.Content);
			  dicInput.Add("int",_software);
			  if(_isServer==0) {
				dicInput["intIsServer"]=_isServer;

				//try {
				//  var colorTemp = new System.Drawing.Color();
				//  _bllPlugin.GetColorDrawingFromMediaBrush(ref colorTemp
				//	,_mainWindow.btnTempColorXanhNhat.Background);

				//  //string strHex = "#"
				//  //  +colorTemp.R.ToString("X2")+colorTemp.G.ToString("X2")+colorTemp.B.ToString("X2");
				//  string strHex6Char = ""
				//	+colorTemp.R.ToString("X2")+colorTemp.G.ToString("X2")+colorTemp.B.ToString("X2");
				//  dicInput["stringHex6Char"]=strHex6Char;

				//} catch(Exception e) {
				//  string str = e.Message;
				//}
			  }

			  string strAppName = "Master Test";
			  if(DicData.ContainsKey("stringAppName")) {
				strAppName=DicData["stringAppName"] as string;
			  }
			  dicInput.Add("string",strAppName.ToUpper());

			  _mainWindow.contnet.Children.Clear();
			  var menu = new MainMenuSphere(dicInput);
			  _mainWindow.contnet.Children.Add(menu);
			}
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ProfileCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(ServerSelected.IsServer == 1) {
			  IsTiling = true;
			  _isProFile = true;
			  OnPropertyChanged(nameof(ShowProFile));
			  _isChangePass = false;
			  OnPropertyChanged(nameof(ShowChangePass));
			  _mainWindow.contnet.Visibility = Visibility.Hidden;
			} else {
			  QTMessageBox.ShowNotify("Bạn không thể cập nhật thông tin cá nhân ở chế độ offline!");
			}
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ChangePassCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			IsTiling = true;
			_isProFile = false;
			OnPropertyChanged(nameof(ShowProFile));
			_isChangePass = true;
			OnPropertyChanged(nameof(ShowChangePass));
			_mainWindow.contnet.Visibility = Visibility.Hidden;

			_usersUpdatePass.OldPassword="";
			_usersUpdatePass.NewPassword="";
			_usersUpdatePass.AgainNewPassword="";
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand SaveProFileCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(CheckData(_usersUpdateProFile)) {
			  try {
				//DateTime dt;
				//DateTime.TryParseExact(_usersUpdateProFile.DOB,"dd/MM/yyyy",
				//  CultureInfo.InvariantCulture,DateTimeStyles.None,out dt);
				//User _userUpdate = new User {
				//  UserID = _user.UserID,
				//  Address = _usersUpdateProFile.Address.Trim(),
				//  Tel = _usersUpdateProFile.Tel,
				//  Surname = _usersUpdateProFile.Surname.Trim(),
				//  Name = _usersUpdateProFile.Name.Trim(),
				//  Password = "",
				//  DOB = dt,
				//  Gender = _usersUpdateProFile.Gender,
				//};

				//var strCase = _bllPlugin.UpdateInfoPersonal(_userUpdate.UserID,_key,_userUpdate);
				//var reviced = JsonConvert.DeserializeObject<IDictionary>(strCase);
				//var status = reviced["status"].ToString();
				//switch(status) {
				//  case "1":
				//	QTMessageBox.ShowNotify(reviced["success"].ToString());

				//	_usersUpdateProFile.Address=_usersUpdateProFile.Address.Trim();
				//	_usersUpdateProFile.Surname=_usersUpdateProFile.Surname.Trim();
				//	_usersUpdateProFile.Name=_usersUpdateProFile.Name.Trim();
				//	break;
				//  case "2":
				//	QTMessageBox.ShowNotify(reviced["success"].ToString());
				//	//Application.Restart();
				//	break;
				//  default:
				//	QTMessageBox.ShowNotify(reviced["error"].ToString());
				//	break;
				//}
			  } catch(Exception ex) {
				QTMessageBox.Show("Ngoại lệ",ex.ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
			  }

			  IsTiling = false;
			  _mainWindow.contnet.Visibility = Visibility.Visible;
			  _isProFile = false;
			  OnPropertyChanged("ShowProFile");
			  _isMain = true;
			  OnPropertyChanged("ShowMain");
			}
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand SaveChangePassCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(CheckDataChangePass(_usersUpdatePass)) {
			  var dicInput = new Dictionary<string,object>();
			  dicInput["string.strId"]=TupleIdNameAccount.Item1;
			  dicInput["string.strUserName"]=TupleIdNameAccount.Item2;
			  dicInput["string.strPassword"]=_bllPlugin.Base64Encode(_usersUpdatePass.NewPassword);

			  {
				var dicOutput = new Dictionary<string,object>();
				Exception exOutput = null;
				DALAccount.UpdatePasswordAccount(ref dicOutput,ref exOutput,dicInput);
				if(exOutput!=null) {
				  Log4Net.Error(exOutput.Message);
				  Log4Net.Error(exOutput.StackTrace);
				  ShowException(exOutput);
				  return;
				}

				string strKeyError = "string";
				if(dicOutput.ContainsKey(strKeyError)) {
				  QTMessageBox.ShowNotify(
					"Thao tác không thành công, bạn vui lòng thử lại!"
					,dicOutput[strKeyError] as string);
				  return;
				}
			  }

			  QTMessageBox.ShowNotify("THAO TÁC THÀNH CÔNG!");

			  System.Windows.Forms.Application.Restart();
			  Process.GetCurrentProcess().Kill();


			  // try {
			  ////var strCase = "";
			  ////if(ServerSelected.IsServer == 1)
			  ////  strCase = _bllPlugin.ChangePassWord(_usersUpdatePass.NewPassword,
			  ////	_usersUpdatePass.OldPassword,_key,_user.UserID,ServerSelected.IsServer);
			  ////else
			  ////  strCase = _bllPlugin.ChangePassWord(_usersUpdatePass.NewPassword);

			  ////var reviced = JsonConvert.DeserializeObject<IDictionary>(strCase);
			  ////var status = reviced["status"].ToString();
			  ////switch(status) {
			  ////  case "1":
			  ////	QTMessageBox.ShowNotify(reviced["success"].ToString());

			  ////	System.Windows.Forms.Application.Restart();
			  ////	Process.GetCurrentProcess().Kill();

			  ////	//_passText = _usersUpdatePass.NewPassword;
			  ////	//OnPropertyChanged("PasswordText");

			  ////	//_isChangePass = false;
			  ////	//OnPropertyChanged("ShowChangePass");

			  ////	//_isMain = true;
			  ////	//OnPropertyChanged("ShowMain");
			  ////	//IsTiling = false;
			  ////	//_mainWindow.contnet.Visibility = Visibility.Visible;

			  ////	//_usersUpdatePass.OldPassword = "";
			  ////	//_usersUpdatePass.NewPassword = "";
			  ////	//_usersUpdatePass.AgainNewPassword = "";
			  ////	break;
			  ////  case "2":
			  ////	QTMessageBox.ShowNotify(reviced["success"].ToString());
			  ////	//Application.Restart();
			  ////	break;
			  ////  default:
			  ////	QTMessageBox.ShowNotify(reviced["error"].ToString());
			  ////	break;
			  ////}
			  // } catch(Exception ex) {
			  //QTMessageBox.Show("Cảnh báo",ex.ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
			  // }

			  //var itm = new DIGILIB.Users();
			  //itm.UserID = _usersUpdateProFile.UserID;
			  //itm.Password = _usersUpdatePass.NewPassword;
			  //itm.Edit_Password();

			  //_userLogin.Password = _usersUpdatePass.NewPassword;
			  //OnPropertyChanged("SetUserLogin");
			  //InvicoMessageBox.Show("Thông báo", "Cập nhật thành công !", MessageBoxButton.OK, MessageBoxImage.Information);
			  //IsTiling = false;
			}
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ShowComputerManagementCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			//System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
			//psi.FileName="compmgmt.msc";
			//psi.Arguments= "/computer=" + m_ClickedMachine;
			//System.Diagnostics.Process.Start(psi);
			//System.Diagnostics.Process.Start("compmgmt.msc");
			System.Diagnostics.Process.Start("eventvwr.msc");
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ShowControlPanelCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			ShowComputerManagementCommand.Execute(null);

			var cplPath = System.IO.Path.Combine(Environment.SystemDirectory,"control.exe");
			System.Diagnostics.Process.Start(cplPath,"/name Microsoft.RegionalAndLanguageOptions");
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ActiveFocusUserControlCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			string strToolTipDefault = "Trang chính";
			_mainWindow.btnAvatar.Focus();
			if(_mainWindow.btnAvatar.Tag==null||(bool)_mainWindow.btnAvatar.Tag==false) {
			  _mainWindow.btnAvatar.Tag=true;
			  _mainWindow.btnBackToMain.ToolTip=strToolTipDefault+".";
			} else {
			  _mainWindow.btnAvatar.Tag=false;
			  _mainWindow.btnBackToMain.ToolTip=strToolTipDefault;
			}
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand KeyUpTxtPasswordCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(_mainWindow.ucLoginMaster.txtPassword.Text.Length!=1) {
			  return;
			}

			// set the cursor position to 2...
			SetSelection(_mainWindow.ucLoginMaster.passBox,1,0);

			// focus the control to update the selection
			_mainWindow.ucLoginMaster.passBox.Focus();
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ShowListNotificationCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			//_mainWindow.ModuleName.Content = "DANH SÁCH TIN NHẮN";
			//_mainWindow.grdNotification.Visibility=Visibility.Collapsed;

			//var dicInput = new Dictionary<string,object>();
			//dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
			//			  new ListMessages_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(
			//				ExcuteFromListMessagesUC));

			//var lstAllTupleMessages = new List<Tuple<Messages,string,string>>();
			//var lstAllTupleMessagesCoText = new List<Tuple<Messages,string,string>>();
			//if(_mainWindow.grdNotification.Tag!=null) {
			//  string strJson=_mainWindow.grdNotification.Tag.ToString();
			//  var reviced = JsonConvert.DeserializeObject<IDictionary>(strJson);
			//  var iLstTemp = (IList)reviced["List<Messages>"];
			//  foreach(var item in iLstTemp) {
			//	var mtemp= JsonConvert.DeserializeObject<Messages>(item.ToString());

			//	var rtbTemp = new System.Windows.Forms.RichTextBox();
			//	_bllPlugin.GetThongDiep(ref rtbTemp,mtemp);

			//	if(rtbTemp.Text!="") {
			//	  lstAllTupleMessagesCoText.Add(
			//		new Tuple<Messages,string,string>(mtemp,rtbTemp.Text,rtbTemp.Rtf));
			//	}
			//	lstAllTupleMessages.Add(
			//	  new Tuple<Messages, string, string>(mtemp,rtbTemp.Text,rtbTemp.Rtf));
			//  }
			//}
			//dicInput["List<Tuple<Messages,string,string>>lstAllTupleMessagesCoText"]=lstAllTupleMessagesCoText;
			//dicInput["List<Tuple<Messages,string,string>>lstAllTupleMessages"]=lstAllTupleMessages;
			//dicInput["intAll"]=lstAllTupleMessages.Count;
			//dicInput["intCoText"]=lstAllTupleMessagesCoText.Count;

			//_mainWindow.contnet.Children.Clear();
			//var menu = new ListMessages(dicInput);
			//_mainWindow.contnet.Children.Add(menu);
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand F1KeyUpCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(_mainWindow.btnAvatar.Tag==null||(bool)_mainWindow.btnAvatar.Tag==false) {
			  return;
			}

			intPressF1Count++;
			if(intPressF1Count > 2) {
			  //Open folder
			  string strPathFileLogToday = "";
			  _bllPlugin.GetPathFileLogToday(ref strPathFileLogToday);

			  intPressF1Count = 0;

			  ActiveFocusUserControlCommand.Execute(null);

			  string strFolderPath = System.IO.Path.GetDirectoryName(strPathFileLogToday);
			  if(!System.IO.Directory.Exists(strFolderPath)) {
				QTMessageBox.ShowNotify("Folder ở đường dẫn bạn chọn hiện không tồn tại!");
				return;
			  }

			  System.Diagnostics.Process.Start(strFolderPath);
			} else {
			  //Không làm gì cả
			}
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand CloseCommand {
	  get {
		return new DelegateCommand(p => {
		  SelectedItem = ModalSelection;
		  IsTiling = false;
		  _mainWindow.contnet.Visibility = Visibility.Visible;
		});
	  }
	}

	public ICommand OpenTeamviewQSCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			string strPathFileUnikey = System.Windows.Forms.Application.StartupPath
			+$"\\UltraViewer\\UltraViewer_Desktop.exe";
			if(!System.IO.File.Exists(strPathFileUnikey)) {
			  QTMessageBox.ShowNotify("Hiện tại chưa có file chạy để thực hiện thao tác này!");
			  return;
			}

			var arrayProcess = Process.GetProcesses();
			foreach(var mProcess in arrayProcess) {
			  string strName = mProcess.ProcessName.ToLower();
			  if(strName.Contains("ultraviewer_desktop")) {
				mProcess.Kill();
				//break;
				//return;
			  }
			}

			_bllPlugin.StartProcessAsAdmin(strPathFileUnikey);
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand OpenUnikeyCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			string strPathFileUnikey = System.Windows.Forms.Application.StartupPath
			+$"\\unikeyx32\\UniKeyNT.exe";
			if(!System.IO.File.Exists(strPathFileUnikey)) {
			  QTMessageBox.ShowNotify("Hiện tại chưa có file chạy để thực hiện thao tác này!");
			  return;
			}

			var arrayProcess = Process.GetProcesses();
			foreach(var mProcess in arrayProcess) {
			  string strName = mProcess.ProcessName.ToLower();
			  if(strName.Contains("unikey")) {
				mProcess.Kill();
				//break;
				//return;
			  }
			}

			_bllPlugin.StartProcessAsAdmin(strPathFileUnikey);
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			Log4Net.Error(ex.StackTrace);
			ShowException(ex);
		  }
		});
	  }
	}

	public ICommand ShowCheckSystemDialogCommand => new DelegateCommand(p => {
	  try {
		var dicInput = new Dictionary<string,object>();
		dicInput.Add("DELEGATE_VOID_IN_OTHER_USERCONTROL",
					  new CheckSystem_ViewModel.DELEGATE_VOID_IN_OTHER_USERCONTROL(ExcuteFromOtherUserControl));

		_mainWindow.ucLoginMaster.IsEnabled=false;

		var frm = new CheckSystem(dicInput);
		frm.WindowStartupLocation=WindowStartupLocation.CenterScreen;
		frm.Owner=Application.Current.MainWindow;
		frm.ShowDialog();

		_mainWindow.ucLoginMaster.IsEnabled=true;

		System.Windows.Forms.Application.Restart();
		System.Diagnostics.Process.GetCurrentProcess().Kill();

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	public ICommand LoadedCommand => new DelegateCommand(p => {
	  try {
		//string strPathFolderHelp = "";
		//if(_software == 16 || _software == 19 || _software == 26) {
		//  string strFolderName = "HelpI";
		//  strPathFolderHelp = System.Windows.Forms.Application.StartupPath
		//  +$"\\{strFolderName}";
		//}

		//if(_software == 20 || _software == 21 || _software == 27) {
		//  string strFolderName = "HelpM";
		//  strPathFolderHelp = System.Windows.Forms.Application.StartupPath
		//  +$"\\{strFolderName}";
		//}

		//if(!System.IO.Directory.Exists(strPathFolderHelp)) {
		//  QTMessageBox.ShowNotify(
		//	"Lỗi khởi động hệ thống, bạn vui lòng liên hệ bộ phận DVKH để được hỗ trợ!");
		//  BlnHideMain=true;
		//  _mainWindow.ucLoginMaster.IsEnabled=false;
		//  return;
		//}

		_mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.Focus();
		string strText = _mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.Text;
		if(strText.Length>0) {
		  _mainWindow.ucLoginMaster.gridTxtHintUserName.txtText.CaretIndex=strText.Length;
		}

	  } catch(Exception ex) {
		Log4Net.Error(ex.Message);
		Log4Net.Error(ex.StackTrace);
		ShowException(ex);
	  }
	});

	#endregion

  }
}
