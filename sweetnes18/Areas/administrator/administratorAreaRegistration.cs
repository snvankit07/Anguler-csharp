using System.Web.Mvc;

namespace sweetnes18.Areas.administrator
{
    public class administratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "administrator",
               "administrator/",
               new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );
            context.MapRoute(
                "administrator_default",
                "administrator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}