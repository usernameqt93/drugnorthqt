using ModelQT.DAL;
using ModelQT.Framework;
using ModelQT.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLogQT.Common;

namespace WebLogQT.Controllers {
  public class CtlHomeController:Controller {
	// GET: CtlHome
	public ActionResult Index() {
	  string strLink = "";
	  try {
		strLink=ConfigurationManager.AppSettings["strLinkRedirect"].ToString();
	  } catch(Exception et) {
		string str = et.Message;
	  }
	  if(strLink!="") {
		return Redirect(strLink);
	  }

	  return Redirect("http://google.com");
	}

	public ActionResult ARIndexLog() {
	  var lst = new List<TblPostBaiViet>();

	  var lstStringBackground = new List<string>();
	  lstStringBackground.Add("bg-warning");
	  lstStringBackground.Add("bg-success");
	  lstStringBackground.Add("bg-danger");
	  lstStringBackground.Add("bg-info");

	  var dal = new DALPost();
	  dal.GetListByPageAndSize(ref lst,0,10);

	  var lstIntRandom = new List<int>();
	  Common.QTTools.GetListIntIndexRandomByCountList(ref lstIntRandom,lstStringBackground.Count);

	  var lstStringClassBackgroundRandom = new List<string>();
	  for(int i = 0;i<200;i++) {
		if(i%2==0) {
		  lstStringClassBackgroundRandom.Add("");
		  continue;
		}

		int intIndex = (i/2)%lstStringBackground.Count;
		lstStringClassBackgroundRandom.Add(lstStringBackground[lstIntRandom[intIndex]]);
	  }

	  ViewBag.LstString=lstStringClassBackgroundRandom;
	  ViewBag.VBLstPost=lst;
	  return View();
	}

	public ActionResult ARIndex() {

	  {
		var dic = new Dictionary<string,object>();
		dic["strTitleH1"]="ĐĂNG KÝ INTERNET CÁP QUANG FPT";
		dic["strDescription"]="Cáp quang FPT sử dụng công nghệ FTTH mới với tốc độ vượt trội và ổn định hơn hẳn so với mạng cáp quang thông thường bảo mật luôn ở mức tối đa";

		var lstStringKey = new List<string>();
		lstStringKey.Add("Html_Goi30M");
		lstStringKey.Add("Html_Goi80M");
		lstStringKey.Add("Html_Goi100M");
		lstStringKey.Add("Html_Goi150M");
		dic["lstStringKey"]=lstStringKey;

		string strJsonToSave = Newtonsoft.Json.JsonConvert.SerializeObject(dic
				,Newtonsoft.Json.Formatting.Indented);
		ViewBag.strJsonDictionaryHoGiaDinh=strJsonToSave;
	  }

	  {
		var dic = new Dictionary<string,object>();
		dic["strTitleH1"]="INTERNET DOANH NGHIỆP - QUÁN GAME";
		dic["strDescription"]="     ";

		var lstStringKey = new List<string>();
		lstStringKey.Add("Html_Goi200M");
		lstStringKey.Add("Html_Goi250M");
		lstStringKey.Add("Html_Goi400M");
		lstStringKey.Add("Html_Goi500M");
		dic["lstStringKey"]=lstStringKey;

		string strJsonToSave = Newtonsoft.Json.JsonConvert.SerializeObject(dic
				,Newtonsoft.Json.Formatting.Indented);
		ViewBag.strJsonDictionaryDoanhNghiep=strJsonToSave;
	  }

	  return View();
	}

	[ChildActionOnly]
	public ActionResult ARMainMenuPV(string strInput) {
	  return PartialView();
	}

	[ChildActionOnly]
	public ActionResult ARListGoiCuocPV(string strJsonDictionary) {
	  var dicInput = JsonConvert.DeserializeObject<Dictionary<string,object>>(strJsonDictionary);

	  var lstStringKey = (List<string>)JsonConvert.DeserializeObject(
			  dicInput["lstStringKey"].ToString(),(typeof(List<string>)));

	  ViewBag.strTitleH1=dicInput["strTitleH1"].ToString();
	  ViewBag.strDescription=dicInput["strDescription"].ToString();

	  var lst = new List<TblHtmlRaw>();

	  var dal = new DALHtmlRaw();
	  dal.GetListByListKey(ref lst,lstStringKey);
	  return PartialView(lst);
	}

	[ChildActionOnly]
	public ActionResult ARFooterPV(string strInput) {
	  return PartialView();
	}

	[ChildActionOnly]
	public ActionResult ARCachLienLacPV(string strInput) {
	  var dicInput = new Dictionary<string,object>();
	  QTTools.GetDictionaryFromKeywordJson(ref dicInput,CommonConstants.STR_CONST_KEYWORD_JSON_CHATONLINE_SETTING);

	  string strKeywordHtml = "KeyKoTrung1311";
	  string strKey = "strKeywordHtml";
	  if(dicInput.ContainsKey(strKey)) {
		strKeywordHtml=dicInput[strKey].ToString();
	  }

	  {
		var lstStringKey = new List<string>();
		lstStringKey.Add(strKeywordHtml);

		var lstHtml = new List<TblHtmlRaw>();

		var dal = new DALHtmlRaw();
		dal.GetListByListKey(ref lstHtml,lstStringKey);

		string strHtml = "";
		if(lstHtml.Count==1&&lstHtml[0]!=null) {
		  strHtml=lstHtml[0].Html;
		}
		ViewBag.strHtmlChatOnline=strHtml;
	  }

	  var lst = new List<TblJson>();
	  {
		var lstStringKey = new List<string>();
		lstStringKey.Add(CommonConstants.STR_CONST_KEYWORD_JSON_LIENLAC);

		var dal = new DALJson();
		dal.GetListByListKey(ref lst,lstStringKey);
	  }

	  string strJsonDictionary = lst[0].Json;

	  var lstLienLac = new List<VMLienLac>();
	  QTTools.GetListLienLacFromJson(ref lstLienLac,strJsonDictionary);

	  return PartialView(lstLienLac);
	}

	[ChildActionOnly]
	public ActionResult ARFooterCopyRightPV(string strInput) {
	  return PartialView();
	}

	public ActionResult ARIndexMain() {
	  return View();
	}

	public ActionResult ARIndexMobile() {
	  return View();
	}

	public ActionResult ARIndexChiTiet() {
	  return View();
	}

	public ActionResult ARLogin() {
	  return Redirect("/AreaAccount");
	  //return View("~/Areas/AreaAccount/Views/CtlLogin/ARIndex.cshtml");
	}

  }
}