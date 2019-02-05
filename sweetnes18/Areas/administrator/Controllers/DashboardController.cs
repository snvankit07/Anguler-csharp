using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Areas.administrator.Models;
using sweetnes18.AhelperClass;

namespace sweetnes18.Areas.administrator.Controllers
{
    [RedirectingAction]
    public class DashboardController : Controller
    {
        private conn db = new conn();

        // GET: administrator/users
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
