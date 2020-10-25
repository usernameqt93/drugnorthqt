using QT.Framework.ToolCommon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

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

  }
}
