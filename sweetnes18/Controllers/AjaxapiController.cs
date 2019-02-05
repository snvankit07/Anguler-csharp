using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using sweetnes18.AhelperClass;
using sweetnes18.Models; 
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data; 
using System.Text; 
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Web;

namespace sweetnes18.Controllers
{
    //JsonResultModel class

    public class ProductMetanew
    {
        
        public int ID { get; set; }
        public int ProductID { get; set; }
        public String ProductTypeKey { get; set; }
        public String ProductKey { get; set; }
        public String ProductValue { get; set; }
        public String Createddate { get; set; }
        public String UpdateDate { get; set; }
    }

    public class JsonResultModel
    {
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public string Results { get; set; }
    }
    // HTTP_PUT Function

    /*----------------Support Class Start-------------------*/
    public class MobileList
    {
        public String Name { get; set; }
        public String MobileNumber { get; set; }
    }
    public class getproducts {
        public int Product_id { get; set; }
        public int Qun { get; set; }
    }
    public class ProductBundledata {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public CartData OrderSummary { get; set; }
        public Double ProductPricing { get; set; }
        public String ProductOrderID { get; set; }
        public int ShippingCompanyID { get; set; }
        public int VendorID { get; set; }
        public int OrderID { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime updatedate { get; }
        public int payable { get; set; }
        public int pickanddeliverStatus { get; set; }
        public int cancelby { get; set; }
        public String cancelMsg { get; set; }
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
        public String CustomizedMsg { get; set; }
        public int PreperationTime { get; set; }
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
        public String OrderCreatedDate{ get; set; }
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

        public String qunmsg { get; set; }
        public String pricemsg { get; set; }
        public String productsubtotalmsg { get; set; }
        public String offermsg { get; set; }
        public String Shippingnmsg { get; set; }
        public String itemnmsg { get; set; }
        public String totalmsg { get; set; }
        public String viewcartmsg { get; set; }

    }
    public class Slider
        {
            public String links { get; set; }
            public String Images { get; set; }
        }
    public class OrderDetails {
        public Products productdetail { get; set; }
        public user vendor { get; set; }
        public int Product_id{ get; set; }
        public int Quantity { get; set; }
        public int Offerprice { get; set; }
        public Double price { get; set; }
        public String couponcode { get; set; }
        public String OfferType { get; set; }

    }
    public class CartProductdata
    {
        public int ProductID { get; set; }
        public String ProductTitle { get; set; }
        public String ProductDec { get; set; }
        public String ProductSalePrice { get; set; }
        public String ProductRegulerPrice { get; set; }
        public int ProductQun { get; set; }
        public String SKU { get; set; }
        public String productimage { get; set; }
        public String productimg { get; set; }
        public int CatID { get; set; }
        public int UserID { get; set; }
        public int BrandID { get; set; }
        public int productStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public String VendorName { get; set; }
        public DateTime UpdateDate { get; set; }
        public int NumberofVisit { get; set; }
        public Double PurchasePrice { get; set; }
        public Double PurchaseQun { get; set; }
        public Double TotalCost { get; set; }
        public Boolean flag { get; set; }
        public String flagmsg { get; set; }
    }
    public class shippingSaved {
        public Int32 CustomerID { get; set; }
        public Int32 UserID { get; set; }
        public user userdetails { get; set; }
    }
    public class Coupon
    {
        public String Couponkey { get; set; }
        public String CouponMessage { get; set; }
        public int COuponType  { get; set; }
    }
    public class payment {
        public Double totalqun { get; set; }
        public Double TotalPrice { get; set; }
        
    }
    public class WholeCartData
    {
        public IEnumerable<CartProductdata> cartData { get; set; }
        public payment Payment { get; set; }
        public Coupon CouponsData { get; set; }
    }
    public class ShippingCompanys
    {
        public int ID { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public IEnumerable<CompanyRate> Rates { get; set; }
        
    }
    public class apiresponse {
            public Boolean flag { get; set; }
            public String message { get; set; }
            public Object result { get; set; }
        }
    public class Productsdata {
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
            public String VendorName { get; set; }
            public int BrandID { get; set; }
            public int productStatus { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdateDate { get; set; }
            public int NumberofVisit { get; set; }
            public Boolean iswishlist { get; set; }
            public int adminoffer { get; set; }
            public int vendoroffer { get; set; }
            public String ActualAmount { get; set; }
            public int IsCustomized { get; set; }
            public int PreperationTime { get; set; }

    }
    public class ProductDetails {
            public Productsdata products { get; set; }
            
            public IEnumerable<ReviewsShow> Review { get; set; }
            public IEnumerable<Productsdata> Rrecentproduct { get; set; }
            public IEnumerable<Productsdata> mostpopuler { get; set; }
            public IEnumerable<ProductMetanew> Slider { get; set; }
            public IEnumerable<ProductMeta> specifications { get; set; }
            public IEnumerable<ProductMeta> AdditionalInformation { get; set; }

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
    /*----------------Support Class End-------------------*/
    public class AjaxapiController : Controller
    {
        private Mobilemsg MOBILE = new Mobilemsg();
        private conn db = new conn();
        private Payment pay = new Payment();
        private Common cfn = new Common();

        private DatabaseConnection abcd = new DatabaseConnection();
        public JsonResult UpdateProductDatas()
        {
            var u = db.user.Where(h => h.usertype == 2).ToList();
            foreach (user x in u)
            {
                if (x.City == "0" || x.City == null)
                {
                    var pp = db.Products.Where(h => h.UserID == x.id).ToList();
                    foreach (Products xx in pp)
                    {
                        abcd.Select("update [dbo].[Products] set [productStatus]='0' where [ProductID]='" + xx.ProductID + "'");
                    }
                }
                else
                {
                    var pp = db.Products.Where(h => h.UserID == x.id).ToList();
                    foreach (Products xx in pp)
                    {                 
                        if (x.status == 1)
                        {
                            if (xx.productStatus != -2)
                            {
                                if (xx.ProductQun > 0)
                                {
                                    Decimal Price = 0;
                                    if (String.IsNullOrEmpty(xx.ProductRegulerPrice))
                                    {
                                        Price = 0;
                                    }
                                    else
                                    {
                                        Price = Convert.ToDecimal(xx.ProductRegulerPrice);
                                    }

                                    if (Price > 0)
                                    {
                                        abcd.Select("update [dbo].[Products] set [productStatus]='1' where [ProductID]='" + xx.ProductID + "'");
                                        var v3 = db.Usersmeta.Where(h => h.userid == xx.UserID && h.metakey.Trim() == "add".ToString().Trim()).FirstOrDefault();
                                        if (String.IsNullOrEmpty(v3.metavalue) || String.IsNullOrWhiteSpace(v3.metavalue))
                                        {
                                            abcd.Select("update [dbo].[Products] set [productStatus]='0' where [ProductID]='" + xx.ProductID + "'");
                                        }
                                    }
                                    else
                                    {
                                        abcd.Select("update [dbo].[Products] set [productStatus]='0' where [ProductID]='" + xx.ProductID + "'");
                                    }
                                }
                                else
                                {
                                    abcd.Select("update [dbo].[Products] set [productStatus]='0' where [ProductID]='" + xx.ProductID + "'");
                                   
                                }
                            }
                        }
                        else
                        {
                            abcd.Select("update [dbo].[Products] set [productStatus]='0' where [ProductID]='" + xx.ProductID + "'");
                        }

                        
                    }
                }
            }
            var p = db.Products.ToList();
            foreach (Products x in p)
            {
                String Sprice = "0";
                String Rprice = "0";
                Int32 Offer = 0;
                Rprice = (x.ProductRegulerPrice);
                if (x.adminoffer > 0 || x.vendoroffer > 0)
                {
                    if (x.vendoroffer > 0)
                    {
                        Offer = Offer + x.vendoroffer;
                    }
                    if (x.adminoffer > 0)
                    {
                        Offer = Offer + x.adminoffer;
                    }
                    Sprice = Math.Round(Convert.ToDouble(x.ActualAmount), 2).ToString();
                    Rprice = Math.Round((Convert.ToDouble(x.ActualAmount) - ((Convert.ToDouble(x.ActualAmount) * Offer) / 100)), 2).ToString();
                }
                else
                {
                    Sprice = "0";
                    Rprice = Math.Round(Convert.ToDouble(x.ActualAmount), 2).ToString(); ;
                }
                abcd.Select("update [dbo].[Products] set [ProductRegulerPrice]='" + Rprice + "',[ProductSalePrice]='" + Sprice + "' where [ProductID]='" + x.ProductID + "'");
            }
            return new JsonResult { Data = "update" };
        }

        /*--------------------SUPPORT---------------*/
        [AllowJsonGet]
        public JsonResult support()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            String fname    =   Request["Fname"];
            String email    =   Request["email"];
            String subject  =   Request["Sub"];
            String Msg      =   Request["Mes"];

            IDictionary<string, string> keys3 = new Dictionary<string, string>() {
                                                    { "%#NAME#%", fname},
                                                    { "%#EMAIL#%", email},
                                                    { "%#SUB#%", subject},
                                                    { "%#MSG#%", Msg}
                                                };
            
            Format a22 = new Format(17, keys3, "hr@snvinfotech.com");
            Format a23 = new Format(17, keys3, "vaibhaw@snvinfotech.com");
            



           m.flag = true;
            m.message = this.LanguageChange("Message Sent");

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*--------------------SUPPORT---------------*/




        [AllowJsonGet]
        public JsonResult timezone()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = DateTime.UtcNow;
            DateTime zone = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);
            TimeSpan start = new TimeSpan(16, 0, 0); //10 o'clock
            
            Int64 now = zone.Ticks;
            
            m.result = "" + now;
           
            m.flag = true;
            m.message = this.LanguageChange("Please Enter Valid Product ID");
            
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------Mobile Number List---------*/
        [AllowJsonGet]
        public JsonResult MobileListdata()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            List<MobileList> ML = new List<MobileList>();
            var u = db.user.Where(h => h.usertype == 1).ToList();
            foreach (user i in u)
            {
                var Count= ML.Where(h => h.MobileNumber == i.mobileno).ToList().Count();
                if (Count == 0) { 
                MobileList ml = new MobileList();
                    ml.Name = i.fname + " " + i.lname;
                    ml.MobileNumber = i.mobileno;
                    ML.Add(ml);
                }
            }
            var a = db.ShippingAddress.ToList();
            foreach (ShippingAddress i in a)
            {
                var Count = ML.Where(h => h.MobileNumber == i.Mobile).ToList().Count();
                if (Count == 0)
                {
                    MobileList ml = new MobileList();
                    ml.Name = i.Fname + " " + i.Lname;
                    ml.MobileNumber = i.Mobile;
                    //ML.Add(ml);
                }
            }

            m.flag = true;
            m.message = this.LanguageChange("Mobile Number List");
            m.result = ML.ToList();

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------Mobile Number List---------*/
        [AllowJsonGet]
        public JsonResult UpdateProductImage()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            List<ProductMeta> pmeta = new List<ProductMeta>();
            ProductMeta pm = new ProductMeta();


            var p = db.Products.Where(h => h.productStatus == 1).ToList();

            foreach (Products i in p)
            {
                var Q = "insert into ProductMeta (ProductID,ProductKey,ProductTypeKey,ProductValue) Values('" + i.ProductID + "','gallery','Images','" + i.productimg + "')";
                abcd.Select(Q);
            }

