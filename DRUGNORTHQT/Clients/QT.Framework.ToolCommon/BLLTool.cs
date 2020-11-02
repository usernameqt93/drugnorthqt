using QT.Framework.ToolCommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace QT.Framework.ToolCommon {
  public class BLLTool {

	public void CheckAndAddItemToList(ref List<int> lstIdSearch,int intTemp) {
	  for(int i = 0;i < lstIdSearch.Count;i++) {
		if(lstIdSearch[i]==intTemp) {
		  return;
		}
	  }

	  lstIdSearch.Add(intTemp);
	}

	public void CheckHaveSpaceBetween(ref bool blnHaveChar,string strInput) {
	  for(int i = 0;i < strInput.Length;i++) {
		if(strInput[i].Equals(" ")) {
		  blnHaveChar=true;
		  return;
		}
	  }
	}

	public void CheckHaveCharVietnamese(ref bool blnHaveChar,string strInput) {
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

	public void CheckAndChangeTimeToTimeHeThong(DateTime serverDateTime) {
	  if(Math.Abs((DateTime.Now - serverDateTime).TotalSeconds) <= 5) //Nếu chênh lệch không quá 5 giây thì không đổi giờ
		return;

	  TimeSpan currentOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
	  int year = serverDateTime.Year;
	  int month = serverDateTime.Month;
	  int day = serverDateTime.Day;
	  int hour = serverDateTime.Hour - (int)currentOffset.TotalHours;
	  int minte = serverDateTime.Minute;
	  int second = serverDateTime.Second;
	  //win 7 và xp
	  SetTime(year,month,day,hour,minte,second);
	  //win 8 và win 10
	  string _sLongTime = serverDateTime.ToLongTimeString();
	  string _sShortDate = serverDateTime.ToShortDateString();
	  if(CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern == "dd-MMM-yy") {
		System.Diagnostics.Process.Start("CMD","/C date " + day + "-" + month + "-" + year);
		System.Diagnostics.Process _process = new System.Diagnostics.Process();
		var _procInfo = new System.Diagnostics.ProcessStartInfo();
		_procInfo.UseShellExecute = true;
		_procInfo.WorkingDirectory = @"C:\Windows\System32";
		_procInfo.FileName = @"C:\Windows\System32\cmd.exe";
		_procInfo.Verb = "runas";
		_procInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		_procInfo.UseShellExecute = true;
		_procInfo.Arguments = "/C date " + day + "-" + month + "-" + year + " | time " + _sLongTime;
		_process.StartInfo = _procInfo;
		_process.Start();
	  } else {
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		var _procInfo = new System.Diagnostics.ProcessStartInfo();
		_procInfo.UseShellExecute = true;
		_procInfo.WorkingDirectory = @"C:\Windows\System32";
		_procInfo.FileName = @"C:\Windows\System32\cmd.exe";
		_procInfo.Verb = "runas";
		_procInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		_procInfo.UseShellExecute = true;
		_procInfo.Arguments = "/C date " + _sShortDate + " | time " + _sLongTime;
		process.StartInfo = _procInfo;
		process.Start();
	  }
	}

	private void SetTime(int year,int month,int day,int hour,int minte,int second) {
	  SYSTEMTIME updatedTime = new SYSTEMTIME();
	  updatedTime.wYear = (ushort)year;
	  updatedTime.wMonth = (ushort)month;
	  updatedTime.wDay = (ushort)day;
	  updatedTime.wHour = (ushort)hour;
	  updatedTime.wMinute = (ushort)minte;
	  updatedTime.wSecond = (ushort)second;
	  SetSystemTime(ref updatedTime);
	}

	/// <summary>
	/// cấu trúc ngày giờ thơi gian
	/// </summary>
	private struct SYSTEMTIME {
	  public ushort wYear;
	  public ushort wMonth;
	  public ushort wDayOfWeek;
	  public ushort wDay;
	  public ushort wHour;
	  public ushort wMinute;
	  public ushort wSecond;
	  public ushort wMilliseconds;
	}

	public void GetSumPageBySumItem(ref int intSumPage,int count,int INT_PAGE_SIZE) {
	  if(count==0) {
		intSumPage=1;
		return;
	  }

	  intSumPage = count % INT_PAGE_SIZE != 0 ?
		count / INT_PAGE_SIZE + 1 : count / INT_PAGE_SIZE;
	}

	/// <summary>
	/// set lại giờ hệ thống
	/// </summary>
	/// <param name="st"></param>
	/// <returns></returns>
	[DllImport("kernel32.dll",SetLastError = true)]
	private static extern bool SetSystemTime([In] ref SYSTEMTIME st);

	public void AddDeepModelToDictionary<T>(ref Dictionary<string,object> dicSubInput,string strKey,T objItem) {
	  T mitem = Helpers.Helpers.DeepCopy<T>(objItem);
	  dicSubInput.Add(strKey,mitem);
	}

	public void AddDeepListModelToDictionary<T>(ref Dictionary<string,object> dicSubInput,
	  string strKey,List<T> lstObject) {
	  List<T> lstTemp = new List<T>();
	  if(lstObject==null) {
		dicSubInput.Add(strKey,null);
		return;
	  }
	  lstTemp.AddRange(lstObject);
	  dicSubInput.Add(strKey,lstTemp); 
	}

	public void AddDeepListModelToDictionary(ref Dictionary<string,object> dicSubInput,
	  string strKey,object obj) {
	  if(obj==null) {
		dicSubInput.Add(strKey,null);
		return;
	  }
	}

	public void ChangeFormatBirthDay(ref string strBirthDay,string strFormat) {
	  string strTemp = strBirthDay;
	  try {
		DateTime dt = Convert.ToDateTime(strTemp);
		strBirthDay= dt.ToString(strFormat);
	  } catch {

	  }
	}
  }
}
