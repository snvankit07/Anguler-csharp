using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using sweetnes18.AhelperClass; 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using sweetnes18.Models; 
namespace sweetnes18.Controllers {
    
    public class CreateaccountController : Controller
    {
        private conn db = new conn();
        private Common cfn = new Common();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrationnow()
        {
            Session["Start"] = Request["Start"];
            return View();
        }





        [HttpPost]
        public RedirectToRouteResult Index(FormCollection collection )
        {
            Session["user"] = collection["fname"];
            // Response.Write( FormData.Fname );
            DatabaseConnection abcd = new DatabaseConnection();
            try
            {
                String Mobile=cfn.mobliefilter(collection["mobileno"]);
                DataSet ds = abcd.Select("EXEC dbo.insertUser  @fname=N'" + collection["fname"] + "', " +
                    "@lname=N'" + collection["lname"] +
                    "', @password=N'" + collection["password"] +
                    "', @mobileno=N'" + Mobile +
                    "', @status=N'" + "1" +
                    "', @usertype=N'" + "1" + 
                    "', @username=N'" + collection["username"] + "'");
            }
            catch ( Exception e)
            {
                string a = e.Message;
                return RedirectToRoute(new
                {
                    controller = "Createaccount",

                });
            }
            IDictionary<string, string> keys = new Dictionary<string, string>() {
                                                                                { "{{name}}", collection["fname"]+" "+collection["lname"] },
                                                                                { "{{username}}", collection["username"] },
                                                                                { "{{password}}", collection["password"] },
                                                                                { "{{url}}", Request.Url.AbsoluteUri }
                                                                                };
            Format a1 = new Format(9, keys, collection["username"] );   
             Session["login"] = "y";
                return RedirectToRoute(new
                {
                    controller = "Createaccount",
                    action = "Thankyou"
                });
            
           

            
        }  

        public ActionResult Thankyou()
        {
            return View();
        }
        public ActionResult logout() {
            Session["login"] = "";
            Session["logindata"] = "";
            Session["userdetail"] = "";
            return RedirectToRoute(new
            {
                controller = "home",
                
            });
        }
        public ActionResult Login()
        {
            Session["MSG"] = "";
            Session["Class"] = "";
            if (Request["userlogin"] != null)
            {
                Session["gotochkout"] = "y";
            }
            string u = Request.Form["username"];
            if(u == null )
            {
               
                return View();
            }
            string p = Request.Form["password"];
            string c = Request.Form["controller"].Replace("/","");
            string a = Request.Form["action"].Replace("/", "");
            u = cfn.mobliefilter(u);
            var exist = db.user.Where(x => (x.username == u || x.mobileno== u) && x.password == p && x.status == 1 && x.usertype==1).FirstOrDefault();
            //var usermeta = db.Usersmeta.Where(x => x.username == u && x.password == p && x.status == 1).FirstOrDefault();
            if (exist == null)
            {
                
                Session["Class"] = "alert alert-danger";
                Session["MSG"] = "Username or Password is wrong.";
                ViewData["MSG"] = Session["MSG"];
                ViewData["Class"] = Session["Class"];
                return View();
            }
            else
            {
                Session["login"] = "y"; 
                Session["userdetail"] = exist;
                Session["MSG"] = "";
                Session["Class"] = "";
                var add=db.ShippingAddress.Where(x => x.userid == exist.id).FirstOrDefault();
                if(add!=null)
                { 
                    Session["AddressID"] = add.Id;
                    Session["ShippingCompanyID"] = 1;
                }
                if ((String)Session["gotochkout"] == "y")
                {
                    return RedirectToRoute(new
                    {
                        controller = "Myorder",
                    });
                }
                if (c != null )
                { 
                   return RedirectToRoute(new
                   {
                             controller = c,
                             action = a
                   });
                }
                return RedirectToRoute(new
                {
                    controller = "Myaccount",
                });
            }            
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}
