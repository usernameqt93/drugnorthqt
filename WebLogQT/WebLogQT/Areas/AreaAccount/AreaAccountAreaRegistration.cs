using System.Web.Mvc;

namespace WebLogQT.Areas.AreaAccount
{
    public class AreaAccountAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaAccount";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaAccount_default",
				"AreaAccount/{controller}/{action}/{id}",
                new { action = "ARIndex",Controller = "CtlLogin", id = UrlParameter.Optional }
            );
        }
    }
}