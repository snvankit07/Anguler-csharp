using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Areas.Vendor.Models;
using sweetnes18.AhelperClass;

namespace sweetnes18.Areas.Vendor.Controllers
{
    [RedirectingVendor]
    public class SettingController : Controller
    {
        public ActionResult Index()
        {
            return View(); 
        }
    }
}
