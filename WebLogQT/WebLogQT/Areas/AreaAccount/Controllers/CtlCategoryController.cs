using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLogQT.Common;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class CtlCategoryController:BaseAdminController {
	// GET: AreaAccount/CtlCategory
	public ActionResult Index() {
	  return View();
	}


	public ActionResult ARIndex() {
	  List<TblCategoryTheLoai> lst = new List<TblCategoryTheLoai>();

	  var dal = new DALCategory();
	  dal.GetListCategoryByPageAndSize(ref lst,0,10);
	  return View(lst);
	}

	public ActionResult ARCreate() {
	  return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult ARCreate(TblCategoryTheLoai minput) {
	  try {
		if(ModelState.IsValid) {
		  string strUser = (string)Session[CommonConstants.USER_SESSION];
		  minput.CreatedBy=strUser;

		  minput.CreatedDate=DateTime.Now;
		  minput.Status=true;

		  var dal = new DALCategory();
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

  }
}