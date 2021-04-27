using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ModelQT.DAL;
using ModelQT.Framework;
using ModelQT.ViewModel;
using Newtonsoft.Json;

namespace WebLogQT.Common {
  public static class QTTools {
	public static string MD5Hash(string text) {
	  MD5 md5 = new MD5CryptoServiceProvider();

	  //compute hash from the bytes of text
	  md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

	  //get hash result after compute it
	  byte[] result = md5.Hash;

	  StringBuilder strBuilder = new StringBuilder();
	  for(int i = 0;i<result.Length;i++) {
		//change it into 2 hexadecimal digits
		//for each byte
		strBuilder.Append(result[i].ToString("x2"));
	  }

	  return strBuilder.ToString();
	}

	public static string RemoveUnicode(string s) {
	  s=s.Trim();
	  string normalized = s.Normalize(NormalizationForm.FormD);
	  StringBuilder sb = new StringBuilder();
	  for(int i = 0;i<normalized.Length;i++) {
		Char c = normalized[i];
		if(Convert.ToInt32(c)==273)
		  sb.Append("d");
		else if(Convert.ToInt32(c)==208|Convert.ToInt32(c)==272)
		  sb.Append("D");
		else if(CharUnicodeInfo.GetUnicodeCategory(c)!=UnicodeCategory.NonSpacingMark)
		  sb.Append(c);
	  }
	  string value = sb.ToString().Normalize(NormalizationForm.FormC);
	  string _return = "";
	  for(int i = 0;i<value.Length-1;i++) {
		string a = value.Substring(i,2);

		if(a=="  ") {
		  _return+="";
		} else {
		  _return+=a.Substring(0,1);
		}

	  }
	  string[] dau = new string[] { ":",",",".","!",";","?","'","-","`","~","@","#","$","%","^","&","*","(",")","/",",","\\","|","’","“" };
	  if(value.Length>0) {
		_return+=value.Substring(value.Length-1,1);
	  }
	  _return=_return.ToLower();
	  string _return2 = "";
	  for(int i = 0;i<_return.Length;i++) {
		bool check = false;
		string a = _return.Substring(i,1);
		for(int j = 0;j<dau.Length;j++) {
		  if(a==dau[j]) {
			check=true;
			break;
		  }
		}
		if(check==true) {
		  a="";
		}
		_return2+=a;
	  }
	  _return2=_return2.Replace("'","");
	  _return2=_return2.Replace(@"\","");
	  return _return2;
	}

	internal static void GetDictionaryFromKeywordJson(ref Dictionary<string,object> dicInput,string strKeyword) {
	  var lstStringKey = new List<string>();
	  lstStringKey.Add(strKeyword);

	  var lst = new List<TblJson>();
	  var dal = new DALJson();
	  dal.GetListByListKey(ref lst,lstStringKey);

	  string strJsonDictionary = lst[0].Json;

	  dicInput = new Dictionary<string,object>();
	  try {
		dicInput=JsonConvert.DeserializeObject<Dictionary<string,object>>(strJsonDictionary);
	  } catch(Exception et) {
		string str = et.Message;
	  }
	}

	internal static void GetListLienLacFromJson(ref List<VMLienLac> lstLienLac,string strJsonDictionary) {
	  try {
		var dicInput = JsonConvert.DeserializeObject<Dictionary<string,object>>(strJsonDictionary);
		lstLienLac=(List<VMLienLac>)JsonConvert.DeserializeObject(
		  dicInput["lstVMLienLac"].ToString(),(typeof(List<VMLienLac>)));
	  } catch(Exception et) {
		string str = et.Message;
	  }
	}

	internal static void UpdateJsonForKeyword(ref bool blnSuccess,string strUser,string strJsonToSave,string strKeyword) {
	  blnSuccess=false;
	  var mJsonInput = new TblJson();

	  mJsonInput.Json=strJsonToSave;
	  mJsonInput.Keyword=strKeyword;

	  //string strUser = (string)Session[CommonConstants.USER_SESSION];
	  mJsonInput.ModifiedBy=strUser;
	  mJsonInput.ModifiedDate=DateTime.Now;

	  string strDescription = "Truy cập trang để xem chi tiết nội dung này ...";
	  try {
		string strPlainTextTrim = QTTools.GetPlainTextFromHtml(mJsonInput.Json);
		strPlainTextTrim=System.Net.WebUtility.HtmlDecode(strPlainTextTrim);
		strDescription=strPlainTextTrim.Replace("  "," ");
	  } catch(Exception et) {
		string str = et.Message;
	  }
	  mJsonInput.Description=(strDescription.Length>240) ? (strDescription.Substring(0,240)+"...") : strDescription;

	  //minput.Status=true;

	  var dal = new DALJson();
	  blnSuccess=dal.BlnUpdateSuccessByKeyword(mJsonInput);
	}

	//public static string DecodeFromUtf8(this string utf8String) {
	//  // copy the string as UTF-8 bytes.
	//  byte[] utf8Bytes = new byte[utf8String.Length];
	//  for(int i = 0;i<utf8String.Length;++i) {
	//	//Debug.Assert( 0 <= utf8String[i] && utf8String[i] <= 255, "the char must be in byte's range");
	//	utf8Bytes[i]=(byte)utf8String[i];
	//  }

	//  return Encoding.UTF8.GetString(utf8Bytes,0,utf8Bytes.Length);
	//}

	public static string GetPlainTextFromHtml(string htmlString) {
	  //string htmlTagPattern = "<.*?>";
	  //var regexCss = new Regex("(\\<script(.+?)\\)|(\\<style(.+?)\\)",RegexOptions.Singleline|RegexOptions.IgnoreCase);
	  //htmlString=regexCss.Replace(htmlString,string.Empty);
	  //htmlString=Regex.Replace(htmlString,htmlTagPattern,string.Empty);
	  //htmlString=Regex.Replace(htmlString,@"^\s+$[\r\n]*","",RegexOptions.Multiline);
	  //htmlString=htmlString.Replace(" ",string.Empty);

	  //return htmlString;

	  //Match any Html tag (opening or closing tags) 
	  // followed by any successive whitespaces
	  //consider the Html text as a single line

	  Regex regex = new Regex("(<.*?>\\s*)+",RegexOptions.Singleline);

	  // replace all html tags (and consequtive whitespaces) by spaces
	  // trim the first and last space

	  string resultText = regex.Replace(htmlString," ").Trim();

	  return resultText;

	}

	internal static void GetListIntIndexRandomByCountList(ref List<int> lstIntIndexRandom,int intCountList) {
	  lstIntIndexRandom=new List<int>();

	  Random rnd = new Random();
	  int intIndexRandom = 0;
	  for(int i = 0;i<intCountList;i++) {
		do {
		  intIndexRandom=rnd.Next(0,intCountList);
		  if(lstIntIndexRandom.Contains(intIndexRandom)==false) {
			lstIntIndexRandom.Add(intIndexRandom);
			break;
		  }
		} while(lstIntIndexRandom.Contains(intIndexRandom)==true);
	  }
	}
  }
}