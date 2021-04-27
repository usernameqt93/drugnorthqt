using ModelQT.DAL;
using ModelQT.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLogQT.Common;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class CtlChatOnlineController:BaseUserController {
	// GET: AreaAccount/CtlChatOnline
	public ActionResult Index() {
	  var dicInput = new Dictionary<string,object>();
	  QTTools.GetDictionaryFromKeywordJson(ref dicInput,CommonConstants.STR_CONST_KEYWORD_JSON_CHATONLINE_SETTING);

	  string strKeywordHtml = "KeyKoTrung1311";
	  string strKey = "strKeywordHtml";
	  if(dicInput.ContainsKey(strKey)) {
		strKeywordHtml=dicInput[strKey].ToString();
	  }

	  var lstTupleIdText = new List<Tuple<string,string,string>>();
	  lstTupleIdText.Add(new Tuple<string, string,string>(
		"flexRadioVChat","Sử dụng chat trực tuyến qua vchat","Html_Active_VChat"));
	  lstTupleIdText.Add(new Tuple<string, string,string>(
		  "flexRadioTawkTo","Sử dụng chat trực tuyến qua tawk.to","Html_Active_TawkTo"));

	  bool blnDaChon = false;
	  var lstTupleIdCheckedDisableText = new List<Tuple<string,string,string,string>>();
	  foreach(var item in lstTupleIdText) {
		if(item.Item3==strKeywordHtml) {
		  lstTupleIdCheckedDisableText.Add(
			new Tuple<string,string,string,string>(
			  item.Item1,"checked disabled",item.Item2,item.Item3));
		  blnDaChon=true;
		  continue;
		}

		lstTupleIdCheckedDisableText.Add(
		  new Tuple<string,string,string,string>(
			item.Item1,"",item.Item2,item.Item3));
	  }

	  if(blnDaChon==true) {
		lstTupleIdCheckedDisableText.Add(
		  new Tuple<string,string,string,string>(
			"flexRadioTat","","Tắt chat trực tuyến","KeyKoTrung1311"));
	  } else {
		lstTupleIdCheckedDisableText.Add(
		  new Tuple<string,string,string,string>(
			"flexRadioTat","checked disabled","Tắt chat trực tuyến","KeyKoTrung1311"));
	  }

	  return View(lstTupleIdCheckedDisableText);
	}

	public JsonResult JRUpdateSetting(string strInput) {
	  if(strInput==null) {
		strInput="";
	  }

	  var dicInput = new Dictionary<string,object>();
	  QTTools.GetDictionaryFromKeywordJson(ref dicInput,CommonConstants.STR_CONST_KEYWORD_JSON_CHATONLINE_SETTING);

	  string strKey = "strKeywordHtml";
	  dicInput[strKey]=strInput;

	  string strJsonToSave = JsonConvert.SerializeObject(dicInput
			,Newtonsoft.Json.Formatting.Indented);

	  string strUser = (string)Session[CommonConstants.USER_SESSION];
	  bool blnSuccess = false;
	  QTTools.UpdateJsonForKeyword(ref blnSuccess,strUser,strJsonToSave,CommonConstants.STR_CONST_KEYWORD_JSON_CHATONLINE_SETTING);
	  if(blnSuccess==true) {
		return Json(new {
		  blnStatusJs = true
		});
	  }

	  return Json(new {
		blnStatusJs = false
	  });
	}

  }
}