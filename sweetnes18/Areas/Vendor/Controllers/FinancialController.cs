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
    public class FinancialController : Controller
    {
        private conn db = new conn();

        public ActionResult Index()
        {
            ViewData["VendorID"] = Session["vendorloginID"];
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewData["VendorID"] = Session["vendorloginID"];
            ViewData["Status"] = id;
            return View();
        }

        public ActionResult Details(int? id)
        {
            ViewData["VendorID"] = Session["vendorloginID"];
            ViewData["Status"] = id;
            ViewData["ID"] = id;
            return View();
        }
        
    }
}