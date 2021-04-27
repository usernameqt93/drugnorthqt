using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class CtlHomeUserController:BaseUserController {
	// GET: AreaAccount/CtlHomeUser
	public ActionResult ARIndex() {
	  return View();
	}

  }
}