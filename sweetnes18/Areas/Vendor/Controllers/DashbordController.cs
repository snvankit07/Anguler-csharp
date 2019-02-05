using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Areas.Vendor.Models; 
using System.IO;
using sweetnes18.AhelperClass;

namespace sweetnes18.Areas.Vendor.Controllers
{
    [RedirectingVendor]
    public class DashboardController : Controller
    {
        private conn db = new conn();

        // GET: Vendor/Products
        public ActionResult Index()
        {
            ViewData["VendorID"] = Session["vendorloginID"]; 
            return View();
        }

    }
}