            m.flag = false;
            m.message = this.LanguageChange("Please Enter Valid Product ID");
            m.result = "";

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------Start ProductDetails For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult ProductDetails()
        {
            String MainIMg;
            var p1 = db.Products.ToList();
            foreach (Products x in p1)
            {
                String Rprice = "0";
                Rprice = (x.ProductRegulerPrice);
               // abcd.Select("update Products set [ActualAmount]='" + Rprice + "' where [ProductID]='" + x.ProductID + "'");
            }

            var p = db.Products.Where(h => h.ProductSalePrice == "0").ToList();
            foreach (Products x in p)
            {
                String Sprice = "0";
                String Rprice = "0";
                Int32 Offer = 0;

                Rprice = (x.ProductRegulerPrice);
                //abcd.Select("update Products set [ActualAmount]='" + Rprice + "' where [ProductID]='" + x.ProductID + "'");

                if (x.adminoffer > 0 || x.vendoroffer > 0)
                {
                    if (x.vendoroffer > 0)
                    {
                        Offer = Offer + x.vendoroffer;

                    }
                    if (x.adminoffer > 0)
                    {
                        Offer = Offer + x.adminoffer;
                    }
                    Sprice = x.ActualAmount;
                    Rprice = (Convert.ToInt32(x.ActualAmount) - ((Convert.ToInt32(x.ActualAmount) * Offer) / 100)).ToString();
                }
                else
                {
                    Sprice = "0";
                    Rprice = x.ActualAmount;
                }

                abcd.Select("update Products set [ProductRegulerPrice]='" + Rprice + "',[ProductSalePrice]='" + Sprice + "' where [ProductID]='" + x.ProductID + "'");
            }

            

            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            


            //List<ProductDetails> PRODUCTDETAIL = new List<ProductDetails>();
            ProductDetails prod = new ProductDetails();

            if (Request["ProductID"] != null)
            {
                Int32 PID = Convert.ToInt32(Request["ProductID"]);


                Int32 UID = 0;
                UID = Convert.ToInt32(Request["user"]);
                /*----------------ProDuct Details----------------*/
                List<Productsdata> PRODUCT = new List<Productsdata>();
                var vv = db.ProductWishlist.Where(h => h.UserID == UID).ToList();
                var pp = db.Products.Where(x => x.ProductID == PID && x.productStatus == 1).FirstOrDefault();

                Productsdata obj = new Productsdata();
                obj.ProductID = pp.ProductID;
                obj.ProductTitle = this.LanguageChangeP(pp.ProductTitle, PID);
                obj.ProductDec = this.LanguageChangeP(pp.ProductDec, PID);
                obj.ProductSalePrice = pp.ProductSalePrice;
                obj.ProductRegulerPrice = pp.ProductRegulerPrice;
                obj.ProductQun = pp.ProductQun;
                MainIMg=obj.productimage = pp.productimage;
                obj.productimg = pp.productimg;

                obj.SKU = pp.SKU;
                obj.CatID = pp.CatID;
                obj.UserID = pp.UserID;
                obj.BrandID = pp.BrandID;
                obj.productStatus = pp.productStatus;
                obj.CreatedDate = pp.CreatedDate;
                obj.UpdateDate = pp.UpdateDate;
                obj.NumberofVisit = pp.NumberofVisit;
                obj.IsCustomized = pp.IsCustomized;
                obj.PreperationTime = pp.PreperationTime;
                obj.adminoffer = pp.adminoffer;
                obj.vendoroffer = pp.vendoroffer;
                obj.ActualAmount = pp.ActualAmount;
                Int32 k = 0;
                foreach (ProductWishlist j in vv)
                {
                    if (j.ProductID == obj.ProductID)
                    {
                        k++;
                    }
                }
                if (k > 0)
                {
                    obj.iswishlist = true;
                }
                else
                {
                    obj.iswishlist = false;
                }
                PRODUCT.Add(obj);
                prod.products = PRODUCT.FirstOrDefault();
                /*----------------END ProDuct Details----------------*/


                //prod.products= db.Products.Where(x => x.ProductID == PID && x.productStatus == 1).FirstOrDefault();
                /*----------------ProDuct Rrecentproduct----------------*/
                List<Productsdata> PRODUCT1 = new List<Productsdata>();
                var vv1 = db.Products.Where(x => x.productStatus == 1 && x.ProductID != PID).Take(6);
                foreach (Products pp1 in vv1)
                {
                    Productsdata obj1 = new Productsdata();
                    obj1.ProductID = pp1.ProductID;
                    obj1.ProductTitle = this.LanguageChangeP(pp1.ProductTitle,PID);
                    obj1.ProductDec = this.LanguageChangeP(pp1.ProductDec,PID);
                    obj1.ProductSalePrice = pp1.ProductSalePrice;
                    obj1.ProductRegulerPrice = pp1.ProductRegulerPrice;
                    obj1.ProductQun = pp1.ProductQun;
                    obj1.productimage = pp1.productimage;
                    obj1.productimg = pp1.productimg;
                    obj1.SKU = pp1.SKU;
                    obj1.CatID = pp1.CatID;
                    obj1.UserID = pp1.UserID;
                    obj1.BrandID = pp1.BrandID;
                    obj1.productStatus = pp1.productStatus;
                    obj1.CreatedDate = pp1.CreatedDate;
                    obj1.UpdateDate = pp1.UpdateDate;
                    obj1.NumberofVisit = pp1.NumberofVisit;
                    Int32 l = 0;
                    foreach (ProductWishlist j in vv)
                    {
                        if (j.ProductID == obj1.ProductID)
                        {
                            l++;
                        }
                    }
                    if (l > 0)
                    {
                        obj1.iswishlist = true;
                    }
                    else
                    {
                        obj1.iswishlist = false;
                    }
                    PRODUCT1.Add(obj1);

                }
                prod.Rrecentproduct = PRODUCT1.ToList();
                /*----------------ProDuct Rrecentproduct----------------*/
                List<ReviewsShow> REVIEWS = new List<ReviewsShow>();
                var Reviews1 = db.ProductReview.Where(x => x.ProductID == PID).Take(6);
                foreach (ProductReview rr in Reviews1)
                {
                    ReviewsShow re = new ReviewsShow();

                    re.CustomerID = rr.CustomerID;
                    re.CustomerName = this.LanguageChange(db.CustomerProfiles.Where(h=>h.CustomerID== rr.CustomerID).FirstOrDefault().CustomerFullName);
                    re.ProductID = rr.ProductID;
                    re.ReviewID = rr.ReviewID;
                    re.Reviewmsg = this.LanguageChange(rr.Reviewmsg);
                    re.StarRating = rr.StarRating;
                    REVIEWS.Add(re);

                }


                prod.Review = REVIEWS.ToList();



                //prod.Review = db.ProductReview.Where(x => x.ProductID == PID).Take(6);

                /*----------------ProDuct Populer----------------*/
                List<Productsdata> PRODUCT2 = new List<Productsdata>();
                var vv2 = db.Products.Where(x => x.productStatus == 1 && x.ProductID != PID).Take(6);
                foreach (Products pp2 in vv2)
                {
                    Productsdata obj2 = new Productsdata();
                    obj2.ProductID = pp2.ProductID;
                    obj2.ProductTitle = this.LanguageChangeP(pp2.ProductTitle,PID);
                    obj2.ProductDec = this.LanguageChangeP(pp2.ProductDec,PID);
                    obj2.ProductSalePrice = pp2.ProductSalePrice;
                    obj2.ProductRegulerPrice = pp2.ProductRegulerPrice;
                    obj2.ProductQun = pp2.ProductQun;
                    obj2.productimage = pp2.productimage;
                    obj2.productimg = pp2.productimg;
                    obj2.SKU = pp2.SKU;
                    obj2.CatID = pp2.CatID;
                    obj2.UserID = pp2.UserID;
                    obj2.BrandID = pp2.BrandID;
                    obj2.productStatus = pp2.productStatus;
                    obj2.CreatedDate = pp2.CreatedDate;
                    obj2.UpdateDate = pp2.UpdateDate;
                    obj2.NumberofVisit = pp2.NumberofVisit;
                    Int32 n = 0;
                    foreach (ProductWishlist j in vv)
                    {
                        if (j.ProductID == obj2.ProductID)
                        {
                            n++;
                        }
                    }
                    if (n > 0)
                    {
                        obj2.iswishlist = true;
                    }
                    else
                    {
                        obj2.iswishlist = false;
                    }
                    PRODUCT2.Add(obj2);

                }
                prod.mostpopuler = PRODUCT2.ToList();
                /*----------------Product Populer----------------*/
                List<ProductMetanew> PRODMETA = new List<ProductMetanew>();
                
                var Slider = db.ProductMeta.Where(x => x.ProductID == PID && (x.ProductKey.Contains("gallery") || x.ProductKey.Contains("Images"))).ToList();
                int PRODID = 0;
                ProductMetanew PP1 = new ProductMetanew();
                PP1.ProductID = PRODID;
                PP1.ProductValue = MainIMg;
                PRODMETA.Add(PP1);
                foreach (ProductMeta s in Slider)
                {
                    if (s.ProductValue.Trim().Length > 0 && s.ProductValue!= "/img/Product/imgs.jpg") { 
                    ProductMetanew PP = new ProductMetanew();
                    PP.ID = s.ID;
                    PRODID=PP.ProductID = s.ProductID;
                    PP.ProductKey = s.ProductKey;
                    PP.ProductTypeKey = s.ProductTypeKey;
                    PP.ProductValue = s.ProductValue;
                    PRODMETA.Add(PP);
                    }
                }
                
                prod.Slider = PRODMETA.ToList();
                var SPEC = db.ProductMeta.Where(x => x.ProductID == PID && x.ProductTypeKey.Contains("specifications")).Take(6);
                List<ProductMeta> SPECF = new List<ProductMeta>();
                foreach (ProductMeta Sm in SPEC)
                {
                    ProductMeta SP = new ProductMeta();
                    SP.ID = Sm.ID;
                    SP.ProductID = Sm.ProductID;
                    SP.ProductKey = this.LanguageChangeP(Sm.ProductKey,PID);
                    SP.ProductValue = this.LanguageChangeP(Sm.ProductValue,PID);
                    SPECF.Add(SP);

                }
                prod.specifications = SPECF.ToList();





                var ADDI = db.ProductMeta.Where(x => x.ProductID == PID && x.ProductTypeKey.Contains("AdditionalInformation")).Take(6);
                List<ProductMeta> ADDIF = new List<ProductMeta>();
                foreach (ProductMeta Sm in ADDI)
                {
                    ProductMeta SP = new ProductMeta();
                    SP.ID = Sm.ID;
                    SP.ProductID = Sm.ProductID;
                    SP.ProductKey = this.LanguageChangeP(Sm.ProductKey, PID);
                    SP.ProductValue = this.LanguageChangeP(Sm.ProductValue, PID);
                    ADDIF.Add(SP);

                }
                prod.AdditionalInformation = ADDIF.ToList();

                m.flag = true;
                m.message = this.LanguageChange("Product Details");
                m.result = prod;

            }
            else
            {
                m.flag = false;
                m.message = this.LanguageChange("Please Enter Valid Product ID");
                m.result = "";
            }
            APIRES.Add(m);
            var json = APIRES.FirstOrDefault();

            return new JsonResult { Data = APIRES.FirstOrDefault() };


        }
        /*-------------------------End ProductDetails For Mobile-----------------------------*/
        /*-------------------------Start Login For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult Login()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            string u = Request["username"];
            string p = Request["password"];

            string token = Request["token"].ToString();
            string device = Request["device"].ToString();
            u=cfn.mobliefilter(u);
            var user = (db.user.Where(x => (x.username == u || x.mobileno == u) && x.password == p && x.status == 1 && x.usertype==1).FirstOrDefault());
            if (user != null)
            {


                DatabaseConnection abcd = new DatabaseConnection();
                string Q = "UPDATE [dbo].[user] SET [mobiletoken] = '" + token + "',devicetype='" + device + "' Where  (username='" + u + "' or mobileno = '" + u + "')";
                DataSet dsc = abcd.Select(Q);


                m.flag = true;
                m.message = this.LanguageChange("Login Successful");
                m.result = user;
            }
            else
            {
                var V = (db.user.Where(x => (x.username == u || x.mobileno == u)).FirstOrDefault());
                if (V == null)
                {
                    m.flag = false;
                    m.message = this.LanguageChange("Entered Email id/Phone number is not registered");
                    m.result = "";
                }
                else {
                   
                    if (V.usertype == 2)
                    {
                        m.flag = false;
                        m.message = this.LanguageChange("Entered Email id/Phone number is registered for Vendor");
                        m.result = "";
                       
                    }
                    else { 
                        m.flag = false;
                        m.message = this.LanguageChange("User id or Password is wrong");
                        m.result = "";
                    }
                }

                
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------End Login For Mobile-----------------------------*/
        /*-------------------------Start Register For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult Register()
        {
            string fname = Request["fname"].ToString();
            string pass = Request["password"].ToString();
            string mobile = cfn.mobliefilter(Request["mobileno"].ToString());
            Int32 status = Convert.ToInt32(1);
            Int32 utype = Convert.ToInt32(1);
            string email = Request["email"].ToString();
            string token = Request["token"].ToString();
            string device = Request["device"].ToString();


            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            var exist2 = db.user.Where(x => x.username == email && x.mobileno == mobile).FirstOrDefault();
            if (exist2 == null)
            {
                var exist = db.user.Where(x => x.mobileno == mobile).FirstOrDefault();
                if (exist == null)
                {
                    var exist1 = db.user.Where(x => x.username == email).FirstOrDefault();
                    if (exist1 == null)
                    {

                        List<user> slide = new List<user>();
                        user a = new user();

                        a.fname = fname;
                        a.password = pass;
                        a.mobileno = mobile;
                        a.status = status;
                        a.usertype = utype;
                        a.username = email;
                        a.mobiletoken = token;
                        a.devicetype = device;
                        db.user.Add(a);
                        db.SaveChanges();
                        var register = (db.user.Where(x => x.mobileno == mobile && x.username == email).FirstOrDefault());
                        cfn.RegisterShippingStatus(register.id);
                        m.flag = true;
                        m.message = this.LanguageChange("Register successful");
                        m.result = register;
                        APIRES.Add(m);
                    }
                    else
                    {

                        m.flag = false;
                        m.message = this.LanguageChange("Email Id already used");
                        m.result = "";
                        APIRES.Add(m);
                    }
                }
                else
                {
                    var count = db.user.Where(x => x.mobileno == mobile && x.usertype == 2).ToList().Count();

                    if (count > 0)
                    {
                        m.flag = false;
                        m.message = this.LanguageChange("This Number Already used in vendor");
                        m.result = "";
                        APIRES.Add(m);
                    }
                    else
                    {

                        m.flag = false;
                        m.message = this.LanguageChange("Mobile number already used");
                        m.result = "";
                        APIRES.Add(m);
                    }

                    
                }
            }
            else
            {

                m.flag = false;
                m.message = this.LanguageChange("Mobile Number/Email Already Used");
                m.result = "";
                APIRES.Add(m);
            }
            //APIRES.ToList();
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------End Register For Mobile-----------------------------*/
        /*-------------------------Start Today Sweet For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult TodaySweet()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            Int32 count = 6;
            Int32 UID = 0;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            UID = Convert.ToInt32(Request["user"]);
            var vv = db.ProductWishlist.Where(h => h.UserID == UID).ToList();
            var TOdaysweet = db.Products.Where(d => d.productStatus == 1 && d.ProductQun > 0).Take(count);

            List<Productsdata> PRODUCT2 = new List<Productsdata>();
            foreach (Products pp2 in TOdaysweet)
            {
                Productsdata obj2 = new Productsdata();
                obj2.ProductID = pp2.ProductID;
                obj2.ProductTitle = this.LanguageChange(pp2.ProductTitle);
                obj2.ProductDec = this.LanguageChange(pp2.ProductDec);
                obj2.ProductSalePrice = pp2.ProductSalePrice;
                obj2.ProductRegulerPrice = pp2.ProductRegulerPrice;
                obj2.ProductQun = pp2.ProductQun;
                obj2.productimage = pp2.productimage;
                obj2.productimg = pp2.productimg;
                obj2.SKU = pp2.SKU;
                obj2.CatID = pp2.CatID;
                obj2.UserID = pp2.UserID;
                obj2.BrandID = pp2.BrandID;
                obj2.productStatus = pp2.productStatus;
                obj2.CreatedDate = pp2.CreatedDate;
                obj2.UpdateDate = pp2.UpdateDate;
                obj2.NumberofVisit = pp2.NumberofVisit;
                Int32 n = 0;
                foreach (ProductWishlist j in vv)
                {
                    if (j.ProductID == obj2.ProductID)
                    {
                        n++;
                    }
                }
                if (n > 0)
                {
                    obj2.iswishlist = true;
                }
                else
                {
                    obj2.iswishlist = false;
                }
                PRODUCT2.Add(obj2);

            }

            m.flag = true;
            m.message = this.LanguageChange("Today Sweet Product");
            m.result = PRODUCT2.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };


        }
        /*-------------------------End Sweet For Mobile-----------------------------*/
        /*-------------------------Start RecentProduct For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult RecentProduct()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();



            Int32 count = 6;
            Int32 UID = 0;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            UID = Convert.ToInt32(Request["user"]);
            var vv = db.ProductWishlist.Where(h => h.UserID == UID).ToList();
            var RecentProduct = db.Products.Where(x => x.productStatus == 1 && x.ProductQun > 0).OrderByDescending(x => x.ProductID).Take(count);

            List<Productsdata> PRODUCT2 = new List<Productsdata>();
            foreach (Products pp2 in RecentProduct)
            {
                Productsdata obj2 = new Productsdata();
                obj2.ProductID = pp2.ProductID;
                obj2.ProductTitle = this.LanguageChange(pp2.ProductTitle);
                obj2.ProductDec = this.LanguageChange(pp2.ProductDec);
                obj2.ProductSalePrice = pp2.ProductSalePrice;
                obj2.ProductRegulerPrice = pp2.ProductRegulerPrice;
                obj2.ProductQun = pp2.ProductQun;
                obj2.productimage = pp2.productimage;
                obj2.productimg = pp2.productimg;
                obj2.SKU = pp2.SKU;
                obj2.CatID = pp2.CatID;
                obj2.UserID = pp2.UserID;
                obj2.BrandID = pp2.BrandID;
                obj2.productStatus = pp2.productStatus;
                obj2.CreatedDate = pp2.CreatedDate;
                obj2.UpdateDate = pp2.UpdateDate;
                obj2.NumberofVisit = pp2.NumberofVisit;
                Int32 n = 0;
                foreach (ProductWishlist j in vv)
                {
                    if (j.ProductID == obj2.ProductID)
                    {
                        n++;
                    }
                }
                if (n > 0)
                {
                    obj2.iswishlist = true;
                }
                else
                {
                    obj2.iswishlist = false;
                }
                PRODUCT2.Add(obj2);

            }

            m.flag = true;
            m.message = this.LanguageChange("Recent Product Products");
            m.result = PRODUCT2.ToList();
            APIRES.Add(m);

            return new JsonResult { Data = APIRES.FirstOrDefault() };


        }
        /*-------------------------End RecentProduct For Mobile-----------------------------*/
        /*-------------------------Start Brand For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult Brand()
        {

            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            Int32 count = 6;
            
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
                var Brand = db.ProductBrand.Where(d => d.BrandStatus == 1).OrderByDescending(d => d.ID).Take(count);
                m.flag = true;
                m.message = this.LanguageChange("Product Brands");
                m.result = Brand;
            }
            else {
                var Brand = db.ProductBrand.Where(d => d.BrandStatus == 1).OrderByDescending(d => d.ID).ToList();
                m.flag = true;
                m.message = this.LanguageChange("All Product Brand");
                m.result = Brand;
            }
            

            
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------End Brand For Mobile-----------------------------*/
        /*-------------------------Start LastView For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult Lastview()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();


            Int32 count = 6;
            Int32 UID = 0;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            UID = Convert.ToInt32(Request["user"]);
            var vv = db.ProductWishlist.Where(h => h.UserID == UID).ToList();
            var LastVIew = db.Products.Where(d => d.productStatus == 1 && d.ProductQun > 0).OrderByDescending(news => news.NumberofVisit).Take(count);

            List<Productsdata> PRODUCT2 = new List<Productsdata>();
            foreach (Products pp2 in LastVIew)
            {
                Productsdata obj2 = new Productsdata();
                obj2.ProductID = pp2.ProductID;
                obj2.ProductTitle = this.LanguageChange(pp2.ProductTitle);
                obj2.ProductDec = this.LanguageChange(pp2.ProductDec);
                obj2.ProductSalePrice = pp2.ProductSalePrice;
                obj2.ProductRegulerPrice = pp2.ProductRegulerPrice;
                obj2.ProductQun = pp2.ProductQun;
                obj2.productimage = pp2.productimage;
                obj2.productimg = pp2.productimg;
                obj2.SKU = pp2.SKU;
                obj2.CatID = pp2.CatID;
                obj2.UserID = pp2.UserID;
                obj2.BrandID = pp2.BrandID;
                obj2.productStatus = pp2.productStatus;
                obj2.CreatedDate = pp2.CreatedDate;
                obj2.UpdateDate = pp2.UpdateDate;
                obj2.NumberofVisit = pp2.NumberofVisit;
                Int32 n = 0;
                foreach (ProductWishlist j in vv)
                {
                    if (j.ProductID == obj2.ProductID)
                    {
                        n++;
                    }
                }
                if (n > 0)
                {
                    obj2.iswishlist = true;
                }
                else
                {
                    obj2.iswishlist = false;
                }
                PRODUCT2.Add(obj2);

            }

            m.flag = true;
            m.message = this.LanguageChange("Last View Products");
            m.result = PRODUCT2.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------End LastView For Mobile-----------------------------*/
        /*-------------------------Start Tranding For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult TrendingSweet()
        {
            
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            
            Int32 count = 6;
            Int32 UID = 0;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            UID = Convert.ToInt32(Request["user"]);
            var vv = db.ProductWishlist.Where(h => h.UserID == UID).ToList();
            var TrendingSweet = db.Products.Where(d => d.productStatus == 1 && d.ProductQun > 0).OrderByDescending(news => news.NumberofVisit).Take(count);

            List<Productsdata> PRODUCT2 = new List<Productsdata>();
            foreach (Products pp2 in TrendingSweet)
            {
                Productsdata obj2 = new Productsdata();
                obj2.ProductID = pp2.ProductID;
                obj2.ProductTitle = this.LanguageChange(pp2.ProductTitle);
                obj2.ProductDec = this.LanguageChange(pp2.ProductDec);
                obj2.ProductSalePrice = pp2.ProductSalePrice;
                obj2.ProductRegulerPrice = pp2.ProductRegulerPrice;
                obj2.ProductQun = pp2.ProductQun;
                obj2.productimage = pp2.productimage;
                obj2.productimg = pp2.productimg;
                obj2.SKU = pp2.SKU;
                obj2.CatID = pp2.CatID;
                obj2.UserID = pp2.UserID;
                obj2.BrandID = pp2.BrandID;
                obj2.productStatus = pp2.productStatus;
                obj2.CreatedDate = pp2.CreatedDate;
                obj2.UpdateDate = pp2.UpdateDate;
                obj2.NumberofVisit = pp2.NumberofVisit;
                Int32 n = 0;
                foreach (ProductWishlist j in vv)
                {
                    if (j.ProductID == obj2.ProductID)
                    {
                        n++;
                    }
                }
                if (n > 0)
                {
                    obj2.iswishlist = true;
                }
                else
                {
                    obj2.iswishlist = false;
                }
                PRODUCT2.Add(obj2);

            }

            m.flag = true;
            m.message = this.LanguageChange("Trending Sweet Products");
            m.result = PRODUCT2.ToList();
            APIRES.Add(m);

            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------End Tranding For Mobile-----------------------------*/
        /*-------------------------Start Mostpopuler For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult Mostpopuler()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();




            Int32 count = 6;
            Int32 UID = 0;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            UID = Convert.ToInt32(Request["user"]);
            var vv = db.ProductWishlist.Where(h => h.UserID == UID).ToList();
            var Mostpopuler = db.Products.Where(d => d.productStatus == 1 && d.ProductQun > 0).OrderByDescending(news => news.NumberofVisit).Take(count);

            List<Productsdata> PRODUCT2 = new List<Productsdata>();
            foreach (Products pp2 in Mostpopuler)
            {
                Productsdata obj2 = new Productsdata();
                obj2.ProductID = pp2.ProductID;
                obj2.ProductTitle = this.LanguageChange(pp2.ProductTitle);
                obj2.ProductDec = this.LanguageChange(pp2.ProductDec);
                obj2.ProductSalePrice = pp2.ProductSalePrice;
                obj2.ProductRegulerPrice = pp2.ProductRegulerPrice;
                obj2.ProductQun = pp2.ProductQun;
                obj2.productimage = pp2.productimage;
                obj2.productimg = pp2.productimg;
                obj2.SKU = pp2.SKU;
                obj2.CatID = pp2.CatID;
                obj2.UserID = pp2.UserID;
                obj2.BrandID = pp2.BrandID;
                obj2.productStatus = pp2.productStatus;
                obj2.CreatedDate = pp2.CreatedDate;
                obj2.UpdateDate = pp2.UpdateDate;
                obj2.NumberofVisit = pp2.NumberofVisit;
                Int32 n = 0;
                foreach (ProductWishlist j in vv)
                {
                    if (j.ProductID == obj2.ProductID)
                    {
                        n++;
                    }
                }
                if (n > 0)
                {
                    obj2.iswishlist = true;
                }
                else
                {
                    obj2.iswishlist = false;
                }
                PRODUCT2.Add(obj2);

            }

            m.flag = true;
            m.message = this.LanguageChange("MostPopuler Products");
            m.result = PRODUCT2.ToList();
            APIRES.Add(m);


            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------End Mostpopuler For Mobile-----------------------------*/
        /*-------------------------Start Search And Filter For Mobile-----------------------------*/
      
