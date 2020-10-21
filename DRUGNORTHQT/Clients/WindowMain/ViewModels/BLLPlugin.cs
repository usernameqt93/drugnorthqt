using HostViewer;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json;
using QT.Framework.LoadingPopup.View;
using QT.Framework.ToolCommon;
using QT.Framework.ToolCommon.Models;
using QT.HamburgerMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WindowMain.Model;
using WindowMain.Models;
using WindowMain.View;

namespace WindowMain.ViewModels {
  public class BLLPlugin {

	private const string CONST_STR_COLOR_HUONGVIET = "#FF058624";
	private const string CONST_STR_COLOR_SAOSAIGON = "#FF3C72A2";

	private const string CONST_STR_KEY_DATETIME_PHIENBAN = "VersionInfo";

	//public string ChangePassWord(string newPass,string oldPass = "",string key = "",int userId = 0,int isServer = 0) {
	//  try {
	//	if(isServer == 1) {
	//	  var check = new Dictionary<string,object>
	//	  {
	//					{"userId", userId},
	//					{"key", key},
	//					{"password_new", User.GetMD5Hash(newPass)},
	//					{"password_old", User.GetMD5Hash(oldPass)}
	//				};
	//	  var n = new Dictionary<string,object>
	//	  {
	//					{"command", AppConfig.enum_OnReceive.EDIT_PASSWORD.ToString()},
	//					{"info", check}
	//				};

	//	  var json = JsonConvert.SerializeObject(n);
	//	  var ss = Client.SendToServer(json,userId.ToString());
	//	  var reviced = JsonConvert.DeserializeObject<IDictionary>(ss);
	//	  var status = reviced["status"].ToString();
	//	  switch(status) {
	//		case "1": {
	//			return "{\"status\":\"1\",\"success\":\"Cập nhật mật khẩu thành công !\"}";
	//		  }
	//		case "2":
	//		  var time = reviced["time"].ToString();
	//		  return "{\"status\":\"2\",\"time\":\"" + time + "\",\"success\":\"Tài khoản đang được đăng nhập trên một máy khác\n Chương trình sẽ tự động đang xuất trong ít phút !\"}";
	//		default:
	//		  return status;
	//	  }
	//	} else {
	//	  if(DALLogin.ChangePassword(newPass) == 1)
	//		return "{\"status\":\"1\",\"success\":\"Cập nhật mật khẩu thành công !\"}";
	//	  else
	//		return "{\"status\":\"0\",\"error\":\"Cập nhật mật khẩu thất bại !\"}";
	//	}
	//  } catch(Exception ex) {
	//	return "{\"status\":\"0\",\"error\":\"" + ex + "\"}";
	//  }
	//}

	#region Function for Loading

	internal void ShowPopupLoading(ref PopupLoading LoadingUC,ref Grid gridPopup) {
	  gridPopup.Children.Clear();
	  LoadingUC = new PopupLoading();
	  gridPopup.Width=LoadingUC.Width;
	  gridPopup.Height=LoadingUC.Height;
	  gridPopup.Children.Add(LoadingUC);
	}

	internal void ChangeInfoLoading(ref PopupLoading loadingUC,ModelProgress mpProgress) {
	  double doubleTemp = Math.Round(mpProgress.DoublePercent,2);
	  loadingUC.controlLoading.StrValue=""+doubleTemp+"%";
	  loadingUC.txtTitle.Content=mpProgress.StrTitle;
	  loadingUC.txtMessage.Text=mpProgress.StrMessageProgress;
	}

	internal void SetSourceToImageBySoftware(ref Image logoIcon,int software) {
	  switch(software) {
		case 20:
		case 21:
		case 27:
		  //Sao Sài Gòn
		  logoIcon.Source = new BitmapImage(
			new Uri("pack://application:,,,/INV.Framework.ProductInfo.Library;component/Resources/logo-masterSSG.png"));
		  break;
		case 16:
		  //Intest
		  logoIcon.Source = new BitmapImage(
			new Uri("pack://application:,,,/INV.Framework.ProductInfo.Library;component/Resources/logo-intest.png"));
		  break;
		case 19:
		  //Lantest
		  logoIcon.Source = new BitmapImage(
			new Uri("pack://application:,,,/INV.Framework.ProductInfo.Library;component/Resources/logo-lantest.png"));
		  break;
		case 26:
		  //Marktest
		  logoIcon.Source = new BitmapImage(
			new Uri("pack://application:,,,/INV.Framework.ProductInfo.Library;component/Resources/logo-marktest.png"));
		  break;
		default:
		  break;
	  }
	}

	internal void SetTitleBySoftware(ref Label lblTitleAbove,int software) {
	  switch(software) {
		case 20:
		  //Sao Sài Gòn Master Test
		  lblTitleAbove.Content="HỆ THỐNG QUẢN LÝ NGÂN HÀNG ĐỀ THI TRỰC TUYẾN";
		  break;
		case 21:
		  //Sao Sài Gòn Master LanTest
		  lblTitleAbove.Content="HỆ THỐNG TỔ CHỨC THI PHÒNG MÁY";
		  break;
		case 27:
		  //Sao Sài Gòn Master MarkTest
		  lblTitleAbove.Content="HỆ THỐNG CHẤM THI";
		  break;
		case 16:
		  //Intest
		  lblTitleAbove.Content="HỆ THỐNG QUẢN LÝ NGÂN HÀNG ĐỀ THI TRỰC TUYẾN";
		  break;
		case 19:
		  //Lantest
		  lblTitleAbove.Content="HỆ THỐNG TỔ CHỨC THI PHÒNG MÁY";
		  break;
		case 26:
		  //Marktest
		  lblTitleAbove.Content="HỆ THỐNG CHẤM THI";
		  break;
		default:
		  break;
	  }
	}

