using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sweetnes18.AhelperClass;
using sweetnes18.Models;

namespace sweetnes18.Controllers
{
    [LaunchingAction]
    public class HomeController : Controller
    {
        private conn db = new conn();
        private ProductUpdate fun = new ProductUpdate();
        private DatabaseConnection abcd = new DatabaseConnection();
        
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();// new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
