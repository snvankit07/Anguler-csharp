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
using System.Web.Script.Serialization;
using Newtonsoft.Json;

using System.Net.Mail;
using System.Text;
using System.Dynamic;


namespace sweetnes18.Areas.Vendor.Controllers
{

    public class rCartObj
    {
        public IEnumerable<CartData> WholCartData { get; set; }
        public double TotalQuntity { get; set; }
        public double TotalPrice { get; set; }
        public double TotalOfferprice { get; set; }
        public double TaxPrice { get; set; }
        public double SubTotalPrice { get; set; }
        public double ShippingCost { get; set; }

        public String qunmsg { get; set; }
        public String pricemsg { get; set; }
        public String productsubtotalmsg { get; set; }
        public String offermsg { get; set; }
        public String Shippingnmsg { get; set; }
        public String itemnmsg { get; set; }
        public String totalmsg { get; set; }
        public String viewcartmsg { get; set; }

    }

    public class rCartData
    {
        public String ProductOrderNumber { get; set; }
        public int Product_id { get; set; }
        public PurchaseProduct Product { get; set; }
        public user Vendor { get; set; }
        public double ProductPurchasePrice { get; set; }
        public int ProductPurchaseQun { get; set; }
        public double Offerprice { get; set; }
        public double ProductOffer { get; set; }
        public double ShippingCost { get; set; }
        public CompanyRate ShippingRatecard { get; set; }
        public Company shippingCompanys { get; set; }
        public int toID { get; set; }
        public String toname { get; set; }
        public int fromID { get; set; }
        public String fromname { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public Boolean Flag { get; set; }
        public String FlagMsg { get; set; }
        public Int32 pickanddeliverStatus { get; set; }
        public String OrderStatus { get; set; }
        public String OrderCreatedDate { get; set; }
        public String Trakingnumber { get; set; }
        public double ProductSubtotal { get; set; }
        public double Discount { get; set; }
        public double Shipping { get; set; }
        public double OrderTotal { get; set; }
    }
    public class rPurchaseProduct
    {

        public int ProductID { get; set; }
        public String ProductTitle { get; set; }

        public String ProductDec { get; set; }
        public String ProductSalePrice { get; set; }
        public String ProductRegulerPrice { get; set; }
        public int ProductQun { get; set; }
        public int ProductPurchaseQun { get; set; }
        public String SKU { get; set; }
        public String productimage { get; set; }
        public String productimg { get; set; }
        public int CatID { get; set; }
        public int UserID { get; set; }
        public int BrandID { get; set; }
        public int productStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
        public int NumberofVisit { get; set; }
        public int adminoffer { get; set; }
        public int vendoroffer { get; set; }
        public String ActualAmount { get; set; }
        public int IsCustomized { get; set; }
        public String CustomizedMsg { get; set; }
        public int PreperationTime { get; set; }
    }


    public class CartObject
    {
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public Products productdetail;
        public user vendor;
    }




    public class OrderDetails
    {
        public Products productdetail { get; set; }
        public user vendor { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public int Offerprice { get; set; }
        public Double price { get; set; }
        public String couponcode { get; set; }
        public String OfferType { get; set; }

    }
    public class OrderData
    {
        public Int32 OrderID { get; set; }
        public String OrderTrnID { get; set; }
        public List<rCartData> OrderDetails { get; set; }
        public String userId  { get; set; }
        public Int32 CustomerID  { get; set; }
        public String CustomerName { get; set; }

    }
    public class OrderTypeData
    {
        public String OrderTypeName { get; set; }
        public String OrderTypeIcon { get; set; }
        public Int32 OrderCount { get; set; }
        public Int32 OrderType { get; set; }

    }
    public class ProductsData
    {
        public int ProductID { get; set; }
        public String ProductTitle { get; set; }
        