	internal void SetImageSourceByTagBorderThongKe(ref BorderThongKe ucOutput,List<HamburgerMenuItem> lstMenu) {
	  HamburgerMenuItem mMenu = null;
	  foreach(var item in lstMenu) {
		if(item.Text.Trim()==ucOutput.Tag.ToString().Trim()) {
		  mMenu=item;
		  break;
		}
	  }
	  if(mMenu!=null) {
		ucOutput.ImageSourceHienThi=mMenu.Icon;
		ucOutput.SelectionCommand=mMenu.SelectionCommand;
		ucOutput.SelectionCommandParameter=mMenu.SelectionCommandParameter;
	  }
	}

	internal void SetColorForMenuBySoftware(ref ModelHamburgerMenu mitemUserManual,int software) {
	  switch(software) {
		case 20:
		case 21:
		case 27:
		  //Sao Sài Gòn
		  mitemUserManual.StrColor=CONST_STR_COLOR_SAOSAIGON;
		  break;
		case 16:
		//Intest
		case 19:
		//Lantest
		case 26:
		  //Marktest
		  mitemUserManual.StrColor=CONST_STR_COLOR_HUONGVIET;
		  break;
		default:
		  break;
	  }
	}

	internal void GetItemUserManualFromListMenu(ref ModelHamburgerMenu mitem,
	  HamburgerMenuItem mItemInput,List<HamburgerMenuItem> _lstMenu) {
	  mitem.Icon=mItemInput.Icon;

	  for(int i = 0;i < _lstMenu.Count;i++) {
		if(_lstMenu[i].ParentID==0&&_lstMenu[i].ItemID==7) {
		  mitem.Icon=_lstMenu[i].Icon;
		  break;
		}
	  }	

	  mitem.ItemID=mItemInput.ItemID;
	  mitem.ParentID=mItemInput.ParentID;
	  mitem.SelectionCommand=mItemInput.SelectionCommand;
	  mitem.SelectionCommandParameter=mItemInput.SelectionCommandParameter;
	  mitem.Text=mItemInput.Text;
	  mitem.StrTextOriginal=mItemInput.Text;
	}

	internal void ChangeTextForMenuSphere(ref string strTextChange) {
	  if(strTextChange.Equals("Quản trị hệ thống")) {
		strTextChange="Quản trị\nhệ thống";
		return;
	  }

	  if(strTextChange.Equals("Thiết lập đề thi")) {
		strTextChange="Thiết lập\nđề thi";
		return;
	  }

	 // if(strTextChange.Equals("Báo cáo thống kê")) {
		//strTextChange="Thiết lập\nđề thi";
		//return;
	 // }

	 // if(strTextChange.Equals("Thiết lập đề thi")) {
		//strTextChange="Thiết lập\nđề thi";
		//return;
	 // }

	 // if(strTextChange.Equals("Thiết lập đề thi")) {
		//strTextChange="Thiết lập\nđề thi";
		//return;
	 // }

	}

	internal void CheckHaveOneMenuInParent(ref bool blnHaveOnlyOneInParent,
	  HamburgerMenuItem hamburgerMenuItem,List<HamburgerMenuItem> lstMenu) {
	  int intCount = 0;
	  for(int i = 0;i < lstMenu.Count;i++) {
		if(lstMenu[i].ItemID==hamburgerMenuItem.ItemID&&lstMenu[i].ParentID==hamburgerMenuItem.ParentID) {
		  intCount++;
		}
	  }

	  if(intCount>1) {
		blnHaveOnlyOneInParent=false;
	  }
	}

	internal void StartBgWorkerDoWork(ref DoWorkEventArgs e,ref ModelProgress mPProgress,
	  double doublePercent,string strTitle,string strMessage) {
	  BLLTools.ReportProgressWorker(ref mPProgress,doublePercent,strTitle,strMessage);
	  //e.Cancel=true;
	}

	//internal void GetSumMaDeFrom(ref int intSumMaDe,List<Tests> lstTest,
	//  List<Tests_Detail> lstTestsDetail,int intSubjectID) {
	//  for(int k = 0;k < lstTest.Count;k++) {
	//	if(lstTest[k].StructureID!=intSubjectID) {
	//	  continue;
	//	}

	//	intSumMaDe++;
	//  }
	//}

	#endregion

	//public string UpdateInfoPersonal(int userId,string key,User user) {
	//  try {
	//	var dicInfo = new Dictionary<string,object> { { "userId",userId },{ "key",key },{ "users",user } };

	//	var dicSend = new Dictionary<string,object>
	//	{
	//				{"command", AppConfig.enum_OnReceive.EDIT_USER_BYUSER.ToString()},
	//				{"info", dicInfo}
	//			};