        /*-------------------------Start Search And Filter For Mobile-----------------------------*/
        /*-------------------------Start Search And Filter For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult pSearchAndFilter()
        {



            String[] Category_option1; int[] Category_option = new int[0]; ;
            //List<String> Category_option = new List<string>();
            if (!String.IsNullOrWhiteSpace(Request["cat"]) && Request["cat"] !="0")
            {
                Category_option1 = HttpUtility.UrlDecode(Request["cat"]).Split(',');
                Category_option = Array.ConvertAll(Category_option1, s => int.Parse(s));
            }
            String Brand_option = Request.QueryString["Brand"];
            String pricing_min = Request.QueryString["pricing_min"];
            String pricing_max = Request.QueryString["pricing_max"];
            String option = Request.QueryString["Tranding"];
            //    [Bind(Include = "Category_option,pricing_max,pricing_min,Brand_option")]
            // FilterObject f1
            String json = String.Empty;
            IEnumerable<Products> p = db.Products;
            List<int> bid = db.ProductBrand.Where(x => x.BrandStatus == 1).Select(x => x.ID).ToList();
            List<int> cid = db.ProductCategory.Where(x => x.CategoryStatus == 1).Select(x => x.ID).ToList();




            if (!(String.IsNullOrWhiteSpace(pricing_max) && String.IsNullOrWhiteSpace(pricing_min)))
            {
                int max = Convert.ToInt32(pricing_max);
                int min = Convert.ToInt32(pricing_min);

                String query = "SELECT * from products where [productStatus] = 1 ";

                if (option == "TodaySweet")
                {
                    DateTime a = DateTime.Today.AddDays(1).AddTicks(-1);
                    DateTime b = DateTime.Today.Date;
                    query += " AND createdDate <= '" + a + "' AND createdDate >= '" + b + "'";
                }

                p = db.Database.SqlQuery<Products>(query);
            }

            // int cat = Convert.ToInt32(Category_option); 
            if (Category_option.Length > 0)
            {
                p = p.Where(x => Category_option.Contains(x.CatID));
            }

            p = p.Where(x => bid.Contains(x.BrandID));
            p = p.Where(x => cid.Contains(x.CatID));

            int brand = Convert.ToInt32(Brand_option);
            if (brand > 0)
            {
                p = p.Where(x => x.BrandID == brand);
            }

            switch (option)
            {
                case "1":
                    p = p.OrderByDescending(x => x.NumberofVisit);
                    break;
                case "Lastview":
                    p = p.OrderByDescending(x => x.UpdateDate);
                    break;
                case "NewProducts":
                    p = p.OrderByDescending(x => x.ProductID);
                    break;

            }
            p = p.Where(x => x.productStatus == 1);
            DateTime todaymax = DateTime.Today.AddDays(1).AddTicks(-1);
            DateTime todaymin = DateTime.Today;
            //.Where(x => System.Convert.ToDateTime(x.CreatedDate) <= todaymax).Where(x => System.Convert.ToDateTime(x.CreatedDate) >= todaymin)
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            m.flag = true;
            m.message = this.LanguageChange("Search And Filter");
            m.result = p.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-----------------------Filternew-----------------------*/
        [AllowJsonGet]
        public JsonResult NewSearchAndFilter()
        {

           

            String[] Category_option1; int[] Category_option = new int[0]; ;
            //List<String> Category_option = new List<string>();
            if (!String.IsNullOrWhiteSpace(Request["cat"]))
            {
                Category_option1 = HttpUtility.UrlDecode(Request["cat"]).Split(',');
                Category_option = Array.ConvertAll(Category_option1, s => int.Parse(s));
            }
            String Brand_option = Request.QueryString["Brand"];
            String pricing_min = Request.QueryString["pricing_min"];
            String pricing_max = Request.QueryString["pricing_max"];
            String option = Request.QueryString["Tranding"];
            //    [Bind(Include = "Category_option,pricing_max,pricing_min,Brand_option")]
            // FilterObject f1
            String json = String.Empty;
            IEnumerable<Products> p = db.Products;
            List<int> bid = db.ProductBrand.Where(x => x.BrandStatus == 1).Select(x => x.ID).ToList();
            List<int> cid = db.ProductCategory.Where(x => x.CategoryStatus == 1).Select(x => x.ID).ToList();




            if (!(String.IsNullOrWhiteSpace(pricing_max) && String.IsNullOrWhiteSpace(pricing_min)))
            {
                int max = Convert.ToInt32(pricing_max);
                int min = Convert.ToInt32(pricing_min);

                String query = "SELECT * from products where [productStatus] = 1 ";

                if (option == "TodaySweet")
                {
                    DateTime a = DateTime.Today.AddDays(1).AddTicks(-1);
                    DateTime b = DateTime.Today.Date;
                    query += " AND createdDate <= '" + a + "' AND createdDate >= '" + b + "'";
                }

                p = db.Database.SqlQuery<Products>(query);
            }

            // int cat = Convert.ToInt32(Category_option); 
            if (Category_option.Length > 0)
            {
                p = p.Where(x => Category_option.Contains(x.CatID));
            }

            p = p.Where(x => bid.Contains(x.BrandID));
            p = p.Where(x => cid.Contains(x.CatID));

            int brand = Convert.ToInt32(Brand_option);
            if (brand > 0)
            {
                p = p.Where(x => x.BrandID == brand);
            }

            switch (option)
            {
                case "1":
                    p = p.OrderByDescending(x => x.NumberofVisit);
                    break;
                case "Lastview":
                    p = p.OrderByDescending(x => x.UpdateDate);
                    break;
                case "NewProducts":
                    p = p.OrderByDescending(x => x.ProductID);
                    break;

            }
            p = p.Where(x => x.productStatus == 1);
            DateTime todaymax = DateTime.Today.AddDays(1).AddTicks(-1);
            DateTime todaymin = DateTime.Today;
            //.Where(x => System.Convert.ToDateTime(x.CreatedDate) <= todaymax).Where(x => System.Convert.ToDateTime(x.CreatedDate) >= todaymin)
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            m.flag = true;
            m.message = this.LanguageChange("Search And Filter");
            m.result = p.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }



