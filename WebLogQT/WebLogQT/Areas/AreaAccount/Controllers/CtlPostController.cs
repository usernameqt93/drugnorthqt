using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

		  minput.CreatedDate=DateTime.Now;
		  minput.Status=true;

		  var dal = new DALPost();
		  long longId = dal.LongInsert(minput);
		  if(longId>0) {
			//ViewBag.strMessageJs="Tự động tạo tài khoản QT thành công(tk=mk)!";
			return RedirectToAction(nameof(ARIndex));
		  }
		  //var session = (UserLogin)Session[CommonConstants.USER_SESSION];
		  //minput.CreatedBy=session.UserName;
		  //var culture = Session[CommonConstants.CurrentCulture];
		  //minput.Language=culture.ToString();
		  //new ContentDao().Create(minput);
		  //return RedirectToAction("Index");
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

  }
}