	//	var jsonSend = JsonConvert.SerializeObject(dicSend);
	//	var str = Client.SendToServer(jsonSend,userId + "");
	//	var dicReviced = JsonConvert.DeserializeObject<IDictionary>(str);
	//	var status = dicReviced["status"].ToString();
	//	switch(status) {
	//	  case "1":
	//		return "{\"status\":\"1\",\"success\":\"Cập nhật hồ sơ thành công !\"}";
	//	  case "2":
	//		var time = dicReviced["time"].ToString();
	//		return "{\"status\":\"2\",\"time\":\"" + time + "\",\"success\":\"Tài khoản đang được đăng nhập trên một máy khác\n Chương trình sẽ tự động đang xuất trong ít phút !\"}";
	//	  default:
	//		return status;
	//	}
	//  } catch(Exception ex) {
	//	return "{\"status\":\"0\",\"error\":\"" + ex + "\"}";
	//  }
	//}

	//public string OnLogin(ref Dictionary<string,object> dicLoginInfo,string strAppName,
	//  DateTime dtPhienBan,int intSoftware,
	//  string user,string pass,int server,ref User outUser,
	//  ref string key,ref string stt) {
	//  var strSatus = "{\"status\":\"0\",\"error\":\"Đăng nhập thất bại !\"}";
	//  if(server == 1) {
	//	try {

	//	  bool strHaveConnectInternet = false;
	//	  string strException = "";
	//	  CheckConnectInternet(ref strHaveConnectInternet,ref strException);
	//	  if(strHaveConnectInternet==false) {
	//		stt = "Máy tính của bạn hiện chưa kết nối mạng, chưa thể thực hiện thao tác này!";
	//		return "error";
	//	  }

	//	  var config = new Config();

	//	  var dicInfo = new Dictionary<string,object>();
	//	  dicInfo["username"]=user;
	//	  dicInfo["password"]=DALLogin.GetMD5Hash(pass);
	//	  dicInfo["mus"]=config.CheckToServer;

	//	  var jsonDtPhienBan = JsonConvert.SerializeObject(dtPhienBan);
	//	  ChangeValueOfKeyInFileConfig(CONST_STR_KEY_DATETIME_PHIENBAN,jsonDtPhienBan);
	//	  dicInfo["DateTime"]=dtPhienBan;
	//	  dicInfo["intSoftware"]=intSoftware;
	//	  dicInfo["stringAppName"]=strAppName;
	//	  dicInfo["stringSchoolName"]=config.TDTenTruong;
	//	  dicInfo["stringPhongSoName"]=config.TDPhongso;

	//	  //var dicSend = new Dictionary<string,object>();
	//	  //dicSend[EnumAction.action.ToString()]=EnumAction.LOGIN.ToString();
	//	  //dicSend[EnumAction.jsonInput.ToString()]=dicInfo;

	//	  var dicSend = new Dictionary<string,object>
	//	 {
	//	  		{"command", AppConfig.enum_OnReceive.LOGIN.ToString()},
	//	  		{"info", dicInfo}
	//	  	};

	//	  var jsonSend = JsonConvert.SerializeObject(dicSend);
	//	  var str = Client.SendToServer(jsonSend,"0");
	//	  var dicReviced = JsonConvert.DeserializeObject<Dictionary<string,object>>(str);
	//	  dicLoginInfo=dicReviced;
	//	  //Đối với trường hợp trả về, key config server trả về là 1 json của Dictionary hoặc trống ""

	//	  var status = dicReviced["status"].ToString();
	//	  switch(status) {
	//		case "1": {
	//			object d = dicReviced["users"].ToString();
	//			key = dicReviced["key"].ToString();
	//			outUser = JsonConvert.DeserializeObject<User>(d.ToString());
	//			outUser.Password = pass;
	//			stt = "Đăng nhập thành công !";
	//			return "ok";
	//		  }
	//		case "2":
	//		  stt = "Tài khoản đang được đăng nhập trên một máy khác !";
	//		  return "logout";
	//		case "99":
	//		  stt = dicReviced["error"].ToString();
	//		  return "disconnect";
	//		case "90":
	//		  stt = dicReviced["exits"].ToString();
	//		  return "exits";
	//		default:
	//		  stt = dicReviced["error"].ToString();
	//		  if(stt.Contains("ds.tables.count = 0")) {
	//			stt = "Tài khoản này không tồn tại !";
	//		  }
	//		  return "error";
	//	  }
	//	} catch(Exception ex) {
	//	  stt = ex.Message;
	//	  return "error";
	//	}
	//  } else {
	//	try {
	//	  switch(DALLogin.CheckLogin(user,pass)) {
	//		case 0:
	//		  stt = "Tên đăng nhập không chính xác !";
	//		  return "error";
	//		case 1:
	//		  stt = "Mật khẩu đăng nhập không chính xác !";
	//		  return "error";
	//		case 2:
	//		  if(intSoftware==19||intSoftware==21) {
	//			outUser = new User { UserID = 0,Username = user,Password = pass,MUType=2 };
	//		  } else {
	//			outUser = new User { UserID = 0,Username = user,Password = pass };
	//		  }
	//		  stt = "Đăng nhập thành công !";
	//		  return "ok";
	//	  }
	//	} catch(Exception ex) {
	//	  stt = ex.Message;
	//	  return "error";
	//	}
	//  }
	//  return strSatus;
	//}