        /*-------------------------Start Search And Filter For Mobile-----------------------------*/
        /*-------------------------Start Search by KeyWord For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult pSearchBykeyword()
        {
            string data = (Request["keyword"]);
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 count = 50000;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            var TrendingSweet = db.Products.Where(d => d.productStatus == 1 && d.ProductTitle.Contains(data) && d.ProductQun > 0).Take(count);
            m.flag = true;
            m.message = this.LanguageChange("Most populer Products");
            m.result = TrendingSweet;
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*-------------------------End Search by KeyWord For Mobile-----------------------------*/
        [AllowJsonGet]
        public JsonResult pSearchBySKU()
        {
            string data = (Request["sku"]);
            Int32 count = 50000;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            var TrendingSweet = db.Products.Where(d => d.productStatus == 1 && d.SKU == (data) && d.ProductQun > 0).Take(count);
            return new JsonResult { Data = new { Message = this.LanguageChange("Product SKU"), result = TrendingSweet, Status = "true" } };
        }
        [AllowJsonGet]
        public JsonResult bycatproduct()
        {
            int CatID = Convert.ToInt32(Request["CatID"]);
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 count = 6;
            Int32 UID = 0;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
            }
            UID = Convert.ToInt32(Request["user"]);
            var vv = db.ProductWishlist.Where(h => h.UserID == UID).ToList();
            var Catpro = db.Products.Where(d => d.productStatus == 1 && d.CatID == CatID && d.ProductQun > 0).Take(count);
            List<Productsdata> PRODUCT2 = new List<Productsdata>();
            foreach (Products pp2 in Catpro)
            {
                Productsdata obj2 = new Productsdata();
                obj2.ProductID = pp2.ProductID;
                obj2.ProductTitle = this.LanguageChange(pp2.ProductTitle);
                obj2.ProductDec = this.LanguageChange(pp2.ProductDec);
                obj2.ProductSalePrice = pp2.ProductSalePrice;
                obj2.ProductRegulerPrice = pp2.ProductRegulerPrice;
                obj2.ProductQun = pp2.ProductQun;
                obj2.productimage = pp2.productimage;
                obj2.productimg = pp2.productimg;
                obj2.SKU = pp2.SKU;
                obj2.CatID = pp2.CatID;
                obj2.UserID = pp2.UserID;
                obj2.BrandID = pp2.BrandID;
                obj2.productStatus = pp2.productStatus;
                obj2.CreatedDate = pp2.CreatedDate;
                obj2.UpdateDate = pp2.UpdateDate;
                obj2.NumberofVisit = pp2.NumberofVisit;
                Int32 n = 0;
                foreach (ProductWishlist j in vv)
                {
                    if (j.ProductID == obj2.ProductID)
                    {
                        n++;
                    }
                }
                if (n > 0)
                {
                    obj2.iswishlist = true;
                }
                else
                {
                    obj2.iswishlist = false;
                }
                PRODUCT2.Add(obj2);
            }
            m.flag = true;
            m.message = this.LanguageChange("Most Populer Products");
            m.result = PRODUCT2.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        [AllowJsonGet]
        public JsonResult catagoryList()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 count = 50000;
            if (Request["no"] != null)
            {
                count = Convert.ToInt32(Request["no"]);
                var TrendingSweet = db.ProductCategory.Where(d => d.CategoryStatus == 1).Take(count);
                m.flag = true;
                m.message = this.LanguageChange("Products Category");
                m.result = TrendingSweet;
            }
            else {
                var TrendingSweet = db.ProductCategory.Where(d => d.CategoryStatus == 1).ToList();
                m.flag = true;
                m.message = this.LanguageChange("Products Category");
                m.result = TrendingSweet;
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        [AllowJsonGet]
        public JsonResult mobilenochk()
        {
            string data = cfn.mobliefilter(Request["mobile"]);
            var json = (db.user.Where(d => d.mobileno == data && d.usertype==1).First());
            return new JsonResult { Data = new { Message = "Mobile no Check", result = json, Status = "true" } };
        }
        [AllowJsonGet]
        public JsonResult emailidchk()
        {
            string data = (Request["email"]);
            var json = (db.user.Where(d => d.username == data && d.usertype == 1).First());
            return new JsonResult { Data = new { Message = "Trending Sweet", result = json, Status = "true" } };
        }
        [AllowJsonGet]
        public JsonResult Slider()
        {
            List<Slider> slide = new List<Slider>();
            Slider a = new Slider();

            a.Images = "/img/Homebanner/advt_03.png";
            a.links = "/Todaysweet?brand=7";
            slide.Add(a);
            a.Images = "/img/Homebanner/advt_02.png";
            a.links = "/Todaysweet?brand=9";
            slide.Add(a);
            a.Images = "/img/Homebanner/advt_01.png";
            a.links = "/Todaysweet?brand=5";
            slide.Add(a);
            var json = slide.ToList();
            return new JsonResult { Data = new { Message = this.LanguageChange("Trending Sweet"), result = json, Status = "true" } };
        }
        /*---------------------Services---------------------------*/
        [AllowJsonGet]
        public JsonResult GetWishList()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 PID = Convert.ToInt32(Request["productid"]);
            Int32 UID = Convert.ToInt32(Request["user"]);
            Int32 flag = Convert.ToInt32(Request["type"]);
            if (flag == 1 || flag == 0)
            {
                String Q;
                String Q1;
                String con = "";
                if (PID > 0 && (flag == 1 || flag == 0))
                {
                    con = " and [ProductID]='" + PID + "'";
                    Q1 = "delete from [dbo].[ProductWishlist] where [ProductID]='0' ";
                    abcd.Select(Q1);
                    Q = "delete from [dbo].[ProductWishlist] where [UserID]='" + UID + "' " + con;
                    abcd.Select(Q);
                }

                if (flag == 1)
                {

                    Q = "insert into [dbo].[ProductWishlist](UserID,ProductID) values('" + UID + "','" + PID + "')";
                    abcd.Select(Q);
                }
            }
            var exist = db.ProductWishlist.Where(x => x.UserID == UID).ToList();
            List<Productsdata> Pro = new List<Productsdata>();
            foreach (ProductWishlist i in exist)
            {
                if (i.ProductID > 0)
                {
                    var p = db.Products.Where(x => x.ProductID == i.ProductID && x.ProductQun > 0).FirstOrDefault();
                    if (p != null)
                    {

                        Productsdata PP = new Productsdata();

                        PP.ProductID = p.ProductID;
                        PP.productimage = p.productimage;
                        PP.ProductRegulerPrice = p.ProductRegulerPrice;
                        PP.ProductQun = p.ProductQun;
                        PP.ProductTitle = this.LanguageChange(p.ProductTitle);
                        PP.iswishlist = true;
                        Pro.Add(PP);
                    }
                }

            }
            m.flag = true;
            m.message = this.LanguageChange("Wish-List");
            m.result = Pro.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
      
        [AllowJsonGet]
        public JsonResult OrdersShow()
        {
            List<CartData> CARTDATA = new List<CartData>();
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            List<ReverseCart> ORDERD = new List<ReverseCart>();
            List<Order> Orders = new List<Order>();
            String a = Request["user"];
            Int32 type = Convert.ToInt32(Request["type"]);
            String or = Request["order"];

            if (!String.IsNullOrEmpty(or))
            {
                Orders = db.Order.Where(x => x.TransactionId.Contains(or)).ToList();  //FOr Order Traking
            }
            else {
                Orders = db.Order.Where(x => x.userID == a).ToList();
            }
            
            
            foreach (Order i in Orders)
            {
                ReverseCart o1 = new ReverseCart();
                Order o = new Order();
                o1.Billing = i.Billing;
                o1.CreatedDate = i.CreatedDate;
                o1.TransactionId = i.TransactionId;
                o1.ModeOfPayment = i.ModeOfPayment;
                o1.OrderID = i.OrderID;
                o1.CustomerID = Convert.ToInt32(i.userID);
                if (!String.IsNullOrEmpty(i.orderDetail))
                {
                    o1.orderDetail = JsonConvert.DeserializeObject<List<CartObj>>(i.orderDetail);
                    foreach (CartObj v in o1.orderDetail)
                    {
                        foreach (CartData v1 in v.WholCartData)
                        {
                            ProductBundle datas;
                            CartData d = new CartData();  
                            datas = db.ProductBundle.Where(h => h.ProductOrderID == v1.ProductOrderNumber).FirstOrDefault();
                            v1.pickanddeliverStatus = datas.pickanddeliverStatus;
                            switch (v1.pickanddeliverStatus)
                            {
                                case -1:
                                case 0:
                                    v1.OrderStatus = this.LanguageChange("Pending");
                                    break;
                                case 1:
                                    v1.OrderStatus = this.LanguageChange("shipment information received");
                                    break;
                                case 2:
                                    v1.OrderStatus = this.LanguageChange("Picked up from Store");
                                    break;
                                case 3:
                                    v1.OrderStatus = this.LanguageChange("Departed");
                                    break;
                                case 4:
                                    v1.OrderStatus = this.LanguageChange("On the Way.");
                                    break;
                                case 5:
                                    v1.OrderStatus = this.LanguageChange("it may delay.");
                                    break;
                                case 6:
                                case 7:
                                    v1.OrderStatus = this.LanguageChange("Delivered.");
                                    break;
                                case -2:
                                    v1.OrderStatus = this.LanguageChange("Cancel.");
                                    break;
                                case -3:
                                    v1.OrderStatus = this.LanguageChange("Not Pickedup.");
                                    break;
                                case -4:
                                    v1.OrderStatus = this.LanguageChange("Order Return.");
                                    break;
                            }
                            d = v1;
                            d.Product.ProductTitle = this.LanguageChange(d.Product.ProductTitle);
                            d.Product.ProductDec = this.LanguageChange(d.Product.ProductDec);

                            if (type == 0)     //All Ordrs
                            {
                                m.message = this.LanguageChange("All Orders");
                                d.OrderCreatedDate = (i.CreatedDate).ToString("dd-MM-yyyy");
                                d.Trakingnumber = i.TransactionId;
                                d.ProductSubtotal = System.Math.Round(v1.ProductPurchasePrice, 2);
                                d.ProductOffer=d.Discount = (System.Math.Round(v1.ProductOffer, 2) * System.Math.Round(v1.ProductPurchasePrice, 2)) / 100;
                                d.Shipping = System.Math.Round(v1.ShippingCost, 2);
                                d.OrderTotal = System.Math.Round((v1.ProductPurchasePrice + d.Shipping - d.Discount), 2);
                                CARTDATA.Add(d);
                            }
                            else if (type == 1 && v1.pickanddeliverStatus <= 5 && v1.pickanddeliverStatus > -2) //Pending Order
                            {
                                m.message = this.LanguageChange("Pending Orders");
                                
                                d.OrderCreatedDate = (i.CreatedDate).ToString("dd-MM-yyyy");
                                d.Trakingnumber = i.TransactionId;
                                d.ProductSubtotal = System.Math.Round(v1.ProductPurchasePrice, 2);
                                d.ProductOffer = d.Discount = (System.Math.Round(v1.ProductOffer, 2) * System.Math.Round(v1.ProductPurchasePrice, 2)) / 100;
                                d.Shipping = System.Math.Round(v1.ShippingCost, 2);
                                d.OrderTotal = System.Math.Round((v1.ProductPurchasePrice + d.Shipping - d.Discount), 2);
                                CARTDATA.Add(d);
                            }
                            else if (type == 2 && v1.pickanddeliverStatus >= 6)  // Complete order
                            {
                                m.message = this.LanguageChange("Complete Orders");
                                
                                d.OrderCreatedDate = (i.CreatedDate).ToString("dd-MM-yyyy");
                                d.Trakingnumber = i.TransactionId;
                                d.ProductSubtotal = System.Math.Round(v1.ProductPurchasePrice, 2);
                                d.ProductOffer = d.Discount = (System.Math.Round(v1.ProductOffer, 2) * System.Math.Round(v1.ProductPurchasePrice, 2)) / 100;
                                d.Shipping = System.Math.Round(v1.ShippingCost, 2);
                                d.OrderTotal = System.Math.Round((v1.ProductPurchasePrice + d.Shipping - d.Discount), 2);
                                CARTDATA.Add(d);

                            }
                            else if (type == 3 && v1.pickanddeliverStatus < -1)  //cancel Order
                            {
                                m.message = this.LanguageChange("Cancel Order");
                               
                                d.OrderCreatedDate = (i.CreatedDate).ToString("dd-MM-yyyy");
                                d.Trakingnumber = i.TransactionId;
                                d.ProductSubtotal = System.Math.Round(v1.ProductPurchasePrice, 2);
                                d.ProductOffer = d.Discount = (System.Math.Round(v1.ProductOffer, 2)* System.Math.Round(v1.ProductPurchasePrice, 2))/100;
                                d.Shipping = System.Math.Round(v1.ShippingCost, 2);
                                d.OrderTotal = System.Math.Round((v1.ProductPurchasePrice + d.Shipping - d.Discount), 2);
                                CARTDATA.Add(d);

                            }
                            
                        }

                    }
                }
                ORDERD.Add(o1);
            }

            m.flag = true;
            m.result = CARTDATA;
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }


        /*------------------GetCart Update---------------------*/
        [AllowJsonGet]
        public JsonResult getProductCartResult()
        {
            /*--------------------Variable------------*/
            String p = Request["cartproduct"];
            Int32 sAddID = 0;
            Int32 sShipcom = 0;
            if (!String.IsNullOrEmpty(Request["addressid"]))
            {
                try
                {
                    sAddID = Convert.ToInt32(Request["addressid"]);
                }
                catch (System.FormatException)
                {
                    sAddID = 0;// or other default value as appropriate in context.
                }
                
            }
            if (!String.IsNullOrEmpty(Request["shippingcompanyid"]))
            {
                try
                {
                    sShipcom = Convert.ToInt32(Request["shippingcompanyid"]);
                }
                catch (System.FormatException)
                {
                    sShipcom = 0;// or other default value as appropriate in context.
                }

            }
           // Int32 sShipcom = Convert.ToInt32(Request["shippingcompanyid"]);

            int Totalq = 0;
            double TotalP = 0;
            double TotalO = 0;
            double TotalS = 0;
            List<int> VendorIDs = new List<int>();
            int i = 0;
            /*--------------------Variable------------*/
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            if (p != "0-0")
            {
                List<CartObj> CARTOBJ = new List<CartObj>();
                List<CartData> CARTDATA = new List<CartData>();
                CartObj o = new CartObj();

                List<getproducts> PRODUCT = new List<getproducts>();
                string[] values = p.Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    getproducts pd = new getproducts();
                    string[] split = values[j].Split('-');
                    if (split[0] != null) { 
                    pd.Product_id = Convert.ToInt32(split[0]);
                    pd.Qun = Convert.ToInt32(split[1]);
                    PRODUCT.Add(pd);
                    }
                }
                var PRODUCTS = PRODUCT.ToList();

                foreach (getproducts pp in PRODUCTS)
                {
                    float shippingcost = 0;
                    CartData d = new CartData();
                    d.ProductOrderNumber = this.GenerateRandomText(10) + pp.Product_id + pp.Qun;
                    d.Flag = true;
                    d.FlagMsg = this.LanguageChange("In Stock");
                    d.Product_id = pp.Product_id;
                    /*----------------Product ---------------------*/
                    List<PurchaseProduct> PRODSD = new List<PurchaseProduct>();
                    PurchaseProduct pr = new PurchaseProduct();
                    Products pd = db.Products.Where(h => h.ProductID == pp.Product_id).FirstOrDefault();


                    pr.ActualAmount = pd.ActualAmount;
                    pr.adminoffer = pd.adminoffer;
                    pr.vendoroffer = pd.adminoffer;
                    pr.BrandID = pd.BrandID;
                    pr.CatID = pd.CatID;
                    pr.IsCustomized = pd.IsCustomized;
                    if (pr.IsCustomized == 1)
                    {
                        pr.CustomizedMsg = this.LanguageChange("This product is customizable");
                    }
                    /*------------Time--------------*/

                    TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = DateTime.UtcNow;
                    DateTime zone = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);
                    TimeSpan start = new TimeSpan(13, 0, 0); //1 o'clock
                    TimeSpan now = zone.TimeOfDay;
                    pr.PreperationTime = 1;
                    m.result = "" + now;
                    if (now <= start)
                    {
                        pr.PreperationTime = 0;
                    }
                    if (pd.PreperationTime > 0)
                    {
                        pr.PreperationTime = pr.PreperationTime + pd.PreperationTime;
                    }


                    pr.ProductID = pd.ProductID;
                    pr.productimage = pd.productimage;
                    pr.productimg = pd.productimg;
                    pr.ProductQun = pd.ProductQun;
                    pr.ProductRegulerPrice = pd.ProductRegulerPrice;
                    pr.SKU = pd.SKU;
                    pr.UserID = pd.UserID;
                    pr.vendoroffer = pd.vendoroffer;
                    pr.adminoffer = pd.adminoffer;
                    pr.productStatus = pd.productStatus;
                    pr.ProductTitle = this.LanguageChange(pd.ProductTitle);
                    pr.ProductSalePrice = pd.ProductSalePrice;
                    PRODSD.Add(pr);
                    d.Product = PRODSD.FirstOrDefault();


                    /*----------------Product ---------------------*/
                    d.Vendor = db.user.Where(h => h.id == d.Product.UserID).FirstOrDefault();
                    d.ProductPurchasePrice = (Convert.ToDouble(d.Product.ActualAmount) * pp.Qun);
                    d.Product.ProductPurchaseQun = pp.Qun;
                    d.ProductPurchaseQun = pp.Qun;

                    d.ProductOffer = Convert.ToDouble(d.Product.adminoffer) + Convert.ToDouble(d.Product.vendoroffer);
                    Totalq = Totalq + pp.Qun;
                    TotalP = TotalP + (Convert.ToDouble(d.Product.ActualAmount) * pp.Qun);

                    d.Offerprice = Math.Round((Convert.ToDouble(d.Product.ActualAmount) - ((Convert.ToDouble(d.Product.ActualAmount) * d.ProductOffer) / 100)) * pp.Qun, 2);
                    TotalO = TotalO + (d.ProductPurchasePrice - d.Offerprice);
                    d.fromID = Convert.ToInt32(d.Vendor.City);
                    if (sAddID > 0)
                    {
                        d.ShippingAddress = db.ShippingAddress.Where(h => h.Id == sAddID).FirstOrDefault();
                        if(d.ShippingAddress!=null)
                        { 
                            Session["PayEmail"] = d.ShippingAddress.email;
                            Session["PayPhone"] = d.ShippingAddress.Mobile;
                            Session["PayfName"] = d.ShippingAddress.Fname;
                            Session["PaylName"] = d.ShippingAddress.Lname;

                            d.toID = d.ShippingAddress.City;
                            d.toname = this.LanguageChange(d.ShippingAddress.CityName);
                        
                        if (d.fromID != 0 && db.cities.Where(h => h.id == d.fromID).FirstOrDefault()!=null)
                        {
                            d.fromname = db.cities.Where(h => h.id == d.fromID).FirstOrDefault().name;
                        }
                     }
                    }
                    if (sShipcom > 0)
                    {
                        d.shippingCompanys = db.Company.Where(h => h.ID == sShipcom).FirstOrDefault();
                        d.ShippingRatecard = db.CompanyRate.Where(h => h.CID == sShipcom && h.sourcecode == d.fromID && h.destinationcode == d.toID).FirstOrDefault();
                        if (d.ProductPurchaseQun >= 1 && d.ShippingRatecard != null)
                        {
                            int IDSDATA = d.Vendor.id;
                            if (VendorIDs.Count() > 0 && VendorIDs.Contains(IDSDATA))
                            {
                                shippingcost = shippingcost + Convert.ToInt64(d.ShippingRatecard.SameCity);
                            }
                            else
                            {
                                shippingcost = shippingcost + Convert.ToInt64(d.ShippingRatecard.price);
                            }
                            if (d.ProductPurchaseQun > 1)
                            {
                                shippingcost = shippingcost + ((d.ProductPurchaseQun - 1) * Convert.ToInt64(d.ShippingRatecard.ExtraQuntityprice));
                            }
                        }
                    }
                    d.ShippingCost = Math.Round(shippingcost, 2);
                    TotalS = TotalS + shippingcost;
                    d.Vendor.password = "";
                    d.Vendor.mobileno = "";
                    d.Vendor.username = "";

                    if (d.Vendor.City == "0")
                    {
                        i++;
                        d.Flag = false;
                        d.FlagMsg = this.LanguageChange("That Product Not-Purchasable");
                    }
                    else if (d.Vendor.status == 0)
                    {
                        i++;
                        d.Flag = false;
                        d.FlagMsg = this.LanguageChange("Vendor Not Available for Shipping This Product");
                    }
                    else if (d.Product.productStatus == 0 && d.Product.productStatus == -2)
                    {
                        i++;
                        d.Flag = false;
                        d.FlagMsg = this.LanguageChange("Out of Stock");
                    }
                    else if (d.Product.ProductQun < pp.Qun)
                    {
                        i++;
                        d.Flag = false;
                        d.FlagMsg = this.LanguageChange("Out of Stock");
                    }
                    CARTDATA.Add(d);
                    VendorIDs.Add(d.Vendor.id);
                }
                /*---------Amit Sir Shipping Add----------*/
                
               /*---------Amit Sir Shipping Add----------*/
                o.TaxPrice = 0;
                o.TotalOfferprice = Math.Round(TotalO, 2);
                o.SubTotalPrice = Math.Round(TotalP, 2);
                Session["amount"] = o.TotalPrice = (Math.Round(o.SubTotalPrice, 2) - Math.Round(TotalO, 2) + o.ShippingCost);
                o.TotalQuntity = Totalq;
                o.WholCartData = CARTDATA.ToList();
                ShippingCost c1 = new ShippingCost(o, sShipcom);
                Int32 add = 0;
                if (!String.IsNullOrEmpty(Request["addressid"]))
                {
                    add = Convert.ToInt32(Request["addressid"]);
                }
                o.ShippingCost = Math.Round(c1.getcost(c1.shippingCalculateFirstTime(add)), 2);
                o.WholCartData = c1.WholCartData;
                Session["amount"] = o.TotalPrice = (Math.Round(o.SubTotalPrice, 2) - Math.Round(TotalO, 2) + o.ShippingCost);


                o.itemnmsg = this.LanguageChange("items");
               

                o.qunmsg = this.LanguageChange("QTY");
                o.pricemsg = this.LanguageChange("Price");
                o.productsubtotalmsg = this.LanguageChange("Product Subtotal");
                o.offermsg = this.LanguageChange("Offer Discount");
                o.Shippingnmsg = this.LanguageChange("Shipping");
                o.totalmsg = this.LanguageChange("Total");
                o.viewcartmsg = this.LanguageChange("View Cart");


                CARTOBJ.Add(o);
                if (i > 0)
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Some Product Out of Stock");
                    m.result = CARTOBJ;
                }
                else
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Order Product");
                    m.result = CARTOBJ;
                }
                if(sAddID > 0)
                {
                    if (db.ShippingAddress.Where(x => x.Id == sAddID).ToList().Count() == 0)
                    {
                       // m.flag = false;
                        //m.message = this.LanguageChange("Please Select Address");
                        //m.result = CARTOBJ;
                    }

                }


            }
            else
            {
                m.flag = false;
                m.message = this.LanguageChange("Cart Empty");
                m.result = null;
            }
           

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        /*------------------End GetCart Update---------------------*/

