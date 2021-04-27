using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLogQT.Common;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class CtlHtmlRawController:BaseAdminController {
	// GET: AreaAccount/CtlHtmlRaw
	public ActionResult Index() {
	  return View();
	}

	public ActionResult ARIndex() {
	  List<TblHtmlRaw> lst = new List<TblHtmlRaw>();

	  var dal = new DALHtmlRaw();
	  dal.GetListByPageAndSize(ref lst,0,10);

	  foreach(var item in lst) {
		string strDes = item.Description;
		try {
		  strDes=System.Net.WebUtility.HtmlDecode(strDes);// Returns é
														  //strDes=QTTools.DecodeFromUtf8(strDes);
		} catch(Exception et) {
		  string str = et.Message;
		}
		item.Description=strDes;
	  }

	  return View(lst);
	}

	public ActionResult ARCreate() {
	  return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ValidateInput(false)]
	public ActionResult ARCreate(TblHtmlRaw minput) {
	  try {
		if(ModelState.IsValid) {
		  string strUser = (string)Session[CommonConstants.USER_SESSION];
		  minput.CreatedBy=strUser;
		  minput.CreatedDate=DateTime.Now;

		  string strDescription = "Truy cập trang để xem chi tiết nội dung này ...";
		  try {
			string strPlainTextTrim = QTTools.GetPlainTextFromHtml(minput.Html);
			strPlainTextTrim=System.Net.WebUtility.HtmlDecode(strPlainTextTrim);
			strDescription=strPlainTextTrim.Replace("  "," ");
		  } catch(Exception et) {
			string str = et.Message;
		  }
		  minput.Description=(strDescription.Length>240) ?(strDescription.Substring(0,240)+"..."): strDescription;

		  minput.Status=true;

		  var dal = new DALHtmlRaw();
		  long longId = dal.LongInsert(minput);
		  if(longId>0) {
			//ViewBag.strMessageJs="Tự động tạo tài khoản QT thành công(tk=mk)!";
			return RedirectToAction(nameof(ARIndex));
		  }
		  ModelState.AddModelError("","Thêm mới không thành công!");
		}

		return View(minput);
	  } catch(Exception et) {
		string str = et.Message;
		ModelState.AddModelError("",str);
		return View(minput);
	  }
	}

	public ActionResult AREdit(long id) {
	  TblHtmlRaw minput = null;

	  var dal = new DALHtmlRaw();
	  dal.GetModelHtmlRawDetailById(ref minput,id);
	  return View(minput);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ValidateInput(false)]
	public ActionResult AREdit(TblHtmlRaw minput) {
	  try {
		if(ModelState.IsValid==false) {
		  return View(minput);
		}

		string strUser = (string)Session[CommonConstants.USER_SESSION];
		minput.ModifiedBy=strUser;
		minput.ModifiedDate=DateTime.Now;

		string strDescription = "Truy cập trang để xem chi tiết nội dung này ...";
		try {
		  string strPlainTextTrim = QTTools.GetPlainTextFromHtml(minput.Html);
		  strPlainTextTrim=System.Net.WebUtility.HtmlDecode(strPlainTextTrim);
		  strDescription=strPlainTextTrim.Replace("  "," ");
		} catch(Exception et) {
		  string str = et.Message;
		}
		minput.Description=(strDescription.Length>240) ? (strDescription.Substring(0,240)+"...") : strDescription;

		//minput.Status=true;

		var dal = new DALHtmlRaw();
		bool blnSuccess = dal.BlnUpdateSuccess(minput);
		if(blnSuccess==true) {
		  //ViewBag.strMessageJs="Tự động tạo tài khoản QT thành công(tk=mk)!";
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

	public JsonResult JRNhanDoi(long longId) {
	  TblHtmlRaw minput = null;

	  var dal = new DALHtmlRaw();
	  dal.GetModelHtmlRawDetailById(ref minput,longId);
	  minput.Keyword+="_Copy";

	  string strUser = (string)Session[CommonConstants.USER_SESSION];
	  minput.CreatedBy=strUser;
	  minput.CreatedDate=DateTime.Now;

	  string strDescription = "Truy cập trang để xem chi tiết nội dung này ...";
	  try {
		string strPlainTextTrim = QTTools.GetPlainTextFromHtml(minput.Html);
		strPlainTextTrim=System.Net.WebUtility.HtmlDecode(strPlainTextTrim);
		strDescription=strPlainTextTrim.Replace("  "," ");
	  } catch(Exception et) {
		string str = et.Message;
	  }
	  minput.Description=(strDescription.Length>240) ? (strDescription.Substring(0,240)+"...") : strDescription;

	  minput.Status=true;

	  //var dal = new DALJson();
	  long longIdInsert = dal.LongInsert(minput);
	  if(longIdInsert>0) {
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