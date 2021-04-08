using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLogQT.Areas.AreaAccount.Models;

namespace WebLogQT.Areas.AreaAccount.Controllers
{
    public class CtlLoginController : Controller {
	// GET: AreaAccount/CtlLogin
	public ActionResult Index() {
	  return View();
	}

	public ActionResult ARIndex() {
	  return View();
	}

	[HttpPost]
	public ActionResult ARIndex(LoginModel minput) {
	  //string Message = "your message here !";
	  ////return Json(Message,JsonRequestBehaviour.AllowGet);
	  //return Json(Message);
	  return View();
	}
  }
}