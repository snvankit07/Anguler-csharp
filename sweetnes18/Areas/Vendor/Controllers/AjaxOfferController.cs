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
using Newtonsoft.Json;

namespace sweetnes18.Areas.Vendor.Controllers
{
    public class Productsdata
    {
        public Products Porduct { get; set; }
        public String Category { get; set; }
    }

    public class AjaxOfferController : Controller
    {
        private conn db = new conn();

        [AllowJsonGet]
        public JsonResult OfferList()
        {
            int id = Convert.ToInt32(Session["vendorloginID"]);
            string json = JsonConvert.SerializeObject(db.ProductOffers.Where(x => x.OfferAddUserID == id).ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult ProductList()
        {
            List<Productsdata> ProductD = new List<Productsdata>();
            int id = Convert.ToInt32(Session["vendorloginID"]);
            var pp = db.Products.Where(x => x.UserID == id).Where(x => x.productStatus == 1).ToList();
            foreach (Products i in pp)
            {
                Productsdata m = new Productsdata();
                m.Porduct = i;
                var category = db.ProductCategory.Where(u => u.ID == i.CatID).FirstOrDefault();
                m.Category = category.CategoryName;
                ProductD.Add(m);
            }
            string json = JsonConvert.SerializeObject(ProductD.ToList());
            return new JsonResult { Data = json };
        }
    }
}
