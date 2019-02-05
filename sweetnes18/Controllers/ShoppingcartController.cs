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

namespace Sweetnes18.Controllers
{
    public class Shipping
    {
        public String AddID { get; set; }
        public String SIDS { get; set; }
    }
    public class ShoppingcartController : Controller
    {
        [CartClear]
        public ActionResult Index()
        {
            return View(); 
        }
        public ActionResult shoppingaddress()
        {
            return View();
        }
        public ActionResult Newshoppingaddress()
        {
            return View();
        }

        [AllowJsonGet]
        public JsonResult GetShippingAddress()
        {
            List<Shipping> SHIP = new List<Shipping>();
            Shipping m = new Shipping();
            String AID;
            String CID;
            String ShippingCal = "";
            Int32 AddID= Convert.ToInt32(Request["AddresID"]);
            Int32 CompanyID = Convert.ToInt32(Request["ShippingCompany"]);
            if (AddID != 0 && CompanyID != 0)
            {
                Session["AddressID"] = AddID;
                Session["ShippingCompanyID"] = CompanyID;
            }
            AID = 0.ToString();
            CID = 0.ToString();
            if (Session["AddressID"] != null)
            {
                AID = Session["AddressID"].ToString();
            }
            if (Session["ShippingCompanyID"] != null)
            {
                CID = Session["ShippingCompanyID"].ToString();
            }
            ShippingCal = "&addressid="+AID+"&shippingcompanyid=" + CID;
            m.AddID = AID;
            m.SIDS = CID;
            SHIP.Add(m);
            return new JsonResult { Data = SHIP };
        }
    
    }

    internal class CartClearAttribute : Attribute
    {
    }
}
