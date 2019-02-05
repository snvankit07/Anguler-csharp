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
namespace Sweetnes18.Controllers
{

    public class cartd {
        public int Product_id { get; set; }
        public int qun { get; set; }
    }
    public class CartData {
            public int Product_id { get; set; }
            public Products Product { get; set;}
            public user Vendor { get; set; }
            public double ProductPurchasePrice { get; set; }
            public int ProductPurchaseQun { get; set; }
            public double Offerprice { get; set; }
            public ProductOffer ProductOffer { get; set; }
            public double ShippingCost { get; set; }
            public Boolean Flag { get; set; }
            public String FlagMsg { get; set; }
    }
    public class CartObj
    {
        public IEnumerable<CartData>  WholCartData { get; set; }
        public double TotalQuntity { get; set; }
        public double TotalPrice { get; set; }
        public double Offerprice { get; set; }
        public double TaxPrice { get; set; }
        public String CouponCode { get; set; }
        public double SubTotalPrice { get; set; }
        public double ShippingCost { get; set; }

    }
    public class CartObject
    {
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public double price { get; set; }
        public double Offerprice { get; set; }
        public Products productdetail;
        public ProductOffer ProductOffer;
        public user vendor;
        public string couponcode {get; set;}
        public string OfferType { get; set; }

    }
    public class CartController : Controller
    {
        private conn db = new conn();


        [AllowJsonGet]
        public JsonResult AddC()
        {
            int PId = Convert.ToInt32(Request["productid"]);
            int PQun = Convert.ToInt32(Request["Quantity"]);
            List<cartd> CartlistD = new List<cartd>();

                String prop = "";
                if(Session["cartshoppingcart"]==null)
                { Session["cartshoppingcart"] = ""; }

                prop = Session["cartshoppingcart"].ToString();
                string[] values = prop.Split(',');
                for (int j = 0; j<values.Length; j++)
                {
                    if (values[j] != null && values[j].Length > 0) {
                        string[] vd = values[j].Split('-');
                        cartd cds = new cartd();
                        cds.Product_id = Convert.ToInt32(vd[0]);
                        cds.qun = Convert.ToInt32(vd[1]); 
                        CartlistD.Add(cds);
                    }
                }
                int intqun=0;
                var removeitem = CartlistD.SingleOrDefault(h => h.Product_id == PId);
                if (removeitem != null)
                {
                    intqun = removeitem.qun;
                    CartlistD.Remove(removeitem);
                }
                cartd cdss = new cartd();
                cdss.Product_id = PId;
                cdss.qun = PQun;
                CartlistD.Add(cdss);
            
            
            var cartd = CartlistD.OrderBy(h => h.Product_id).ToList();
            int i = 0;
            prop = "";
            foreach (cartd c in cartd)
            {
                prop += c.Product_id + "-" + c.qun + ",";
                i++;
            }
            prop = prop.Substring(0, prop.Length - 1);
            Session["cartshoppingcart"] = prop;
            
            
            return new JsonResult { Data = prop };
        }


        [AllowJsonGet]
        public JsonResult getC()
        {
            List<cartd> CartlistD = new List<cartd>();
            String prop = "";
            if (Session["cartshoppingcart"] != null)
            {
                prop = Session["cartshoppingcart"].ToString();
                string[] values = prop.Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    if (values[j] != null && values[j].Length > 0)
                    {
                        string[] vd = values[j].Split('-');
                            cartd cds = new cartd();
                            cds.Product_id = Convert.ToInt32(vd[0]);
                            cds.qun = Convert.ToInt32(vd[1]);
                            CartlistD.Add(cds);
                    }
                }

                var cartd = CartlistD.ToList();
                int i = 0;
                prop = "";
                foreach (cartd c in cartd)
                {
                    prop += c.Product_id + "-" + c.qun + ",";
                    i++;
                }
                prop = prop.Substring(0, prop.Length - 1);
                Session["cartshoppingcart"] = prop;
                return new JsonResult { Data = prop };

            }
            return new JsonResult { Data = false };
        }


