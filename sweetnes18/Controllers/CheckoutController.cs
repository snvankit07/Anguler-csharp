using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sweetnes18.AhelperClass;
using sweetnes18.Models;
using Newtonsoft.Json;

namespace Sweetnes18.Controllers
{  
    public class checkoutform
    {
        public String fname { get; set; }
        public String lname { get; set; }
        public String CustomerMobileNumber { get; set; }
        public String CustomerBillingAdd { get; set; }
        public String CustomerShippingAdd { get; set; }
        public String CustomerEmailID { get; set; }
    } 
    public class CheckoutController : Controller
    {   
        private conn db = new conn();
        
        public ActionResult Index()
        {
            if (Request["userlogin"] == "1") { 
                user u = new user();
                u = (sweetnes18.Models.user)Session["userdetail"];
                CustomerProfile s = db.CustomerProfiles.SingleOrDefault(x=>x.CustomerID == u.id );
                ViewData["customer"] = s;
            }
            return View(); 
        }
        [AllowJsonGet]
        public JsonResult Add([Bind(Include = "fname,lname,CustomerMobileNumber,CustomerBillingAdd,CustomerShippingAdd,CustomerEmailID")] checkoutform formupdate)
        {
            CustomerProfile c1 = new CustomerProfile();
            c1.CustomerBillingAdd   = Request["CustomerBillingAdd"];
            c1.CustomerShippingAdd  = Request["CustomerShippingAdd"];
            c1.CustomerMobileNumber = Request["CustomerMobileNumber"];
            c1.CustomerEmailID      = Request["CustomerEmailID"];
            db.CustomerProfiles.Add(c1);
            db.SaveChanges();
            
            Session["CustomerID"]= db.CustomerProfiles.Max(item => item.CustomerID);
            if (Session["login"]!=null && Convert.ToString(Session["login"]) == "y") { 
                DatabaseConnection abcd = new DatabaseConnection();
                //Response.Write(Session["userdetail"]);
                user userdetail = (sweetnes18.Models.user)Session["userdetail"];
                string billing = Request["CustomerBillingAdd"];
                string shipping= Request["CustomerShippingAdd"];
                var Q = "update [dbo].[user] set [billing]='"+ billing + "',[shipping]='"+ shipping + "' where [id]="+ userdetail.id;
                abcd.Select(Q);
            }

            String json = "1";
            return new JsonResult { Data = json };
        }
         
    }
}
