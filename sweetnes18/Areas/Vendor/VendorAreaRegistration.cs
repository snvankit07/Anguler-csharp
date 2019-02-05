using System.Web.Mvc;

namespace sweetnes18.Areas.Vendor
{
    public class VendorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Vendor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
              "Vendor",
              "Vendor/",
              new { controller = "Login", action = "Index", id = UrlParameter.Optional }
          );
            context.MapRoute(
                "Vendor_default",
                "Vendor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}