	internal void CheckConnectInternet(ref bool strHaveConnectInternet,ref string strException) {
	  try {
		#region Kiểm tra máy tính có kết nối internet hay không
		using(var client = new System.Net.WebClient()) {
		  string strLink = "http://clients3.google.com/generate_204";
		  using(client.OpenRead(strLink)) {
			strHaveConnectInternet=true;
		  }
		}
		#endregion
	  } catch(Exception e) {
		strException = e.Message;
		//InvicoMessageBox.ShowNotify(
		//  "Máy tính của bạn hiện chưa kết nối mạng, chưa thể thực hiện thao tác này!",str);
		//strErrorConnectInternet="Máy tính của bạn hiện chưa kết nối mạng, chưa thể thực hiện thao tác này!";
		return;
	  }
	}

	internal void ChangeValueOfKeyInFileConfig(string strKey,string strValue) {
	  Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	  if(_config.AppSettings.Settings.AllKeys.Contains(strKey)) {
		_config.AppSettings.Settings.Remove(strKey);
	  }
	  _config.AppSettings.Settings.Add(strKey,strValue);
	  ConfigurationManager.RefreshSection("appSettings");
	  _config.Save(ConfigurationSaveMode.Modified);
	  ConfigurationManager.RefreshSection(_config.AppSettings.SectionInformation.Name);
	  Properties.Settings.Default.Reload();
	}

	internal void GetValueRandomNotInList(ref int intRandomValue,ref List<int> lstIntRandom,int intCountColor) {
	  int intCountIncrease = 0;
	  var rnd = new Random();
	  do {
		intRandomValue = rnd.Next(intCountColor);
		System.Threading.Thread.Sleep(20);
		intCountIncrease++;
	  } while(lstIntRandom.Contains(intRandomValue)&&intCountIncrease<16);

	  for(int i = 0;i < 8;i++) {
		lstIntRandom.Add(intRandomValue+i-5);
	  }
	}

	//public string OnLogin(string user,string pass,int server,ref User outUser,ref string key,ref string stt) {
	//  var strSatus = "{\"status\":\"0\",\"error\":\"Đăng nhập thất bại !\"}";
	//  if(server == 1) {
	//	try {
	//	  var config = new Config();
	//	  var dicInfo = new Dictionary<string,object> {
	//						{"username", user},
	//						{"password", DALLogin.GetMD5Hash(pass)},
	//						{"mus", config.CheckToServer}
	//			};

	//	  var dicSend = new Dictionary<string,object>
	//  {
	//				{"command", AppConfig.enum_OnReceive.LOGIN.ToString()},
	//				{"info", dicInfo}
	//			};

	//	  var jsonSend = JsonConvert.SerializeObject(dicSend);
	//	  var str = Client.SendToServer(jsonSend,"0");
	//	  var dicReviced = JsonConvert.DeserializeObject<IDictionary>(str);
	//	  var status = dicReviced["status"].ToString();
	//	  switch(status) {
	//		case "1": {
	//			object d = dicReviced["users"].ToString();
	//			key = dicReviced["key"].ToString();
	//			outUser = JsonConvert.DeserializeObject<User>(d.ToString());
	//			outUser.Password = pass;
	//			stt = "Đăng nhập thành công !";
	//			return "ok";
	//		  }
	//		case "2":
	//		  stt = "Tài khoản đang được đăng nhập trên một máy khác !";
	//		  return "logout";
	//		case "99":
	//		  stt = dicReviced["error"].ToString();
	//		  return "disconnect";
	//		case "90":
	//		  stt = dicReviced["exits"].ToString();
	//		  return "exits";
	//		default:
	//		  stt = dicReviced["error"].ToString();
	//		  if(stt.Contains("ds.tables.count = 0")) {
	//			stt = "Tài khoản này không tồn tại !";
	//		  }
	//		  return "error";
	//	  }
	//	} catch(Exception ex) {
	//	  stt = ex.Message;
	//	  return "error";
	//	}
	//  } else {
	//	try {
	//	  switch(DALLogin.CheckLogin(user,pass)) {
	//		case 0:
	//		  stt = "Tên đăng nhập không chính xác !";
	//		  return "error";
	//		case 1:
	//		  stt = "Mật khẩu đăng nhập không chính xác !";
	//		  return "error";
	//		case 2:
	//		  outUser = new User { UserID = 0,Username = user,Password = pass };
	//		  stt = "Đăng nhập thành công !";
	//		  return "ok";
	//	  }
	//	} catch(Exception ex) {
	//	  stt = ex.Message;
	//	  return "error";
	//	}
	//  }
	//  return strSatus;
	//}

	public string Base64Encode(string plainText) {
	  var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
	  return System.Convert.ToBase64String(plainTextBytes);
	}

	public string Base64Decode(string base64EncodedData) {
	  var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
	  return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
	}

	//private static string _key = "";
	//private static string _infoUser = ""; // cái này phải là kiểu User
	//private static int _ktIsregister = 0;

