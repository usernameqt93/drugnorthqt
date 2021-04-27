using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebLogQT.Common;

namespace WebLogQT.Areas.AreaAccount.Controllers {
  public class BaseAdminController:Controller {
	// GET: AreaAccount/Base
	//public ActionResult Index()
	//{
	//    return View();
	//}

	protected override void OnActionExecuting(ActionExecutingContext filterContext) {
	  // var session = (UserLogin)Session[CommonConstants.USER_SESSION];
	  // if(session==null) {
	  //filterContext.Result=new RedirectToRouteResult(new
	  //	RouteValueDictionary(new { controller = "Login",action = "Index",Area = "Admin" }));
	  // }
	  string str = (string)Session[CommonConstants.USER_SESSION];
	  if(str==null||str!="superadminqt") {
		filterContext.Result=new RedirectToRouteResult(new
			RouteValueDictionary(new { controller = "CtlLogin",action = "ARIndex",Area = "AreaAccount" }));
	  }
	  TempData["strUsername"]=str;
	  base.OnActionExecuting(filterContext);
	}

  }
}