        public String ProductDec { get; set; }
        public String ProductSalePrice { get; set; }
        public String ProductRegulerPrice { get; set; }
        public int ProductQun { get; set; }
        public String productimage { get; set; }
        public String productimg { get; set; }
        public String SKU { get; set; }
        public int CatID { get; set; }
        public int UserID { get; set; }
        public int BrandID { get; set; }
        public int productStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int NumberofVisit { get; set; }
    }
    public class apiresponse
    {
        public Boolean flag { get; set; }
        public String message { get; set; }
        public int totalcount { get; set; }
        public Object result { get; set; }
    }
    public class useruserdata
    {
        public int id { get; set; }
        public String fname { get; set; }
        public String lname { get; set; }
        public String mobileno { get; set; }
        public int status { get; set; }
        public int usertype { get; set; }
        public String username { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String CityName { get; set; }
        public String Address { get; set; }
        public String BusinessName { get; set; }
        public String BusinessAbout { get; set; }
        public String BusinessDec { get; set; }

        public String Accountholder { get; set; }
        public String Accountnumber { get; set; }
        public String IBAN { get; set; }
        public String Swiftcode { get; set; }
        public String Bankname { get; set; }
        public String Bankcity { get; set; }
        public String Bankcountry { get; set; }
        public String Vatnumber { get; set; }

    }
    public class Profiledata
    {
        public Object userdata { get; set; }
        public Object usermeta { get; set; }
       
    }
    public class Ordershow
    {
        public Object Orderlist { get; set; }
        public Object allorder { get; set; }

    }
    public class VendorAjaxController : Controller
    {
        private conn db = new conn();
        private DatabaseConnection abcd = new DatabaseConnection();

        [AllowJsonGet]
        public JsonResult ProductList()
        {


            String date_StartS = Request.QueryString["date_Start"];

            DateTime date_Start = Convert.ToDateTime(date_StartS);
            String date_EndS = Request.QueryString["date_End"];
            DateTime date_End = Convert.ToDateTime(date_EndS);
            String terms = Request.QueryString["term"];

            String skipS = Request.QueryString["skip"];
            int Skip = Convert.ToInt32(skipS);
            String TakeS = Request.QueryString["take"];
            int Take = Convert.ToInt32(TakeS);

            String CountS = Request.QueryString["count"];
            int Count = 0;
            if (!String.IsNullOrEmpty(CountS) && CountS.Length > 0)
            {
                Count = Convert.ToInt32(CountS);
            }
            String downloadS = Request.QueryString["download"];
            int download = 0;
            if (!String.IsNullOrEmpty(downloadS) && downloadS.Length > 0)
            {
                download = Convert.ToInt32(downloadS);
            }
            Int32 VID = Convert.ToInt32(Session["vendorloginID"]);
            //Int32 VID = Convert.ToInt32(Request["vendorID"]);


            IQueryable<Products> q = db.Products.Where(x => x.productStatus != -2 && x.UserID == VID   );
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x => x.ProductTitle.Contains(terms) || x.ProductDec.Contains(terms));
            }
            if (date_Start.Year > 1985)
            {
                q = q.Where(x => x.CreatedDate > date_Start).Where(x => x.CreatedDate < date_End);
            }
            List<Products> prod = new List<Products>();
            int totalcount = 0;
            if (download == 0 )
            {
                prod = q.OrderByDescending(x => x.ProductID).Skip(Skip).Take(Take).ToList();
                totalcount = q.OrderByDescending(x => x.ProductID).Count();
                 
            } 
            else if (download == 1)
            {
                prod = q.OrderByDescending(x => x.ProductID).ToList();
            }


            List<ProductsData> PROD = new List<ProductsData>();

            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            

            foreach (Products i in prod)
            {
                ProductsData p = new ProductsData();
                p.BrandID = i.BrandID;
                p.CatID = i.CatID;
                p.CreatedDate = i.CreatedDate;
                p.NumberofVisit = i.NumberofVisit;
                p.ProductDec = i.ProductDec;
                p.ProductID = i.ProductID;
                string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");
                string curFile = directory + "/" + System.IO.Path.GetFileName(i.productimage);
                if (System.IO.File.Exists(curFile))
                {
                    p.productimage = i.productimage;
                    p.productimg = i.productimg; ;
                }
                else
                {
                    p.productimage = "/img/imgs.jpg";
                    p.productimg = "/img/imgs.jpg";
                }

                p.ProductQun = i.ProductQun;
                p.ProductRegulerPrice = i.ProductRegulerPrice;
                p.ProductSalePrice = i.ProductSalePrice;
                p.productStatus = i.productStatus;
                p.ProductTitle = i.ProductTitle;
                p.SKU = i.SKU;
                p.UpdateDate = i.UpdateDate;
                p.UserID = i.UserID;
                PROD.Add(p);
            }

            m.flag = true;
            m.message = "Products List";
            m.result = PROD.ToList();
            m.totalcount = totalcount;
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
         

        [AllowJsonGet]
        public JsonResult getAllOfferList()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 UserID = Convert.ToInt32(Request["id"]);
            var offer = db.ProductOffers.Where(h => h.OfferAddUserID == UserID).ToList();

            m.flag = true;
            m.message = "All Offer List";
            m.result = offer;

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult getOrderTypeWithCount()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 UserID = Convert.ToInt32(Request["id"]);