        [AllowJsonGet]
        public JsonResult FinishPayment() {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            List<Order> O = new List<Order>();
            List<OrderDetails> OrderD = new List<OrderDetails>();

            String p            = Request["cartproduct"];
            Int32 sAddID        = Convert.ToInt32(Request["addressid"]);
            Int32 sShipcom      = Convert.ToInt32(Request["shippingcompanyid"]);
            Int32 customerID    = 0;
            String userID       = Request["user"];
            String Type         = Request["paytype"];
            Int32 TID          = Convert.ToInt32(Request["TID"]);
            String tids = this.GenerateRandomText(10);
            if (Session["Paymentdata"] != null && Convert.ToInt32(Session["Paymentdata"]) > 0)
            {
                TID = Convert.ToInt32(Session["Paymentdata"]);
                Session["Paymentdata"] = 0;
            }

            /*-----------------------------Cart Product Show-------------------------*/

            /*--------------------Variable------------*/
            int Totalq = 0;
            double TotalP = 0;
            double TotalO = 0;
            double TotalS = 0;
            List<int> VendorIDs = new List<int>();



            int i = 0;
            /*--------------------Variable------------*/
            

            List<CartObj> CARTOBJ = new List<CartObj>();
            List<CartData> CARTDATA = new List<CartData>();
            CartObj o = new CartObj();

            List<getproducts> PRODUCT = new List<getproducts>();
            string[] values = p.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                getproducts pd = new getproducts();
                string[] split = values[j].Split('-');
                pd.Product_id = Convert.ToInt32(split[0]);
                pd.Qun = Convert.ToInt32(split[1]);
                PRODUCT.Add(pd);
            }
            var PRODUCTS = PRODUCT.ToList();
            CustomerProfile c = new CustomerProfile();
            foreach (getproducts pp in PRODUCTS)
            {

                float shippingcost = 0;
                CartData d = new CartData();
                d.ProductOrderNumber = this.GenerateRandomText(9) + pp.Product_id+pp.Qun ;
                d.Flag = true;
                d.FlagMsg = "";
                d.Product_id = pp.Product_id;
                /*----------------Product ---------------------*/
                List<PurchaseProduct> PRODSD = new List<PurchaseProduct>();
                PurchaseProduct pr = new PurchaseProduct();
                Products pd = db.Products.Where(h => h.ProductID == pp.Product_id).FirstOrDefault();
                
                pr.ActualAmount = pd.ActualAmount;
                pr.adminoffer = pd.adminoffer;
                pr.BrandID = pd.BrandID;
                pr.CatID = pd.CatID;
                pr.IsCustomized = pd.IsCustomized;
                /*------------Time--------------*/
                TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = DateTime.UtcNow;
                DateTime zone = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);
                TimeSpan start = new TimeSpan(13, 0, 0); //10 o'clock

