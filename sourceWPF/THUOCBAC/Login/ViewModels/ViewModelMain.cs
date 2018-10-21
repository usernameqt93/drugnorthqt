using Invico.MessageBox;
using log4net;
using Login.View;
using QTTool.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Login.ViewModels {
  public class ViewModelMain:ModelBase {

	#region === Defines ===

	private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	internal MainWindow _mainWindow;
	private int _software = 16;
	private string _version = "1.0.0.0";
	private string _dateTime = "";

	//public HamburgerMenuItem controlSupervision;

	//readonly BLLLogin _login = new BLLLogin();
	//readonly BLLChangePass _changePass = new BLLChangePass();
	//readonly BLLHoSoCaNhan _object = new BLLHoSoCaNhan();

	private Version _versionAppExe = new Version();

	//public static User _user = new User();
	//public static string _key = "";
	//public static int _isServer = 0;
	//private int _countDisconnect = 0;
	//private string _userText = "";
	//private string _passText = "";
	//private ModelUsers _userLogin;
	//private ModelUsers _usersUpdateProFile;
	//private ModelChangePass _usersUpdatePass;
	//private string _modalSelection;
	//private string _selectedItem;
	//private bool _isModal = false, _isProFile = false, _isChangePass = false, _isLogin = true, _isMain = false;
	//private List<int> _lstMenuID = new List<int>();
	//private static List<Dictionary<int,List<string>>> _lstSubMenuNames = new List<Dictionary<int,List<string>>>();
	//private static List<Dictionary<int,List<AvailableArrayProcessor>>> _lstModules = new List<Dictionary<int,List<AvailableArrayProcessor>>>();
	////readonly static BLLMain MainConfig = new BLLMain();
	//private List<MenuModel> _lstMenuItems = new List<MenuModel>();

	//private System.Windows.Forms.Timer TimerTextChanged = new System.Windows.Forms.Timer() {
	//  Interval=3000
	//};

	private Dictionary<string,object> DicData;
	private Tuple<bool,string,string,int> TupleSetting;
	private string StrPathLoadDll = "";

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(Dictionary<string,object> dic);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private string StrOldPassword;

	//#region === Những thuộc tính binding ===

	//private Client _licenseInfo = new Client();

	//public Client LicenseInfo {
	//  get { return _licenseInfo; }
	//  set { _licenseInfo = value; OnPropertyChanged("LicenseInfo"); }
	//}

	//public bool ShowLogin {
	//  get { return _isLogin; }
	//  set {
	//	_isLogin = value;
	//	OnPropertyChanged("ShowLogin");
	//  }
	//}
	//public bool ShowMain {
	//  get { return _isMain; }
	//  set {
	//	_isMain = value;
	//	OnPropertyChanged("ShowMain");
	//  }
	//}
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

	//private List<ServerModel> _lstServer = new List<ServerModel>();
	///// <summary>
	///// Danh sách server
	///// </summary>
	//public List<ServerModel> LstServer {
	//  get { return _lstServer; }
	//  set {
	//	_lstServer = value;
	//	OnPropertyChanged("LstServer");
	//  }
	//}

	//private ServerModel _serverSelected;
	//public ServerModel ServerSelected {
	//  get {
	//	return _serverSelected;
	//  }
	//  set {
	//	_serverSelected = value;
	//	OnPropertyChanged("ServerSelected");
	//  }
	//}

	//private bool _checkSavedAccount;
	//private string StrStatusLicense = "TrialExpired";
	//private LicenseState EnumLicenseState;

	///// <summary>
	///// Trạng thái lưu thông tin tài khoản
	///// </summary>
	//public bool CheckSavedAccount {
	//  get {
	//	return _checkSavedAccount;
	//  }
	//  set {
	//	_checkSavedAccount = value;
	//	OnPropertyChanged("CheckSavedAccount");
	//  }
	//}

	//public object SetUserProFile {
	//  get {
	//	return this._usersUpdateProFile;
	//  }
	//  set {
	//	_usersUpdateProFile = value as ModelUsers;
	//	OnPropertyChanged("SetUserProFile");
	//  }
	//}
	//public object SetUserPass {
	//  get {
	//	return this._usersUpdatePass;
	//  }
	//  set {
	//	_usersUpdatePass = value as ModelChangePass;
	//	OnPropertyChanged("SetUserPass");
	//  }
	//}
	//public object SetUserLogin {
	//  get {
	//	return this._userLogin;
	//  }
	//  set {
	//	_userLogin = value as ModelUsers;
	//	OnPropertyChanged("SetUserLogin");
	//  }
	//}
	//public string SelectedItem {
	//  get { return _selectedItem; }
	//  set {
	//	_selectedItem = value;
	//	OnPropertyChanged("SelectedItem");
	//  }
	//}
	//public string ModalSelection {
	//  get { return _modalSelection; }
	//  set {
	//	_modalSelection = value;
	//	OnPropertyChanged("ModalSelection");
	//  }
	//}
	//public bool IsTiling {
	//  get { return _isModal; }
	//  set {
	//	_isModal = value;
	//	OnPropertyChanged("IsTiling");
	//  }
	//}
	//public bool ShowProFile {
	//  get { return _isProFile; }
	//  set {
	//	_isProFile = value;
	//	OnPropertyChanged("ShowProFile");
	//  }
	//}
	//public bool ShowChangePass {
	//  get { return _isChangePass; }
	//  set {
	//	_isChangePass = value;
	//	OnPropertyChanged("ShowChangePass");
	//  }
	//}

	//ICommand clickComand { get; set; }
	//public ICommand LoginCommand { get; set; }
	//public ICommand LogoutCommand { get; set; }
	//public ICommand BackSpaceCommand { get; set; }

	//#endregion

	#endregion

	#region === Handle ===

	public ViewModelMain(MainWindow _viewMain,Dictionary<string,object> dicData) {
	  _mainWindow = _viewMain;
	  //_userLogin = new ModelUsers();
	  //_usersUpdateProFile = new ModelUsers();
	  //_usersUpdatePass = new ModelChangePass();
	  //LoginCommand = new View.RelayCommand<object>((p) => Search(_userText,_passText));
	  //LogoutCommand = new View.RelayCommand<object>((p) => LogOut(_userText));
	  //BackSpaceCommand = new View.RelayCommand<object>((p) => PressBackSpace(_passText));

	  // if(ConfigurationManager.AppSettings["Software"] != null) {
	  //_software = int.Parse(ConfigurationManager.AppSettings["Software"]);
	  // }

	  // if(ConfigurationManager.AppSettings["Version"] != null) {
	  //_version = ConfigurationManager.AppSettings["Version"];
	  // } else {
	  //_version = Assembly.GetExecutingAssembly().GetName().Version + "";
	  // }

	  // if(ConfigurationManager.AppSettings["DateTime"] != null) {
	  //_dateTime = ConfigurationManager.AppSettings["DateTime"];
	  // } else {
	  //_dateTime = DateTime.Now.ToString("dd'/'MM'/'yyyy");
	  // }

	  //DicData=dicData;
	  //_viewMain.windowMain.Title=dicData["stringTitle"] as string;
	  //StrPathLoadDll =dicData["stringPath"] as string;
	  //Tuple<int,string,string> tuple = dicData["Tuple<int,string,string><_software,_version,_dateTime>"] as Tuple<int,string,string>;
	  //_software=tuple.Item1;
	  //_version=tuple.Item2;
	  //_dateTime=tuple.Item3;
	  //ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)dicData["DELEGATE_VOID_IN_OTHER_USERCONTROL"];

	  //TupleSetting=dicData["Tuple<bool,string,string,int><checkSaveLoginInfo,userName,passUser,isServer>"] as Tuple<bool,string,string,int>;

	  //LoadForm();
	}

	#endregion

	#region === Các hàm chung ===

	//private bool CheckData(ModelUsers users) {
	//  if(string.IsNullOrEmpty(users.Name) || string.IsNullOrEmpty(users.Surname)) {
	//	InvicoMessageBox.ShowNotify("Họ tên người dùng không được bỏ trống!");
	//	return false;
	//  }

	//  if(users.Name.Trim().Equals("") || users.Surname.Trim().Equals("")) {
	//	InvicoMessageBox.ShowNotify("Họ tên người dùng không được bỏ trống!");
	//	return false;
	//  }

	//  if(users.Surname.Length>20) {
	//	InvicoMessageBox.ShowNotify("Họ không được lớn hơn 20 kí tự!");
	//	return false;
	//  }

	//  if(users.Name.Length>20) {
	//	InvicoMessageBox.ShowNotify("Tên không được lớn hơn 20 kí tự!");
	//	return false;
	//  }

	//  var _regexSpecial = new Regex(@"[!@#$%^&*\(\)\-\+=~`><\?\?""/.,:;\'{}\[\]|\\]");
	//  if(_regexSpecial.IsMatch(users.Name + users.Surname)) {
	//	InvicoMessageBox.Show("Cảnh báo","Họ tên người dùng không được chứa ký tự đặc biệt!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	return false;
	//  }

	//  if(string.IsNullOrEmpty(users.DOB)) {
	//	InvicoMessageBox.Show("Cảnh báo","Thông tin ngày sinh không được bỏ trống!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	return false;
	//  }
	//  string[] formats = { "d/MM/yyyy","dd/MM/yyyy" };
	//  var dt = DateTime.Now;
	//  var now = DateTime.Today;
	//  var isValidFormat = DateTime.TryParseExact(users.DOB,formats,new CultureInfo("en-US"),DateTimeStyles.None,out dt);
	//  if(!isValidFormat) {
	//	InvicoMessageBox.Show("Cảnh báo","Thông tin ngày sinh không đúng định dạng!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	return false;
	//  }

	//  if(dt.Year > now.Year) {
	//	InvicoMessageBox.Show("Cảnh báo","Thông tin ngày sinh không hợp lệ!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	return false;
	//  }
	//  var age = now.Year - dt.Year;
	//  if(DateTime.Now.Month < dt.Month || (DateTime.Now.Month == dt.Month && DateTime.Now.Day < dt.Day))
	//	age--;

	//  if(age < 6 || age > 60) {
	//	InvicoMessageBox.Show("Cảnh báo","Thông tin ngày sinh không hợp lệ!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	return false;
	//  }

	//  var isValidInput = new Regex(@"^\d{9,11}$");
	//  var strPhone = users.Tel;
	//  if(!isValidInput.IsMatch(strPhone)) {
	//	InvicoMessageBox.Show("Cảnh báo","Thông tin số điện thoại không hợp lệ!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	return false;
	//  }

	//  return true;
	//}

	//public void Execute(object parameter) {
	//  var control = parameter as HamburgerMenuItem;

	//  //if(_licenseInfo.State == LicenseState.OK || _licenseInfo.State == LicenseState.InTrialPeriod) {
	//  if(StrStatusLicense.Equals("OK")|| StrStatusLicense.Equals("InTrialPeriod")) {
	//	//Sản phẩm đã được kích hoạt hoặc đang trong t/g dùng thử. Tiếp tục cho sử dụng bình thường
	//  } else {
	//	//Sản phẩm đã hết t/g sử dụng, hoặc key đc cấp và key phản hồi không khớp. Chặn sử dụng các chức năng khác, trừ chức năng đăng ký bản quyền
	//	if(control.Text == "Trợ giúp" || control.Text == "Đăng ký bản quyền" || control.Text == "Thông tin sản phẩm" || control.Text == "Hướng dẫn sử dụng") {
	//	  //Cho phép thao tác
	//	} else {
	//	  return;
	//	}
	//  }

	//  if(_software==19) {
	//	if(control.Text.ToUpper().Equals(("Giám sát thi").ToUpper())) {
	//	  controlSupervision = control;
	//	}
	//	if(!control.Text.ToUpper().Equals(("Giám sát thi").ToUpper()) && controlSupervision != null) {

	//	  var tag = controlSupervision.Tag;

	//	  var processor = tag as AvailableArrayProcessor;
	//	  if(processor != null)
	//		processor.Instance.Dispose();

	//	}
	//  }

	//  _mainWindow.ModuleName.Content = control.Text.ToUpper();
	//  if(control.ParentID != 0) {
	//	var tag = control.Tag;

	//	var processor = tag as AvailableArrayProcessor;
	//	_mainWindow.contnet.Children.Clear();
	//	IDictionary<string,object> dicData = new Dictionary<string,object>();

	//	dicData.Add("nameSubmenu",control.Text);

	//	dicData.Add("LicenseInfo",LicenseInfo);
	//	dicData.Add("select",control.TabIndex);
	//	dicData.Add("software",_software);
	//	dicData.Add("Version",_version);

	//	if(DicData.ContainsKey("VersionAppExe")) {
	//	  dicData.Add("VersionAppExe",DicData["VersionAppExe"] as Version);
	//	}

	//	dicData.Add("DateTime",_dateTime);
	//	dicData.Add("User",ViewModelMain._user);
	//	dicData.Add("Key",ViewModelMain._key);
	//	dicData.Add("isServer",ViewModelMain._isServer);
	//	dicData.Add("content",_mainWindow.contnet);
	//	dicData.Add("register","_ktIsregister");

	//	dicData.Add("mainWindow",_mainWindow.windowMain);

	//	var config = new Config();
	//	Tuple<string,string> tupleInfo = new Tuple<string,string>(config.TDPhongso,config.TDTenTruong);

	//	dicData.Add("Tuple<string,string>",tupleInfo);

	//	if(processor != null)
	//	  processor.Instance.Process(dicData); // processing...
	//  } else {
	//	foreach(var itm in _mainWindow.LstMenus.Content) {
	//	  if(itm.ParentID == control.ItemID)
	//		itm.Visibility = itm.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
	//	  else if(itm.ParentID != 0 & itm.Lever != 0)
	//		itm.Visibility = Visibility.Collapsed;
	//	}
	//  }
	//}

	//public bool CanExecute(object parameter) {
	//  return true;
	//}

	//private void RunCommand(byte status,string cmd = "shutdown -t 0 -r -f") {
	//  switch(status) {
	//	case 1: {
	//		ExecuteCommand("@ECHO OFF");
	//		ExecuteCommand("ipconfig /flushdns");
	//	  }
	//	  break;
	//	case 2: {
	//		ExecuteCommand("@ECHO OFF");
	//		ExecuteCommand(cmd);
	//	  }
	//	  break;
	//	default: {
	//		ExecuteCommand("@ECHO OFF");
	//		ExecuteCommand(cmd);
	//	  }
	//	  break;
	//  }
	//}

	//private static void ExecuteCommand(string command,bool stt = true) {
	//  int exitCode;
	//  ProcessStartInfo processInfo;
	//  Process process;

	//  processInfo = new ProcessStartInfo("cmd.exe","/c " + command);
	//  processInfo.CreateNoWindow = true;
	//  processInfo.UseShellExecute = false;
	//  // *** Redirect the output ***
	//  processInfo.RedirectStandardError = true;
	//  processInfo.RedirectStandardOutput = true;

	//  process = Process.Start(processInfo);
	//  process.WaitForExit();

	//  // *** Read the streams ***
	//  // Warning: This approach can lead to deadlocks, see Edit #2

	//  var output = process.StandardOutput.ReadToEnd();
	//  var error = process.StandardError.ReadToEnd();

	//  exitCode = process.ExitCode;
	//  if(stt) {
	//	Console.WriteLine("output>> " + (String.IsNullOrEmpty(output) ? "OK" : output));
	//	Console.WriteLine("error>> " + (String.IsNullOrEmpty(error) ? "(none)" : error));
	//	Console.WriteLine("ExitCode: " + exitCode,"ExecuteCommand");
	//  }
	//  process.Close();
	//}

	//private bool CheckDataChangePass(ModelChangePass users) {

	//  if(string.IsNullOrEmpty(users.OldPassword)) {
	//	InvicoMessageBox.Show("Cảnh báo","Bạn cần nhập mật khẩu cũ!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	_mainWindow.TxtPassOld.Focus();
	//	return false;
	//  }

	//  if(string.IsNullOrEmpty(users.NewPassword)) {
	//	InvicoMessageBox.Show("Cảnh báo","Bạn cần nhập mật khẩu mới!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	_mainWindow.TxtPassNew.Focus();
	//	return false;
	//  }

	//  if(string.IsNullOrEmpty(users.AgainNewPassword)) {
	//	InvicoMessageBox.Show("Cảnh báo","Bạn cần nhập lại mật khẩu mới!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	_mainWindow.TxtPassNewAgain.Focus();
	//	return false;
	//  }

	//  if(users.AgainNewPassword != users.NewPassword) {
	//	InvicoMessageBox.Show("Cảnh báo","Mật khẩu mới chưa khớp!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	_mainWindow.TxtPassNewAgain.Focus();
	//	return false;
	//  }

	//  if(users.OldPassword != _passText) {
	//	InvicoMessageBox.Show("Cảnh báo","Mật khẩu cũ không chính xác!",MessageBoxButton.OK,MessageBoxImage.Warning);
	//	_mainWindow.TxtPassOld.Focus();
	//	return false;
	//  }

	//  if(users.AgainNewPassword.Equals(_passText)) {
	//	InvicoMessageBox.ShowNotify("Mật khẩu mới không được trùng với mật khẩu cũ!");
	//	_mainWindow.TxtPassNew.Focus();
	//	return false;
	//  }

	//  return true;
	//}

	///// <summary>
	///// Kiểm tra bản quyền - Ngô Văn Ngọc
	///// </summary>
	//private void CheckLicense() {
	//  string test = _licenseInfo.State.ToString();

	//  if(_licenseInfo.State == LicenseState.OK || _licenseInfo.State == LicenseState.InTrialPeriod) {
	//	//Trường hợp này sản phẩm đã được kích hoạt hoặc đang trong t/g dùng thử, cho tiếp tục sử dụng bình thường
	//  } else if(_licenseInfo.State == LicenseState.TrialExpired) {
	//	//Trường hợp này là key dùng thử đã hết t/g dùng thử.
	//	InvicoMessageBox.ShowWarning("Bạn đã hết thời hạn dùng thử phần mềm!");

	//  } else if(_licenseInfo.State == LicenseState.ActivationExpired) {
	//	//Trường hợp này là key kích hoạt đã hết thời hạn sử dụng.
	//	InvicoMessageBox.ShowWarning("Bạn đã hết thời hạn sử dụng phần mềm!");
	//  } else if(_licenseInfo.State == LicenseState.ActivationNeeded) {
	//	//Mã đăng ký có tồn tại, có hợp lệ nhưng yêu cầu phải kích hoạt thủ công
	//	InvicoMessageBox.ShowWarning("Mã kích hoạt sản phẩm lỗi! Bạn cần kích hoạt lại sản phẩm để sử dụng!");
	//  }
	//}

	///// <summary>
	///// Kiểm tra bản quyền - Phạm Quốc Tuấn
	///// </summary>
	//private void CheckLicenseApp() {
	//  //string test = _licenseInfo.State.ToString();
	//  StrStatusLicense="TrialExpired";
	//  EnumLicenseState=_licenseInfo.State;

	//  string strAppName = "Master Test";
	//  if(DicData.ContainsKey("stringAppName")) {
	//	strAppName=DicData["stringAppName"] as string;
	//  }
	//  _mainWindow.lblInfoAppLicense.Content="Bạn đang dùng \""+strAppName+"\" bản chưa đăng ký mã bản quyền";

	//  if(EnumLicenseState == LicenseState.TrialExpired) {
	//	//Trường hợp này là key dùng thử đã hết t/g dùng thử.
	//	StrStatusLicense="TrialExpired";
	//	InvicoMessageBox.ShowWarning("Bạn đã hết thời hạn dùng thử phần mềm!");
	//	return;
	//  }

	//  if(EnumLicenseState == LicenseState.ActivationExpired) {
	//	//Trường hợp này là key kích hoạt đã hết thời hạn sử dụng.
	//	StrStatusLicense="ActivationExpired";
	//	InvicoMessageBox.ShowWarning("Bạn đã hết thời hạn sử dụng phần mềm!");
	//	return;
	//  }

	//  if(EnumLicenseState == LicenseState.ActivationNeeded) {
	//	//Mã đăng ký có tồn tại, có hợp lệ nhưng yêu cầu phải kích hoạt thủ công
	//	StrStatusLicense="ActivationNeeded";
	//	InvicoMessageBox.ShowWarning("Mã kích hoạt sản phẩm lỗi! Bạn cần kích hoạt lại sản phẩm để sử dụng!");
	//	return;
	//  }

	//  if(EnumLicenseState == LicenseState.InTrialPeriod) {
	//	//Trường hợp này sản phẩm đang trong t/g dùng thử, cho tiếp tục sử dụng bình thường
	//	StrStatusLicense="InTrialPeriod";
	//	return;
	//  }

	//  if(EnumLicenseState == LicenseState.OK) {
	//	//Trường hợp này sản phẩm đã được kích hoạt, cho tiếp tục sử dụng bình thường
	//	StrStatusLicense="OK";
	//	_mainWindow.lblInfoAppLicense.Content=(new Config()).TDTruong;
	//	return;
	//  }


	//}

	//public void Search(string strUser,string strPass) {
	//  // if(strPass.Trim().Equals("")) {
	//  //InvicoMessageBox.ShowNotify("Thông tin đăng nhập không đầy đủ!");
	//  //return;
	//  // }
	//  if(strPass.Length==0||strUser.Trim().Equals("")) {
	//	InvicoMessageBox.ShowNotify("Thông tin đăng nhập không đầy đủ!");
	//	return;
	//  }
	//  if(!string.IsNullOrEmpty((strUser + strPass).Trim())) {
	//	var key = "";
	//	var mes = "";
	//	var status = "";
	//	status = (new BLLPlugin()).OnLogin(_software,strUser.Trim(),strPass.Trim(),ServerSelected.IsServer,ref _user,ref key,ref mes);
	//	//if(_software==19) {
	//	//  status = (new BLLPlugin()).OnLogin(_software,strUser.Trim(),strPass.Trim(),ServerSelected.IsServer,ref _user,ref key,ref mes);
	//	//} else {
	//	//  status = (new BLLPlugin()).OnLogin(strUser.Trim(),strPass.Trim(),ServerSelected.IsServer,ref _user,ref key,ref mes);
	//	//}

	//	_usersUpdateProFile.UserName = _user.Username;
	//	_usersUpdateProFile.Name = _user.Name;
	//	_usersUpdateProFile.Surname = _user.Surname;

	//	var strDateTime = "";
	//	if(_user.DOB.Day < 10) {
	//	  strDateTime += "0" + _user.DOB.Day;
	//	} else {
	//	  strDateTime += _user.DOB.Day;
	//	}
	//	if(_user.DOB.Month < 10) {
	//	  strDateTime += "/0" + _user.DOB.Month;
	//	} else {
	//	  strDateTime += "/" + _user.DOB.Month;
	//	}
	//	strDateTime += "/" + _user.DOB.Year;

	//	_usersUpdateProFile.DOB = strDateTime;

	//	_usersUpdateProFile.Gender = _user.Gender;
	//	_usersUpdateProFile.Tel = _user.Tel;
	//	_usersUpdateProFile.Address = _user.Address;
	//	_usersUpdateProFile.GroupID = _user.GroupID;

	//	switch(_usersUpdateProFile.GroupID) {
	//	  case 7:
	//		_usersUpdateProFile.GroupName = "Quản trị hệ thống";
	//		break;
	//	  case 6:
	//		_usersUpdateProFile.GroupName = "Admin sở";
	//		break;
	//	  case 5:
	//		_usersUpdateProFile.GroupName = "Admin phòng";
	//		break;
	//	  case 4:
	//		_usersUpdateProFile.GroupName = "Admin trường";
	//		break;
	//	  case 3:
	//		_usersUpdateProFile.GroupName = "Cán bộ";
	//		break;
	//	  case 2:
	//		_usersUpdateProFile.GroupName = "Giáo viên";
	//		break;
	//	  case 1:
	//		_usersUpdateProFile.GroupName = "Học sinh";
	//		break;
	//	}

	//	_usersUpdateProFile.MuInfo = _user.MUInfo;
	//	OnPropertyChanged("SetUserProFile");

	//	switch(status) {
	//	  case "ok":
	//		//check bản quyền sản phẩm
	//		CheckLicenseApp();

	//		//MsgBox.Show(mes, "Thông báo", MsgBox.Buttons.OK, MsgBox.Icon.Info);
	//		_countDisconnect = 0;

	//		if(CheckSavedAccount) {
	//		  //WindowMain.Properties.Settings.Default.userName = strUser;
	//		  //WindowMain.Properties.Settings.Default.passUser = (new BLLPlugin()).Base64Encode(strPass);
	//		  //WindowMain.Properties.Settings.Default.isServer = _serverSelected.IsServer;
	//		  //WindowMain.Properties.Settings.Default.checkSaveLoginInfo = true;
	//		  //WindowMain.Properties.Settings.Default.Save();

	//		  SaveSettings(ref DicData,ref TupleSetting,strUser,(new BLLPlugin()).Base64Encode(strPass),_serverSelected.IsServer,true);
	//		  _isServer = _serverSelected.IsServer;
	//		} else {
	//		  //WindowMain.Properties.Settings.Default.userName = string.Empty;
	//		  //WindowMain.Properties.Settings.Default.passUser = string.Empty;
	//		  //WindowMain.Properties.Settings.Default.isServer = _serverSelected.IsServer;
	//		  //WindowMain.Properties.Settings.Default.checkSaveLoginInfo = false;
	//		  //WindowMain.Properties.Settings.Default.Save();

	//		  SaveSettings(ref DicData,ref TupleSetting,string.Empty,string.Empty,_serverSelected.IsServer,false);
	//		  _isServer = _serverSelected.IsServer;
	//		}

	//		LoadData();

	//		DateTime dtLoginTimeGanNhat = (_isServer==0) ? DateTime.Now : _user.LoginTime;
	//		ShowInfoUserLogin(strUser,dtLoginTimeGanNhat);

	//		_isLogin = false;
	//		OnPropertyChanged("ShowLogin");
	//		_isMain = true;
	//		OnPropertyChanged("ShowMain");

	//		//Hide();
	//		break;
	//	  case "notok":
	//		InvicoMessageBox.ShowNotify(mes);
	//		break;
	//	  case "logout":
	//		InvicoMessageBox.ShowNotify(mes);
	//		//Application.Restart();
	//		break;
	//	  case "disconnect":
	//		InvicoMessageBox.ShowNotify(mes);
	//		_countDisconnect++;
	//		break;
	//	  case "exits":
	//		RunCommand(2,mes);
	//		break;
	//	  case "error":
	//		InvicoMessageBox.ShowNotify(mes);
	//		break;
	//	}
	//  } else {
	//	InvicoMessageBox.ShowNotify("Thông tin đăng nhập không đầy đủ!");
	//	return;
	//  }
	//}

	//private void ShowInfoUserLogin(string username,DateTime now) {
	//  //_mainWindow.txtHelloUser.Content="Xin chào, "+username;
	//  _mainWindow.txtHelloUser.Text="Xin chào, "+username;
	//  _mainWindow.txtTimeLogin.Content="Thời gian đăng nhập: "+now.ToString("dd/MM/yyyy HH:mm:ss");
	//}

	//private void SaveSettings(ref Dictionary<string,object> dicData,ref Tuple<bool,string,string,int> tupleSetting
	//  ,string strUser,string strPass,int isServer,bool blnCheckSaveLogin) {
	//  tupleSetting=new Tuple<bool,string,string,int>(
	//	blnCheckSaveLogin,strUser,strPass,isServer
	//	);
	//  dicData.Remove("Tuple<bool,string,string,int><checkSaveLoginInfo,userName,passUser,isServer>");
	//  dicData.Add("Tuple<bool,string,string,int><checkSaveLoginInfo,userName,passUser,isServer>",tupleSetting);
	//  SaveSettingsToProperties(strUser,strPass,isServer,blnCheckSaveLogin);
	//}

	//private void SaveSettingsToProperties(string strUser,string strPass,int isServer,bool blnCheckSaveLogin) {
	//  if(ExcuteInOtherUserControl!=null) {
	//	Dictionary<string,object> dic = new Dictionary<string,object>();
	//	dic.Add("stringUser",strUser);
	//	dic.Add("stringPass",strPass);
	//	dic.Add("int",isServer);
	//	dic.Add("bool",blnCheckSaveLogin);

	//	ExcuteInOtherUserControl(dic);
	//  }
	//}

	//private void LoadData() {
	//  _lstMenuID.Clear();
	//  _lstSubMenuNames.Clear();
	//  _lstModules.Clear();
	//  _mainWindow.LstMenus.Content.Clear();
	//  _lstMenuItems.Clear();

	//  List<int> lstRuleOfUser = new List<int>();

	//  if(_isServer == 0) {
	//	for(int i = 0;i < 100;i++) {
	//	  lstRuleOfUser.Add(i);
	//	}
	//  } else {
	//	foreach(var rule in _user.LstRules) {
	//	  lstRuleOfUser.Add(rule.RuleID);
	//	}

	//	//Add thêm các rule trợ giúp, đăng ký bản quyền, xem thông tin sp
	//	for(int i = 87;i < 90;i++) {
	//	  lstRuleOfUser.Add(i);
	//	}

	//	//Thêm quyền quản lý môn chung nếu tài khoản thuộc nhóm superadmin
	//	if(_user.GroupID == 7) {
	//	  lstRuleOfUser.Add(90);
	//	}

	//	if(_software==19) {
	//	  #region Fake rule 60 63 cho phan thong ke bao cao - PhamQuocTuan
	//	  // if(!lstRuleOfUser.Contains(60)) {
	//	  //lstRuleOfUser.Add(60);
	//	  // }
	//	  // if(!lstRuleOfUser.Contains(63)) {
	//	  //lstRuleOfUser.Add(63);
	//	  // }
	//	  // lstRuleOfUser.Sort();
	//	  #endregion
	//	}
	//  }

	//  bool server = _isServer == 0 ? false : true;

	//  //string pathTemp = string.Empty;
	//  //if()

	//  _mainWindow.LstMenus.Content.Clear();
	//  _mainWindow.contnet.Children.Clear();
	//  clickComand = null;

	//  //MainConfig.LoadPlugins(lstRuleOfUser, ref _lstMenuItems, server, @"PlugIns");
	//  //(new BLLPlugin()).LoadPlugins(lstRuleOfUser,ref _lstMenuItems,server,@"Tes\PlugIns");
	//  (new BLLPlugin()).LoadPlugins(_software,lstRuleOfUser,ref _lstMenuItems,server,StrPathLoadDll);

	//  clickComand = new View.RelayCommand<object>(Execute,CanExecute);
	//  var k = 0;
	//  foreach(var menuItems in _lstMenuItems) {
	//	if(menuItems.LstMenuChilds.Count <= 0) {
	//	  continue;
	//	}

	//	if(menuItems.LstMenuChilds.Count == 1) {
	//	  var itmSubMenu = new HamburgerMenuItem();
	//	  var sourceSub = new BitmapImage();
	//	  sourceSub.BeginInit();
	//	  //sourceSub.UriSource = new Uri(BLLMain.LoadIcon(menuItems.ID),UriKind.Relative);
	//	  sourceSub.UriSource = new Uri(@"/Assets/" + menuItems.LstMenuChilds[0].IconFileName,UriKind.RelativeOrAbsolute);
	//	  sourceSub.DecodePixelHeight = 32;
	//	  sourceSub.DecodePixelWidth = 32;
	//	  sourceSub.EndInit();
	//	  itmSubMenu.Icon = sourceSub;
	//	  //itmSubMenu.Text = menuItems.Name;
	//	  itmSubMenu.Text = menuItems.LstMenuChilds[0].NameItem;

	//	  if(itmSubMenu.Text.Equals("Quản lý tổ chức thi")) {
	//		itmSubMenu.Text = "Tổ chức thi";
	//	  }

	//	  itmSubMenu.SelectionCommand = clickComand;
	//	  //itmSubMenu.Tag = null;
	//	  itmSubMenu.Tag = menuItems.LstMenuChilds[0].Tag;
	//	  itmSubMenu.ParentID = menuItems.ID;
	//	  //itmSubMenu.ItemID = menuItems.ID;
	//	  itmSubMenu.Lever = 0;
	//	  itmSubMenu.SelectionCommandParameter = itmSubMenu;
	//	  _mainWindow.LstMenus.Content.Add(itmSubMenu);

	//	  k++;
	//	  continue;
	//	}

	//	var itmMenu = new HamburgerMenuItem();
	//	var source = new BitmapImage();
	//	source.BeginInit();
	//	source.UriSource = new Uri((new BLLPlugin()).LoadIcon(menuItems.ID,_software),UriKind.Relative);
	//	source.DecodePixelHeight = 32;
	//	source.DecodePixelWidth = 32;
	//	source.EndInit();
	//	itmMenu.Icon = source;
	//	itmMenu.Text = menuItems.Name;
	//	itmMenu.SelectionCommand = clickComand;
	//	itmMenu.Tag = null;
	//	itmMenu.ItemID = menuItems.ID;
	//	itmMenu.Lever = 0;
	//	itmMenu.SelectionCommandParameter = itmMenu;
	//	_mainWindow.LstMenus.Content.Add(itmMenu);

	//	for(int i = 0;i < menuItems.LstMenuChilds.Count;i++) {
	//	  if(_user.GroupID == 7 && Convert.ToInt32(menuItems.LstMenuChilds[i].Tag.Instance.Attributes.Rules.Split('|')[0]) == 90) {
	//		menuItems.LstMenuChilds[i].NameItem = "Quản lý môn chung";
	//	  }

	//	  var itmSubMenu = new HamburgerMenuItem();
	//	  var sourceSub = new BitmapImage();
	//	  sourceSub.BeginInit();
	//	  sourceSub.UriSource = new Uri(@"/Assets/" + menuItems.LstMenuChilds[i].IconFileName,UriKind.RelativeOrAbsolute);
	//	  sourceSub.DecodePixelHeight = 22;
	//	  sourceSub.DecodePixelWidth = 22;
	//	  sourceSub.EndInit();
	//	  itmSubMenu.Icon = sourceSub;
	//	  itmSubMenu.Text = menuItems.LstMenuChilds[i].NameItem;
	//	  itmSubMenu.SelectionCommand = clickComand;
	//	  itmSubMenu.Tag = menuItems.LstMenuChilds[i].Tag;
	//	  itmSubMenu.Visibility = Visibility.Collapsed;
	//	  itmSubMenu.ParentID = menuItems.ID;
	//	  itmSubMenu.TabIndex = i + 1;
	//	  itmSubMenu.Lever = 1;
	//	  itmSubMenu.SelectionCommandParameter = itmSubMenu;

	//	  //Nếu người dùng đã đăng ký bản quyền thì không hiển thị menu đăng ký nữa
	//	  if(itmSubMenu.Text.Equals("Đăng ký bản quyền")&&EnumLicenseState == LicenseState.OK) {
	//		continue;
	//	  }

	//	  _mainWindow.LstMenus.Content.Add(itmSubMenu);
	//	}
	//	k++;
	//  }
	//  SetDefault();
	//}

	//private void SetDefault() {
	//  var lstModules = _lstModules.Where(x => x.ContainsKey((int)AppConfig.enum_ParentFunction.BAOCAO)).ToList();
	//  var processor = (lstModules.Count > 0) ? lstModules[0][(int)AppConfig.enum_ParentFunction.BAOCAO][0] as AvailableArrayProcessor : null;
	//  _mainWindow.contnet.Children.Clear();
	//  //IDictionary<string,object> tam = new Dictionary<string,object>
	//  //{
	//  //	{"LicenseInfo", new Client() },
	//  //	{ "select", 0},
	//  //	{ "software", 0},
	//  //	{ "Version", ""},
	//  //	{ "DateTime", ""},
	//  //	{ "User", new User()},
	//  //	{ "Key", "" },
	//  //	{ "isServer", 0},
	//  //	{ "content", _mainWindow.contnet },
	//  //	{ "register", "_ktIsregister" }
	//  //};

	//  IDictionary<string,object> tam = new Dictionary<string,object>();
	//  tam.Add("nameSubmenu","");
	//  tam.Add("LicenseInfo",new Client());
	//  tam.Add("select",0);
	//  tam.Add("software",0);
	//  tam.Add("Version","");
	//  tam.Add("DateTime","");
	//  tam.Add("User",new User());
	//  tam.Add("Key","");
	//  tam.Add("isServer",0);
	//  tam.Add("content",_mainWindow.contnet);
	//  tam.Add("register","_ktIsregister");

	//  tam.Add("mainWindow",_mainWindow.windowMain);
	//  if(processor != null)
	//	processor.Instance.Process(tam); // processing...
	//}

	//public void LogOut(string strUser) {

	//  var dialogConfirm = InvicoMessageBox.ShowConfirm("Bạn có chắc chắn muốn đăng xuất?");
	//  if(dialogConfirm!=MessageBoxResult.Yes) {
	//	return;
	//  }

	//  //_isMain = false;
	//  //OnPropertyChanged("ShowMain");
	//  //_isLogin = true;
	//  //OnPropertyChanged("ShowLogin");

	//  //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
	//  //Application.Current.Shutdown();

	//  //Application.Current.Shutdown();
	//  //System.Windows.Forms.Application.Restart();

	//  //Application.Current.Shutdown();
	//  //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);

	//  //_mainWindow.DataContext=new ViewModelMain(_mainWindow);
	//  //_mainWindow.Hide();

	//  //_mainWindow.ShowInTaskbar = false;
	//  //_mainWindow.Hide();
	//  //MainWindow _frm = new MainWindow(DicData);
	//  //_frm.Show();

	//  System.Windows.Forms.Application.Restart();
	//  Process.GetCurrentProcess().Kill();
	//}

	//private void LoadForm() {
	//  SetListServer();
	//  GetAccountOldInfo();

	//  _licenseInfo = new Client(System.AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
	//  OnPropertyChanged("LicenseInfo");

	//}

	//private void PressBackSpace(string strPass) {
	//  if(strPass.Equals(StrOldPassword)) {
	//	PasswordText = "";
	//	StrOldPassword = "Password không thể trùng";
	//  }
	//}

	//private void GetAccountOldInfo() {
	//  //Thông tin userName
	//  if(TupleSetting.Item1) {
	//	_userText = TupleSetting.Item2;
	//	_passText = (new BLLPlugin()).Base64Decode(TupleSetting.Item3);
	//	StrOldPassword = _passText;

	//	int isServer = TupleSetting.Item4;
	//	_checkSavedAccount = TupleSetting.Item1;

	//	if(isServer == 1) {
	//	  _serverSelected = _lstServer[1];
	//	} else {
	//	  _serverSelected = _lstServer[0];
	//	}
	//  } else {
	//	_userText = "";
	//	_passText = "";
	//	_serverSelected = _lstServer[0];
	//	_checkSavedAccount = false;
	//  }
	//  OnPropertyChanged("UserText");
	//  OnPropertyChanged("PasswordText");
	//  OnPropertyChanged("ServerSelected");
	//  OnPropertyChanged("CheckSavedAccount");
	//}

	//private void SetListServer() {
	//  // try {
	//  //int dsfds = Convert.ToInt32("sdfgdsfdsf");
	//  // } catch(Exception ex) {
	//  //Log4Net.Error(ex.Message);
	//  // }
	//  var config = new Config();

	//  ServerModel _local = new ServerModel();
	//  _local.ServerName = Environment.MachineName;
	//  _local.IsServer = 0;

	//  _lstServer.Add(_local);

	//  if(_software!=26&&_software!=27) {
	//	ServerModel _server = new ServerModel();
	//	_server.ServerName = config.TDPhongso;
	//	_server.IsServer = 1;

	//	_lstServer.Add(_server);
	//  }

	//  OnPropertyChanged("LstServer");
	//}

	//private void timerTextChanged_Tick(object sender,EventArgs e) {
	//  if(_mainWindow.LstMenus.IsOpen==true) {
	//	_mainWindow.LstMenus.IsOpen=false;
	//  }
	//  TimerTextChanged.Stop();
	//}

	#endregion

	//#region === Command ===

	//public ICommand MenuMouseLeaveCommand {
	//  get {
	//	return new DelegateCommand(p => {
	//	  //TimerTextChanged=new System.Windows.Forms.Timer() { Interval=1000 };
	//	  //TimerTextChanged.Tick += new EventHandler(timerTextChanged_Tick);
	//	  //TimerTextChanged.Start();
	//	});
	//  }
	//}

	//public ICommand MenuMouseEnterCommand {
	//  get {
	//	return new DelegateCommand(p => {
	//	  TimerTextChanged.Stop();
	//	  if(_mainWindow.LstMenus.IsOpen==false) {
	//		_mainWindow.LstMenus.IsOpen=true;
	//	  }
	//	});
	//  }
	//}

	//public ICommand ProfileCommand {
	//  get {
	//	return new DelegateCommand(p => {
	//	  if(ServerSelected.IsServer == 1) {
	//		IsTiling = true;
	//		_isProFile = true;
	//		OnPropertyChanged("ShowProFile");
	//		_isChangePass = false;
	//		OnPropertyChanged("ShowChangePass");
	//		_mainWindow.contnet.Visibility = Visibility.Hidden;
	//	  } else {
	//		InvicoMessageBox.Show("Cảnh báo","Bạn không thể cập nhật thông tin cá nhân ở chế độ offline!",MessageBoxButton.OK,MessageBoxImage.Information);
	//	  }
	//	});
	//  }
	//}

	//public ICommand ChangePassCommand {
	//  get {
	//	return new DelegateCommand(p => {
	//	  IsTiling = true;
	//	  _isProFile = false;
	//	  OnPropertyChanged("ShowProFile");
	//	  _isChangePass = true;
	//	  OnPropertyChanged("ShowChangePass");
	//	  _mainWindow.contnet.Visibility = Visibility.Hidden;

	//	  _usersUpdatePass.OldPassword="";
	//	  _usersUpdatePass.NewPassword="";
	//	  _usersUpdatePass.AgainNewPassword="";
	//	});
	//  }
	//}

	//public ICommand SaveProFileCommand {
	//  get {
	//	return new DelegateCommand(p => {
	//	  if(CheckData(_usersUpdateProFile)) {
	//		try {
	//		  DateTime dt;
	//		  DateTime.TryParseExact(_usersUpdateProFile.DOB,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out dt);
	//		  User _userUpdate = new User {
	//			UserID = _user.UserID,
	//			Address = _usersUpdateProFile.Address.Trim(),
	//			Tel = _usersUpdateProFile.Tel,
	//			Surname = _usersUpdateProFile.Surname.Trim(),
	//			Name = _usersUpdateProFile.Name.Trim(),
	//			Password = "",
	//			DOB = dt,
	//			Gender = _usersUpdateProFile.Gender,
	//		  };

	//		  var strCase = (new BLLPlugin()).UpdateInfoPersonal(_userUpdate.UserID,_key,_userUpdate);
	//		  var reviced = JsonConvert.DeserializeObject<IDictionary>(strCase);
	//		  var status = reviced["status"].ToString();
	//		  switch(status) {
	//			case "1":
	//			  InvicoMessageBox.Show("Thông báo",reviced["success"].ToString(),MessageBoxButton.OK,MessageBoxImage.Information);

	//			  _usersUpdateProFile.Address=_usersUpdateProFile.Address.Trim();
	//			  _usersUpdateProFile.Surname=_usersUpdateProFile.Surname.Trim();
	//			  _usersUpdateProFile.Name=_usersUpdateProFile.Name.Trim();
	//			  break;
	//			case "2":
	//			  InvicoMessageBox.Show("Cảnh báo",reviced["success"].ToString(),MessageBoxButton.OK,MessageBoxImage.Warning);
	//			  //Application.Restart();
	//			  break;
	//			default:
	//			  InvicoMessageBox.Show("Cảnh báo",reviced["error"].ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
	//			  break;
	//		  }
	//		} catch(Exception ex) {
	//		  InvicoMessageBox.Show("Ngoại lệ",ex.ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
	//		}

	//		IsTiling = false;
	//		_mainWindow.contnet.Visibility = Visibility.Visible;
	//		_isProFile = false;
	//		OnPropertyChanged("ShowProFile");
	//		_isMain = true;
	//		OnPropertyChanged("ShowMain");
	//	  }
	//	});
	//  }
	//}

	//public ICommand SaveChangePassCommand {
	//  get {
	//	return new DelegateCommand(p => {
	//	  if(CheckDataChangePass(_usersUpdatePass)) {
	//		try {
	//		  var strCase = "";
	//		  if(ServerSelected.IsServer == 1)
	//			strCase = (new BLLPlugin()).ChangePassWord(_usersUpdatePass.NewPassword,_usersUpdatePass.OldPassword,_key,_user.UserID,ServerSelected.IsServer);
	//		  else
	//			strCase = (new BLLPlugin()).ChangePassWord(_usersUpdatePass.NewPassword);

	//		  var reviced = JsonConvert.DeserializeObject<IDictionary>(strCase);
	//		  var status = reviced["status"].ToString();
	//		  switch(status) {
	//			case "1":
	//			  InvicoMessageBox.Show("Thông báo",reviced["success"].ToString(),MessageBoxButton.OK,MessageBoxImage.Information);

	//			  _passText = _usersUpdatePass.NewPassword;
	//			  OnPropertyChanged("PasswordText");

	//			  _isChangePass = false;
	//			  OnPropertyChanged("ShowChangePass");

	//			  _isMain = true;
	//			  OnPropertyChanged("ShowMain");
	//			  IsTiling = false;
	//			  _mainWindow.contnet.Visibility = Visibility.Visible;

	//			  _usersUpdatePass.OldPassword = "";
	//			  _usersUpdatePass.NewPassword = "";
	//			  _usersUpdatePass.AgainNewPassword = "";
	//			  break;
	//			case "2":
	//			  InvicoMessageBox.Show("Cảnh báo",reviced["success"].ToString(),MessageBoxButton.OK,MessageBoxImage.Warning);
	//			  //Application.Restart();
	//			  break;
	//			default:
	//			  InvicoMessageBox.Show("Cảnh báo",reviced["error"].ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
	//			  break;
	//		  }
	//		} catch(Exception ex) {
	//		  InvicoMessageBox.Show("Cảnh báo",ex.ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
	//		}

	//		//var itm = new DIGILIB.Users();
	//		//itm.UserID = _usersUpdateProFile.UserID;
	//		//itm.Password = _usersUpdatePass.NewPassword;
	//		//itm.Edit_Password();

	//		//_userLogin.Password = _usersUpdatePass.NewPassword;
	//		//OnPropertyChanged("SetUserLogin");
	//		//InvicoMessageBox.Show("Thông báo", "Cập nhật thành công !", MessageBoxButton.OK, MessageBoxImage.Information);
	//		//IsTiling = false;
	//	  }
	//	});
	//  }
	//}

	//public ICommand CloseCommand {
	//  get {
	//	return new DelegateCommand(p => {
	//	  SelectedItem = ModalSelection;
	//	  IsTiling = false;
	//	  _mainWindow.contnet.Visibility = Visibility.Visible;
	//	});
	//  }
	//}

	//#endregion

  }
}