            List<OrderTypeData> OrderType = new List<OrderTypeData>();
            OrderTypeData o = new OrderTypeData();

            o.OrderTypeName = "Pending Order";
            o.OrderTypeIcon = "/img/impicon/open_order.png";
            o.OrderCount = db.ProductBundle.Where(x => x.VendorID == UserID).GroupBy(h => h.OrderID).Count();
            o.OrderType = 0;
            OrderType.Add(o);
            OrderTypeData o1 = new OrderTypeData();
            o1.OrderTypeName = "Cancel Orders";
            o1.OrderTypeIcon = "/img/impicon/cancelled_order.png";
            o1.OrderCount = db.ProductBundle.Where(x => x.VendorID == UserID).GroupBy(h => h.OrderID).Count();
            o1.OrderType = 1;
            OrderType.Add(o1);

            OrderTypeData o2 = new OrderTypeData();
            o2.OrderTypeName = "Delivered Orders";
            o2.OrderTypeIcon = "/img/impicon/all_order.png";
            o2.OrderCount = db.ProductBundle.Where(x => x.VendorID == UserID).GroupBy(h => h.OrderID).Count();
            o2.OrderType = 2;
            OrderType.Add(o2);


            List<Ordershow> ORDERSHOW = new List<Ordershow>();
            Ordershow OR = new Ordershow();
            OR.Orderlist = OrderType.ToList();
            OR.allorder = db.ProductBundle.Where(h => h.VendorID == UserID).ToList();
            ORDERSHOW.Add(OR);

            m.flag = true;
            m.message = "Business Info";
            m.result = ORDERSHOW.FirstOrDefault();

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult Order1List()
        {
            int id = 1;
            return this.OrderList(id);
        }
        [AllowJsonGet]
        public JsonResult Order2List()
        {
            int id = 2;
            return this.OrderList(id);
        }
        [AllowJsonGet]
        public JsonResult Order0List()
        {
            int id = 0;
            return this.OrderList(id);
        }
         

        [AllowJsonGet]
        public JsonResult OrderList(int id)
        {

            String date_StartS = Request.QueryString["date_Start"];

            DateTime date_Start = Convert.ToDateTime(date_StartS);
            String date_EndS = Request.QueryString["date_End"];
            DateTime date_End = Convert.ToDateTime(date_EndS);
            String terms = Request.QueryString["term"];
            int termsI = int.TryParse(terms, out termsI) ? termsI : 0;

            String skipS = Request.QueryString["skip"];
            int Skip = Convert.ToInt32(skipS);
            String TakeS = Request.QueryString["take"];
            int Take = Convert.ToInt32(TakeS);

            String CountS = Request.QueryString["count"];
            int Count = 0;
            if (!String.IsNullOrEmpty(CountS) && CountS.Length > 0)
            {
                Count = Convert.ToInt32(CountS);
            }
            String downloadS = Request.QueryString["download"];
            int download = 0;
            if (!String.IsNullOrEmpty(downloadS) && downloadS.Length > 0)
            {
                download = Convert.ToInt32(downloadS);
            }

            Int32 UID = Convert.ToInt32(Session["vendorloginID"]);
            if(UID == 0 )
            {
                UID = Convert.ToInt32(Request["uid"]);
            }

             
            List<apiresponse> APIRES = new List<apiresponse>();
            List<OrderData> ORDER = new List<OrderData>();
            apiresponse m = new apiresponse();
           
            Int32 type = Convert.ToInt32(Request["id"]);

            type = id;
            
             //var q =  db.Orders.Join(db.ProductBundle,x=>x.OrderID, y=>y.OrderID, (x, ProductBundlex) => ProductBundlex..Where(a=>a.VendorID == UID).Select(ProductBundlex.VendorID).DefaultIfEmpty() ).Where(h => h.x.VendorID == UID);
          
            var q = db.ProductBundle.Where(h => h.VendorID == UID); 
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x => x.OrderID.Equals(termsI));
            }
            if (date_Start.Year > 1985)
            {
                q = q.Where(x =>Convert.ToDateTime(x.CreatedDate) > date_Start).Where(x => Convert.ToDateTime(x.CreatedDate) < date_End);
            }
            dynamic prod  = String.Empty;
            int totalcount = 0;
            if (download == 0)
            {
                prod = q.OrderByDescending(x => x.OrderID).Skip(Skip).Take(Take).ToList();
                totalcount = q.OrderByDescending(x => x.OrderID).Count();

            }
            else if (download == 1)
            {
                prod = q.OrderByDescending(x => x.OrderID).ToList();
            }