                TimeSpan now = zone.TimeOfDay;
                pr.PreperationTime = 1;
                m.result = "" + now;
                if (now <= start)
                {
                    pr.PreperationTime = 0;
                }
                if (pd.PreperationTime > 0)
                {
                    pr.PreperationTime = pr.PreperationTime + pd.PreperationTime;
                }
                pr.ProductID = pd.ProductID;
                pr.productimage = pd.productimage;
                pr.productimg = pd.productimg;
                pr.ProductQun = pd.ProductQun;
                pr.ProductRegulerPrice = pd.ProductRegulerPrice;
                pr.SKU = pd.SKU;
                pr.UserID = pd.UserID;
                pr.vendoroffer = pd.vendoroffer;
                pr.adminoffer = pd.adminoffer;
                pr.productStatus = pd.productStatus;
                pr.ProductTitle = this.LanguageChange(pd.ProductTitle);
                pr.ProductSalePrice = pd.ProductSalePrice;
                PRODSD.Add(pr);
                d.Product = PRODSD.FirstOrDefault();
                /*----------------Product ---------------------*/
                d.Vendor = db.user.Where(h => h.id == d.Product.UserID).FirstOrDefault();
                d.ProductPurchasePrice = Math.Round((Convert.ToDouble(d.Product.ActualAmount) * pp.Qun),2);
                d.Product.ProductPurchaseQun = pp.Qun;
                d.ProductPurchaseQun = pp.Qun;
                d.ProductOffer = Math.Round(Convert.ToDouble(d.Product.adminoffer) + Convert.ToDouble(d.Product.vendoroffer),2);
                Totalq = Totalq + pp.Qun;
                TotalP = TotalP + Math.Round((Convert.ToDouble(d.Product.ActualAmount) * pp.Qun),2);
                d.Offerprice = Math.Round((Convert.ToDouble(d.Product.ActualAmount) - ((Convert.ToDouble(d.Product.ActualAmount) * d.ProductOffer) / 100)) * pp.Qun, 2);
                TotalO = TotalO + Math.Round((d.ProductPurchasePrice - d.Offerprice),2);
                d.fromID = Convert.ToInt32(d.Vendor.City);
                if (sAddID > 0)
                {
                    d.ShippingAddress = db.ShippingAddress.Where(h => h.Id == sAddID).FirstOrDefault();
                    d.toID = d.ShippingAddress.City;
                    d.toname = d.ShippingAddress.CityName;
                    if (d.fromID != 0)
                    {
                        d.fromname = db.cities.Where(h => h.id == d.fromID).FirstOrDefault().name;
                    }
                }
                if (sShipcom > 0)
                {
                    d.shippingCompanys = db.Company.Where(h => h.ID == sShipcom).FirstOrDefault();
                    d.ShippingRatecard = db.CompanyRate.Where(h => h.CID == sShipcom && h.sourcecode == d.fromID && h.destinationcode == d.toID).FirstOrDefault();
                    if (d.ProductPurchaseQun >= 1 && d.ShippingRatecard != null)
                    {
                        int IDSDATA = d.Vendor.id;
                        if (VendorIDs.Count() > 0 && VendorIDs.Contains(IDSDATA))
                        {
                            shippingcost = shippingcost + Convert.ToInt64(d.ShippingRatecard.SameCity);
                        }
                        else
                        {
                            shippingcost = shippingcost + Convert.ToInt64(d.ShippingRatecard.price);
                        }
                        if (d.ProductPurchaseQun > 1)
                        {
                            shippingcost = shippingcost + ((d.ProductPurchaseQun - 1) * Convert.ToInt64(d.ShippingRatecard.ExtraQuntityprice));
                        }
                    }
                }
                d.ShippingCost = shippingcost;
                TotalS = TotalS + shippingcost;
                d.Vendor.password = "";
                var address=db.Usersmeta.Where(h => h.userid == d.Vendor.id && h.metakey == "add").FirstOrDefault();
                if(address!=null)
                { 
                    d.Vendor.shipping = 0;
                }
                var Business = db.Usersmeta.Where(h => h.userid == d.Vendor.id && h.metakey == "Business").FirstOrDefault();
                if (Business != null)
                {
                    d.Vendor.Postalcode = Business.metavalue;
                }
                if (d.Vendor.City == "0")
                {
                    i++;
                    d.Flag = false;
                    d.FlagMsg = this.LanguageChange("That Product Non-Purchasable");
                }
                else if (d.Vendor.status == 0)
                {
                    i++;
                    d.Flag = false;
                    d.FlagMsg = this.LanguageChange("Vendor Not Available for Shipping This Product");
                }
                else if (d.Product.productStatus == 0)
                {
                    i++;
                    d.Flag = false;
                    d.FlagMsg = "Out of Stock";
                }
                else if (d.Product.ProductQun < pp.Qun)
                {
                    i++;
                    d.Flag = false;
                    d.FlagMsg = this.LanguageChange("Out of Stock");
                }

                Session["CustomerEmail"] = d.ShippingAddress.email;
                Session["MOBILE"] = d.ShippingAddress.Mobile;



                IDictionary<string, string> keys2 = new Dictionary<string, string>() {
                                                    { "%#product#%", d.ProductOrderNumber},
                                                    { "%#link#%", "https://www.sweetness.ae/vendor"}
                                                };
                
                Format a3 = new Format(11, keys2, d.Vendor.username);
                Format a33 = new Format(11, keys2, "hr@snvinfotech.com");

                if (d.Product.IsCustomized == 0) { 
                    IDictionary<string, string> ShippingInfo = new Dictionary<string, string>() {
                                                    { "%#Ref#%", d.ProductOrderNumber},
                                                };

                    Format Ship1 = new Format(18, ShippingInfo, d.shippingCompanys.shippingemail);
                    Format Ship2 = new Format(18, ShippingInfo, "snv.ankit@gmail.com");
                    
                }


                CARTDATA.Add(d);

                c.CustomerFullName = d.ShippingAddress.Fname + " " + d.ShippingAddress.Lname;
                c.CustomerMobileNumber = c.CustomerEmailID = d.ShippingAddress.Mobile;
                c.CustomerBillingAdd = c.CustomerShippingAdd = d.ShippingAddress.Address;
                VendorIDs.Add(d.Vendor.id);
            }
            
            db.CustomerProfiles.Add(c);
            db.SaveChanges();
            customerID=  db.CustomerProfiles.Max(item => item.CustomerID);
            o.ShippingCost = Math.Round(TotalS,2);
            o.TaxPrice = 0;
            o.TotalOfferprice = Math.Round(TotalO,2);
            
            o.TotalQuntity = Totalq;
            o.WholCartData = CARTDATA.ToList();

            ShippingCost c1 = new ShippingCost(o, sShipcom);
            Int32 add = 0;
            if (Request["addressid"] != null || Request["addressid"].Trim().Length > 0)
            {
                add = Convert.ToInt32(Request["addressid"]);
            }
            o.ShippingCost = Math.Round(c1.getcost(c1.shippingCalculateFirstTime(add)), 2);
            o.WholCartData = c1.WholCartData;
            o.TotalPrice = (Math.Round(o.SubTotalPrice, 2) - Math.Round(TotalO, 2) + o.ShippingCost);


            o.SubTotalPrice = Math.Round(TotalP, 2);
            Session["TotalPrice"]=o.TotalPrice = (o.SubTotalPrice - o.TotalOfferprice) + o.ShippingCost;
            CARTOBJ.Add(o);
            String json = new JavaScriptSerializer().Serialize(CARTOBJ.ToList());
            
