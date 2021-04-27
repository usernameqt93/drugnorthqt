using ModelQT.DAL;
using ModelQT.Framework;
using ModelQT.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLogQT.Common;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class CtlLienLacController:BaseUserController {
	// GET: AreaAccount/CtlLienLac
	public ActionResult Index() {
	  return View();
	}

	public ActionResult ARIndex() {
	  if(Session[CommonConstants.ID_SESSION]!=null) {
		var dicToSaveJson = new Dictionary<string,object>();
		dicToSaveJson["longId"]=((long)Session[CommonConstants.ID_SESSION]);
		string strJsonToSave = JsonConvert.SerializeObject(dicToSaveJson
			  ,Newtonsoft.Json.Formatting.Indented);
		ViewBag.strJsonDictionary=strJsonToSave;
	  }

	  var lstStringKey = new List<string>();
	  lstStringKey.Add(CommonConstants.STR_CONST_KEYWORD_JSON_LIENLAC);

	  var lst = new List<TblJson>();
	  var dal = new DALJson();
	  dal.GetListByListKey(ref lst,lstStringKey);

	  string strJsonDictionary = lst[0].Json;
	  Session[CommonConstants.LIST_LIENLAC_SESSION]=strJsonDictionary;

	  var lstLienLac = new List<VMLienLac>();
	  QTTools.GetListLienLacFromJson(ref lstLienLac,strJsonDictionary);

	  return View(lstLienLac);
	}

	public ActionResult ARCreate() {
	  return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ValidateInput(false)]
	public ActionResult ARCreate(VMLienLac minput) {
	  try {
		if(ModelState.IsValid==false) {
		  return View(minput);
		}

		var lstLienLac = new List<VMLienLac>();
		string strJson = (string)Session[CommonConstants.LIST_LIENLAC_SESSION];
		QTTools.GetListLienLacFromJson(ref lstLienLac,strJson);

		minput.Id=lstLienLac.Count;
		lstLienLac.Add(minput);

		var dicToSaveJson = new Dictionary<string,object>();
		dicToSaveJson["lstVMLienLac"]=lstLienLac;
		string strJsonToSave = JsonConvert.SerializeObject(dicToSaveJson
			  ,Newtonsoft.Json.Formatting.Indented);

		string strUser = (string)Session[CommonConstants.USER_SESSION];
		bool blnSuccess = false;
		QTTools.UpdateJsonForKeyword(ref blnSuccess,strUser,strJsonToSave,CommonConstants.STR_CONST_KEYWORD_JSON_LIENLAC);
		if(blnSuccess==true) {
		  return RedirectToAction(nameof(ARIndex));
		}

		ModelState.AddModelError("","Thao tác không thành công!");

		return View(minput);
	  } catch(Exception et) {
		string str = et.Message;
		ModelState.AddModelError("",str);
		return View(minput);
	  }
	}

	public JsonResult JRShowUpdatePartialView(long longId) {
	  Session[CommonConstants.ID_SESSION]=longId;
	  return Json(new {
		blnStatusJs = true
	  });
	}

	[ChildActionOnly]
	public ActionResult ARUpdatePV(string strJsonDictionary) {
	  var lstLienLac = new List<VMLienLac>();
	  string strJson = (string)Session[CommonConstants.LIST_LIENLAC_SESSION];
	  QTTools.GetListLienLacFromJson(ref lstLienLac,strJson);

	  if(lstLienLac.Count==0) {
		return PartialView(new VMLienLac());
	  }

	  long longId = 0;
	  try {
		var dicInput = JsonConvert.DeserializeObject<Dictionary<string,object>>(strJsonDictionary);

		longId=(long)dicInput["longId"];
	  } catch(Exception et) {
		string str = et.Message;
	  }

	  foreach(var item in lstLienLac) {
		if(item.Id==longId) {
		  return PartialView(item);
		}
	  }

	  return PartialView(new VMLienLac());
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ValidateInput(false)]
	public ActionResult ARUpdatePV(VMLienLac minput) {
	  try {
		if(ModelState.IsValid==false) {
		  return PartialView(minput);
		}

		var lstLienLac = new List<VMLienLac>();
		string strJson = (string)Session[CommonConstants.LIST_LIENLAC_SESSION];
		QTTools.GetListLienLacFromJson(ref lstLienLac,strJson);

		foreach(var item in lstLienLac) {
		  if(item.Id==minput.Id) {
			item.StrNameButton=minput.StrNameButton;
			item.StrLinkLienLac=minput.StrLinkLienLac;
			item.StrLinkImageIcon=minput.StrLinkImageIcon;
			item.BlnOpenNewTab=minput.BlnOpenNewTab;
			item.BlnHienThi=minput.BlnHienThi;
			break;
		  }
		}

		var dicToSaveJson = new Dictionary<string,object>();
		dicToSaveJson["lstVMLienLac"]=lstLienLac;
		string strJsonToSave = JsonConvert.SerializeObject(dicToSaveJson
			  ,Newtonsoft.Json.Formatting.Indented);

		string strUser = (string)Session[CommonConstants.USER_SESSION];
		bool blnSuccess = false;
		QTTools.UpdateJsonForKeyword(ref blnSuccess,strUser,strJsonToSave,CommonConstants.STR_CONST_KEYWORD_JSON_LIENLAC);
		if(blnSuccess==true) {
		  Session[CommonConstants.ID_SESSION]=null;
		  return RedirectToAction(nameof(ARIndex));
		}

		ModelState.AddModelError("","Thao tác không thành công!");

		return PartialView(minput);
	  } catch(Exception et) {
		string str = et.Message;
		ModelState.AddModelError("",str);
		return PartialView(minput);
	  }
	}

  }
}