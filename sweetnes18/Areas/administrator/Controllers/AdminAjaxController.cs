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
using System.Data.Entity;
using System.Web.Helpers;

namespace sweetnes18.Areas.administrator.Controllers
{
    public class transaction
    {
        public Int64 id { get; set; }
        public String dates { get; set; }
        public String Decription { get; set; }
        public String OrderId { get; set; }
        public String TotalAmount { get; set; }
        public String AdminAmount { get; set; }
        public String PayableAmount { get; set; }
        public String Shipping { get; set; }
        public String Status { get; set; }
        public String Title { get; set; }
        public String Balance { get; set; }
        public Order o { get; set; }

    }
    public class ReverseCart
    {

        public int OrderID { get; set; }
        public String Shipping { get; set; }
        public String Billing { get; set; }
        public int CustomerID { get; set; }
        public String TransactionId { get; set; }
        public String ModeOfPayment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        // public String orderDetail { get; set; } 
        public List<CartObj> orderDetail { get; set; }
    }
    public class PurchaseProduct
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
        public int PreperationTime { get; set; }
    }
    public class ProductsListData
    {

        public int ProductID { get; set; }
        public String ProductTitle { get; set; }
        public String ProductTitleAr { get; set; }

        public String ProductDec { get; set; }
        public String ProductDecAr { get; set; }
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
        public int NumberofVisit { get; set; }
        public int adminoffer { get; set; }
        public int vendoroffer { get; set; }
        public String ActualAmount { get; set; }
        public int IsCustomized { get; set; }
        public int PreperationTime { get; set; }
        public List<String> images { get; set; }
        public List<ProductMetad> Specif { get; set; }
        public List<ProductMetad> Additional { get; set; }

    }
    public class ProductMetad
    {

        public String ProductKey { get; set; }
        public String ProductKeyAr { get; set; }
        public String ProductValue { get; set; }
        public String ProductValueAr { get; set; }

    }
    public class CartData
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
    public class CartObj
    {
        public IEnumerable<CartData> WholCartData { get; set; }
        public double TotalQuntity { get; set; }
        public double TotalPrice { get; set; }
        public double TotalOfferprice { get; set; }
        public double TaxPrice { get; set; }
        public double SubTotalPrice { get; set; }
        public double ShippingCost { get; set; }

    }
    public class ReviewsShow
    {
        public int ReviewID { get; set; }
        public String CustomerName { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public String Token { get; set; }
        public int StarRating { get; set; }
        public String Reviewmsg { get; set; }
    }
    public class OrderBandal
    {
        public String OrderID { get; set; }
        public CartData MainCartdata { get; set; }
        public String OrderStatusMsg { get; set; }
        public String Customizemsg { get; set; }
        public String CustomizeImage { get; set; }
        public String CancleMsg { get; set; }
        public String CancleImage { get; set; }

    }
    public class Response
    {
        public Boolean flag { get; set; }
        public String message { get; set; }
        public Object result { get; set; }
    }
    public class Dashboarddata
    {
        public Double AllPayment { get; set; }
        public Double PendingPayment { get; set; }
        public Double ClearPayment { get; set; }
        public Double Order { get; set; }
        public Double Customer { get; set; }
        public Double Product { get; set; }
        public IEnumerable<graphdata> graphdata { get; set; }

    }
    public class graphdata
    {
        public string dates { get; set; }
        public string purchaseCount { get; set; }
        public string purchaseCost { get; set; }
    }
    public class apiresponse
    {
        public Boolean flag { get; set; }
        public String message { get; set; }
        public Object result { get; set; }
    }
    public class ProductsDetails
    {
        public int ProductID { get; set; }
        public String ProductTitle { get; set; }
        public String ProductTitleAr { get; set; }
        public String ProductDec { get; set; }
        public String ProductDecAr { get; set; }
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
        public int NumberofVisit { get; set; }
        public int adminoffer { get; set; }
        public int vendoroffer { get; set; }
        public String ActualAmount { get; set; }
        public int IsCustomized { get; set; }
        public int PreperationTime { get; set; }
    }
    public class ShippingCompanys
    {
        public int ID { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public IEnumerable<CompanyRate> Rates { get; set; }

    }
    public class Productmetas
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public String ProductTypeKey { get; set; }
        public String ProductKey { get; set; }
        public String ProductValue { get; set; }
        public String ProductKeyAr { get; set; }
        public String ProductValueAr { get; set; }

    }
    public class UserData
    {
        public user user { get; set; }
        public Double TotalAmount  { get; set; }
        public Double unpaidAmount { get; set; }
        public Double PaidAmount { get; set; }
        public Double PandingAmount { get; set; }
        public Double CancleAmount { get; set; }
    }
    public class AdminAjaxController : Controller
    {
        private conn db = new conn();

        [AllowJsonGet]
        public JsonResult ShippingCompanyPrice()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            List<ShippingCompanys> SHIP = new List<ShippingCompanys>();

            var company = db.Company.ToList();
            foreach (Company x in company)
            {
                ShippingCompanys s = new ShippingCompanys();
                s.ID = x.ID;
                s.name = x.name;
                s.description = x.description;
                s.Rates = db.CompanyRate.Where(h => h.CID == s.ID).ToList();
                SHIP.Add(s);
            }

            m.flag = true;
            m.message = "Shipping Company With Price";
            m.result = SHIP.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult ValueShipping()
        {
            var um = db.Usersmeta.Where(h => h.metakey == "shipvalue").Where(h => h.userid == 1).FirstOrDefault();
            return new JsonResult { Data = um };
        }
        [AllowJsonGet]
        public JsonResult PromotionShipping()
        {
            Int32 Shipping = Convert.ToInt32(Request["Shippng"]);
            var USR = db.user.ToList();
            if (USR.Count()>0)
            {
                foreach (user u in USR)
                {
                    var UserData = db.user.Where(x => x.id == u.id).FirstOrDefault();
                    if (UserData != null)
                    {
                        if(Shipping==0 || Shipping==1)
                        {
                            UserData.shipping = Shipping;
                            db.SaveChanges();
                            var um=db.Usersmeta.Where(h => h.metakey == "shipvalue").Where(h => h.userid == 1).FirstOrDefault();
                            um.metavalue = Shipping.ToString();
                            db.SaveChanges();


                        }
                    }
                }
            }

            //var json = (Company);
            return new JsonResult { Data = 1 };
        }


        [AllowJsonGet]
        public JsonResult companyphoneupdate()
        {
            Int32 ID = Convert.ToInt32(Request["id"]);
            String Phone = Request["phone"];
            var Company = db.Company.Where(x => x.ID == ID).FirstOrDefault();
            if (Company != null)
            {
                Company.description = Phone;

                db.Entry(Company).State = EntityState.Modified;
                db.SaveChanges();
            }
            
            var json = (Company);
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult user()
        {

            string json = JsonConvert.SerializeObject(db.user.Where(u => u.status != -2).ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult GetProductsByID()
        {
            Int32 ID = Convert.ToInt32(Request["ID"]);
            List<ProductsDetails> PRO= new List<ProductsDetails>();
            ProductsDetails p = new ProductsDetails();
            var pro=db.Products.Where(u => u.ProductID == ID).FirstOrDefault();
            p.BrandID = pro.BrandID;
            p.adminoffer = pro.adminoffer;
            p.vendoroffer = pro.vendoroffer;
            p.UserID = pro.UserID;
            p.SKU = pro.SKU;
            p.ProductTitle = pro.ProductTitle;


            p.ProductID = pro.ProductID;
            p.ProductTitle = pro.ProductTitle;
            p.ProductDec = pro.ProductDec;
            p.ProductSalePrice = pro.ProductSalePrice;
            p.ProductRegulerPrice = pro.ProductRegulerPrice;
            p.ProductQun = pro.ProductQun;
            p.SKU = pro.SKU;
            p.productimage = pro.productimage;
            p.productimg = pro.productimg;
            p.CatID = pro.CatID;
            p.UserID = pro.UserID;
            p.BrandID = pro.BrandID;
            p.productStatus = pro.productStatus;
            p.adminoffer = pro.adminoffer;
            p.vendoroffer = pro.vendoroffer;
            p.ActualAmount = pro.ActualAmount;
            p.IsCustomized = pro.IsCustomized;
            p.PreperationTime = pro.PreperationTime;
            p.ProductTitleAr = LanguageChange(pro.ProductTitle,pro.ProductID);
            p.ProductDecAr = LanguageChange(pro.ProductDec, pro.ProductID);
            PRO.Add(p);



            var json = (PRO.FirstOrDefault());
            return new JsonResult { Data = json };
        }

        

        [AllowJsonGet]
        public JsonResult GetAllCategory()
        {
            int UID = Convert.ToInt32(Session["vendorloginID"]);
            string json;
            if (UID > 0)
            {
                json = JsonConvert.SerializeObject(db.ProductCategory.Where(u => u.CategoryStatus ==1 || (u.CategoryStatus==0 && u.UserID==UID )).ToList());
            }
            else
            {
                json = JsonConvert.SerializeObject(db.ProductCategory.Where(u => u.CategoryStatus != -2).ToList());
            }


            
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult GetAllBrand()
        {
            int UID = Convert.ToInt32(Session["vendorloginID"]);
            string json;
            if (UID > 0)
            {
                json = JsonConvert.SerializeObject(db.ProductBrand.Where(u => u.BrandStatus ==1 || (u.UserID==UID && u.BrandStatus==0)).ToList());
            }
            else
            {
                json = JsonConvert.SerializeObject(db.ProductBrand.Where(u => u.BrandStatus != -2).ToList());
            }
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult GetAllVendor()
        {
            string json = JsonConvert.SerializeObject(db.user.Where(u => u.status != -2 && u.usertype==2).ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult GetAllVendorsList()
        {
            List<UserData> UDATA = new List<UserData>();

            var vendor=db.user.Where(u => u.status != -2 && u.usertype == 2).ToList();
            foreach (user v in vendor)
            {
                if(db.ProductBundle.Where(x => x.VendorID ==v.id).ToList().Count()>0)
                {
                    var ListData=db.ProductBundle.Where(x => x.VendorID == v.id).ToList();
                    Double TotalCost = 0;
                    Double Totalunpaid = 0;
                    Double Totalpaid = 0;
                    Double cancle = 0;
                    Double panding = 0;
                    foreach (ProductBundle pcs in ListData)
                    {
                        dynamic stuff = JsonConvert.DeserializeObject(pcs.OrderSummary);
                        double data = Convert.ToDouble(Convert.ToDouble(stuff.Product.ProductRegulerPrice) * Convert.ToDouble(stuff.ProductPurchaseQun));
                        data = data - (data * 8 / 100);
                        if (pcs.payable == 1)
                        {
                            Totalpaid = Totalpaid + data;
                        }
                        else {
                            if (pcs.pickanddeliverStatus < 6 && pcs.pickanddeliverStatus >= -1)
                            {
                                panding = panding + data;
                            }
                            else if (pcs.pickanddeliverStatus <= -2)
                            {
                                cancle = cancle + data;
                            }
                            else { 
                                Totalunpaid = Totalunpaid + data;
                            }
                        }
                        TotalCost = TotalCost + data;
                    }

                    UserData U= new UserData();
                    U.user = v;
                    U.TotalAmount = TotalCost;
                    U.PaidAmount = Totalpaid;
                    U.unpaidAmount = Totalunpaid;
                    U.CancleAmount = cancle;
                    U.PandingAmount = panding;
                    UDATA.Add(U);
                }
            }

            return new JsonResult { Data = UDATA.ToList()};
        }


        [AllowJsonGet]
        public JsonResult GetProductMeta()
        {
            Int32 ID = Convert.ToInt32(Request["id"]);
            String Meta = (Request["metakey"]).ToString();

            List<Productmetas> META = new List<Productmetas>();
            var p=db.ProductMeta.Where(u => u.ProductID == ID && u.ProductTypeKey.Contains(Meta)).ToList();
            foreach (ProductMeta v in p)
            {
                Productmetas m = new Productmetas();
                if (v.ProductKey.Trim().Length > 0)
                {
                    m.ID = v.ID;
                    m.ProductID = v.ProductID;
                    m.ProductKey = v.ProductKey;
                    m.ProductValue = v.ProductValue;
                    m.ProductTypeKey = v.ProductTypeKey;
                    m.ProductKeyAr = LanguageChange(v.ProductKey, v.ProductID);
                    m.ProductValueAr = LanguageChange(v.ProductValue, v.ProductID);
                    META.Add(m);
                }
            }

           
            return new JsonResult { Data = META.ToList() };
        }

        [AllowJsonGet]
        public JsonResult delete()
        {
            Int32 ID = Convert.ToInt32(Request["id"]); 
            ProductMeta m1 = new ProductMeta();
            m1 = db.ProductMeta.Where(u => u.ID == ID).FirstOrDefault(); 
            db.ProductMeta.Remove(m1);
            db.SaveChanges();
            String json = JsonConvert.SerializeObject(1);
            return new JsonResult { Data = json };
        }



        [AllowJsonGet]
        public JsonResult Products()
        {
            string json = JsonConvert.SerializeObject(db.Products.Where(u => u.productStatus != -2).ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult Orders()
        {
            var json = db.Order.Where(u => u.orderstatus != -2).ToList();
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult CMS()
        {
            string json = JsonConvert.SerializeObject(db.CMS.Where(u => u.PageStatus != -2).ToList());
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult coupons()
        {

            string json = JsonConvert.SerializeObject(db.ProductOffer.ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult discount()
        {

            string json = JsonConvert.SerializeObject(db.ProductOffer.ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult discounts()
        {

            string json = JsonConvert.SerializeObject(db.ProductOffer.ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult customer()
        {

            var json = db.CustomerProfiles.ToList();
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult GetUserDetails()
        {
            Int32 userID = Convert.ToInt32(Request["userID"]);
            var user = db.user.Where(x => x.id == userID).FirstOrDefault();
            return new JsonResult { Data = user };
        }

        [AllowJsonGet]
        public JsonResult OrderStatusChange()
        {
            Int32 status = Convert.ToInt32(Request["status"]);
            String TrId = Request["trnsId"];
            var Orders = db.Order.Where(x => x.TransactionId == TrId).FirstOrDefault();
            if (Orders != null)
            {


                Orders.orderstatus = status;
                Orders.Billing = "";

                db.Entry(Orders).State = EntityState.Modified;
                db.SaveChanges();
            }
            var Ordersn = db.Order.Where(x => x.TransactionId == TrId).FirstOrDefault();
            if (status == 1)
            {


                var c = db.CustomerProfiles.Where(x => x.CustomerID == Orders.customerID).FirstOrDefault();
                IDictionary<string, string> keys1 = new Dictionary<string, string>() {
                                                                                    { "%#product#%", TrId},
                                                                                    { "%#link#%", "https://www.sweetness.ae/myorder/review?Token="+TrId}
                                                                                };


                Format a1 = new Format(15, keys1, c.CustomerEmailID);
                Format a2 = new Format(15, keys1, "snv.ankit@gmail.com");

            }
            var json = (Ordersn);
            return new JsonResult { Data = json };
        }
        private string GenerateRandomText(int v)
        {

            const string Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, v)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result;

        }

        [AllowJsonGet]
        public JsonResult AllbyPage()
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

            //var 

            //DatabaseConnection abcd = new DatabaseConnection();
            //String Q = "select * from  [dbo].["+table+"]  Where  VendorID ='" + id + "' order by Createddate desc";
            //var dsc = JsonConvert.SerializeObject(abcd.Select(Q));



            IQueryable<Products> q = db.Products.Where(x => x.productStatus != -2);
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x => x.ProductTitle.Contains(terms) || x.ProductDec.Contains(terms));
            }
            if (date_Start.Year > 1985)
            {
                q = q.Where(x => x.CreatedDate > date_Start).Where(x => x.CreatedDate < date_End);
            }


            List<Products> c = q.OrderByDescending(x => x.ProductID).Skip(Skip).Take(Take).ToList();
            String json = JsonConvert.SerializeObject(c);

            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult ProductsbyPage()
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

            IQueryable<Products> q = db.Products.Where(x => x.productStatus != -2);
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where( x => x.ProductTitle.Contains(terms) || x.ProductDec.Contains(terms) );
            }
            if ( date_Start.Year > 1985)
            {
                q = q.Where(x => x.CreatedDate > date_Start).Where(x => x.CreatedDate < date_End);
            }
            List<Products> c = new List<Products>();
            if (download == 0 && Count == 0)
            {
                 c = q.OrderByDescending(x => x.ProductID).Skip(Skip).Take(Take).ToList();
            }
            else if (download == 0 && Count == 1)
            {
                String json1 = JsonConvert.SerializeObject(q.OrderByDescending(x => x.ProductID).Count());
                    return new JsonResult { Data = json1 };
            }
            else if (download == 1 )
            { 
                 c = q.OrderByDescending(x => x.ProductID).ToList();
            }
            String json = JsonConvert.SerializeObject(c);

            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult ProductsCount()
        {
            String json = JsonConvert.SerializeObject(db.Products.Where(x => x.productStatus != -2).Count());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult UsersbyPage()
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

            IQueryable<user> q = db.user.Where(x => x.status != -2); 
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x => x.username.Contains(terms) || x.mobileno.Contains(terms));
            }
            if (date_Start.Year > 1985)
            {
                q = q.Where(x => x.Createddate > date_Start).Where(x => x.Createddate < date_End);
            }
            List<user> c = new List<user>();
            if (download == 0 && Count == 0)
            {
                c = q.OrderByDescending(x => x.id).Skip(Skip).Take(Take).ToList();
            }
            else if (download == 0 && Count == 1)
            {
                String json1 = JsonConvert.SerializeObject(q.OrderByDescending(x => x.id).Count());
                return new JsonResult { Data = json1 };
            }
            else if (download == 1)
            {
                c = q.OrderByDescending(x => x.id).ToList();
            }
            String json = JsonConvert.SerializeObject(c);

            return new JsonResult { Data = json };
            //String json = JsonConvert.SerializeObject(db.user.Where(x => x.status != -2).OrderByDescending(x => x.id).Skip(Skip).Take(Take).ToList());
            //return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult UsersCount()
        {
            String json = JsonConvert.SerializeObject(db.user.Where(x => x.status != -2).Count());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult ProductCategorysbyPage()
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

            IQueryable<ProductCategory> q = db.ProductCategory.Where(x => x.CategoryStatus != -2);
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x => x.CategoryName.Contains(terms) || x.CategorySlug.Contains(terms));
            }
            if (date_Start.Year > 1985)
            {
                q = q.Where(x => x.Createddate > date_Start).Where(x => x.Createddate < date_End);
            }
            List<ProductCategory> c = new List<ProductCategory>();
            if (download == 0 && Count == 0)
            {
                c = q.OrderByDescending(x => x.ID).Skip(Skip).Take(Take).ToList();
            }
            else if (download == 0 && Count == 1)
            {
                String json1 = JsonConvert.SerializeObject(q.OrderByDescending(x => x.ID).Count());
                return new JsonResult { Data = json1 };
            }
            else if (download == 1)
            {
                c = q.OrderByDescending(x => x.ID).ToList();
            }
            String json = JsonConvert.SerializeObject(c);

            return new JsonResult { Data = json };
            //String json = JsonConvert.SerializeObject(db.ProductCategory.Where(x => x.CategoryStatus != -2).OrderByDescending(x => x.ID).Skip(Skip).Take(Take).ToList());
            //return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult ProductCategorysCount()
        {
            String json = JsonConvert.SerializeObject(db.ProductCategory.Where(x => x.CategoryStatus != -2).Count());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult ProductBrandsbyPage()
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

            IQueryable<ProductBrand> q = db.ProductBrand.Where(x => x.BrandStatus != -2);
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x => x.BrandName.Contains(terms) || x.Brandslug.Contains(terms) );
            }
            if (date_Start.Year > 1985)
            { 
                q = q.Where(x => x.Createddate > date_Start).Where(x => x.Createddate < date_End);
            }
            List<ProductBrand> c = new List<ProductBrand>();
            if (download == 0 && Count == 0)
            {
                c = q.OrderByDescending(x => x.ID).Skip(Skip).Take(Take).ToList();
            }
            else if (download == 0 && Count == 1)
            {
                String json1 = JsonConvert.SerializeObject(q.OrderByDescending(x => x.ID).Count());
                return new JsonResult { Data = json1 };
            }
            else if (download == 1)
            {
                c = q.OrderByDescending(x => x.ID).ToList();
            }
            String json = JsonConvert.SerializeObject(c);

            return new JsonResult { Data = json };
            //String json = JsonConvert.SerializeObject(db.ProductBrand.Where(x => x.BrandStatus != -2).OrderByDescending(x => x.ID).Skip(Skip).Take(Take).ToList());
            //return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult ProductBrandsCount()
        {
            String json = JsonConvert.SerializeObject(db.ProductBrand.Where(x => x.BrandStatus != -2).Count());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult OrdersbyPage()
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

            IQueryable<Order> q = db.Order.Where(x => x.orderstatus != -2);
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x =>  x.TransactionId.Contains(terms) || x.Shipping.Contains(terms) || x.Billing.Contains(terms) );
            }
            if (date_Start.Year > 1985)
            {
                q = q.Where(x => x.CreatedDate > date_Start).Where(x => x.CreatedDate < date_End);
            }
            List<Order> c = new List<Order>();
            if (download == 0 && Count == 0)
            {
                c = q.OrderByDescending(x => x.customerID).Skip(Skip).Take(Take).ToList();
            }
            else if (download == 0 && Count == 1)
            {
                String json1 = JsonConvert.SerializeObject(q.OrderByDescending(x => x.customerID).Count());
                return new JsonResult { Data = json1 };
            }
            else if (download == 1)
            {
                c = q.OrderByDescending(x => x.customerID).ToList();
            }
            String json = JsonConvert.SerializeObject(c);

            return new JsonResult { Data = json };

             
            //String skipS = Request.QueryString["skip"];
            //int Skip = Convert.ToInt32(skipS);
            //String TakeS = Request.QueryString["take"];
            //int Take = Convert.ToInt32(TakeS);
            //String json = JsonConvert.SerializeObject(db.Order.Where(x => x.orderstatus != -2).OrderByDescending(x => x.OrderID).Skip(Skip).Take(Take).ToList());
            //return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult OrdersCount()
        {
            String json = JsonConvert.SerializeObject(db.Order.Where(x => x.orderstatus != -2).Count());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult CMSsbyPage()
        {
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
                download = Convert.ToInt32(download);
            }
            String date_StartS = Request.QueryString["date_Start"];
            DateTime date_Start = Convert.ToDateTime(date_StartS);
            String date_EndS = Request.QueryString["date_End"];
            DateTime date_End = Convert.ToDateTime(date_EndS);
            String terms = Request.QueryString["term"];


            IQueryable<CMS> q = db.CMS.Where(x => x.PageStatus != -2);
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                q = q.Where(x => x.PageTitle.Contains(terms) || x.PageDec.Contains(terms));
            }
            if (date_Start.Year > 1985)
            {
                q = q.Where(x => x.CreatedDate > date_Start).Where(x => x.CreatedDate < date_End);
            }
            List<CMS> c = new List<CMS>();
            if (download == 0 && Count==0 )
            {
                c = q.OrderByDescending(x => x.ID).Skip(Skip).Take(Take).ToList();
            }
            else if(download == 0 && Count == 1)
            { 
                String json1 = JsonConvert.SerializeObject(q.OrderByDescending(x => x.ID).Count());
                return new JsonResult { Data = json1 };  
            }
            if(download == 1 && Count == 0)
            {
                c = q.OrderByDescending(x => x.ID).ToList();
            }
            String json = JsonConvert.SerializeObject(c);

            return new JsonResult { Data = json };






            //String json = JsonConvert.SerializeObject(db.CMS.Where(x => x.PageStatus != -2).OrderByDescending(x => x.ID).Skip(Skip).Take(Take).ToList());
            //return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult CMSsCount()
        {
            String json = JsonConvert.SerializeObject(db.CMS.Where(x => x.ID != -2).Count());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult VendorsbyPage()
        {

            //int ProductID = Convert.ToInt32(Request["Product"]);

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

              
           //var q = (from t in db.ProductBundle
           //                         join u in db.user on t.VendorID equals u.id
           //                         group new { t, u } by new { Vendor = t.VendorID } into g
           //                         select new
           //                         {

           //                             g.Key.Vendor,
           //                             pricing = g.Sum(jx => x.t.ProductPricing),
           //                             Createddate = g.(x=>x.u.Createddate) ,
           //                             Name    = g.Where(x => x.u.Createddate < date_End ),
           //                         }); // db.ProductCategory.Where(x => x.CategoryStatus != -2);
                                        //   q= q.Where(x => x.CategoryStatus != -2);
            var table = db.user.GroupJoin( db.ProductBundle, x => x.id, y => y.VendorID, (x, y) => new { x, y }).Select( g => new { g.x.id , pricing = g.y.Sum(o => (int?)o.ProductPricing) ?? 0  , g.x.Createddate, g.x.lname  });
            if (!String.IsNullOrEmpty(terms) && terms.Length > 0)
            {
                 table = table.Where(x => x.id == termsI || x.lname.Contains(terms));
            }
            if (date_Start.Year > 1985)
            {
                 table = table.Where(x => x.Createddate > date_Start).Where(x => x.Createddate < date_End);
            } 

            if (download == 0 && Count == 0)
            {
                dynamic c = table.OrderByDescending(x => x.id).Skip(Skip).Take(Take).ToList();
                String json1 = JsonConvert.SerializeObject(c);
                return new JsonResult { Data = json1 };
            }
            else if (download == 0 && Count == 1)
            {
                String json2 = JsonConvert.SerializeObject(table.OrderByDescending(x => x.id).Count());
                return new JsonResult { Data = json2 };
            }
            else if (download == 1)
            {
                dynamic c = table.OrderByDescending(x => x.id).ToList();
                String json3 = JsonConvert.SerializeObject(c);
                return new JsonResult { Data = json3 };
            }
            String json4 = String.Empty;
            return new JsonResult { Data = json4 };


            //var q = (from t in db.ProductBundle
            //         join u in db.user on t.VendorID equals u.id
            //         group new { t, u } by new { Vendor = t.VendorID } into g
            //         select new
            //         {

            //             g.Key.Vendor,
            //             pricing = g.Sum(x => x.t.ProductPricing), 
            //         });

            //  var p = db.Database.SqlQuery<Products>(q);
            //db.ProductBundle.GroupJoin()
            //String json = JsonConvert.SerializeObject(q.OrderBy(x=>x.Vendor).Skip(Skip).Take(Take).ToList());
            //return new JsonResult { Data = json };



            //List<Vendor> v1 = db.user.Where(x => x.status != -2).Where(x => x.usertype == 1).OrderByDescending(x => x.id).Skip(Skip).Take(Take).ToList();
            //String json = JsonConvert.SerializeObject(db.user.ToList());
            //return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult showpayOut()
        {
            String ID = Request.QueryString["id"];
            int id = Convert.ToInt32(ID);
            DatabaseConnection abcd = new DatabaseConnection();
            String Q = "select * from  [dbo].[MoneyRecord]  Where  VendorID ='" + id + "' order by Createddate desc";
            var dsc = JsonConvert.SerializeObject(abcd.Select(Q));
            return new JsonResult { Data = dsc };
        }




        [AllowJsonGet]
        public JsonResult paynow()
        {
            String ID = Request.QueryString["id"];
            int id = Convert.ToInt32(ID);
            String AM = Request.QueryString["amount"];
            String amount = (AM);
            DatabaseConnection abcd = new DatabaseConnection();

            MoneyRecord payment = new MoneyRecord();
            payment.Payment = amount;
            payment.VendorID = id;
            
            db.MoneyRecord.Add(payment);
            db.SaveChanges();

            var Q = db.ProductBundle.Where(h => h.VendorID == id && ( h.pickanddeliverStatus >= 6 || h.pickanddeliverStatus < -1)).ToList();
            foreach(ProductBundle pb in Q)
            {
                var FOrder = db.ProductBundle.Where(h1 => h1.Id == pb.Id).FirstOrDefault();
                if (FOrder != null)
                {
                    FOrder.payable = 1;
                    db.SaveChanges();
                }
            }
            
            return new JsonResult { Data = Q };
        }


        [AllowJsonGet]
        public JsonResult Vendorspaymentshow()
        {
            String ID = Request.QueryString["id"];
            int id = Convert.ToInt32(ID);
            String Type = Request.QueryString["type"];
            int type = Convert.ToInt32(Type);
           
            DatabaseConnection abcd = new DatabaseConnection();
            string Q = "";
            var orderd = db.ProductBundle.Where(x => x.VendorID == id).ToList();
            return new JsonResult { Data = orderd };
        }


        [AllowJsonGet]
        public JsonResult VendorsCount()
        {
            String json = JsonConvert.SerializeObject(db.user.Where(x => x.status != -2).Where(x => x.usertype == 2).Count());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult userstatus()
        {

            String statuss = Request.QueryString["status"];
            int status = Convert.ToInt32(statuss);
            String id = Request.QueryString["id"];
            int ID = Convert.ToInt32(id);
            var users = db.user.Where(x => x.id == ID).FirstOrDefault();
            if (users != null)
            {
                users.status = status;
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
            }
            var json = db.user.Where(x => x.id == ID).ToList();
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult getuser()
        {
            String ID = Request.QueryString["id"];
            int id = Convert.ToInt32(ID);
            var json = (db.user.Where(x => x.id == id).ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult getuserupdate()
        {
            Int32 status = Convert.ToInt32(Request["userstatus"]);
            Int32 usertype = Convert.ToInt32(Request["usertype"]);
            Int32 id = Convert.ToInt32(Request["id"]);
            String password = Request["password"].ToString();
            String fname = Request["fname"].ToString();
            String lname = Request["lname"].ToString();
            String mobileno = Request["mobileno"].ToString();
            String username = Request["email"].ToString();

            var user = db.user.Where(x => x.id == id).FirstOrDefault();
            if (user != null)
            {

                user.fname = fname;
                user.lname = lname;
                user.username = username;
                user.usertype = usertype;
                user.mobileno = mobileno;
                //user.password = password;
                user.status = status;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            var json = db.user.Where(x => x.id == id).ToList();
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult VendorOrdersCount()
        {
            Int32 id = Convert.ToInt32(Request["id"]);
            String json = JsonConvert.SerializeObject(db.ProductBundle.Where(x => x.VendorID == id).GroupBy(x => x.OrderID).Count());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult VendorProductsCount()
        {
            Int32 id = Convert.ToInt32(Request["id"]);
            String json = JsonConvert.SerializeObject(db.Products.Where(x => x.UserID == id).Where(x => x.productStatus != -2 ).Count());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult VendorSaleCount()
        {
            Int32 id = Convert.ToInt32(Request["id"]);
            String json = JsonConvert.SerializeObject(db.ProductBundle.Where(x => x.VendorID == id).Sum(x => x.ProductPricing));
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult SaleCount()
        {
            String json = JsonConvert.SerializeObject(db.ProductBundle.Sum(x => x.ProductPricing));
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult AdminWithdrawalAmount()
        {
            String json = JsonConvert.SerializeObject(db.ProductBundle.Where(x => x.payable == 1).Sum(x => x.ProductPricing));
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult AdminPendingAmount()
        {
            String json = JsonConvert.SerializeObject(db.ProductBundle.Where(x => x.payable == 0).Sum(x => x.ProductPricing));
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult VendorWithdrawalAmount()
        {
            Int32 id = Convert.ToInt32(Request["id"]);
           // String json = JsonConvert.SerializeObject(Convert.ToDouble(db.ProductBundle.Where(x => x.VendorID == id).Where(x => x.payable == 1).Sum(x => x.ProductPricing)));
            return new JsonResult { Data = "100.00" };
        }
        [AllowJsonGet]
        public JsonResult VendorPendingAmount()
        {
            Int32 id = Convert.ToInt32(Request["id"]);
            String json = JsonConvert.SerializeObject(db.ProductBundle.Where(x => x.VendorID == id).Where(x => x.payable == 0).Sum(x => x.ProductPricing));
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult OrdersShow()
        {
            String Msg = "";
            Object response = 0;
            List<ReverseCart> ReverseORDERD = new List<ReverseCart>();
            ReverseCart RO = new ReverseCart();


            List<OrderBandal> ORDERBANDAL = new List<OrderBandal>();

            Int32 type = Convert.ToInt32(Request["type"]);
            Int32 uid = Convert.ToInt32(Request["user"]);
            List<ProductBundle> v = new List<ProductBundle>();
            if (uid == 0)
            {
                v = db.ProductBundle.Where(x => x.OrderSummary != null).ToList();
            }
            else
            {
                v = db.ProductBundle.Where(x => x.VendorID == uid && x.OrderSummary != null).ToList();
            }
            foreach (ProductBundle v1 in v)
            {

                OrderBandal O = new OrderBandal();
                switch (v1.pickanddeliverStatus)
                {
                    case 0:
                        O.OrderStatusMsg = " Pending";
                        break;
                    case 1:
                        O.OrderStatusMsg = " shipment information received";
                        break;
                    case 2:
                        O.OrderStatusMsg = " Picked up from Store ";
                        break;
                    case 3:
                        O.OrderStatusMsg = " Departed";
                        break;
                    case 4:
                        O.OrderStatusMsg = " On the Way.";
                        break;
                    case 5:
                        O.OrderStatusMsg = " it may delay.";
                        break;
                    case 6:
                    case 7:
                        O.OrderStatusMsg = " Delivered.";
                        break;
                    case -2:
                        O.OrderStatusMsg = " Cancel.";
                        break;
                    case -1:
                        O.OrderStatusMsg = " Customized Order Pending Approved From Vendor.";
                        break;
                    case -3:
                        O.OrderStatusMsg = " not picked up.";
                        break;
                    case -4:
                        O.OrderStatusMsg = " return.";
                        break;
                }

                if (!String.IsNullOrEmpty(v1.OrderSummary))
                {
                    O.MainCartdata = JsonConvert.DeserializeObject<CartData>(v1.OrderSummary);
                    O.MainCartdata.OrderStatus = O.OrderStatusMsg;
                    O.MainCartdata.pickanddeliverStatus = v1.pickanddeliverStatus;
                    O.MainCartdata.OrderCreatedDate = v1.CreatedDate.ToString();
                    O.MainCartdata.ProductSubtotal = (Convert.ToDouble(O.MainCartdata.Product.ActualAmount) * O.MainCartdata.ProductPurchaseQun) + Convert.ToDouble(0.00);
                    O.MainCartdata.Discount = Convert.ToDouble(O.MainCartdata.Product.adminoffer) + Convert.ToDouble(O.MainCartdata.Product.vendoroffer) + Convert.ToDouble(0.00);
                    O.MainCartdata.Discount = (O.MainCartdata.ProductSubtotal * O.MainCartdata.Discount / 100);
                    O.MainCartdata.Shipping = Convert.ToDouble(O.MainCartdata.ShippingCost);
                    O.MainCartdata.OrderTotal = O.MainCartdata.ProductSubtotal + O.MainCartdata.Shipping - O.MainCartdata.Discount + Convert.ToDouble(0.00);
                    O.CancleImage = v1.cancelImage;
                    O.CancleMsg = v1.cancelMsg;
                    O.CustomizeImage = v1.customizationImage;
                    O.Customizemsg = v1.customizationmsg;

                }
                O.OrderID = v1.ProductOrderID;
                if (type == 1)
                {
                    Msg = "All Order";
                    ORDERBANDAL.Add(O);
                }
                else if (type == 2 && v1.pickanddeliverStatus <= 5 && v1.pickanddeliverStatus >= -1)
                {
                    ORDERBANDAL.Add(O);
                    Msg = "Pending Order";
                }
                else if (type == 3 && v1.pickanddeliverStatus > 5)
                {
                    Msg = "Complete Order";
                    ORDERBANDAL.Add(O);
                }
                else if (type == 4 && (v1.pickanddeliverStatus == -2 || v1.pickanddeliverStatus == -3 || v1.pickanddeliverStatus == -4))
                {
                    ORDERBANDAL.Add(O);
                    Msg = "Cancel Order";
                }

            }


            response = Responsedata(true, Msg, ORDERBANDAL);
            return new JsonResult { Data = response };
        }



        [AllowJsonGet]
        public JsonResult OrdersShowMain()
        {
            String Msg = "";
            Object response = 0;
            List<ReverseCart> ReverseORDERD = new List<ReverseCart>();
            ReverseCart RO = new ReverseCart();


            List<OrderBandal> ORDERBANDAL = new List<OrderBandal>();

            Int32 type = Convert.ToInt32(Request["type"]);
            Int32 uid = Convert.ToInt32(Request["user"]);
            List<ProductBundle> v=new List<ProductBundle>();
            if (uid == 0 && type==1)
            {
                v = db.ProductBundle.Where(x=>x.OrderSummary != null).ToList();
            }
            else if(uid > 0) {
                if (type == -6)
                {
                    v = db.ProductBundle.Where(x => x.VendorID == uid).ToList();
                }
                if (type == -3)
                {
                    v = db.ProductBundle.Where(x => x.VendorID == uid &&  x.pickanddeliverStatus == -3).ToList();
                }
                if (type == -4)
                {
                    v = db.ProductBundle.Where(x => x.VendorID == uid &&  x.pickanddeliverStatus == -4).ToList();
                }
                if (type == -1)
                {
                    v = db.ProductBundle.Where(x => x.VendorID == uid &&  x.pickanddeliverStatus == -1).ToList();
                }
                if (type == 1)
                {
                    v = db.ProductBundle.Where(x => x.VendorID == uid && x.pickanddeliverStatus >=0 && x.pickanddeliverStatus <= 5).ToList();
                }
                if (type == -2)
                {
                    v = db.ProductBundle.Where(x => x.VendorID == uid &&  x.pickanddeliverStatus == -2).ToList();
                }
                if (type == 6)
                {
                    v = db.ProductBundle.Where(x => x.VendorID == uid &&  x.pickanddeliverStatus>=6).ToList();
                }
                
            }
            foreach (ProductBundle v1 in v)
            {

                OrderBandal O = new OrderBandal();
                switch (v1.pickanddeliverStatus)
                {
                    case 0:
                        O.OrderStatusMsg = " Pending";
                        break;
                    case 1:
                        O.OrderStatusMsg = " shipment information received";
                        break;
                    case 2:
                        O.OrderStatusMsg = " Picked up from Store ";
                        break;
                    case 3:
                        O.OrderStatusMsg = " Departed";
                        break;
                    case 4:
                        O.OrderStatusMsg = " On the Way.";
                        break;
                    case 5:
                        O.OrderStatusMsg = " it may delay.";
                        break;
                    case 6:
                    case 7:
                        O.OrderStatusMsg = " Delivered.";
                        break;
                    case -2:
                        O.OrderStatusMsg = " Cancel.";
                        break;
                    case -1:
                        O.OrderStatusMsg = " Pending Approved.";
                        break;
                    case -3:
                        O.OrderStatusMsg = " not picked up.";
                        break;
                    case -4:
                        O.OrderStatusMsg = " return.";
                        break;
                }

                if (!String.IsNullOrEmpty(v1.OrderSummary))
                {
                    O.MainCartdata = JsonConvert.DeserializeObject<CartData>(v1.OrderSummary);
                    O.MainCartdata.OrderStatus = O.OrderStatusMsg;
                    O.MainCartdata.pickanddeliverStatus = v1.pickanddeliverStatus;
                    O.MainCartdata.OrderCreatedDate = v1.CreatedDate.ToString();
                    O.MainCartdata.ProductSubtotal = (Convert.ToDouble(O.MainCartdata.Product.ActualAmount) * O.MainCartdata.ProductPurchaseQun) + Convert.ToDouble(0.00);
                    O.MainCartdata.Discount = Convert.ToDouble(O.MainCartdata.Product.adminoffer) + Convert.ToDouble(O.MainCartdata.Product.vendoroffer) + Convert.ToDouble(0.00);
                    O.MainCartdata.Discount = (O.MainCartdata.ProductSubtotal * O.MainCartdata.Discount / 100);
                    O.MainCartdata.Shipping = Convert.ToDouble(O.MainCartdata.ShippingCost);
                    O.MainCartdata.OrderTotal = O.MainCartdata.ProductSubtotal + O.MainCartdata.Shipping - O.MainCartdata.Discount + Convert.ToDouble(0.00);
                    O.CancleImage = v1.cancelImage;
                    O.CancleMsg = v1.cancelMsg;
                    O.CustomizeImage = v1.customizationImage;
                    O.Customizemsg = v1.customizationmsg;

                }
                O.OrderID = v1.ProductOrderID;
                
                    Msg = "All Order";
                    ORDERBANDAL.Add(O);
            }


            response = Responsedata(true, Msg, ORDERBANDAL);
            return new JsonResult { Data = response };
        }

        [AllowJsonGet]
        public JsonResult AllVendor()
        {
            String Msg = "Vendor List";
            Object response = 0;
            var vendor=db.user.Where(h => h.usertype == 2).ToList();
            List<user> USER = new List<user>();
            foreach (user v in vendor)
            {
               if(db.ProductBundle.Where(h=>h.VendorID==v.id).ToList().Count()>0)
                { 
                user u = new user();
                u.id = v.id;
                u.fname = v.fname;
                u.lname = v.lname+" ("+ db.ProductBundle.Where(h => h.VendorID == v.id).ToList().Count().ToString() + ")";
                USER.Add(u);
            }
            }


            response = Responsedata(true, Msg, USER.ToList());
            return new JsonResult { Data = response };
        }



        [AllowJsonGet]
        public JsonResult languageload()
        {
            List<Language> l = db.Language.ToList();
            //List<String[]> s = new List<string[]>();
            //Language[] myArray = l.ToArray(); 
            //foreach (var item in myArray)
            //{
            //    String[] ns = new String[] { item.en , item.ar };
            //    s.Add(ns);
            //}
               // foreach ( l )
            String json = JsonConvert.SerializeObject(l); 
            return new JsonResult { Data = json };
        }

        public String LanguageChange(String text, int ID)
        {
            String lang;
            lang = "ar";
            
            Language data;
            if (ID > 0)
            {
                data = db.Language.Where(h => h.en.Contains(text.Trim()) && h.Keys.Contains(ID.ToString())).FirstOrDefault();
            }
            else
            {
                data = db.Language.Where(h => h.en.Contains(text)).FirstOrDefault();

            }

            if (data != null)
            {
                if (lang == "en")
                {
                    text = data.en;
                }
                else
                {
                    text = data.ar;
                }
            }
            return text;
        }
        /*-------------------Comon Response Data--------------*/
        private Object Responsedata(bool flag = false, String msg = "No Data Found", Object rts = null)
        {
            List<Response> APIRES = new List<Response>();
            Response r = new Response();

            r.flag = flag;
            r.message = msg;
            r.result = rts;
            APIRES.Add(r);
            return APIRES.FirstOrDefault();
        }
        /*-------------------Comon Response Data--------------*/

    }
}