	//static readonly Label LabelReport = new Label();
	//private readonly HostService _mHostAdapter = new HostService(LabelReport);
	public string LoadIcon(int key,int intSoftware) {
	  switch(key) {
		//case (int)AppConfig.enum_ParentFunction.QUANLY:
		//  return @"/Assets/settings.png";
		//case (int)AppConfig.enum_ParentFunction.LAMDETHI:
		//  return @"/Assets/Examination.png";
		//case (int)AppConfig.enum_ParentFunction.NGANHANGCAUHOI:
		//  return @"/Assets/QuestionsBank.png";

		//case (int)AppConfig.enum_ParentFunction.TOCHUCTHI:
		//  if(intSoftware==19||intSoftware==21) {
		//	return @"/Assets/LANSetupExam.png";
		//  }
		//  return @"/Assets/student.png";

		//case (int)AppConfig.enum_ParentFunction.THONGKETHI:
		//  return @"/Assets/mark.png";

		//case (int)AppConfig.enum_ParentFunction.BAOCAO:
		//  if(intSoftware==19||intSoftware==21) {
		//	return @"/Assets/StatisticReport.png";
		//  }
		//  //return @"/Assets/report.png";
		//  return @"/Assets/StatisticReport.png";

		//case (int)AppConfig.enum_ParentFunction.TROGIUP:
		//  return @"/Assets/help.png";
		default:
		  return string.Empty;
	  }
	}
	/// <summary>
	/// Load danh dách chức năng theo danh sách Pulgin.
	/// </summary>
	/// <param name="lstRuleOfUser"> Danh sách quyền của người dùng.</param>
	/// <param name="lstIdBigFun"> Danh sách trả về mã nhóm chức năng.</param>
	/// <param name="lstBigFun">Danh sách trả về các chức năng con theo mã nhóm chức năng.</param>
	/// <param name="lstBigPlugin">Danh sách trả về các Plugin theo mã nhóm chức năng. </param>
	/// <param name="checkServer">Kiểm tra xem là đang chay client hay local</param>
	/// <param name="forder"> Đường dẫn thư mục chứ Plugin</param>

	public void LoadPlugins(int intSoftware,List<int> lstRuleOfUser,ref List<MenuModel> lstMenuItems
	  ,bool checkServer = true,string forder = "") {
	  string pathPlugin = System.AppDomain.CurrentDomain.BaseDirectory + forder + "\\";
	  string pathPluginClient = System.AppDomain.CurrentDomain.BaseDirectory + forder + "\\Client\\";
	  string pathPluginLocation = System.AppDomain.CurrentDomain.BaseDirectory + forder + "\\Location\\";

	  if(!Directory.Exists(pathPlugin)) {
		Directory.CreateDirectory(pathPlugin);
	  }

	  if(!Directory.Exists(pathPluginClient)) {
		Directory.CreateDirectory(pathPluginClient);
	  }

	  if(!Directory.Exists(pathPluginLocation)) {
		Directory.CreateDirectory(pathPluginLocation);
	  }

	  var LabelReport = new Label();
	  var mHostAdapter = new HostService(LabelReport);

	  mHostAdapter.Dispose();
	  mHostAdapter.FindPlugIns(pathPlugin);

	  //Load plugins thuộc client/location
	  if(checkServer) {
		mHostAdapter.FindPlugIns(pathPluginClient);
	  } else {
		mHostAdapter.FindPlugIns(pathPluginLocation);
	  }

	  var lstTupleNameGroup = new List<Tuple<int,string>>();
	  lstTupleNameGroup.Add(new Tuple<int,string>(2,"Quản trị hệ thống"));

	  var lstGroupID = new List<int>();
	  //_mHostAdapter.FindPlugIns(pathPlugin);
	  foreach(HostViewer.Types.AvailableArrayProcessor plugin in mHostAdapter.PlugIns) {
		int orderParent = 0;
		int orderChild = 0;

		int.TryParse(plugin.Instance.Attributes.Publisher.Split('|')[0],out orderParent);
		int.TryParse(plugin.Instance.Attributes.Publisher.Split('|')[1],out orderChild);

		var groupID = 0;
		var boolCheck = int.TryParse(plugin.Instance.Attributes.Group,out groupID);
		if(boolCheck == false) {
		  continue;
		}

		if(!lstGroupID.Contains(groupID)) {
		  lstGroupID.Add(groupID);
		  var menuNew = new MenuModel();
		  menuNew.Order = orderParent;
		  menuNew.ID = groupID;
		  var tupleGroup = lstTupleNameGroup.FirstOrDefault(x => x.Item1==groupID);
		  if(tupleGroup!=null) {
			menuNew.Name=tupleGroup.Item2;
		  }
		  //menuNew.Name = AppConfig.ToText((AppConfig.enum_ParentFunction)Enum.ToObject(typeof(AppConfig.enum_ParentFunction),groupID));

		  if(intSoftware==26||intSoftware==27) {
			int intIdChamThi = 1;
			if(menuNew.ID == intIdChamThi) {
			  menuNew.Name = "Chấm thi";
			}
			//int intIdQuanLy = 2;
			// if(menuNew.ID==intIdQuanLy) {
			//menuNew.Name="Quản lý";
			// }
		  }

		  lstMenuItems.Add(menuNew);
		}

		foreach(var menu in lstMenuItems) {
		  if(menu.ID == groupID) {
			if(plugin.Instance.Attributes.Quantity > 1) {
			  var cat = new[] { "|" };
			  var mangCat = plugin.Instance.Attributes.Name.Split(cat,0);
			  var mangCatRule = plugin.Instance.Attributes.Rules.Split(cat,0);
			  var lstIconFileName = plugin.Instance.Attributes.Description.Split(cat,0);

			  for(var i = 0;i < mangCat.Length;i++) {
				if(lstRuleOfUser.Contains(Convert.ToInt32(mangCatRule[i])) == false) {
				  continue;
				}
				var subMenuItemNew = new SubMenuModel();
				subMenuItemNew.Order = orderChild;
				subMenuItemNew.NameItem = mangCat[i];
				subMenuItemNew.IconFileName = lstIconFileName[i];
				subMenuItemNew.Tag = plugin;
				menu.LstMenuChilds.Add(subMenuItemNew);
			  }
			} else {
			  if(lstRuleOfUser.Contains(Convert.ToInt32(plugin.Instance.Attributes.Rules)) == true) {
				var subMenuItemNew = new SubMenuModel();
				subMenuItemNew.Order = orderChild;
				subMenuItemNew.NameItem = plugin.Instance.Attributes.Name;
				subMenuItemNew.IconFileName = plugin.Instance.Attributes.Description;
				subMenuItemNew.Tag = plugin;
				menu.LstMenuChilds.Add(subMenuItemNew);
			  }
			}
		  }
		}
	  }

	  foreach(var menu in lstMenuItems) {
		menu.LstMenuChilds = menu.LstMenuChilds.OrderBy(m => m.Order).ToList();
	  }
	  lstMenuItems = lstMenuItems.OrderBy(m => m.Order).ToList();

	  mHostAdapter.Report(mHostAdapter.PlugIns.Count + " Plug-In(s) Loaded."); // reports to clients...
	}

