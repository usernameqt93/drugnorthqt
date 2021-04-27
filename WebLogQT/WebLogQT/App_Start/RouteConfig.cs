using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebLogQT {
  public class RouteConfig {
	public static void RegisterRoutes(RouteCollection routes) {
	  routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

	  routes.MapRoute(
		  name: "Login",
		  url: "admin",
		  defaults: new { controller = "CtlHome",action = "ARLogin",id = UrlParameter.Optional },
		  namespaces: new[] { "WebLogQT.Controllers" }
	  );

	  routes.MapRoute(
		  name: "Post Detail",
		  url: "chi-tiet/{metatitle}-{longId}",
		  defaults: new { controller = "CtlPost",action = "ARDetail",id = UrlParameter.Optional },
		  namespaces: new[] { "WebLogQT.Controllers" }
	  );

	  //routes.MapRoute(
	  // name: "Default",
	  // url: "{controller}/{action}/{id}",
	  // defaults: new { controller = "Home",action = "Index",id = UrlParameter.Optional }
	  //);

	  routes.MapRoute(
		  name: "Home template fpt",
		  url: "ARIndex",
		  defaults: new { controller = "CtlHome",action = "ARIndex",id = UrlParameter.Optional }
	  );

	  routes.MapRoute(
		  name: "Home template log",
		  url: "ARIndexLog",
		  defaults: new { controller = "CtlHome",action = "ARIndexLog",id = UrlParameter.Optional }
	  );

	  routes.MapRoute(
		  name: "Default",
		  url: "{controller}/{action}/{id}",
		  defaults: new { controller = "CtlHome",action = "Index",id = UrlParameter.Optional }
	  );
	}
  }
}