            String bill = "";
            String ship = "";
            Order order = new Order();
            order.customerID = customerID;
            order.userID = c1.UpdateUserShippingStatus(userID);
            order.orderDetail = json;
            order.ModeOfPayment = Type;
            order.TransactionId = tids;
            order.Billing = bill;
            order.Shipping = ship;

            order.TransactionIdPayment = TID;
            db.Order.Add(order);
            db.SaveChanges();
            
            
            IDictionary<string, string> keys1 = new Dictionary<string, string>() {
                                                    { "%#product#%", tids},
                                                    { "%#link#%", "https://www.sweetness.ae/Myorder/TrackOrder?orderid="+tids}
                                                };

            
            Format a4 = new Format(11, keys1, "hr@snvinfotech.com");
            
            var cartproduct =CARTOBJ.FirstOrDefault().WholCartData;
            foreach (var cart_single in cartproduct)
            {
                ProductBundle p1 = new ProductBundle();
                int quntity = cart_single.Product.ProductQun;
                quntity = quntity - cart_single.ProductPurchaseQun;


                if (quntity == 0)
                {
                    abcd.Select("update Products set [productStatus]=0,[ProductQun]='" + quntity + "' where [ProductID]='" + cart_single.Product_id + "'");
                }
                else
                { 
                    abcd.Select("update Products set [ProductQun]='" + quntity + "' where [ProductID]='" + cart_single.Product_id + "'");
                }
                p1.OrderID = order.OrderID;
                p1.ProductID = cart_single.Product.ProductID;
                p1.ProductOrderID = cart_single.ProductOrderNumber;
                p1.ProductPricing = (Convert.ToDouble(cart_single.Product.ProductRegulerPrice)*cart_single.ProductPurchaseQun)+cart_single.ShippingCost;
                p1.VendorID = cart_single.Vendor.id;
                p1.ShippingCompanyID = cart_single.shippingCompanys.ID;
                p1.payable = 0;
                p1.OrderSummary = JsonConvert.SerializeObject(cart_single);
                p1.iscustomization = cart_single.Product.IsCustomized;
                if (p1.iscustomization == 1)
                {
                    p1.pickanddeliverStatus = -1;
                }
                else {
                    p1.pickanddeliverStatus = 0;
                }
                
                
                
                db.ProductBundle.Add(p1);
                db.SaveChanges();
            }

            String Res = "";
            if (Session["PAYsuccessIndicator"] != null)
            {
                Res = Session["PAYsuccessIndicator"].ToString();
            }
            else {
                Res = this.GenerateRandomText(25);
            }

            IDictionary<string, string> keys3 = new Dictionary<string, string>() {
                                                    { "%#Payment#%", " "+Session["TotalPrice"].ToString()+" AED"},
                                                    { "%#Ref#%", tids},
                                                    { "%#link#%", " https://www.sweetness.ae/Myorder/TrackOrder?orderid="+tids}
                                                };
            Format a2 = new Format(12, keys3, Session["CustomerEmail"].ToString());
            Format a22 = new Format(12, keys3, "hr@snvinfotech.com");

            String MSG = "Order "+ tids + " has been placed successfully. Track your order on https://www.sweetness.ae/Myorder/TrackOrder?orderid=" + tids;
            MOBILE.MobileM(MSG, Session["MOBILE"].ToString());
            //MOBILE.MobileM(MSG,"7879411522",true); 

            m.flag = true;
            m.message = this.LanguageChange("Complete Orders");
            m.result = tids;
            
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        private string GenerateRandom_Trns(int v,Boolean flag=false)
        {
            TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = DateTime.UtcNow;
            DateTime zone = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);
            

