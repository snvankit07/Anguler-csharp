using sweetnes18.AhelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sweetnes18.Controllers
{
    public class supportController : Controller
    {
        public ActionResult Index()
        {
            if (Request["Submit"] != null) { 
            String fname = Request["Fname"];
            String email = Request["email"];
            String subject = Request["Subject"];
            String Msg = Request["Message"];

            IDictionary<string, string> keys3 = new Dictionary<string, string>() {
                                                    { "%#NAME#%", fname},
                                                    { "%#EMAIL#%", email},
                                                    { "%#SUB#%", subject},
                                                    { "%#MSG#%", Msg}
                                                };
          //Format a22 = new Format(17, keys3, "hr@snvinfotech.com");
            Format a23 = new Format(17, keys3, "vaibhaw@snvinfotech.com");
          //Format a24 = new Format(17, keys3, "lettertoamit@gmail.com");
                ViewData["msg"] = "Your Message Send successfully";
        }


            ViewData["msg"] = "";

            return View(); 
        }
    }
}
