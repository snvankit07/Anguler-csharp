using sweetnes18.AhelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sweetnes18.Controllers
{
    [LaunchingAction]
    public class PrivacyPolicyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }

        

        public ActionResult TermsAr()
        {
            return View();
        }
        public ActionResult TermsEn()
        {
            return View();
        }
        
        public ActionResult PrivacyEn()
        {
            return View();
        }
        
    }
}