        [AllowJsonGet]
        public JsonResult RemoveC()
        {
            int PId = Convert.ToInt32(Request["productid"]);
            List<cartd> CartlistD = new List<cartd>();
            String prop = "";
            if (Session["cartshoppingcart"] != null)
            {
                prop = Session["cartshoppingcart"].ToString();
                string[] values = prop.Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    if (values[j] != null && values[j].Length > 0)
                    {
                        string[] vd = values[j].Split('-');
                        if (Convert.ToInt32(vd[0]) != PId)
                        {
                            cartd cds = new cartd();
                            cds.Product_id = Convert.ToInt32(vd[0]);
                            cds.qun = Convert.ToInt32(vd[1]);
                            CartlistD.Add(cds);
                        }
                    }
                }
                var cartd = CartlistD.ToList();
                int i = 0;
                prop = "";
                foreach (cartd c in cartd)
                {
                    prop += c.Product_id + "-" + c.qun + ",";
                    i++;
                }
                if (i > 0) { 
                    prop = prop.Substring(0, prop.Length - 1);
                }
                
                Session["cartshoppingcart"] = prop;
                
                
                return new JsonResult { Data = Session["cartshoppingcart"] };
            }
            return new JsonResult { Data = false };
        }

        [AllowJsonGet]
        public JsonResult AddCart()
        {
            List<CartObj> cart = new List<CartObj>();
            List<CartData> cartlistData = new List<CartData>();
            CartData d = new CartData();
            d.Product_id = Convert.ToInt32(Request["productid"]);
            d.ProductPurchaseQun = Convert.ToInt32(Request["Quantity"]);
            var temp = db.Products.SingleOrDefault(x => x.ProductID == d.Product_id);
            if (temp != null)
            {
                d.Product = temp;
                d.Vendor = db.user.SingleOrDefault(x => x.id == d.Product.UserID);
                d.Vendor.password = "";
                d.Vendor.mobileno = "";
                d.Vendor.Postalcode = "";
            }
            d.ProductPurchasePrice = (Convert.ToDouble(d.Product.ProductRegulerPrice) * Convert.ToDouble(d.ProductPurchaseQun));
            var  v = Session["cartContents"];
            if (Session["cartContents"] != null)
            {
                cart = (List<CartObj>)Session["cartContents"];
                var c = cart.FirstOrDefault();
                foreach (CartData dd in c.WholCartData)
                {
                    var Prod = db.Products.Where(h => h.ProductID == dd.Product_id).FirstOrDefault();
                    var vendors = db.user.Where(h => h.id == dd.Product.UserID).FirstOrDefault();
                    CartData cartProduct = new CartData();
                    cartProduct.Offerprice = dd.Offerprice;
                    cartProduct.Product = dd.Product;
                    cartProduct.ProductOffer = dd.ProductOffer;
                    cartProduct.ProductPurchasePrice = dd.ProductPurchasePrice;
                    cartProduct.ProductPurchaseQun = dd.ProductPurchaseQun;
                    cartProduct.Product_id = dd.Product_id;
                    cartProduct.ShippingCost = dd.ShippingCost;
                    cartProduct.Vendor = dd.Vendor;
                    cartProduct.Flag = true;
                    cartProduct.FlagMsg = "";
                    if (Prod.ProductQun < dd.ProductPurchaseQun){
                        cartProduct.Flag = false;
                        cartProduct.FlagMsg = "Product Quantity Is Low " + Prod.ProductQun;

                    }
                    else if (Prod.productStatus != 1)
                    {
                        cartProduct.Flag = false;
                        cartProduct.FlagMsg = "Sorry You Can't Buy That Product";
                    }
                    else if (vendors.status != 1)
                    {
                        cartProduct.Flag = false;
                        cartProduct.FlagMsg = "Sorry You Can't Purchase This Product Beacuse Vendor Is Inactive";
                    }
                    if (Prod.ProductID == d.Product_id && d.ProductPurchaseQun < 1)
                    {
                        cartProduct.ProductPurchaseQun = 1;
                    }
                    cartlistData.Add(cartProduct);
                }
                var data=cartlistData.Where(h => h.Product_id == d.Product_id).FirstOrDefault();
                if (data != null)
                {
                    data.ProductPurchaseQun = d.ProductPurchaseQun;
                }
                else {
                    var Prod = db.Products.Where(h => h.ProductID ==d.Product_id).FirstOrDefault();
                    var vendors = db.user.Where(h => h.id == d.Product.UserID).FirstOrDefault();
                    d.Flag = true;
                    d.FlagMsg = "";
                    if (Prod.ProductQun < d.ProductPurchaseQun){
                        d.Flag = false;
                        d.FlagMsg = "Product Quantity Is Low " + Prod.ProductQun;
                    }
                    else if (Prod.productStatus != 1)
                    {
                        d.Flag = false;
                        d.FlagMsg = "You Can't Buy That Product";
                    }
                    else if (vendors.status != 1)
                    {
                        d.Flag = false;
                        d.FlagMsg = "Sorry You Can't Purchase This Product Beacuse Vendor Is Inactive";
                    }
                    cartlistData.Add(d);
                }
            }
            else {
                var Prod = db.Products.Where(h => h.ProductID == d.Product_id).FirstOrDefault();
                var vendors = db.user.Where(h => h.id == d.Product.UserID).FirstOrDefault();
                d.Flag = true;
                d.FlagMsg = "";
                if (Prod.ProductQun < d.ProductPurchaseQun)
                {
                    d.Flag = false;
                    d.FlagMsg = "Product Quantity Is Low " + Prod.ProductQun;
                }
                else if (Prod.productStatus != 1)
                {
                    d.Flag = false;
                    d.FlagMsg = "You Can't Buy That Product";
                }
                else if (vendors.status != 1)
                {
                    d.Flag = false;
                    d.FlagMsg = "Sorry You Can't Purchase This Product Beacuse Vendor Is Inactive";
                }
                cartlistData.Add(d);
            }
            List<CartObj> CartObjLIST = new List<CartObj>();
            CartObj CartObj = new CartObj();
            CartObj.WholCartData = cartlistData;
            CartObj.TotalPrice = 0.0;
            CartObj.SubTotalPrice = 0.0;
            CartObj.CouponCode = "dddd";
            CartObjLIST.Add(CartObj);
            Session["cartContents"] = CartObjLIST;
            var json = CartObjLIST.FirstOrDefault();
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult RemoveCart()
        {
            String json = String.Empty;
            List<CartObj> cart = new List<CartObj>();
            CartObj a = new CartObj();
            var Product_id = Convert.ToInt32(Request["productid"]);
            if (Session["cartContents"] != null)
            {
                List<CartData> CartData = new List<CartData>();
                cart = (List<CartObj>)Session["cartContents"];
                var c = cart.FirstOrDefault();
                foreach (CartData dd in c.WholCartData)
                {
                    if (dd.Product_id != Product_id) {
                        CartData.Add(dd);
                    }
                }
                c.WholCartData = CartData;
                cart.Add(c);
            }
            Session["cartContents"] = cart;
             json = "1"; 
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult getCart()
        {
            
            List<CartObj> cart = new List<CartObj>();
            CartObj a = new CartObj();
            List<CartData> CartDatas = new List<CartData>();
            if (Session["cartContents"] != null)
            {
                cart = (List<CartObj>)Session["cartContents"];
                var c = cart.FirstOrDefault();
                foreach (CartData dd in c.WholCartData)
                {
                    CartData cartData = new CartData();
                    cartData = dd;
                    cartData.Offerprice = Convert.ToDouble(dd.Product.ProductSalePrice);
                    cartData.ShippingCost = 10;
                    cartData.Flag = true;
                    cartData.FlagMsg = "";
                    var Prod    = db.Products.Where(h => h.ProductID == dd.Product_id).FirstOrDefault();
                    var Ven = db.user.Where(h => h.id == dd.Product.UserID).FirstOrDefault();
                    if (Prod.ProductQun < dd.ProductPurchaseQun)
                    {
                        cartData.Flag = false;
                        cartData.FlagMsg = "Product Quantity Is Low " + Prod.ProductQun;
                    }
                    else if (dd.Product.productStatus != 1)
                    {
                        cartData.Flag = false;
                        cartData.FlagMsg = "You Can't Buy That Product";
                    }
                    else if (dd.Vendor.status != 1)
                    {
                        cartData.Flag = false;
                        cartData.FlagMsg = "Sorry You Can't Purchase This Product Beacuse Vendor Is Inactive";
                    }
                    CartDatas.Add(cartData);
                }
            }
            Double PriceToTAL = 0;
            Double OfferPrice = 0;
            Double Quntity = 0;
            var DataPro = CartDatas.ToList();
            foreach (CartData d in DataPro)
            {
                PriceToTAL = PriceToTAL + d.ProductPurchasePrice;
                Quntity = Quntity + d.ProductPurchaseQun;
                OfferPrice = OfferPrice + d.Offerprice;
            }
            List<CartObj> UpdateCart = new List<CartObj>();
            
            a.WholCartData = DataPro;
            a.TotalQuntity = Quntity;
            a.TotalPrice = PriceToTAL;
            a.Offerprice = OfferPrice;
            a.TaxPrice = (a.TotalPrice- a.Offerprice)*10/100;
            a.SubTotalPrice = 0.0;
            UpdateCart.Add(a);
            Session["cartContents"] = UpdateCart;
            var json = UpdateCart.FirstOrDefault();
            return new JsonResult { Data = json }; 
        }


        [AllowJsonGet]
        public JsonResult Add()
        {
            String json = String.Empty;
            List<CartObject> cartlist = new List<CartObject>();
            CartObject a = new CartObject();
            a.Product_id = Convert.ToInt32(Request["productid"]);
            a.Quantity = Convert.ToInt32(Request["Quantity"]);
            var temp = db.Products.SingleOrDefault(x => x.ProductID == a.Product_id);
            if (temp != null )
            {
                a.productdetail = temp;
                a.vendor = db.user.SingleOrDefault(x => x.id == a.productdetail.UserID);
            }
            if (Session["cartContent"] != null)
            {
                cartlist = (List<CartObject>)Session["cartContent"];
                var cl = cartlist.FirstOrDefault(d => d.Product_id == a.Product_id);
                if (cl != null) { cl.Quantity = a.Quantity; }
                else
                {
                    if(a.productdetail != null)
                     cartlist.Add(a);
                }
                Session["cartContent"] = cartlist;
            }
            else
            {
                if (a.productdetail != null)
                cartlist.Add(a);
                Session["cartContent"] = cartlist;
            }
            json = JsonConvert.SerializeObject(cartlist);
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult UpdateCart()
        {
            String json = String.Empty;
            List<CartObject> cartlist1 = new List<CartObject>();
            List<CartObject> cartlist = new List<CartObject>();
            cartlist = (List<CartObject>)Session["cartContent"];
            string code = null;
            if (Request["CouponCode"] != null)
            {
                Session["CouponCode"] = code = Request["CouponCode"].ToString();
            }
            else {
                if (Session["cartContent"] != null && Session["CouponCode"]!=null) { 
                  code = Session["CouponCode"].ToString();
                }
            }
            if (Session["cartContent"] != null)
                {
                    for (int i = 0; i < cartlist.Count; i++)
                    {
                        CartObject a = new CartObject();
                        a.Product_id = cartlist[i].Product_id;
                        a.Quantity = cartlist[i].Quantity;
                        a.productdetail = cartlist[i].productdetail;
                        a.vendor = cartlist[i].vendor;
                        a.couponcode = code;
                        a.ProductOffer = db.ProductOffer.SingleOrDefault(d => d.OfferCode == code);
                        a.price = Convert.ToDouble(a.Quantity) * Convert.ToDouble(a.productdetail.ProductRegulerPrice);
                        if (a.ProductOffer != null)
                        {
                            if (a.ProductOffer.OfferUseType == "2")
                            {
                                a.OfferType = "Product";
                                if (a.Product_id == a.ProductOffer.productID)
                                {
                                    a.Offerprice = 0;
                                    switch (a.ProductOffer.OfferType)
                                    {
                                        case "1":
                                            a.Offerprice = a.price - (a.price * Convert.ToDouble(a.ProductOffer.OfferAmount) / 100);
                                            break;
                                        case "2":
                                            a.Offerprice = a.price - Convert.ToDouble(a.ProductOffer.OfferAmount);
                                            break;
                                    }
                                }

                            }
                            else if (a.ProductOffer.OfferUseType == "1")
                            {
                                a.OfferType = "WholeCart";
                            }
                        }
                        else {
                            a.Offerprice = 0;
                            a.OfferType = "no";
                        }
                        cartlist1.Add(a);
                    }
                }
            Session["cartContent"] = cartlist1;
            json = JsonConvert.SerializeObject(cartlist1);
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult Remove()
        {
            int PId = Convert.ToInt32(Request["productid"]);
            List<cartd> CartlistD = new List<cartd>();
            String prop = "";
            if (Session["cartshoppingcart"] != null)
            {
                prop = Session["cartd"].ToString();
                string[] values = prop.Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    if (values[j] != null && values[j].Length > 0)
                    {
                        string[] vd = values[j].Split('-');
                        cartd cds = new cartd();
                        cds.Product_id = Convert.ToInt32(vd[0]);
                        cds.qun = Convert.ToInt32(vd[1]);
                        CartlistD.Add(cds);
                    }
                }
                var removeitem = CartlistD.SingleOrDefault(h => h.Product_id == PId);
                if (removeitem != null)
                {
                    CartlistD.Remove(removeitem);
                }
            }
            var cartd = CartlistD.ToList();
            int i = 0;
            prop = "";
            foreach (cartd c in cartd)
            {
                prop += c.Product_id + "-" + c.qun + ",";
                i++;
            }
            if (i > 1)
            {
                prop = prop.Substring(0, prop.Length - 1);
            }
            Session["cartshoppingcart"] = prop;
            String json = String.Empty;
            List<CartObject> cartlist = new List<CartObject>();
            CartObject a = new CartObject();
            a.Product_id = Convert.ToInt32(Request["productid"]);
            if (Session["cartContent"] != null)
            {
                cartlist = (List<CartObject>)Session["cartContent"];
                var itemToRemove = cartlist.SingleOrDefault(d => d.Product_id == a.Product_id);
                if (itemToRemove != null)
                    cartlist.Remove(itemToRemove);
                 Session["cartContent"] = cartlist;
            } 
            json = JsonConvert.SerializeObject(cartlist);
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult get()
        {
            List<CartObject> cartlist = new List<CartObject>();
            if (Session["cartContent"] != null)
            {
                cartlist = (List<CartObject>)Session["cartContent"];
                Session["cartContent"] = cartlist;
            }
            String json = JsonConvert.SerializeObject(Session["cartContent"]);
            return new JsonResult { Data = json };
        }
        
        [AllowJsonGet]
        public JsonResult Empty()
        {
            Session["cartshoppingcart"] = null;
            Session["AddressID"] = null;
            Session["ShippingCompanyID"] = null;
            String json = JsonConvert.SerializeObject(Session["cartContent"]);
            return new JsonResult { Data = json };
        }
    }
}
