using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebLogQT.Common;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class CtlPostController:BaseController {
	// GET: AreaAccount/CtlPost
	public ActionResult Index() {
	  return View();
	}

	public ActionResult ARIndex() {
	  List<TblPostBaiViet> lst = new List<TblPostBaiViet>();

	  var dal = new DALPost();
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
	  SetViewBag();
	  return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[ValidateInput(false)]
	public ActionResult ARCreate(TblPostBaiViet minput) {
	  try {
		if(ModelState.IsValid) {
		  string strUser = (string)Session[CommonConstants.USER_SESSION];
		  minput.CreatedBy=strUser;

		  string strDescription = "Truy cập trang để xem chi tiết nội dung này ...";
		  try {
			string strPlainTextTrim = QTTools.GetPlainTextFromHtml(minput.Detail);
			strPlainTextTrim=System.Net.WebUtility.HtmlDecode(strPlainTextTrim);
			strDescription= strPlainTextTrim.Replace("  "," ");
		  } catch(Exception et) {
			string str = et.Message;
		  }
		  minput.Description=strDescription.Substring(0,240)+"...";

		  minput.CreatedDate=DateTime.Now;
		  minput.Status=true;

		  var dal = new DALPost();
		  long longId = dal.LongInsert(minput);
		  if(longId>0) {
			//ViewBag.strMessageJs="Tự động tạo tài khoản QT thành công(tk=mk)!";
			return RedirectToAction(nameof(ARIndex));
		  }
		  ModelState.AddModelError("","Thêm mới không thành công!");
		}

		SetViewBag();
		return View(minput);
	  } catch(Exception et) {
		string str = et.Message;
		ModelState.AddModelError("",str);
		return View(minput);
	  }
	}

	private void SetViewBag(long? longSelectedId = null) {
	  List<TblCategoryTheLoai> lst = new List<TblCategoryTheLoai>();

	  var dal = new DALCategory();
	  dal.GetListCategoryByPageAndSize(ref lst,0,1000);
	  ViewBag.CategoryID=new SelectList(lst,"ID","Name",longSelectedId);
	}

	#region JsonResult

	public JsonResult JRCreateMetaTitle(string strJsonInput) {
	  string strTitle = new JavaScriptSerializer().Deserialize<string>(strJsonInput);
	  string strTextTrimNoUnicode = QTTools.RemoveUnicode(strTitle.Trim());
	  string strMetaTitle = strTextTrimNoUnicode.Replace("  "," ").Replace(" ","-");
	  return Json(new {
		blnStatusJs = true,
		strOutputJs = strMetaTitle
	  });
	}

	//public JsonResult JRCreateDescription(string strJsonInput) {
	//  string strHTML = new JavaScriptSerializer().Deserialize<string>(strJsonInput);
	//  string strPlainTextTrim = QTTools.GetPlainTextFromHtml(strHTML);
	//  string strOutput = strPlainTextTrim.Replace("  "," ");
	//  return Json(new {
	//	blnStatusJs = true,
	//	strOutputJs = strOutput
	//  });
	//}

	#endregion

  }
}