            foreach (dynamic orders in prod)
            {

                OrderData o = new OrderData();
                o.OrderID = orders.OrderID;
                o.OrderTrnID = orders.TransactionId;

                if (!String.IsNullOrEmpty(orders.orderDetail))
                {
                    o.OrderDetails = JsonConvert.DeserializeObject<List<CartObject>>(orders.orderDetail);
                }

                o.userId = orders.userID;
                o.CustomerID = orders.customerID;
                Int32 CID = Convert.ToInt32(o.userId);
                var customer = db.user.Where(hhh => hhh.id == CID).FirstOrDefault();
                if (customer == null)
                {
                    o.CustomerName = "Guest";
                }
                else
                {
                    o.CustomerName = customer.fname;
                }
                ORDER.Add(o);

            }

             


            m.flag = true;
            m.message = "Order Show BY Status";
            m.result = ORDER.ToList();
            m.totalcount = totalcount;
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };


        }







        [AllowJsonGet]
        public JsonResult GetOrderByStatus()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            List<OrderData> ORDER = new List<OrderData>();
            apiresponse m = new apiresponse();
            Int32 UID = Convert.ToInt32(Request["uid"]);
            Int32 type = Convert.ToInt32(Request["id"]);
            var Bandle = db.ProductBundle.Where(h => h.VendorID == UID).ToList();

            foreach (ProductBundle i in Bandle)
            {
                Int32 orderc = ORDER.Where(v => v.OrderID == i.OrderID).Count();
                if (orderc == 0)
                {
                    var orders = db.Orders.Where(hh => hh.OrderID == i.OrderID && hh.orderstatus == type).FirstOrDefault();
                    if (orders != null)
                    {
                        OrderData o = new OrderData();
                        o.OrderID = i.OrderID;
                        o.OrderTrnID = orders.TransactionId;

                        if (!String.IsNullOrEmpty(orders.orderDetail))
                        {
                            o.OrderDetails = JsonConvert.DeserializeObject<List<rCartData>>(orders.orderDetail);
                        }

                        o.userId = orders.userID;
                        o.CustomerID = orders.customerID;
                        Int32 CID = Convert.ToInt32(o.userId);
                        var customer = db.user.Where(hhh => hhh.id == CID).FirstOrDefault();
                        if (customer == null)
                        {
                            o.CustomerName = "Guest";
                        }
                        else
                        {
                            o.CustomerName = customer.fname;
                        }
                        ORDER.Add(o);
                    }
                }
            }