	//internal void UpdateUserProfileLogin(ref ModelUsers _usersUpdateProFile,User _user) {
	//  _usersUpdateProFile.UserName = _user.Username;
	//  _usersUpdateProFile.Name = _user.Name;
	//  _usersUpdateProFile.Surname = _user.Surname;

	//  var strDateTime = "";
	//  if(_user.DOB.Day < 10) {
	//	strDateTime += "0" + _user.DOB.Day;
	//  } else {
	//	strDateTime += _user.DOB.Day;
	//  }
	//  if(_user.DOB.Month < 10) {
	//	strDateTime += "/0" + _user.DOB.Month;
	//  } else {
	//	strDateTime += "/" + _user.DOB.Month;
	//  }
	//  strDateTime += "/" + _user.DOB.Year;

	//  _usersUpdateProFile.DOB = strDateTime;

	//  _usersUpdateProFile.Gender = _user.Gender;
	//  _usersUpdateProFile.Tel = _user.Tel;
	//  _usersUpdateProFile.Address = _user.Address;
	//  _usersUpdateProFile.GroupID = _user.GroupID;

	//  switch(_usersUpdateProFile.GroupID) {
	//	case 7:
	//	  _usersUpdateProFile.GroupName = "Quản trị hệ thống";
	//	  break;
	//	case 6:
	//	  _usersUpdateProFile.GroupName = "Admin sở";
	//	  break;
	//	case 5:
	//	  _usersUpdateProFile.GroupName = "Admin phòng";
	//	  break;
	//	case 4:
	//	  _usersUpdateProFile.GroupName = "Admin trường";
	//	  break;
	//	case 3:
	//	  _usersUpdateProFile.GroupName = "Cán bộ";
	//	  break;
	//	case 2:
	//	  _usersUpdateProFile.GroupName = "Giáo viên";
	//	  break;
	//	case 1:
	//	  _usersUpdateProFile.GroupName = "Học sinh";
	//	  break;
	//  }

	//  _usersUpdateProFile.MuInfo = _user.MUInfo;

	//}

	internal void SetToolTipForLabelComputerName(ref Label txtData) {
	  string strToolTipResult = $"Thông tin hiện tại trên phần mềm:" ;
	  //strToolTipResult += $"\n+ {AppConfig.ToText((AppConfig.enum_Server)1)}";
	  strToolTipResult += 
		$"\n+ {System.Threading.Thread.CurrentThread.CurrentCulture.DisplayName}";
	  strToolTipResult += 
		$"\n+ {System.Threading.Thread.CurrentThread.CurrentCulture.Name}";
	  strToolTipResult += 
		$"\n+ {System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FullDateTimePattern}";
	  strToolTipResult += 
		$"\n+ {System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern}";
	  strToolTipResult += 
		$"\n+ {System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern}";

	  var myCurrentLang = System.Windows.Forms.InputLanguage.CurrentInputLanguage;
	  strToolTipResult +=
		$"\n+ Language preferences (keyboard) : {myCurrentLang.Culture.ThreeLetterISOLanguageName.ToUpper()}"
		+$" - {myCurrentLang.Culture.DisplayName} - {myCurrentLang.Culture.Name}";

	  string strDauThapPhan = "";

	  string strDauFullName = "";
	  string strToolTipThapPhan = "";
	  BLLTools.GetInfoPhanThapPhan(ref strDauThapPhan,ref strDauFullName,ref strToolTipThapPhan);
	  strToolTipThapPhan=
		$"Phần mềm hiện đang ngăn cách phần thập phân bởi dấu {strDauFullName} '{strDauThapPhan}'";
	  strToolTipResult+="\n+ "+strToolTipThapPhan;
	  //strToolTipResult+="\n(Click để hiển thị)";

	  txtData.ToolTip=strToolTipResult;
	}

	internal void CheckUpdateOnline(ref bool blnChayCapNhat,Dictionary<string,object> dicUpdateOnline) {
	  string strFolderName = dicUpdateOnline["stringtxtDownloadFolderName"] as string;
	  string strPathFolder = System.Windows.Forms.Application.StartupPath+$"\\{strFolderName}";
	  if(!System.IO.Directory.Exists(strPathFolder)) {
		blnChayCapNhat=true;
	  }
	}

