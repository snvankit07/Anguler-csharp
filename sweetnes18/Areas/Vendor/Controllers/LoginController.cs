using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sweetnes18.AhelperClass;
using System.Web.Mvc;
using System.Data;
using sweetnes18.Areas.Vendor.Models;



namespace sweetnes18.Areas.Vendor.Controllers
{
    public class LoginController : Controller
    {
        private conn db = new conn();
        private Common cfn = new Common();
        // GET: administrator/Login
        public ActionResult Index()
        { 
                string u = (String)Request["username"]; 
                string p = (String)Request["password"];
            u = cfn.mobliefilter(u);
            if (!( String.IsNullOrEmpty(u) || String.IsNullOrEmpty(u) ) )
            {
                
                var usr=db.user.Where(h => (h.mobileno == (u) || h.username == u) && h.password == p && h.usertype==2 && h.status==1).FirstOrDefault();


                if (usr != null)
                {
                    Session["vendorlogin"] = "y";
                    Session["vendorloginID"] = usr.id;
                    return RedirectToRoute(new
                    {
                        controller = "/Dashboard",
                        action = "index"

                    });
                }
                else {
                    ViewData["ErrorMSg"] = "User name and password is wrong.";
                }
            }
            

            return View();
        }
        public RedirectToRouteResult Logout() {
            Session["vendorlogin"] = "";
            Session["vendorloginID"] =-1; 
            return RedirectToRoute(new
            {
                controller = "/Dashboard",

            });
           
        }
    }
}