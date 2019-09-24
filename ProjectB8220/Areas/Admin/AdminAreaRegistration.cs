using System.Web.Mvc;

namespace ProjectB8220.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_Home",
                "Admin",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "ProjectB8220.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "ProjectB8220.Areas.Admin.Controllers" }
            );
        }
    }
}