            m.flag = true;
            m.message = "Order Show BY Status";
            m.result = ORDER.ToList();

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };

        }


        [AllowJsonGet]
        public JsonResult getbusinessinfo()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 UID = 0;

            if (Request["user"] != null)
            {
                UID = Convert.ToInt32(Request["user"]);
            }
            else
            {
                UID = Convert.ToInt32(Session["vendorloginID"]);
            }



            var u = db.Usersmeta.Where(h => h.userid == UID).ToList();

            m.flag = true;
            m.message = "Business Info";
            m.result = u;

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }


        [AllowJsonGet]
        public JsonResult VendorProfileData()
        {

            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            List<Profiledata> usersd = new List<Profiledata>();
            Profiledata usersd1 = new Profiledata();
            Int32 VID = 0;
            if (Request["vendorID"] != null)
            {
                VID = Convert.ToInt32(Request["vendorID"]);
            }
            else
            {
                VID = Convert.ToInt32(Session["vendorloginID"]);

            }
            

            usersd1.userdata = db.user.Where(x => x.id == VID).ToList();
            usersd1.usermeta = db.Usersmeta.Where(x => x.userid == VID).ToList();
            usersd.Add(usersd1);

            m.flag = true;
            m.message = "Whole Business Info";
            m.result = usersd.FirstOrDefault();

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult UpdateVendorProfile()
        {

            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            Int32 UID = Convert.ToInt32(Request["userid"]);
            String Fname = (Request["fName"]).ToString();
            String lName = (Request["lName"]).ToString();
            String About = (Request["About"]).ToString();
            String Business = (Request["Business"]).ToString();
            String City = (Request["City"]).ToString();
            String Country = (Request["Country"]).ToString();
            String Dec = (Request["Dec"]).ToString();
            String State = (Request["State"]).ToString();
            String add = (Request["add"]).ToString();
            String op = (Request["oldpass"]).ToString();
            String np = (Request["newpass"]).ToString();
            String cnp = (Request["cnewpass"]).ToString();
           

            if (op.Trim().Count() > 1)
            {
                if (np.Trim().Count() > 1)
                {
                    if (np == op)
                    {
                        var user2 = db.user.Where(h => h.id == UID && h.password == np).FirstOrDefault();
                        if (user2 != null)
                        {
                            user user1 = db.user.Where(h => h.id == UID).FirstOrDefault();
                            user1.password = cnp;
                            db.SaveChanges();
                        }
                        else
                        {
                            m.flag = false;
                            m.message = "Your Password Doesn't match Our Database";
                            m.result = "";
                        }

                    }
                    else
                    {

                        m.flag = false;
                        m.message = "Password Mismatch";
                        m.result = "";

                    }
                }
                else
                {
                    m.flag = false;
                    m.message = "Please Enter More Then 6 Charecter";
                    m.result = "";
                }
            }

            user user = db.user.Where(h => h.id == UID).FirstOrDefault();
            user.fname = Fname;
            user.lname = lName;
            user.City = City;
            user.Country = Country;
            user.billing = add;
            //user.vatNumber = vatNumber;
            db.SaveChanges();

            abcd.Select("delete from [dbo].[Usersmeta] where  userid='" + UID + "'");

            /*---------------------------------*/
            Usersmeta b = new Usersmeta();
            b.metakey = "Business";
            b.userid = UID;
            b.metavalue = Business;
            db.Usersmeta.Add(b);
            db.SaveChanges();
            /*---------------------------------*/
            Usersmeta ad = new Usersmeta();
            ad.metakey = "add";
            ad.userid = UID;
            ad.metavalue = add;
            db.Usersmeta.Add(ad);
            db.SaveChanges();
            /*---------------------------------*/
            Usersmeta Ab = new Usersmeta();
            Ab.metakey = "About";
            Ab.userid = UID;
            Ab.metavalue = About;
            db.Usersmeta.Add(Ab);
            db.SaveChanges();
            /*---------------------------------*/
            Usersmeta D = new Usersmeta();
            D.metakey = "Dec";
            D.userid = UID;
            D.metavalue = Dec;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            /*-------------Vendor Extra Data--------------*/
            String Accountholder = Request["Accountholder"].ToString();
            String Accountnumber = Request["Accountnumber"].ToString();
            String IBAN = Request["IBAN"].ToString();
            String Swiftcode = Request["Swiftcode"].ToString();
            String Bankname = Request["Bankname"].ToString();
            String Bankcity = Request["Bankcity"].ToString();
            String Bankcountry = Request["Bankcountry"].ToString();
            String Vatnumber = Request["Vatnumber"].ToString();


            /*-------------Vendor Extra Data--------------*/
            D.metakey = "Vatnumber";
            D.userid = UID;
            D.metavalue = Vatnumber;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            /*---------------------------------*/

            D.metakey = "Accountholder";
            D.userid = UID;
            D.metavalue = Accountholder;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            /*---------------------------------*/

            D.metakey = "Accountnumber";
            D.userid = UID;
            D.metavalue = Accountnumber;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            /*---------------------------------*/

            D.metakey = "IBAN";
            D.userid = UID;
            D.metavalue = IBAN;
            db.Usersmeta.Add(D);
            db.SaveChanges();


            /*---------------------------------*/

            D.metakey = "Swiftcode";
            D.userid = UID;
            D.metavalue = Swiftcode;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            /*---------------------------------*/

            D.metakey = "Bankname";
            D.userid = UID;
            D.metavalue = Bankname;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            /*---------------------------------*/

            D.metakey = "Bankcity";
            D.userid = UID;
            D.metavalue = Bankcity;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            /*---------------------------------*/

            D.metakey = "Bankcountry";
            D.userid = UID;
            D.metavalue = Bankcountry;
            db.Usersmeta.Add(D);
            db.SaveChanges();

            m.flag = true;
            m.message = "Successfully Update Vendor Your Profile";
            m.result = "";

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult UpdateStatus() {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            String OID = Convert.ToString(Request["id"]);
            ProductBundle pb = db.ProductBundle.Where(h => h.ProductOrderID.Trim() == OID.Trim()).FirstOrDefault();
            pb.pickanddeliverStatus = 0;
            db.SaveChanges();
            var bundle= db.ProductBundle.Where(h => h.ProductOrderID.Trim() == OID.Trim()).FirstOrDefault(); ;
            m.flag = true;
            m.message = "update";
            m.result = bundle;

            

            IDictionary<string, string> ShippingInfo = new Dictionary<string, string>() {
                                                    { "%#Ref#%", OID},
                                                };

            Format Ship1 = new Format(18, ShippingInfo, db.Company.Where(x=>x.ID==bundle.ShippingCompanyID).FirstOrDefault().shippingemail);
            




            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };

        }


    }
}
