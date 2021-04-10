using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLogQT.Controllers {
  public class CtlHomeController:Controller {
	// GET: CtlHome
	public ActionResult Index() {
	  return View();
	}

	public ActionResult ARIndex() {
	  List<TblPostBaiViet> lst = new List<TblPostBaiViet>();

	  var dal = new DALPost();
	  dal.GetListByPageAndSize(ref lst,0,10);

	  ViewBag.VBLstPost=lst;
	  return View();
	}

  }
}