            Int64 now = zone.Ticks;
            String Chars;
            Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
            if (flag==true)
            { 
                Chars = "0123456789";
            }
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, v)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result+ now;

        }
        private string GenerateRandomText(int v, Boolean flag = false)
        {
            TimeZoneInfo UAETimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time"); DateTime utc = DateTime.UtcNow;
            DateTime zone = TimeZoneInfo.ConvertTimeFromUtc(utc, UAETimeZone);


            Int64 now = zone.Ticks;
            String Chars;
            Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
            if (flag == true)
            {
                Chars = "0123456789";
            }
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, v)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result;

        }

        [AllowJsonGet]
        public JsonResult ShippingCompany()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            List<Company> COM = new List<Company>();

            var company = db.Company.ToList();
            foreach (Company x in company)
            {
                Company s = new Company();
                var Rates = db.CompanyRate.Where(h => h.CID == x.ID).ToList();
                if (Rates.Count() > 0)
                {
                    s.ID = x.ID;
                    s.name = x.name;
                    s.logo = x.logo;
                    s.description = x.description;
                    s.user = x.user;
                    s.pass = x.pass;
                    COM.Add(s);

                }

            }
            m.flag = true;
            m.message = this.LanguageChange("Shipping Company");
            m.result = COM.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
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
            m.message = this.LanguageChange("Shipping Company With Price");
            m.result = SHIP.ToList();
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        [AllowJsonGet]
        public JsonResult ShipingCityList()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            //var citys=db.cities.Where(g=>g.state_id== 292223 || g.state_id == 290594).ToList();
            var citys = db.cities.ToList();

            m.flag = true;
            m.message = this.LanguageChange("Shipping City Data");
            m.result = citys;
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        [AllowJsonGet]
        public JsonResult AddShippingAddress()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            ShippingAddress h = new ShippingAddress();
            h.userid = Convert.ToInt32(Request["user"]);
            h.City = Convert.ToInt32(Request["cityID"]);
            h.CityName = db.cities.Where(l => l.id == h.City).FirstOrDefault().name;
            h.Fname = Request["Fname"].ToString();
            h.Lname = Request["Lname"].ToString();
            h.StreetName = Request["StreetName"].ToString();
            h.BuildingName = Request["BuildingName"].ToString();
            h.Location = Request["Location"].ToString();
            h.Mobile = Request["Mobile"].ToString();
            h.email= Request["email"].ToString();
            h.ShoppingNote = Request["ShoppingNote"].ToString();
            h.Address = h.Fname + " " + h.Lname + "<br>" + h.StreetName + "<br>" + h.BuildingName + "<br>" + h.Location + "<br><b>City </b>" + h.City + "<br><b>Mobile:</b> " + h.Mobile;

            db.ShippingAddress.Add(h);
            db.SaveChanges();

            int lastProductId = db.ShippingAddress.Max(item => item.Id);
            var ShippingAddress = db.ShippingAddress.Where(x => x.userid == h.userid && h.Id==lastProductId).ToList();

            if (ShippingAddress.Count() > 0)
            {
                m.flag = true;
                m.message = this.LanguageChange("Shipping Address");
                m.result = ShippingAddress;
            }
            else
            { 
                m.flag = false;
                m.message = this.LanguageChange("No Shipping Address Found");
                m.result = ShippingAddress;
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        [AllowJsonGet]
        public JsonResult DeleteShippingAddress()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            ShippingAddress h = new ShippingAddress();

            Int32 ID = Convert.ToInt32(Request["AddressID"]);
            abcd.Select("delete from [dbo].[ShippingAddress] where [id]='" + ID + "'");

            h.userid = Convert.ToInt32(Request["user"]);
            if (h.userid != 0)
            {
                var ShippingAddress = db.ShippingAddress.Where(x => x.userid == h.userid).ToList();

                if (ShippingAddress.Count() > 0)
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Shipping Address");
                    m.result = ShippingAddress;

                }
                else
                {

                    m.flag = false;
                    m.message = this.LanguageChange("No Shipping Address Found");
                    m.result = ShippingAddress;

                }
            }
            else {
                m.flag = true;
                m.message = this.LanguageChange("Address removed");
                m.result = 0;
            }

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        [AllowJsonGet]
        public JsonResult UpdateShippingAddress()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            ShippingAddress h = new ShippingAddress();

            Int32 ID = Convert.ToInt32(Request["AddressID"]);
            var ship=db.ShippingAddress.Where(d => d.Id == ID).ToList();
            if (ship.Count() > 0)
            {
                abcd.Select("delete from [dbo].[ShippingAddress] where [id]='" + ID + "'");

                h.userid = Convert.ToInt32(Request["user"]);
                h.City = Convert.ToInt32(Request["cityID"]);
                h.CityName = db.cities.Where(l => l.id == h.City).FirstOrDefault().name;
                h.Fname = Request["Fname"].ToString();
                h.Lname = Request["Lname"].ToString();
                h.StreetName = Request["StreetName"].ToString();
                h.BuildingName = Request["BuildingName"].ToString();
                h.Location = Request["Location"].ToString();
                h.Mobile = Request["Mobile"].ToString();
                h.email = Request["email"].ToString();
                h.ShoppingNote = Request["ShoppingNote"].ToString();
                h.Address = h.Fname + " " + h.Lname + "<br>" + h.StreetName + "<br>" + h.BuildingName + "<br>" + h.Location + "<br><b>City </b>" + h.City + "<br><b>Mobile:</b> " + h.Mobile;
                db.ShippingAddress.Add(h);
                db.SaveChanges();
                int lastProductId = db.ShippingAddress.Max(item => item.Id);
                var ShippingAddress = db.ShippingAddress.Where(x => x.Id == lastProductId).FirstOrDefault();


                m.flag = true;
                m.message = this.LanguageChange("Update Shipping Address");
                m.result = ShippingAddress;
            }
            else {
                m.flag = false;
                m.message = this.LanguageChange("This Id not Found");
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        [AllowJsonGet]
        public JsonResult GetShippingAddress()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 UID;
            UID = Convert.ToInt32(Request["user"]);
            if(Session["userdetail"] != null)
            {
                user u = new user();
                u = (user)Session["userdetail"];
                UID = u.id;
            }
            if (UID != 0)
            {
                var ShippingAddress = db.ShippingAddress.Where(h => h.userid == UID).ToList();
                if (ShippingAddress.Count() > 0)
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Shipping Address");
                    m.result = ShippingAddress;
                }
                else
                {
                    m.flag = false;
                    m.message = this.LanguageChange("No Shipping Address Found");
                    m.result = ShippingAddress;
                }
            }
            else {
                m.flag = false;
                m.message = this.LanguageChange("This Service Only For Users Not For guest");
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult GetShippingAddressGuest()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 ID = Convert.ToInt32(Request["AddressID"]);
                var ShippingAddress = db.ShippingAddress.Where(h => h.Id == ID).ToList();
                if (ShippingAddress.Count() > 0)
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Shipping Address");
                    m.result = ShippingAddress;
                }
                else
                {
                    m.flag = false;
                    m.message = this.LanguageChange("No Shipping Address Found");
                    m.result = ShippingAddress;
                }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult WriteReview()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String token = Request["token"];
            Int32  rating = Convert.ToInt32(Request["rating"]);
            Int32 deliveryrating = Convert.ToInt32(Request["Ratingdelivery"]);
            String review = Request["review"];
            ProductBundle prod  =   db.ProductBundle.Where(x => x.ProductOrderID.Contains(token)).FirstOrDefault();
            Order           odr =   db.Order.Where(h => h.OrderID == prod.OrderID).FirstOrDefault();
            int CustID=odr.customerID;
            if (prod.pickanddeliverStatus == 7) {
                m.flag = false;
                m.message = this.LanguageChange("Your Review Already Submited");
                m.result = null;
            } else if (prod.pickanddeliverStatus < 6) {
                m.flag = false;
                m.message = this.LanguageChange("Your Not eligible to Write A Review");
                m.result = null;
            } else {
                List<ProductReview> REVIEW = new List<ProductReview>();
                ProductReview r = new ProductReview();
                r.CustomerID = CustID;
                r.ProductID = prod.ProductID;
                r.Reviewmsg = review;
                r.StarRating = rating;
                r.Token = token;
                r.StarRatingdelivery = deliveryrating;
                db.ProductReview.Add(r);
                db.SaveChanges();
                string q = "update ProductBundle set [pickanddeliverStatus]=7 where [ProductOrderID]='" + token + "'";
                abcd.Select(q);
                m.flag = true;
                m.message = this.LanguageChange("Thank you for review");
                m.result = null;
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult CancelOrder()
        {
            String Msg;
            Msg = "";
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String token = Request["token"];
            Msg = Convert.ToString(Request["cancelMsg"]);
            string q = "update ProductBundle set [pickanddeliverStatus]=-2,[cancelby]=1,cancelMsg='"+Msg+"' where [ProductOrderID]='" + token + "'";
            abcd.Select(q);
                m.flag = true;
                m.message = token+" "+ this.LanguageChange("Order Cancel Successfull");
                m.result = null;
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult GetOrderProduct()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String ID = Request["id"].ToString();
            var q = db.ProductBundle.Where(h=>h.ProductOrderID.Contains(ID)).FirstOrDefault();
            var ORDERID=db.Order.Where(h => h.OrderID == q.OrderID).FirstOrDefault();
            q.ProductOrderID=ORDERID.TransactionId;
            
            m.flag = true;
            m.message = JsonConvert.SerializeObject(q.CreatedDate, new IsoDateTimeConverter());   
            m.result = (q);
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }


        [AllowJsonGet]
        public JsonResult UpdateProfile()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int64 ID = Convert.ToInt64(Request["user"]);
            var q = db.user.Where(h => h.id==ID).FirstOrDefault();
            if (q != null)
            {
                q.fname = Convert.ToString(Request["fname"]);
                q.lname = Convert.ToString(Request["lname"]);
              
                db.SaveChanges();
                m.flag = true;
                m.message = this.LanguageChange("Profile update");
                m.result = null;

            }
            else {

                m.flag = false;
                m.message = this.LanguageChange("Please Enter valid User ID");
                m.result = null;
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult UpdateProfilePassword()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int64 ID    = Convert.ToInt64(Request["user"]);
            String oldp = Convert.ToString(Request["pass"]);
            var q = db.user.Where(h => h.id == ID && h.password.Contains(oldp)).FirstOrDefault();
            if (q != null)
            {
                if (!String.IsNullOrEmpty(Request["newpass"]))
                {
                    q.password = Convert.ToString(Request["newpass"]);
                    db.SaveChanges();
                    m.flag = true;
                    m.message = this.LanguageChange("Password update");
                }
                else {
                    m.flag = false;
                    m.message = this.LanguageChange("Please Enter valid newpassword");
                }
                   
                m.result = null;

            }
            else
            {
                m.flag = false;
                m.message = LanguageChange("Old password not match");
                m.result = null;
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
/*-------------------------Shipping Api--------------------*/
        [AllowJsonGet]
        public JsonResult LoginShipping()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            APIRES.DefaultIfEmpty();
            String user = Convert.ToString(Request["user"]);
            String pass = Convert.ToString(Request["pass"]);
            if (!String.IsNullOrEmpty(user))
            {
                if (!String.IsNullOrEmpty(pass))
                {
                    var q = db.Company.Where(h => h.user.Trim()==user && h.pass.Trim()==pass).ToList();
                    if (q.Count() > 0)
                    {
                        Session["company"] = q[0].ID;
                        Session["companydata"] = q[0];
                        Session["companylogin"] = "y";
                        m.flag = true;
                        m.message = this.LanguageChange("User Login");
                        m.result = q;
                    }
                    else
                    {
                        Session["companylogin"] = "";
                        m.flag = false;
                        m.message = this.LanguageChange("Username Or Password Worng");
                        m.result = null;
                    }
                }
                else
                {
                    Session["companylogin"] = "";
                    m.flag = false;
                    m.message = this.LanguageChange("Password Empty");
                    m.result = null;
                }
            }
            else {
                Session["companylogin"] = "";
                m.flag = false;
                m.message = this.LanguageChange("Username Empty");
                m.result = null;
            }

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult ShippingOrder()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 id = Convert.ToInt32(Request["ShippingID"]);
            Int32 type = Convert.ToInt32(Request["Type"]);
            
            if (type == 1)
            {
               var q = db.ProductBundle.Where(h => h.ShippingCompanyID == id && h.pickanddeliverStatus < 6 && h.pickanddeliverStatus >= 0).ToList();
                if (q.Count() > 0)
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Open Order");
                    m.result = this.bundle(q);
                }
                else {
                    m.flag = false;
                    m.message = this.LanguageChange("No Order Found");
                    m.result = null;
                }
            }
            else if (type == 2)
            {
                var q = db.ProductBundle.Where(h => h.ShippingCompanyID == id && h.pickanddeliverStatus >= 6).ToList();
                if (q.Count() > 0)
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Complete Order");
                    m.result = this.bundle(q);
                }
                else
                {
                    m.flag = false;
                    m.message = this.LanguageChange("No Order Found");
                    m.result = null;
                }
            }
            else if (type == 3)
            {
                var q = db.ProductBundle.Where(h => h.ShippingCompanyID == id && (h.pickanddeliverStatus==-2 || h.pickanddeliverStatus == -3 || h.pickanddeliverStatus == -4)).ToList();
                if (q.Count() > 0)
                {
                    m.flag = true;
                    m.message = this.LanguageChange("Cancel Order");
                    m.result = this.bundle(q);
                }
                else
                {
                    m.flag = false;
                    m.message = this.LanguageChange("No Order Found");
                    m.result = null;
                }
            }
            else
            {
                m.flag = false;
                m.message = this.LanguageChange("No Order Found And/Or Type is Wrong ");
                m.result = null;

            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult ChkSessionPayment()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String ResultIndicator = Convert.ToString(Request["ResultIndicator"]);
            String successIndicator = Convert.ToString(Session["PAYsuccessIndicator"]);
            if (ResultIndicator == successIndicator)
            {
                m.flag = true;
                m.message = this.LanguageChange("Payment Done");
                m.result = "/myorder/Paynowdone";
            }
            else
            {
                m.flag = false;
                m.message = this.LanguageChange("Payment Not Done");
                m.result = "/shoppingcart";
            }
            

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }



        [AllowJsonGet]
        public JsonResult updateshippingdata()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String id = Convert.ToString(Request["orderid"]);
            Int32 type = Convert.ToInt32(Request["ststus"]);

            var q=db.ProductBundle.Where(h => h.ProductOrderID.Trim() == id.ToString()).FirstOrDefault();
            if (type > -5)
            {
                q.pickanddeliverStatus = type;
                if (type == -3)
                {
                    q.cancelby = 3;
                }
                if (type == -4)
                {
                    q.cancelby = 4;
                }



                db.SaveChanges();
                m.flag = true;
                m.message = this.LanguageChange("update data");
                m.result = null;

            }
            else {
                m.flag = false;
                m.message = this.LanguageChange("Not update");
                m.result = null;

            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }


        public List<ProductBundledata> bundle(List<ProductBundle> q)
        {
            List<ProductBundledata> BUNDAL = new List<ProductBundledata>();
            BUNDAL.DefaultIfEmpty();
            foreach (ProductBundle bb in q)
            {
                ProductBundledata b = new ProductBundledata();
                b.OrderID = bb.OrderID;
                b.Id = bb.Id;
                b.payable = bb.payable;
                b.ProductID = bb.ProductID;
                b.ProductOrderID = bb.ProductOrderID;
                b.ProductPricing = bb.ProductPricing;
                b.ShippingCompanyID = bb.ShippingCompanyID;
                b.VendorID = bb.VendorID;
                b.cancelby = bb.cancelby;
                b.pickanddeliverStatus = bb.pickanddeliverStatus;
                b.OrderSummary = JsonConvert.DeserializeObject<CartData>(bb.OrderSummary);
                BUNDAL.Add(b);
            }


            return BUNDAL.ToList();
        }


/*-------------------------Shipping Api--------------------*/
        [AllowJsonGet]
        public JsonResult Language()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            var q = db.Language.ToList();
            m.flag = true;
            m.message = this.LanguageChange(" Languag");
            m.result = (q);
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }

        [AllowJsonGet]
        public JsonResult MessageSent()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String msg      =   Request["message"].ToString();
            String mobile   =   Request["mobile"].ToString();
            
            m.flag = true;
            m.message = this.LanguageChange("Message has been Sent");
            m.result = MOBILE.MobileM(msg, mobile); ;
        
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault()  };
        }



        [AllowJsonGet]
        public JsonResult PasswordSetMobile()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String Mobile = cfn.mobliefilter(Convert.ToString(Request["mobile"]));
            String Pass = Convert.ToString(Request["password"]);
            var q = db.user.Where(h => h.mobileno == Mobile && h.usertype==1).FirstOrDefault();
            if (!String.IsNullOrEmpty(q.mobileno))
            {
                q.password = Pass;
                db.SaveChanges();
                m.flag = true;
                m.message = this.LanguageChange("Password Reset");
                m.result = (q);
            }
            else {
                m.flag = false;
                m.message = this.LanguageChange("Mobile Number Not Found");
                m.result = (q);
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
         [AllowJsonGet]
        public JsonResult PasswordCheackMobile()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String Mobile = cfn.mobliefilter(Convert.ToString(Request["mobile"]));
            var q = db.user.Where(h => h.mobileno == Mobile && h.usertype == 1).ToList();
          
            if (q.Count() > 0)
            {

                String OTP = GenerateRandomText(6, true);
                String OTPN = OTP;
                OTP = "Use " + OTP + " Sweetness Customer account password reset code";
                MOBILE.MobileM(OTP, Mobile);

                m.flag = true;
                m.message = this.LanguageChange("OTP has been sent");
                m.result = (OTPN);
            }
            else
            {
                var q1 = db.user.Where(h => h.mobileno == Mobile && h.usertype == 2).ToList();
                if (q1.Count() > 0)
                {
                    m.flag = false;
                    m.message = this.LanguageChange("This Number Already used in vendor");
                    m.result = "";
                }
                else {

                    m.flag = false;
                    m.message = this.LanguageChange("Mobile Number Not Found");
                    m.result = "";
                }
                    
            }
            
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
        }
        public String LanguageChange(String text)
        {
            String lang;
            lang = "en";
            String la = Convert.ToString(Request["lang"]);
            if (la != null)
            {
                lang = la;
            }
            var data = db.Language.Where(h => h.en.StartsWith(text)).FirstOrDefault(); 
            if (data != null) { 
                if (lang == "ar")
                {
                    text = data.ar;
                }
                
        }
            return text;
        }

        



        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                String sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                if(sResponse==null)
                {
                    sResponse = 1.ToString();
                }
                return sResponse;
            
        }
        /*-----------new code----------------*/
        [AllowJsonGet]
        public async Task<JsonResult> PaynowResult()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            var d = await PayNow();
            var data = JsonConvert.DeserializeObject(d);
            // Response.Write(d.error);
            JObject jObj = (JObject)data; //initialized somewhere, perhaps in your foreach
            var msgProperty = jObj.Property("error");

            //check if property exists
            if (msgProperty != null)
            {
                m.flag = false;
                m.message = this.LanguageChange("Data Was Wrong");
                m.result = d;

            }
            else
            {
                PaymentgatewayData p = new PaymentgatewayData();
                p.Gatewaydata = d;
                db.PaymentgatewayData.Add(p);
                db.SaveChanges();
                
                m.flag = true;
                m.message = this.LanguageChange("Payment Send");
                m.result = p.ID;

            }

            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault()};

}


            public async Task<String> PayNow()
        {
            

            String Trns = this.GenerateRandom_Trns(5);
            String URL;
            String CardNO    = Convert.ToString(Request["cardNo"]);
            Int32  Month     = Convert.ToInt32(Request["month"]);
            Int32  Year      = Convert.ToInt32(Request["year"]);
            Int32  CVV       = Convert.ToInt32(Request["cvv"]);
            Double AMOUNT    = Convert.ToDouble(Request["amount"]);
            String Order     = this.GenerateRandom_Trns(2) ;
            
            URL = "https://eu-gateway.mastercard.com/api/rest/version/49/merchant/TEST4003464/order/" + Order + "/transaction/" + Trns;
            //Response.Write(URL);
            String username = "merchant.TEST4003464";
            String password = "da55f77d0fdcab48ac9cda2901a8e0ba";
            var data = await pay.PaymentMethod(URL, username , password, CardNO, Month, Year, CVV, AMOUNT);
            //Response.Write((data));
            //Response.Write(JsonConvert.SerializeObject(data));
            return (data);
        }




        public async Task<String> CreatePaySession()
        {
            String Order = this.GenerateRandom_Trns(2);
            String URL;
            Double AMOUNT = Convert.ToDouble(Request["amount"]);
            String CURR = "AED";

            String EMAIL = Request["PayEmail"].ToString(); 
            String PHONE = Request["PayPhone"].ToString();
            String FNAME = Request["PayfName"].ToString();
            String LNAME = Request["PaylName"].ToString();

            URL = "https://eu-gateway.mastercard.com/api/rest/version/49/merchant/TEST4003464/session/";
            String username = "merchant.TEST4003464";
            String password = "da55f77d0fdcab48ac9cda2901a8e0ba";
            var data = await pay.PaymentMethodSession(URL, username, password, Order, AMOUNT, CURR, EMAIL, PHONE, FNAME, LNAME);
            return (data);
        }

        [AllowJsonGet]
        public JsonResult SetMsg(String msg="",int type=1)
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String c = "";
            switch (type)
            {
                case 1:
                    c = "success";
                    break;
                case 2:
                    c = "danger";
                    break;
            }
                Session["sweetMsg"] = "<div class='alert alert-"+c+"'>"+ this.LanguageChange(msg) + "</div>";

                m.flag = true;
                m.message = c;
                m.result = Session["sweetMsg"];

                APIRES.Add(m);
                return new JsonResult { Data = APIRES.FirstOrDefault() };
            }

        public String LanguageChangeP(String text, int ID)
        {
            String lang;
            lang = "en";
            if(Request["lang"]!=null)
            { 
                lang = Request["lang"];
            }
            Language data;
            if (ID > 0)
            {
                data = db.Language.Where(h => h.en.Contains(text) && h.Keys.Contains(ID.ToString())).FirstOrDefault();
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



    }
}