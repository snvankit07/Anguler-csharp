using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace sweetnes18.AhelperClass
{

    public class CustomerActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             String s = String.Empty;
            string con = filterContext.RouteData.Values["controller"].ToString();
            string act = filterContext.RouteData.Values["action"].ToString();
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{

            //    var returnUrl = filterContext.HttpContext.Request.RawUrl;
            //    if (filterContext.HttpContext.Request.RequestType == "POST")
            //    {
            //        returnUrl = filterContext.HttpContext.Request.UrlReferrer.PathAndQuery;
            //        // look for FORM values in request to append to the returnUrl
            //        // this can be helpful for a good user experience (remembering checkboxes/text fields etc)
            //    }
            //    s = returnUrl;
            //    //filterContext.Result = new RedirectResult(String.Concat("~/Account/LogOn", "?ReturnUrl=", returnUrl));
            //}
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current == null || HttpContext.Current.Session == null || (string)HttpContext.Current.Session["login"] != "y")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "createaccount",
                    action = "login",
                    c = con,
                    a = act
                }));
            }
        }
    }

    public class LaunchingActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Session["Start"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Createaccount",
                    action = "Registrationnow"

                }));
            }
        }
    }



    public class CartClearRedirectingActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current.Session["cartshoppingcart"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "home"
                    
                }));
            }
        }
    }


    public class PaynowchkActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current == null || HttpContext.Current.Session == null || (string)HttpContext.Current.Session["Paymentdata"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Myorder",
                    action = "index"
                }));
            }
        }
    }

    

    public class RedirectingActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current == null || HttpContext.Current.Session == null || (string)HttpContext.Current.Session["adminlogin"] != "y")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "login",
                    action = "index"
                }));
            }
        }
    }

    public class RedirectingVendorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current == null || HttpContext.Current.Session == null || (string)HttpContext.Current.Session["vendorlogin"] != "y")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "login",
                    action = "index"
                }));
            }
        }
    }


    public class RedirectingShippingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current == null || HttpContext.Current.Session == null || (string)HttpContext.Current.Session["companylogin"] != "y")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Company",
                    action = "index"
                }));
            }
        }
    }


    public class AllowJsonGetAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var jsonResult = filterContext.Result as JsonResult;

            if (jsonResult == null)
                throw new ArgumentException("Action does not return a JsonResult, attribute AllowJsonGet is not allowed");
    

            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            base.OnResultExecuting(filterContext);
        }
    }

}