	internal void KiemTraVaCapNhatPhienBan(ref bool blnStopFunction,Dictionary<string,object> dicLoginInfo,
	  string strKeyKichHoatUpdateOnline) {
	  if(dicLoginInfo.ContainsKey(strKeyKichHoatUpdateOnline)) {
		string strJsonDictionary = dicLoginInfo[strKeyKichHoatUpdateOnline] as string;
		var dicUpdateOnline = JsonConvert.DeserializeObject<Dictionary<string,object>>(strJsonDictionary);

		bool blnAutoTaiLink = (bool)dicUpdateOnline["boolchkAutoTaiLinkKhiLogin"];
		if(blnAutoTaiLink==true) {
		  DateTime dtPhienBanClient = (DateTime)dicLoginInfo["DateTimePhienBanClientHienTai"];
		  DateTime dtPhienBanChoPhepUpdate = (DateTime)dicUpdateOnline["DateTimetxtTimeDuocPhepUpdate"];
		  if(dtPhienBanClient.Date<dtPhienBanChoPhepUpdate.Date) {
			blnStopFunction=false;
			return;
		  }

		  //string strFolderName = dicUpdateOnline["stringtxtDownloadFolderName"] as string;
		  //string strPathFolder = System.Windows.Forms.Application.StartupPath+$"\\{strFolderName}";
		  //if(!System.IO.Directory.Exists(strPathFolder)) {
		  //  System.IO.Directory.CreateDirectory(strPathFolder);
		  //}

		  string strBase64DaMaHoa = "";
		  MaHoaBase64ChoJson(ref strBase64DaMaHoa,strJsonDictionary);

		  string strFileNameFullExtension = dicUpdateOnline["stringtxtInfoFromServerFileName"] as string;
		  System.IO.File.WriteAllText(
			System.Windows.Forms.Application.StartupPath+$"\\{strFileNameFullExtension}",strBase64DaMaHoa);

		  bool blnChayCapNhat = false;
		  CheckUpdateOnline(ref blnChayCapNhat,dicUpdateOnline);
		  if(blnChayCapNhat==true) {
			string strUpdateAppName = "UpdateVersionPro.exe";
			string strPathUpdateApp = System.Windows.Forms.Application.StartupPath+$"\\{strUpdateAppName}";
			if(!System.IO.File.Exists(strPathUpdateApp)) {
			  QT.MessageBox.QTMessageBox.ShowNotify(
				"Không tìm thấy bản chạy cập nhật, bạn vui lòng kiểm tra lại!",strPathUpdateApp);
			  blnStopFunction=false;
			  return;
			}

			System.Diagnostics.Process.Start(strPathUpdateApp);
			blnStopFunction=true;
			return;
		  }
		}
	  }

	  blnStopFunction=false;
	}

	internal void TryToRunUnikeyAsAdminIfNotRun() {
	  try {
		string strPathFileUnikey = System.Windows.Forms.Application.StartupPath
		  +$"\\unikeyx32\\UniKeyNT.exe";
		if(!System.IO.File.Exists(strPathFileUnikey)) {
		  return;
		}

		//Process[] pname = Process.GetProcessesByName("unikey");
		//if(pname.Length!=0) {
		//  return;
		//}
		var arrayProcess = Process.GetProcesses();
		foreach(var mProcess in arrayProcess) {
		  string strName = mProcess.ProcessName.ToLower();
		  if(strName.Contains("unikey")) {
			//mProcess.Kill();
			//break;
			return;
		  }
		}

		StartProcessAsAdmin(strPathFileUnikey);
	  } catch(Exception e) {
		string str = e.Message;
	  }
	}

	internal void StartProcessAsAdmin(string strPath) {
	  var proc = new System.Diagnostics.Process();
	  proc.StartInfo.FileName=strPath;
	  //proc.StartInfo.WindowStyle=ProcessWindowStyle.Minimized;
	  proc.StartInfo.UseShellExecute=true;
	  proc.StartInfo.Verb="runas";
	  proc.Start();
	}

	internal void GetPathFileLogToday(ref string strPathFileLogToday) {
	  var hierarchy = LogManager.GetRepository() as Hierarchy;
	  Logger logger = hierarchy.Root;

	  IAppender[] appenders = logger.Repository.GetAppenders();

	  // Check each appender this logger has
	  foreach(IAppender appender in appenders) {
		Type t = appender.GetType();
		// Get the file name from the first FileAppender found and return
		if(t.Equals(typeof(FileAppender)) || t.Equals(typeof(RollingFileAppender))) {
		  strPathFileLogToday = ((FileAppender)appender).File;
		  break;
		}
	  }
	}

	internal void MaHoaBase64ChoJson(ref string strBase64DaMaHoa,string strJsonDictionary) {
	  byte[] byt = System.Text.Encoding.UTF8.GetBytes(strJsonDictionary);
	  string strBase64 = Convert.ToBase64String(byt);
	  string strBeginAddToBase64 = "qt";
	  string strEndAddToBase64 = "tp";
	  //string strFileNameFullExtension = "Update.dat";

	  strBase64DaMaHoa=strBeginAddToBase64+strBase64+strEndAddToBase64;
	}

