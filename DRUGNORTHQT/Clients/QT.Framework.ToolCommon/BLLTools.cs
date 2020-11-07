using QT.Framework.ToolCommon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace QT.Framework.ToolCommon {
  public static class BLLTools {

	public static void AddItemCbo(int intId,string strName,object objItem,
	  ref ObservableCollection<ModelItems> lstCbo) {
	  var mItem = new ModelItems() { ID = intId,Name = strName };
	  if(objItem != null) {
		mItem.ObjItem = objItem;
	  }
	  lstCbo.Add(mItem);
	}

	public static void GetSumPageBySumItem(ref int intSumPage,int count,int INT_PAGE_SIZE) {
	  if(count==0) {
		intSumPage=1;
		return;
	  }

	  intSumPage = count % INT_PAGE_SIZE != 0 ?
		count / INT_PAGE_SIZE + 1 : count / INT_PAGE_SIZE;
	}

	#region Function for DeepCopy cho Dictionary

	public static void AddDeepModelToDictionary<T>(ref Dictionary<string,object> dicSubInput,string strKey,T objItem) {
	  T mitem = Helpers.Helpers.DeepCopy<T>(objItem);
	  dicSubInput.Add(strKey,mitem);
	}

	public static void AddDeepListModelToDictionary<T>(ref Dictionary<string,object> dicSubInput,
	  string strKey,List<T> lstObject) {
	  List<T> lstTemp = new List<T>();
	  if(lstObject==null) {
		dicSubInput.Add(strKey,null);
		return;
	  }
	  lstTemp.AddRange(lstObject);
	  dicSubInput.Add(strKey,lstTemp);
	}

	//public static void AddDeepListModelToDictionary(ref Dictionary<string,object> dicSubInput,
	//  string strKey,object obj) {
	//  if(obj==null) {
	//	dicSubInput.Add(strKey,null);
	//	return;
	//  }
	//}

	#endregion

	public static void CheckHaveSpaceBetween(ref bool blnHaveChar,string strInput) {
	  for(int i = 0;i < strInput.Length;i++) {
		if(strInput[i].Equals(" ")) {
		  blnHaveChar=true;
		  return;
		}
	  }
	}

	public static void CheckHaveCharVietnamese(ref bool blnHaveChar,string strInput) {
	  char[] _lstChar = new char[] { 'á', 'à', 'ả', 'ã', 'ạ', 'â', 'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ', 'ă', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ',
			'đ',
			'é','è','ẻ','ẽ','ẹ','ê','ế','ề','ể','ễ','ệ',
			'í','ì','ỉ','ĩ','ị',
			'ó','ò','ỏ','õ','ọ','ô','ố','ồ','ổ','ỗ','ộ','ơ','ớ','ờ','ở','ỡ','ợ',
			'ú','ù','ủ','ũ','ụ','ư','ứ','ừ','ử','ữ','ự',
			'ý','ỳ','ỷ','ỹ','ỵ'};
	  for(int i = 0;i < strInput.Length;i++) {
		if(_lstChar.Contains(strInput[i])) {
		  blnHaveChar=true;
		  return;
		}
	  }
	}

	public static void ChangeFormatBirthDay(ref string strBirthDay,string strFormat) {
	  string strTemp = strBirthDay;
	  try {
		DateTime dt = Convert.ToDateTime(strTemp);
		strBirthDay= dt.ToString(strFormat);
	  } catch {

	  }
	}

	/// <summary>
	/// Lấy thông tin về dấu thập phân()
	/// </summary>
	/// <param name="strDauThapPhan">Ví dụ như . hoặc ,</param>
	/// <param name="strChamHayPhay">Trả về 'chấm' hoặc 'phẩy'</param>
	/// <param name="strToolTip">Trả về máy tính đang cài đặt dấu gì ...</param>
	public static void GetInfoPhanThapPhan(ref string strDauThapPhan,
	  ref string strChamHayPhay,ref string strToolTip) {
	  strDauThapPhan =
		System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString();

	  strChamHayPhay = (strDauThapPhan.Equals(".")) ? "chấm" : "phẩy";

	  strToolTip=$"Máy tính của bạn hiện đang cài đặt ngăn cách phần thập phân bởi dấu {strChamHayPhay} '{strDauThapPhan}'";
	  strToolTip+="\nBạn có thể thay đổi bằng cách vào Control Panel --> Clock and Region";
	}

	#region Function for Loading

	/// <summary>
	/// Khởi tạo BackgroundWorker
	/// </summary>
	/// <param name="mpProgress"></param>
	/// <param name="bgWorker_DoWork"></param>
	/// <param name="bgWorker_RunWorkerCompleted"></param>
	/// <param name="bgWorker_ProgressChanged"></param>
	/// <param name="objInput">Object truyền vào hàm DoWork</param>
	public static void SetupBgWorker(ref ModelProgress mpProgress,
  Action<object,DoWorkEventArgs> bgWorker_DoWork,
  Action<object,RunWorkerCompletedEventArgs> bgWorker_RunWorkerCompleted,
  Action<object,ProgressChangedEventArgs> bgWorker_ProgressChanged,object objInput = null) {
	  mpProgress.BgWorker = new BackgroundWorker();
	  mpProgress.BgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
	  mpProgress.BgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
	  mpProgress.BgWorker.ProgressChanged+=new ProgressChangedEventHandler(bgWorker_ProgressChanged);

	  mpProgress.BgWorker.WorkerReportsProgress = true;
	  mpProgress.BgWorker.WorkerSupportsCancellation = true;

	  if(!mpProgress.BgWorker.IsBusy) {
		if(objInput==null) {
		  mpProgress.BgWorker.RunWorkerAsync();
		  return;
		}

		mpProgress.BgWorker.RunWorkerAsync(objInput);
	  }
	}

	/// <summary>
	/// Thay đổi thành x phần trăm, title và thông báo ở Progress
	/// </summary>
	/// <param name="mpProgress"></param>
	/// <param name="doublePercent">Phần trăm cần hiển thị</param>
	/// <param name="strTitle">Tiêu đề Progress</param>
	/// <param name="strMessage">Nội dung thông báo</param>
	public static void ReportProgressWorker(ref ModelProgress mpProgress,
	  double doublePercent,string strTitle,string strMessage) {
	  mpProgress.DoublePercent=doublePercent;
	  mpProgress.StrTitle=strTitle;
	  mpProgress.StrMessageProgress=strMessage;
	  mpProgress.BgWorker.ReportProgress(0);
	}

	/// <summary>
	/// Giữ nguyên title, thông báo, tăng thêm vào phần trăm hiện tại thêm x phần trăm
	/// </summary>
	/// <param name="mpProgress"></param>
	/// <param name="doubleIncrease">Phần trăm cần cộng thêm</param>
	public static void IncreaseProgressWorker(ref ModelProgress mpProgress,double doubleIncrease) {
	  mpProgress.DoublePercent+=doubleIncrease;
	  mpProgress.BgWorker.ReportProgress(0);
	}

	/// <summary>
	/// Thay đổi title, thông báo, tăng thêm vào phần trăm hiện tại thêm x phần trăm
	/// </summary>
	/// <param name="mpProgress"></param>
	/// <param name="doubleIncrease">Phần trăm cần cộng thêm</param>
	/// <param name="strTitle"></param>
	/// <param name="strMessage"></param>
	public static void IncreaseProgressWorker(ref ModelProgress mpProgress,double doubleIncrease,
	  string strTitle,string strMessage) {
	  mpProgress.DoublePercent+=doubleIncrease;
	  mpProgress.StrTitle=strTitle;
	  mpProgress.StrMessageProgress=strMessage;
	  mpProgress.BgWorker.ReportProgress(0);
	}

	/// <summary>
	/// Tính toán lấy phần trăm cần tăng trong vòng for
	/// </summary>
	/// <param name="doubleOutput">Kết quả đầu ra</param>
	/// <param name="intSum">Tổng số lần lặp của vòng for</param>
	/// <param name="doublePercentCurrent">Phần trăm hiện tại đang hiển thị</param>
	/// <param name="intCountUseReportProgress">Số lần sử dụng ReportProgress trong vòng for</param>
	public static void GetIncreasePercent(ref double doubleOutput,int intSum,
	  double doublePercentCurrent,int intCountUseReportProgress) {
	  if(intSum==0) {
		return;
	  }

	  doubleOutput=Math.Round(((100-doublePercentCurrent)/(intSum+1))/intCountUseReportProgress,2);
	}

	#endregion

	#region Get và set value in file config

	/// <summary>
	/// Kiểm tra giá trị của key trong file config, nếu có key thì xóa đi và thêm mới giá trị key và value(trim() luôn value này)
	/// </summary>
	/// <param name="strKey"></param>
	/// <param name="strValue"></param>
	public static void ChangeValueOfKeyInFileConfig(string strKey,string strValue) {
	  Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	  if(_config.AppSettings.Settings.AllKeys.Contains(strKey)) {
		_config.AppSettings.Settings.Remove(strKey);
	  }
	  _config.AppSettings.Settings.Add(strKey,strValue.Trim());
	  ConfigurationManager.RefreshSection("appSettings");
	  _config.Save(ConfigurationSaveMode.Modified);
	  ConfigurationManager.RefreshSection(_config.AppSettings.SectionInformation.Name);
	  Properties.Settings.Default.Reload();
	}

	/// <summary>
	/// Lấy giá trị value A(trim luôn) của key B trong file config, nếu không có key thì không làm gì Output
	/// </summary>
	/// <param name="strOutputValue"></param>
	/// <param name="strKey"></param>
	public static void GetValueFromFileConfig(ref string strOutputValue,string strKey) {
	  if(System.Configuration.ConfigurationManager.AppSettings[strKey]!=null) {
		strOutputValue=(System.Configuration.ConfigurationManager.AppSettings[strKey]).Trim();
	  }
	}

	#endregion

	#region Chuyển dữ liệu từ dạng bytes sang Dictionary và ngược lại

	/// <summary>
	/// Chuyển dữ liệu từ Dictionary sang json rồi chuyển sang dạng byte
	/// </summary>
	/// <param name="byteOutput"></param>
	/// <param name="dicInput"></param>
	public static void GetBytesJsonFromDictionary(ref byte[] byteOutput,
  Dictionary<string,object> dicInput) {
	  var strJson = JsonConvert.SerializeObject(dicInput);

	  var encode = new UTF8Encoding();
	  byteOutput = encode.GetBytes(strJson);
	}

	/// <summary>
	/// Chuyển dữ liệu từ dạng byte sang json rồi chuyển sang Dictionary
	/// </summary>
	/// <param name="dicOutput"></param>
	/// <param name="byteInput"></param>
	public static void GetDictionaryFromBytesJson(ref Dictionary<string,object> dicOutput,byte[] byteInput) {
	  var _encode = new UTF8Encoding();
	  var strJson = _encode.GetString(byteInput,0,byteInput.Length);
	  dicOutput = JsonConvert.DeserializeObject<Dictionary<string,object>>(strJson);
	}

	#endregion

	/// <summary>
	/// Xóa folder temp rồi copy file ra thư mục temp rồi trả về path temp để import chẳng hạn ...
	/// </summary>
	/// <param name="strPathFile"></param>
	public static void CopyAndGetPathFileTemp(ref string strPathFile) {
	  string CONST_STR_TEMPORARY_FOLDER_NAME = "TemporaryFiles";
	  string strPathFolderTemp = System.Windows.Forms.Application.StartupPath
		+$"\\{CONST_STR_TEMPORARY_FOLDER_NAME}";
	  try {
		if(System.IO.Directory.Exists(strPathFolderTemp)) {
		  //System.IO.Directory.Delete(strPathFolderTemp,true);
		  DeteleFolderReadOnly(strPathFolderTemp);
		}

		System.IO.Directory.CreateDirectory(strPathFolderTemp);
	  } catch(Exception e) {
		string str = e.Message;
	  }

	  string strPathFileTemp = strPathFolderTemp+$"\\{System.IO.Path.GetFileName(strPathFile)}";
	  try {
		System.IO.File.Copy(strPathFile,strPathFileTemp,true);
	  } catch(Exception e) {
		string str = e.Message;

		strPathFileTemp = strPathFolderTemp
		  +$"\\{DateTime.Now.ToString("yyyyMMddHHmmss")}{System.IO.Path.GetFileName(strPathFile)}";
		System.IO.File.Copy(strPathFile,strPathFileTemp,true);
	  }

	  var fileInfo = new System.IO.FileInfo(strPathFileTemp);
	  fileInfo.Attributes= System.IO.FileAttributes.Normal;

	  strPathFile =strPathFileTemp;
	}

	/// <summary>
	/// Xóa folder temp rồi copy file ra thư mục temp rồi trả về path temp theo strNewExtension(ví dụ: .doc) để import chẳng hạn ...
	/// </summary>
	public static void CopyAndGetPathFileTempByNewExtension(ref string strPathFile,string strNewExtension) {
	  string CONST_STR_TEMPORARY_FOLDER_NAME = "TemporaryFiles";
	  string strPathFolderTemp = System.Windows.Forms.Application.StartupPath
		+$"\\{CONST_STR_TEMPORARY_FOLDER_NAME}";
	  try {
		if(System.IO.Directory.Exists(strPathFolderTemp)) {
		  //System.IO.Directory.Delete(strPathFolderTemp,true);
		  DeteleFolderReadOnly(strPathFolderTemp);
		}

		System.IO.Directory.CreateDirectory(strPathFolderTemp);
	  } catch(Exception e) {
		string str = e.Message;
	  }

	  string strPathFileTemp = strPathFolderTemp
		+$"\\{System.IO.Path.GetFileNameWithoutExtension(strPathFile)+strNewExtension}";
	  try {
		System.IO.File.Copy(strPathFile,strPathFileTemp,true);
	  } catch(Exception e) {
		string str = e.Message;

		strPathFileTemp=strPathFolderTemp
		  +$"\\{DateTime.Now.ToString("yyyyMMddHHmmss")}{System.IO.Path.GetFileNameWithoutExtension(strPathFile)+strNewExtension}";
		System.IO.File.Copy(strPathFile,strPathFileTemp,true);
	  }

	  var fileInfo = new System.IO.FileInfo(strPathFileTemp);
	  fileInfo.Attributes=System.IO.FileAttributes.Normal;

	  strPathFile=strPathFileTemp;
	}

	private static void DeteleFolderReadOnly(string strPathFolderTemp) {
	  var directory = new System.IO.DirectoryInfo(strPathFolderTemp) {
		Attributes = System.IO.FileAttributes.Normal
	  };

	  foreach(var info in directory.GetFileSystemInfos("*",System.IO.SearchOption.AllDirectories)) {
		info.Attributes = System.IO.FileAttributes.Normal;
	  }

	  directory.Delete(true);
	}

	/// <summary>
	/// Ví dụ list string là a b c 
	/// thì output là "a,b,c" hoặc "t.a,t.b,t.c" với t là tiền tố, dấu phẩy là phân cách
	/// </summary>
	/// <param name="strOutput"></param>
	/// <param name="lstStringInput"></param>
	/// <param name="strCharSplit"></param>
	/// <param name="strTienTo"></param>
	public static void GetStringJoinSplitChar(ref string strOutput
	  ,List<string> lstStringInput,string strCharSplit,string strTienTo) {
	  if(lstStringInput.Count==0) {
		return;
	  }

	  string strThemVao = "";
	  if(strTienTo!="") {
		strThemVao=$"{strTienTo}.";
	  }

	  for(int i = 0;i<lstStringInput.Count;i++) {
		if(i==0) {
		  strOutput+=strThemVao+lstStringInput[i];
		  continue;
		}

		strOutput+=strCharSplit+strThemVao+lstStringInput[i];
	  }
	}

	/// <summary>
	/// Ví dụ list string là a b c 
	/// thì output là "a,b,c" hoặc "t.a,t.b,t.c" với t là tiền tố, dấu phẩy là phân cách
	/// </summary>
	/// <param name="strOutput"></param>
	/// <param name="lstStringInput"></param>
	/// <param name="strCharSplit"></param>
	/// <param name="strTienTo"></param>
	public static void GetStringJoinSplitChar(ref string strOutput
	  ,List<int> lstStringInput,string strCharSplit,string strTienTo) {
	  if(lstStringInput.Count==0) {
		return;
	  }

	  string strThemVao = "";
	  if(strTienTo!="") {
		strThemVao=$"{strTienTo}.";
	  }

	  for(int i = 0;i<lstStringInput.Count;i++) {
		if(i==0) {
		  strOutput+=strThemVao+lstStringInput[i];
		  continue;
		}

		strOutput+=strCharSplit+strThemVao+lstStringInput[i];
	  }
	}

	public static void UpperTextStartByQuantity(ref string strOutput,string strInput,int intSoKyTuDauTien) {
	  if(intSoKyTuDauTien<=0) {
		strOutput=strInput;
		return;
	  }

	  if(intSoKyTuDauTien>=strInput.Length) {
		strOutput=strInput.ToUpper();
		return;
	  }

	  strOutput=strInput.Substring(0,intSoKyTuDauTien).ToUpper()+strInput.Substring(intSoKyTuDauTien);
	}

	public static void SetValueBaseRowDataTableByIndexRow(ref ModelBaseRow mrow,int intIndexRow
	  ,DataTable dtInput) {
	  if(dtInput==null||intIndexRow>=dtInput.Rows.Count) {
		return;
	  }

	  int intSumColumn = dtInput.Columns.Count;
	  for(int k = 0;k<intSumColumn;k++) {
		var mcell = new ModelBaseCell();
		mcell.StrColumnName=dtInput.Columns[k].ColumnName;

		object objTemp = dtInput.Rows[intIndexRow][k];
		mcell.ObjItem=objTemp;
		if(objTemp!=null) {
		  mcell.Str=dtInput.Rows[intIndexRow][k].ToString();
		}

		mrow.SetValueCell(k,mcell);
	  }
	}

	#region Convert object to string theo format

	/// <summary>
	/// Nếu decimal bằng 0 thì trả về 0 vì mặc định nó trả về 00, không thì trả về đúng dạng
	/// </summary>
	/// <param name="strOutput"></param>
	/// <param name="decInput"></param>
	/// <param name="strEndString"></param>
	public static void GetStringFormatTienMat(ref string strOutput,decimal decInput,string strEndString) {
	  if(decInput<0) {
		return;
	  }
	  if(decInput==0) {
		strOutput="0"+strEndString;
		return;
	  }

	  strOutput=""+string.Format("{0:0,0}",decInput)+strEndString;
	}

	/// <summary>
	/// mặc định trả về 0 value và "0"+"strEndString" nếu không hợp lệ
	/// </summary>
	/// <param name="decOutput"></param>
	/// <param name="strOutput"></param>
	/// <param name="objInput"></param>
	/// <param name="strEndString"></param>
	public static void GetStringFormatTienMat(ref decimal decOutput,ref string strOutput
	  ,object objInput,string strEndString) {
	  decOutput=0;
	  try {
		decOutput=Convert.ToDecimal(objInput);
	  } catch(Exception e) {
		string str = e.Message;
	  }

	  GetStringFormatTienMat(ref strOutput,decOutput,strEndString);
	}

	/// <summary>
	/// nếu không hợp lệ, mặc định sẽ trả về 1993.11.13 và string không thay đổi gì cả
	/// </summary>
	/// <param name="dtOutput"></param>
	/// <param name="strOutput"></param>
	/// <param name="objInput"></param>
	public static void GetStringFormatDateTimeVN(ref DateTime dtOutput,ref string strOutput,object objInput) {
	  dtOutput=new DateTime(1993,11,13);
	  try {
		dtOutput=Convert.ToDateTime(objInput);
		strOutput=dtOutput.ToString("yyyy-MM-dd HH:mm:ss");
	  } catch(Exception e) {
		string str = e.Message;
	  }
	}

	#endregion

	/// <summary>
	/// mặc định trả về 0 value và "0"+"strEndString" nếu không hợp lệ
	/// </summary>
	/// <param name="mOutput"></param>
	/// <param name="obj"></param>
	/// <param name="strEndString"></param>
	public static void GetModelDecimalFromObject(ref ModelBaseDecimal mOutput,object obj,string strEndString) {
	  decimal objTemp = 0;
	  string strHienThi = "";
	  BLLTools.GetStringFormatTienMat(ref objTemp,ref strHienThi,obj,strEndString);
	  mOutput.Value=objTemp;
	  mOutput.Str=strHienThi;
	}

	/// <summary>
	/// nếu không hợp lệ, mặc định sẽ trả về 1993.11.13 và string ""
	/// </summary>
	/// <param name="mOutput"></param>
	/// <param name="obj"></param>
	public static void GetModelDateTimeFromObject(ref ModelBaseDateTime mOutput,object obj) {
	  DateTime objTemp = new DateTime(1993,11,13);
	  string strHienThi = "";
	  BLLTools.GetStringFormatDateTimeVN(ref objTemp,ref strHienThi,obj);
	  mOutput.Value=objTemp;
	  mOutput.Str=strHienThi;
	}

  }
}
