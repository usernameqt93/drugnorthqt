using ModelQT.DAL;
using ModelQT.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLogQT.Controllers {
  public class CtlPostController:Controller {
	// GET: CtlPost
	public ActionResult Index() {
	  return View();
	}

	public ActionResult ARDetail(long longId) {
	  TblPostBaiViet minput = null;

	  var dal = new DALPost();
	  dal.GetModelPostDetailById(ref minput,longId);
	  //ViewBag.mpcDetailCategory=new DALProductCategory().MPCViewDetail(minput.CategoryID.Value);
	  //ViewBag.LstRelatedProducts=dal.LstRelatedProducts(longId);
	  return View(minput);
	}
  }
}