	internal void LoadJsonFromRegistry(ref string strJsonInReg,string[] arrayStringReg) {
	  try {
		Microsoft.Win32.RegistryKey key;
		key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey($"{arrayStringReg[0]}"+@"\"+$"{arrayStringReg[1]}");
		string stringValueBase64 = (string)key.GetValue(arrayStringReg[2]);
		strJsonInReg=Base64Decode(stringValueBase64);
	  } catch(Exception e) {
		string str = e.Message;
	  }
	}

	#region Function for ListMessages_ViewModel

	//internal void LoadGridMainByPage(ref ObservableCollection<ModelMessage> lstGridMain
 // ,int intIdPage,int CONST_INT_PAGE_SIZE,List<Tuple<Messages,string,string>> lstInput) {
	//  lstGridMain.Clear();

	//  int intStartIndex = intIdPage*CONST_INT_PAGE_SIZE;
	//  int intMaxEndIndexByPage = (intIdPage+1) * CONST_INT_PAGE_SIZE;
	//  int intEndIndex = lstInput.Count < intMaxEndIndexByPage ?
	//	lstInput.Count : intMaxEndIndexByPage;

	//  var lstInputByPage = new List<Tuple<Messages,string,string>>();
	//  for(int i = intStartIndex;i < intEndIndex;i++) {
	//	lstInputByPage.Add(lstInput[i]);
	//  }

	//  LoadGridMainByList(ref lstGridMain,lstInputByPage);

	//}

	//private void LoadGridMainByList(ref ObservableCollection<ModelMessage> lstGridMain
	//  ,List<Tuple<Messages,string,string>> lstInputByPage) {
	//  lstGridMain.Clear();

	//  int intIndexIncrease = 0;
	//  foreach(var item in lstInputByPage) {
	//	var mitem = new ModelMessage();
	//	mitem.Stt = ++intIndexIncrease;
	//	mitem.ObjItem = item;

	//	mitem.IntId=item.Item1.MessageID;
	//	mitem.StrTaiKhoanGui=item.Item1.Sender;
	//	mitem.IntMessageType=item.Item1.MessageType;

	//	string strType = "";
	//	GetStringTypeFromIndexEnum(ref strType,mitem.IntMessageType);
	//	mitem.StrMessageType=strType;
	//	//mitem.StrMessageType=AppConfig.ToText((AppConfig.enum_MessageType)mitem.IntMessageType);

	//	//		try {
	//	//		  byte[] byteTemp = item.MContent;
	//	//		  int intLengthByte = Compressor.Decompress(byteTemp).Length;
	//	//		  if(intLengthByte<20000) {
	//	//			mitem.Rtf=System.Text.Encoding.UTF8.GetString(
	//	//			  Compressor.Decompress(byteTemp),0,(Compressor.Decompress(byteTemp).Length));

	//	//			//System.Windows.Forms.RichTextBox rtbTemp = new System.Windows.Forms.RichTextBox();
	//	//			//rtbTemp.Rtf=mitem.Rtf;

	//	//		  } else {
	//	//			mitem.Rtf=@"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}}
	//	//{\colortbl ;\red0\green0\blue0;}
	//	//\viewkind4\uc1\pard\cf1\lang1033\f0\fs18 .\par
	//	//}";
	//	//		  }
	//	//		} catch(Exception e) {
	//	//		  string str = e.Message;
	//	//		}
	//	mitem.StrText=item.Item2;
	//	mitem.Rtf=item.Item3;

	//	mitem.Selected = false;
	//	lstGridMain.Add(mitem);
	//  }
	//}

	private void GetStringTypeFromIndexEnum(ref string strType,int intMessageType) {
	  switch(intMessageType) {
		case 2: {
			strType="Về kỳ thi";
		  }
		  break;
		case 3: {
			strType="Câu hỏi đã đạt";
		  }
		  break;
		case 4: {
			strType="Câu hỏi chưa đạt";
		  }
		  break;
		default:
		  strType="Khác";
		  break;
	  }
	}

	//internal void GetThongDiep(ref System.Windows.Forms.RichTextBox rtbThongDiep,Messages mMessage) {
	//  try {
	//	if(mMessage.MContent==null) {
	//	  rtbThongDiep.Text="";
	//	  return;
	//	}
	//	var Encoding = new UTF8Encoding();
	//	var strText = "";
	//	try {
	//	  string strTextContent = Encoding.GetString(
	//		mMessage.MContent,0,mMessage.MContent.Length);
	//	  int intTemp = strTextContent.IndexOf("\n");
	//	  strText=strTextContent.Substring(intTemp+1);
	//	  try {
	//		rtbThongDiep.Rtf=strText;
	//	  } catch {
	//		try {
	//		  rtbThongDiep.Rtf=strTextContent;
	//		  try {
	//			if(rtbThongDiep.Text.Substring(0,12).Contains("Mã câu hỏi")) {
	//			  int intTemp2 = rtbThongDiep.Text.IndexOf("\n");
	//			  string strTextKoCoMaCauHoi = rtbThongDiep.Text.Substring(intTemp2+1);
	//			  rtbThongDiep.Text=strTextKoCoMaCauHoi;
	//			}
	//		  } catch {

	//		  }
	//		} catch {
	//		  rtbThongDiep.Text=strText;
	//		}
	//	  }
	//	} catch {
	//	  rtbThongDiep.Text="";
	//	}
	//  } catch(Exception ex) {
	//	string str = ex.Message;
	//	rtbThongDiep.Text="";
	//  }
	//}

	#endregion

  }
}
