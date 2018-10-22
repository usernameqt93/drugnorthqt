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

	private readonly BLLPlugin _bllPlugin = new BLLPlugin();

	private Version _versionAppExe = new Version();

	//public static User _user = new User();
	//public static string _key = "";
	//public static int _isServer = 0;
	//private int _countDisconnect = 0;
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

	public delegate void DELEGATE_VOID_IN_OTHER_USERCONTROL(ref Dictionary<string,object> dicInput);
	public DELEGATE_VOID_IN_OTHER_USERCONTROL ExcuteInOtherUserControl;

	private Dictionary<string,object> DicSubInput;

	private string StrOldPassword;

	#region === Những thuộc tính binding ===

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

	private string _userText = "";

	public string StrUserText {
	  get {
		return _userText;
	  }
	  set {
		_userText = value;
		OnPropertyChanged(nameof(StrUserText));
	  }
	}

	private string _passText = "";

	public string StrPasswordText {
	  get {
		return _passText;
	  }
	  set {
		_passText = value;
		OnPropertyChanged(nameof(StrPasswordText));
	  }
	}

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

	#endregion

	#endregion

	#region === Handle ===

	public ViewModelMain(MainWindow _viewMain,Dictionary<string,object> dicInput) {
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
	  //_software=tuple.Item1;
	  //_version=tuple.Item2;
	  //_dateTime=tuple.Item3;
	  ExcuteInOtherUserControl=(DELEGATE_VOID_IN_OTHER_USERCONTROL)dicInput["DELEGATE_VOID_IN_OTHER_USERCONTROL"];
	  DicSubInput=dicInput["Dictionary<string,object>"] as Dictionary<string,object>;

	  LoadForm();
	}

	#endregion

	#region === Các hàm chung ===

	private void LoadForm() {
	  _mainWindow.windowMain.Title=DicSubInput["stringTitle"] as string;

	  _mainWindow.chkRemember.IsChecked=(bool)DicSubInput["boolCheckSaveLogin"];
	  if((bool)_mainWindow.chkRemember.IsChecked) {
		string strPassDecode = "";
		_bllPlugin.GetPassBase64Decode(ref strPassDecode,DicSubInput["stringPassword"] as string);
		LoadUserPassSaved(DicSubInput["stringUserName"] as string,strPassDecode);
	  } else {
		LoadUserPassSaved("","");
	  }
	}

	private void LoadUserPassSaved(string strUser,string strPass) {
	  StrUserText=strUser;
	  StrPasswordText=strPass;
	}

	private void SaveSettingsToProperties(string strUser,string strPass,int isServer,bool blnCheckSaveLogin) {
	  if(ExcuteInOtherUserControl!=null) {
		Dictionary<string,object> dicInput = new Dictionary<string,object>();
		dicInput.Add("stringUser",strUser);
		dicInput.Add("stringPass",strPass);
		dicInput.Add("int",isServer);
		dicInput.Add("bool",blnCheckSaveLogin);

		ExcuteInOtherUserControl(ref dicInput);
	  }
	}

	private void ShowException(string _strMessage) {
	  InvicoMessageBox.ShowNotify(_strMessage);
	}

	#endregion

	#region === Command ===

	public ICommand LoginCommand {
	  get {
		return new DelegateCommand(p => {
		  try {
			if(StrUserText.Trim().Equals("")) {
			  InvicoMessageBox.ShowNotify("Bạn chưa nhập tên đăng nhập!");
			  StrUserText="";
			  return;
			}

			if(StrPasswordText.Trim().Equals("")) {
			  InvicoMessageBox.ShowNotify("Mật khẩu không được nhập toàn dấu cách!");
			  StrPasswordText="";
			  return;
			}

			if((bool) _mainWindow.chkRemember.IsChecked) {
			  string strPassEncode = "";
			  _bllPlugin.GetPassBase64Encode(ref strPassEncode,StrPasswordText.Trim());
			  SaveSettingsToProperties(StrUserText.Trim(),strPassEncode,0,true);
			}else {
			  SaveSettingsToProperties("","",0,false);
			}

			InvicoMessageBox.ShowNotify("Lưu thành công!");
		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			ShowException(ex.Message);
		  }
		});
	  }
	}

	public ICommand LoadedCommand {
	  get {
		return new DelegateCommand(p => {
		  try {

		  } catch(Exception ex) {
			Log4Net.Error(ex.Message);
			ShowException(ex.Message);
		  }
		});
	  }
	}

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

	public ICommand CloseCommand {
	  get {
		return new DelegateCommand(p => {
		  //SelectedItem = ModalSelection;
		  //IsTiling = false;
		  //_mainWindow.contnet.Visibility = Visibility.Visible;
		});
	  }
	}

#endregion

  }
}
