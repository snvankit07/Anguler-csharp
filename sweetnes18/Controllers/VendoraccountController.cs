using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sweetnes18.AhelperClass;
using sweetnes18.Models;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Dynamic;

namespace sweetnes18.Controllers {

    public class VendoraccountController : Controller
    {
        private conn db = new conn();
        private Common cfn = new Common();
        public ActionResult Index()
        {
            ViewData["Error1"] = ViewData["Error"] = "";
            if (Session["ErrorMSg"]!=null)
            {
                ViewData["Error"] = Session["ErrorMSg"];
            }
            if (Session["ErrorMSg1"] != null)
            {
                ViewData["Error1"] = Session["ErrorMSg1"];
            }
            
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Index(FormCollection collection)
        {

            Session["user"] = collection["fname"];
            Session["ErrorMSg"] = "";
            Session["ErrorMSg1"] = "";
            // Response.Write( FormData.Fname );
            user u = new user();




            u.fname     = collection["fname"];
            u.lname     = collection["lname"];
            u.password  = collection["password"];
            u.mobileno  = cfn.mobliefilter(collection["mobileno"]);
            u.City      = collection["city"];
            u.status    = 1;
            u.usertype  = 2;
            u.username  = collection["username"];
            int i = 0;
            String Msg = "";
            String Msg1 = "";
            if (db.user.Where(h => h.username == u.username && h.mobileno == u.mobileno).ToList().Count() > 0)
            {
                Msg1 += "\nEmail Address and Mobile Number Already Exist For Vendor";
                i++;
            }
            if (db.user.Where(h => h.mobileno == u.mobileno).ToList().Count() > 0)
            {
                Msg += "Mobile Number Already Exist For Vendor";
                i++;
            }
            if (db.user.Where(h => h.username == u.username).ToList().Count() > 0)
            {
                Msg1 += "\nEmail Address Already Exist For Vendor";
                i++;
            }
            
            if (i > 0)
            {
                Session["ErrorMSg"] = Msg;
                Session["ErrorMSg1"] = Msg1;
                return RedirectToRoute(new
                {
                    controller = "vendoraccount",
                    action = "index"
                });
            }
            Session["ErrorMSg"] = "";
            Session["ErrorMSg1"] = "";
            db.user.Add(u);
            db.SaveChanges();


            var register = (db.user.Where(x => x.mobileno == u.mobileno && x.username == u.username).FirstOrDefault());
            List<Usersmeta> UM = new List<Usersmeta>();
            Usersmeta U = new Usersmeta();
            U.metakey = "Vatnumber";
            U.metavalue = collection["Vatnumber"];
            U.userid = register.id;
            db.Usersmeta.Add(U);
            db.SaveChanges();



            IDictionary<string, string> keys = new Dictionary<string, string>() {
                                                                                { "{{name}}", collection["fname"]+" "+collection["lname"] },
                                                                                { "{{username}}", collection["username"] },
                                                                                { "{{password}}", collection["password"] },
                                                                                { "{{url}}", Request.Url.AbsoluteUri }
                                                                                };
            Format a1 = new Format(10, keys, collection["username"]);
            return RedirectToRoute(new
            {
                controller = "Vendoraccount",
                action = "Thankyou"
            });
        }  

        public ActionResult Thankyou()
        {
            
            return View();
        }
        public ActionResult Login()
        {
            Response.Write(Request["username"]);
            return View();
        }

        public ActionResult ForgetPassword()
        {
            
            return View();
        }






    }
}
