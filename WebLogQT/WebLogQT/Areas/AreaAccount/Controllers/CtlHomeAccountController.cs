using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class CtlHomeAccountController:BaseAdminController {
	// GET: AreaAccount/CtlHomeAccount
	public ActionResult ARIndex() {
	  return View();
	}
  }
}