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
using System.Text.RegularExpressions;
using System.Drawing;

using System.Drawing.Drawing2D;

namespace sweetnes18.Areas.Vendor.Controllers
{
    public class transaction {
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
        public String  OrderID{ get; set; }
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
    public class graphdata {
        public string dates { get; set; }
        public string purchaseCount { get; set; }
        public string purchaseCost { get; set; }
    }


    public class VendorApiController : Controller
    {

        private conn db = new conn();
        private ProductUpdate fun = new ProductUpdate();
        private Mobilemsg MOBILE = new Mobilemsg();
        private Common cfn = new Common();
        private DatabaseConnection abcd = new DatabaseConnection();
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
        /*-------------------Dashboard Data-------------*/
       



        [AllowJsonGet]
        public JsonResult Dashboard()
        {
            
            Double AllAmount = 0;
            Double PendingAmount = 0;
            Double ClearAmount = 0;
            
            Int32 userid = Convert.ToInt32(Request["user"]);
            var dashboard = db.ProductBundle.Where(h=>h.VendorID== userid && (h.pickanddeliverStatus != -2 || h.pickanddeliverStatus != -3 || h.pickanddeliverStatus != -4) ).ToList();
            foreach (ProductBundle pb in dashboard)
            {
                CartData detailsdata = JsonConvert.DeserializeObject<CartData>(pb.OrderSummary);
                
                pb.ProductPricing= pb.ProductPricing-Common.ApplyAdminAmountFormula(pb.ProductPricing);
                pb.ProductPricing = pb.ProductPricing - detailsdata.ShippingCost;
                AllAmount = AllAmount+pb.ProductPricing;
                if(pb.payable==0 && pb.pickanddeliverStatus<6)
                { 
                    PendingAmount = PendingAmount + pb.ProductPricing;
                }
                if (pb.payable == 1 && pb.pickanddeliverStatus >= 6)
                {
                    ClearAmount = ClearAmount + pb.ProductPricing;
                }
            }
            
            List<Dashboarddata> DBS = new List<Dashboarddata>();
            Dashboarddata D = new Dashboarddata();
            D.AllPayment = Math.Round(AllAmount,2);
            D.ClearPayment = Math.Round(ClearAmount,2);
            D.PendingPayment = Math.Round(PendingAmount,2);
            D.Order = db.ProductBundle.Where(h => h.VendorID == userid).ToList().Count();
            D.Product = db.Products.Where(h => h.UserID == userid && h.productStatus!=-2).ToList().Count();
            D.Customer = db.ProductBundle.Where(h => h.VendorID == userid).ToList().Count();
            DBS.Add(D);
            Object Response = 0;
            Response = this.Responsedata(true, "Dashboard Data", DBS.ToList());
            return new JsonResult { Data = Response };
        }


        [AllowJsonGet]
        public JsonResult ProductStatus()
        {
            object response = "";
            Int32  ProID = Convert.ToInt32(Request["ProductID"]);
            Int32 Status = Convert.ToInt32(Request["Status"]); 

            Products proStstus = db.Products.Where(h => h.ProductID == ProID).FirstOrDefault();
            if (Status == -2)
            {
                proStstus.productStatus = -2;
            }
            else {
                if (Status == 1)
                {
                    proStstus.productStatus = 0;
                }
                else
                {
                    proStstus.productStatus = 1;
                }
            }
            db.SaveChanges();
            response = this.Responsedata(true,"Product Status update", proStstus);
            return new JsonResult { Data = response };
        }





        /*-------------------Dashboard Data-------------*/
        [AllowJsonGet]
        public JsonResult Login()
        {
            String userid = cfn.mobliefilter(Convert.ToString(Request["user"]));
            String pass = Convert.ToString(Request["pass"]);
            var Vendor = db.user.Where(h => h.status == 1 && h.usertype == 2 && (h.username.Trim() == userid.Trim() || h.mobileno.Trim() ==(userid.Trim())) && h.password.Trim() == (pass.Trim())).FirstOrDefault();
            Object response = 0;
            if (Vendor != null)
            {
                if (Vendor.password != pass)
                {
                    response = this.Responsedata(false, "PassWord Wrong", null);
                }
                else if (Vendor.username != userid || Vendor.mobileno != userid)
                {
                    response = this.Responsedata(false, "User ID Wrong", null);
                }
                response = this.Responsedata(true, "Vendor Login", Vendor);
            }
            else
            {
                var V = db.user.Where(h => h.username.Trim() == userid.Trim() || h.mobileno.Trim() == (userid.Trim())).FirstOrDefault();
                if (V == null)
                {
                    
                    response = this.Responsedata(false, "Entered Email id/Phone number is not registered", Vendor);

                }
                else {
                    if (V.usertype == 1)
                    {
                        response = this.Responsedata(false, "Entered Email id/Phone number is registered for Customer", Vendor);
                    }
                    else { 
                        response = this.Responsedata(false, "User name or password is wrong", Vendor);
                }
                }

            }
            return new JsonResult { Data = response };
        }
        /*-----------------Register-----------------------*/
        [AllowJsonGet]
        public JsonResult Register()
        {
            Object response = 0;
            string fname = Request["fname"].ToString();
            string pass = Request["password"].ToString();
            string mobile = cfn.mobliefilter(Request["mobileno"].ToString());
            Int32 status = Convert.ToInt32(1);
            Int32 utype = Convert.ToInt32(2);
            string email = Request["email"].ToString();
            string city = Request["city"].ToString();
            string token = Request["token"].ToString();
            string device = Request["device"].ToString();
            string Vatnumber = Request["Vatnumber"].ToString();


            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            if (Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {

                var exist2 = db.user.Where(x => x.username == email && x.mobileno == mobile).FirstOrDefault();
                if (exist2 == null)
                {
                    var exist = db.user.Where(x => x.mobileno == mobile).FirstOrDefault();
                    if (exist == null)
                    {
                        if (mobile.Length >= 9 && mobile.Length <= 10)
                        {
                            var exist1 = db.user.Where(x => x.username == email).FirstOrDefault();
                            if (exist1 == null)
                            {
                                List<user> slide = new List<user>();
                                user a = new user();

                                a.fname = fname;
                                a.password = pass;
                                a.mobileno = cfn.mobliefilter(mobile);
                                a.status = status;
                                a.usertype = utype;
                                a.username = email;
                                a.mobiletoken = token;
                                a.devicetype = device;
                                a.City = city;
                                db.user.Add(a);
                                db.SaveChanges();
                                var register = (db.user.Where(x => x.mobileno == mobile && x.username == email).FirstOrDefault());
                                List<Usersmeta> UM = new List<Usersmeta>();
                                Usersmeta U = new Usersmeta();
                                U.metakey = "Vatnumber";
                                U.metavalue = Vatnumber;
                                U.userid = register.id;

                                db.Usersmeta.Add(U);
                                db.SaveChanges();
                                cfn.RegisterShippingStatus(register.id);

                                response = Responsedata(true, "Register Successful", register);




                            }
                            else
                            {
                                response = Responsedata(false, "Email Id Already Used", null);
                            }
                        }
                        else {
                            response = Responsedata(false, "Please enter valid mobile number", null);
                        }
                    }
                    else
                    {
                        response = Responsedata(false, "Mobile Number Already Used", null);
                    }
                }
                else
                {
                    response = Responsedata(false, "Mobile Number/Email Already Used", null);
                }
            }
            else
            {
                response = Responsedata(false, "Please Enter Valid Email id", null);

            }
            return new JsonResult { Data = response };
        }
    /*-----------------Product-----------------------*/
        /*-----------------Product List-----------------------*/
        [AllowJsonGet]
        public JsonResult ProductList()
        {
            Object response = 0;
            int uid = Convert.ToInt32(Request["user"]);
            int Page = 0;
            int PageC = 5;
            if (Request["p"] != null)
            {
                Page = Convert.ToInt32(Request["p"])-1;
                if (Page < 0)
                {
                    Page = 0;
                }
            }
            else
            {
                PageC = 5000;
            }

            List<ProductsListData> PRODUCT = new List<ProductsListData>();


            Int32 Pcount = PageC * Page;
            var p = db.Products.Where(h => h.UserID == uid && h.productStatus != -2).OrderByDescending(x => x.ProductID).Skip(Pcount).Take(PageC);
            foreach (Products pp in p)
            {
                ProductsListData PRO = new ProductsListData();
                PRO.ProductTitle = pp.ProductTitle;
                PRO.ProductTitleAr = this.LanguageChangeP(pp.ProductTitle,pp.ProductID);
                PRO.SKU = pp.SKU;
                PRO.UserID = pp.UserID;
                PRO.productStatus = pp.productStatus;
                PRO.ProductSalePrice = pp.ProductSalePrice;
                PRO.ProductRegulerPrice = pp.ProductRegulerPrice;
                PRO.ProductQun = pp.ProductQun;
                PRO.productimg = this.Getnoimg(pp.productimg);
                PRO.productimage = this.Getnoimg(pp.productimage);
                PRO.ProductID = pp.ProductID;
                PRO.ProductDec = pp.ProductDec;
                PRO.ProductDecAr = this.LanguageChangeP(pp.ProductDec,pp.ProductID);
                PRO.PreperationTime = pp.PreperationTime;
                PRO.IsCustomized = pp.IsCustomized;
                PRO.NumberofVisit = pp.NumberofVisit;
                PRO.CatID = pp.CatID;
                PRO.BrandID = pp.BrandID;
                PRO.vendoroffer = pp.vendoroffer;
                var imgs= db.ProductMeta.Where(h => h.ProductID == pp.ProductID && (h.ProductTypeKey.Contains("Images") || h.ProductTypeKey.Contains("gallery"))).ToList();
                List<String> IMG = new List<String>();
                
                foreach (ProductMeta p1 in imgs)
                {
                    IMG.Add(this.Getnoimg(p1.ProductValue));
                    
                }
                
                PRO.images = IMG.ToList();
                var Additi = db.ProductMeta.Where(h => h.ProductID == pp.ProductID && h.ProductTypeKey.Contains("AdditionalInformation")).ToList();
                List<ProductMetad> PAD = new List<ProductMetad>();
                foreach (ProductMeta p1 in Additi)
                {
                    ProductMetad PD = new ProductMetad();
                    if (p1.ProductKey.Trim().Length > 0)
                    {
                        PD.ProductKey = p1.ProductKey;
                        PD.ProductKeyAr = this.LanguageChangeP(p1.ProductKey, pp.ProductID);
                        PD.ProductValue = p1.ProductValue;
                        PD.ProductValueAr = this.LanguageChangeP(p1.ProductValue, pp.ProductID);
                        PAD.Add(PD);
                    }
                }
                
                PRO.Additional= PAD.ToList();
                var Specif= db.ProductMeta.Where(h => h.ProductID == pp.ProductID && h.ProductTypeKey.Contains("specifications")).ToList();
                List<ProductMetad> SPC = new List<ProductMetad>();
                foreach (ProductMeta p1 in Specif)
                {
                    ProductMetad PS = new ProductMetad();
                    if (p1.ProductKey.Trim().Length > 0) { 
                        PS.ProductKey = p1.ProductKey;
                        PS.ProductKeyAr = this.LanguageChangeP(p1.ProductKey, pp.ProductID);
                        PS.ProductValue = p1.ProductValue;
                        PS.ProductValueAr = this.LanguageChangeP(p1.ProductValue, pp.ProductID);
                        SPC.Add(PS);
                    }
                }
                PRO.Specif = SPC.ToList();
                PRO.ActualAmount = pp.ActualAmount;
                PRODUCT.Add(PRO);
            }
            
            if (PRODUCT.ToList().Count() > 0)
            {
                response = Responsedata(true, "Product List", PRODUCT.ToList());

            }
            else
            {
                response = Responsedata(false, "No Product Found", null);

            }

            return new JsonResult { Data = response };
        }

        /*-----------------Product List-----------------------*/
        [AllowJsonGet]
        public JsonResult ProductListP()
        {
            Object response = 0;
            int uid = Convert.ToInt32(Request["user"]);
            int Page = 0;
            int PageC = 5;
            if (Request["p"] != null)
            {
                Page = Convert.ToInt32(Request["p"]);
            }
            else {
                PageC = 5000;
            }

            List<ProductsListData> PRODUCT = new List<ProductsListData>();


            Int32 Pcount = PageC * Page;
            var p = db.Products.Where(h => h.UserID == uid && h.productStatus != -2).OrderByDescending(x => x.CreatedDate).Skip(Pcount).Take(PageC);
            foreach (Products pp in p)
            {
                ProductsListData PRO = new ProductsListData();
                PRO.ProductTitle = pp.ProductTitle;
                PRO.ProductTitleAr = this.LanguageChangeP(pp.ProductTitle, pp.ProductID);
                PRO.SKU = pp.SKU;
                PRO.ProductSalePrice = pp.ProductSalePrice;
                PRO.ProductRegulerPrice = pp.ProductRegulerPrice;
                PRO.ProductQun = pp.ProductQun;
                PRO.productimg = this.Getnoimg(pp.productimg);
                PRO.productimage = this.Getnoimg(pp.productimage);
                PRO.ProductID = pp.ProductID;
                PRO.ProductDec = pp.ProductDec;
                PRO.ProductDecAr = this.LanguageChangeP(pp.ProductDec, pp.ProductID);
                PRO.PreperationTime = pp.PreperationTime;
                PRO.IsCustomized = pp.IsCustomized;
                PRO.NumberofVisit = pp.NumberofVisit;
                PRO.CatID = pp.CatID;
                PRO.BrandID = pp.BrandID;
                PRO.vendoroffer = pp.vendoroffer;
                var imgs = db.ProductMeta.Where(h => h.ProductID == pp.ProductID && (h.ProductTypeKey.Contains("Images") || h.ProductTypeKey.Contains("gallery"))).ToList();
                List<String> IMG = new List<String>();
                foreach (ProductMeta p1 in imgs)
                {
                    IMG.Add(this.Getnoimg(p1.ProductValue));

                }
                PRO.images = IMG.ToList();
                var Additi = db.ProductMeta.Where(h => h.ProductID == pp.ProductID && h.ProductTypeKey.Contains("AdditionalInformation")).ToList();
                List<ProductMetad> PAD = new List<ProductMetad>();
                foreach (ProductMeta p1 in Additi)
                {
                    ProductMetad PD = new ProductMetad();
                    if (p1.ProductKey.Trim().Length > 0)
                    {
                        PD.ProductKey = p1.ProductKey;
                        PD.ProductKeyAr = this.LanguageChangeP(p1.ProductKey, pp.ProductID);
                        PD.ProductValue = p1.ProductValue;
                        PD.ProductValueAr = this.LanguageChangeP(p1.ProductValue, pp.ProductID);
                        PAD.Add(PD);
                    }
                }

                PRO.Additional = PAD.ToList();
                var Specif = db.ProductMeta.Where(h => h.ProductID == pp.ProductID && h.ProductTypeKey.Contains("specifications")).ToList();
                List<ProductMetad> SPC = new List<ProductMetad>();
                foreach (ProductMeta p1 in Specif)
                {
                    ProductMetad PS = new ProductMetad();
                    if (p1.ProductKey.Trim().Length > 0)
                    {
                        PS.ProductKey = p1.ProductKey;
                        PS.ProductKeyAr = this.LanguageChangeP(p1.ProductKey, pp.ProductID);
                        PS.ProductValue = p1.ProductValue;
                        PS.ProductValueAr = this.LanguageChangeP(p1.ProductValue, pp.ProductID);
                        SPC.Add(PS);
                    }
                }
                PRO.Specif = SPC.ToList();
                PRO.ActualAmount = pp.ActualAmount;
                PRODUCT.Add(PRO);
            }

            if (PRODUCT.ToList().Count() > 0)
            {
                response = Responsedata(true, "Product List", PRODUCT.ToList());

            }
            else
            {
                response = Responsedata(false, "No Product Found", null);

            }

            return new JsonResult { Data = response };
        }

        /*-----------------Product Details-----------------------*/
        [AllowJsonGet]
        public JsonResult ProductDetailById()
        {
            Object response = 0;
            Int64 id = Convert.ToInt64(Request["id"]);

            var p = db.Products.Where(h => h.ProductID==id).FirstOrDefault();
           
                response = Responsedata(true, "Product Details", p);
                return new JsonResult { Data = response };
        }
        /*-----------------Product Delete-----------------------*/
        [AllowJsonGet]
        public JsonResult ProductDelete()
        {
            Object response = 0;
            Int64 pid = Convert.ToInt64(Request["PRODUCTID"]);
            var p = db.Products.Where(h => h.ProductID == pid).FirstOrDefault();
            if (p!=null)
            {
                
                p.productStatus = -2;
                db.SaveChanges();
                response = Responsedata(true, "Product Delete Success", p);
            }
            else
            {
                response = Responsedata(false, "This Product already Delete", null);

            }

            return new JsonResult { Data = response };
        }
        /*-----------------Add Product-----------------------*/

        [AllowJsonGet]
        public JsonResult AddProduct()
        {
            /*------------Variable-------------------*/
            Object response = 0;
            String ProductnameEn = Convert.ToString(Request["pnameen"]);
            String ProductnameAr = Convert.ToString(Request["pnameAr"]);
            Int16 brandid        = Convert.ToInt16(Request["brand"]);
            Int16 catid          = Convert.ToInt16(Request["cat"]);
            String SKU           = Convert.ToString(Request["sku"]);
            Double Price         = Convert.ToDouble(Request["price"]);
            Int32 qun            = Convert.ToInt32(Request["qun"]);
            String pDecEn        = Convert.ToString(Request["pdecen"]);
            String PDecAr        = Convert.ToString(Request["pdecar"]);
            Int16 offer          = Convert.ToInt16(Request["offer"]);
            Int16 VendorID       = Convert.ToInt16(Request["VendorID"]);
            Int16 iscustom = 0;
            Int16 iscustomDays = 0;


            if (!String.IsNullOrEmpty(Request["iscustom"]) &&  Request["iscustom"].ToString().Trim().Length>0)
            {
                iscustom = Convert.ToInt16(Request["iscustom"].ToString());
            }
            if (!String.IsNullOrEmpty(Request["customdays"]) && Request["customdays"].ToString().Trim().Length > 0)
            {
                iscustomDays = Convert.ToInt16(Request["customdays"]);
            }
            String IMages        = Convert.ToString(Request["Images"]);
            
            if (brandid == 0)
            {
                response = Responsedata(false, "Please Enter Valid Brand Id", null);
            }
            else if (catid == 0)
            {
                response = Responsedata(false, "Please Enter Valid Category Id", null);
            }
            else if (VendorID == 0)
            {
                response = Responsedata(false, "Please Enter Valid Vendor ID", null);
            }
            else if (offer < 0 && offer > 100)
            {
                response = Responsedata(false, "Please Enter Valid Offer valid", null);
            }
            else if (iscustom < 0 && iscustom > 1)
            {
                response = Responsedata(false, "Is Custom is not valid", null);
            }
            else if (iscustomDays < 0 && iscustomDays >= 15)
            {
                response = Responsedata(false, "Please Enter Valid Customization Days", null);
            }
            else if (Price < 0)
            {
                response = Responsedata(false, "Please Enter Valid Price", null);
            }
            else if (qun < 0)
            {
                response = Responsedata(false, "Please Enter Valid Quntity", null);
            }
            else
            {
                Products p = new Products();
                p.ProductTitle = ProductnameEn;
                p.SKU = "SWEET-" + (db.Products.ToList().Count() + 1).ToString();
                p.CatID = catid;
                p.BrandID = brandid;
                p.adminoffer = 0;
                p.vendoroffer = offer;
                p.ActualAmount = Price.ToString();
                p.ProductQun = qun;
                p.ProductSalePrice = Price.ToString();
                p.UserID = VendorID;
                if (offer > 0)
                {
                    p.ProductRegulerPrice = (Price - ((Price * offer) / 100)).ToString();
                }
                else {
                    p.ProductRegulerPrice = 0.ToString();
                }

                
                var userdata=db.user.Where(h => h.id == VendorID).FirstOrDefault();
                var useradd = db.Usersmeta.Where(h => h.metakey.Contains("add") && h.userid == VendorID).FirstOrDefault();
                String msgs = "";
                
                p.productStatus = productpublishChk(brandid, catid);
                msgs = "Product Added successfully";
                if (Convert.ToInt32(userdata.City) == 0)
                {
                    p.productStatus = 0;
                    msgs = "Vendor City Not Select Complete But Product Upload";
                }
                /* if (userdata.status==0)
                 {
                     p.productStatus = 0;
                     msgs = "Vendor Status Unpublish Complete But Product Upload";
                 }
                 if (String.IsNullOrEmpty(useradd.metavalue))
                 {
                     p.productStatus = 0;
                     msgs = "Vendor Address Not Complete But Product Upload";
                 }
                 */
                String Path = "/img/Product/";
                string[] Img = IMages.Split(',');
                p.productimage = this.CreateThumbnail(0, 0, this.Getnoimg(Path + Img[0]));
                p.productimg = this.CreateThumbnail(0, 0, this.Getnoimg(Path + Img[0]));
                p.ProductDec = pDecEn;
                p.IsCustomized = iscustom;
                p.PreperationTime = iscustomDays;
                db.Products.Add(p);
                db.SaveChanges();
                var productID = p.ProductID;
                /*--------------------ProductExtraImages----------*/
                for (int i = 1; i < 5; i++)
                {
                    
                    { 
                        String img = this.Getnoimg(Path + Img[i]);
                        fun.UpdateProductMeta(productID, "gallery", "Images", this.CreateThumbnail(0, 0, img));
                    }
                }
                /*--------------------ProductExtraImages----------*/

                String TitleA = Request["pnameAr"];
                String TitleEn = Request["pnameen"];

                String ContentA = Request["pdecar"];
                String ContentEn = Request["pdecen"];
                if (TitleA == "")
                {
                    TitleA = TitleEn;
                }
                if (ContentA == "")
                {
                    ContentA = ContentEn;
                }
                Language Lang = new Language();
                Lang.Keys = productID.ToString();
                Lang.en = TitleEn.Trim();
                Lang.ar = TitleA.Trim();
                db.Language.Add(Lang);
                db.SaveChanges();
                Lang.Keys = productID.ToString();
                Lang.en = (ContentEn.Trim());
                Lang.ar = ContentA.Trim();
                db.Language.Add(Lang);
                db.SaveChanges();

                /*-----------------------------------*/

                Int32 SpecCount = Convert.ToInt32(Request["specifcount"]);
                Int32 AddCount = Convert.ToInt32(Request["addiotionalcount"]);
                if(SpecCount>0)
                { 
                    for (int i = 1; i <= SpecCount; i++)
                    {
                        Language LangSp = new Language();
                        String SPcKeyEn = Convert.ToString(Request["SpecifKEn" + i]);
                        String SPcValEn = Convert.ToString(Request["SpecifVEn" + i]);
                        String SPcKeyAr = Convert.ToString(Request["SpecifKEn" + i]);
                        String SPcValAr = Convert.ToString(Request["SpecifVAr" + i]);


                        if (!String.IsNullOrEmpty(SPcValEn))
                        {
                            ProductMeta pm = new ProductMeta();
                            pm.ProductID = productID;
                            pm.ProductTypeKey = "specifications";
                            pm.ProductKey = SPcKeyEn;
                            pm.ProductValue = SPcValEn;
                            db.ProductMeta.Add(pm);
                            db.SaveChanges();


                            LangSp.Keys = productID.ToString();
                            LangSp.en = (SPcKeyEn.Trim());
                            LangSp.ar = SPcKeyAr.Trim();
                            db.Language.Add(LangSp);
                            db.SaveChanges();

                            LangSp.Keys = productID.ToString();
                            LangSp.en = SPcValEn.Trim();
                            LangSp.ar = SPcValAr.Trim();
                            db.Language.Add(LangSp);
                            db.SaveChanges();
                        }
                    }
                }
                if (AddCount > 0) { 
                    for (int i = 1; i <= AddCount; i++)
                    {
                        Language LangAd = new Language();
                        String AddKeyEn = Convert.ToString(Request["AinfoKEn" + i]);
                        String AddValEn = Convert.ToString(Request["AinfoVEn" + i]);
                        String AddKeyAr = Convert.ToString(Request["AinfoKAr" + i]);
                        String AddValAr = Convert.ToString(Request["AinfoVAr" + i]);

                        if (!String.IsNullOrEmpty(AddValEn))
                        { 
                        ProductMeta pm = new ProductMeta();
                        pm.ProductID = productID;
                        pm.ProductTypeKey = "AdditionalInformation";
                        pm.ProductKey = AddKeyEn;
                        pm.ProductValue = AddValEn;
                        db.ProductMeta.Add(pm);
                        db.SaveChanges();


                        LangAd.Keys = productID.ToString();
                        LangAd.en = (AddKeyEn.Trim());
                        LangAd.ar = AddKeyAr.Trim();
                        db.Language.Add(LangAd);
                        db.SaveChanges();

                        LangAd.Keys = productID.ToString();
                        LangAd.en = AddValEn.Trim();
                        LangAd.ar = AddValAr.Trim();
                        db.Language.Add(LangAd);
                        db.SaveChanges();
                        }
                    }
                }
                /*-----------------------------------*/


                fun.productupdate();

                response = Responsedata(true, msgs, db.Products.Where(h=>h.ProductID== productID));
            }
            return new JsonResult { Data = response };
        }

        public int productpublishChk(int brandID, int CATID)
        {
            var cat = db.ProductCategory.Where(h => h.ID == CATID && h.CategoryStatus == 1).ToList().Count();
            var brand = db.ProductBrand.Where(h => h.ID == brandID && h.BrandStatus == 1).ToList().Count();
            return cat * brand;

        }

        /*-----------------Add Product-----------------------*/
        [AllowJsonGet]
        public JsonResult EditProduct()
        {
            /*------------Variable-------------------*/
            Object response = 0;
            String ProductnameEn = Convert.ToString(Request["pnameen"]);
            String ProductnameAr = Convert.ToString(Request["pnameAr"]);
            Int16  brandid = Convert.ToInt16(Request["brand"]);
            Int16  catid = Convert.ToInt16(Request["cat"]);
            String SKU = Convert.ToString(Request["sku"]);
            Double Price = Convert.ToDouble(Request["price"]);
            Int32  qun = Convert.ToInt32(Request["qun"]);
            String pDecEn = Convert.ToString(Request["pdecen"]);
            String PDecAr = Convert.ToString(Request["pdecar"]);
            Int16  offer = Convert.ToInt16(Request["offer"]);
            Int16  VendorID = Convert.ToInt16(Request["VendorID"]);
            Int16 iscustom = 0;
            Int16 iscustomDays = 0;


            if (!String.IsNullOrEmpty(Request["iscustom"]) && Request["iscustom"].ToString().Trim().Length > 0)
            {
                iscustom = Convert.ToInt16(Request["iscustom"].ToString());
            }
            if (!String.IsNullOrEmpty(Request["customdays"]) && Request["customdays"].ToString().Trim().Length > 0)
            {
                iscustomDays = Convert.ToInt16(Request["customdays"]);
            }
            String IMages = Convert.ToString(Request["Images"]);
            int ProductID = Convert.ToInt32(Request["ProductID"]);

            if (brandid == 0)
            {
                response = Responsedata(false, "Please Enter Valid Brand Id", null);
            }
            else if (catid == 0)
            {
                response = Responsedata(false, "Please Enter Valid Category Id", null);
            }
            else if (VendorID == 0)
            {
                response = Responsedata(false, "Please Enter Valid Vendor ID", null);
            }
            else if (offer < 0 && offer > 100)
            {
                response = Responsedata(false, "Please Enter Valid Offer valid", null);
            }
            else if (iscustom < 0 && iscustom > 1)
            {
                response = Responsedata(false, "Is Custom is not valid", null);
            }
            else if (iscustomDays < 0 && iscustomDays >= 15)
            {
                response = Responsedata(false, "Please Enter Valid Customization Days", null);
            }
            else if (Price < 0)
            {
                response = Responsedata(false, "Please Enter Valid Price", null);
            }
            else if (qun < 0)
            {
                response = Responsedata(false, "Please Enter Valid Quntity", null);
            }
            else
            {
                Products p = db.Products.Where(h=>h.ProductID == ProductID).FirstOrDefault();
                p.ProductTitle = ProductnameEn;
                p.SKU = "SWEET-" + ProductID.ToString();
                p.CatID = catid;
                p.BrandID = brandid;
                p.adminoffer = 0;
                p.vendoroffer = offer;
                p.ActualAmount = Price.ToString();
                p.ProductQun = qun;
                p.ProductSalePrice = Price.ToString();
                p.UserID = VendorID;
                p.IsCustomized = iscustom;
                p.PreperationTime = iscustomDays;
                if (offer > 0)
                {
                    p.ProductRegulerPrice = (Price - ((Price * offer) / 100)).ToString();
                }
                else
                {
                    p.ProductRegulerPrice = 0.ToString();
                }
                

                var userdata = db.user.Where(h => h.id == VendorID).FirstOrDefault();
                var useradd = db.Usersmeta.Where(h => h.metakey.Contains("add") && h.userid == VendorID).FirstOrDefault();
                String msgs = "";
                p.productStatus = productpublishChk(brandid, catid);
                
                msgs = "Product Added successfully";
                if (p.productStatus==0)
                {
                    p.productStatus = 0;
                    msgs = "Vendor City Not Select Complete But Product Upload";
                }
                if (Convert.ToInt32(userdata.City) == 0)
                {
                    p.productStatus = 0;
                    msgs = "Vendor City Not Select Complete But Product Upload";
                }
                /* if (userdata.status==0)
                 {
                     p.productStatus = 0;
                     msgs = "Vendor Status Unpublish Complete But Product Upload";
                 }
                 if (String.IsNullOrEmpty(useradd.metavalue))
                 {
                     p.productStatus = 0;
                     msgs = "Vendor Address Not Complete But Product Upload";
                 }
                 */
                String Path = "/img/Product/";
                string[] Img = IMages.Split(',');
                p.productimage = this.CreateThumbnail(0, 0, Path + Img[0]);
                p.productimg = this.CreateThumbnail(0, 0, Path + Img[0]);
                p.ProductDec = pDecEn;
                db.SaveChanges();
                String IDL=ProductID.ToString();
                var Langdbs=db.Language.Where(h => h.Keys.Contains(IDL)).ToList();
                if(Langdbs.Count()>0)
                { 
                     abcd.Select("delete [dbo].[Language] where Keys like '" + IDL + "'");
                }
                var metadata = db.ProductMeta.Where(h => h.ProductID == ProductID).ToList();
                if (metadata.Count() > 0)
                { 
                    abcd.Select("delete [dbo].[ProductMeta] where ProductID='" + ProductID + "'");
                }
                /*--------------------ProductExtraImages----------*/
                for (int i = 1; i < Img.Length; i++)
                {
                    if (Img[i].Trim().Length > 0)
                    {
                        String img = Path + Img[i];
                        fun.UpdateProductMeta(ProductID, "gallery", "Images", this.CreateThumbnail(0, 0, Path + Img[i]));
                        /*ProductMeta pm = new ProductMeta();
                        pm.ProductID = ProductID;
                        pm.ProductKey = "Images";
                        pm.ProductTypeKey = "gallery";
                        pm.ProductValue = this.CreateThumbnail(0, 0, Path + Img[i]);
                        db.ProductMeta.Add(pm);
                        db.SaveChanges();*/
                    }
                }
                /*--------------------ProductExtraImages----------*/

                String TitleA = Request["pnameAr"];
                String TitleEn = Request["pnameen"];

                String ContentA = Request["pdecar"];
                String ContentEn = Request["pdecen"];
                if (TitleA == "")
                {
                    TitleA = TitleEn;
                }
                if (ContentA == "")
                {
                    ContentA = ContentEn;
                }
                Language Lang = new Language();
                Lang.Keys = ProductID.ToString();
                Lang.en = TitleEn.Trim();
                Lang.ar = TitleA.Trim();
                db.Language.Add(Lang);
                db.SaveChanges();
                Lang.Keys = ProductID.ToString();
                Lang.en = (ContentEn.Trim());
                Lang.ar = ContentA.Trim();
                db.Language.Add(Lang);
                db.SaveChanges();

                /*-----------------------------------*/

                Int32 SpecCount = Convert.ToInt32(Request["specifcount"]);
                Int32 AddCount = Convert.ToInt32(Request["addiotionalcount"]);
                if (SpecCount > 0)
                {
                    for (int i = 1; i <= SpecCount; i++)
                    {
                        if (Convert.ToString(Request["SpecifKEn" + i]).Trim().Length > 0)
                        {
                            Language LangSp = new Language();
                            String SPcKeyEn = Convert.ToString(Request["SpecifKEn" + i]);
                            String SPcValEn = Convert.ToString(Request["SpecifVEn" + i]);
                            String SPcKeyAr = Convert.ToString(Request["SpecifKAr" + i]);
                            String SPcValAr = Convert.ToString(Request["SpecifVAr" + i]);


                            if (!String.IsNullOrEmpty(SPcValEn))
                            {
                                ProductMeta pm = new ProductMeta();
                                pm.ProductID = ProductID;
                                pm.ProductTypeKey = "specifications";
                                pm.ProductKey = SPcKeyEn;
                                pm.ProductValue = SPcValEn;
                                db.ProductMeta.Add(pm);
                                db.SaveChanges();


                                LangSp.Keys = ProductID.ToString();
                                LangSp.en = (SPcKeyEn.Trim());
                                LangSp.ar = SPcKeyAr.Trim();
                                db.Language.Add(LangSp);
                                db.SaveChanges();

                                LangSp.Keys = ProductID.ToString();
                                LangSp.en = SPcValEn.Trim();
                                LangSp.ar = SPcValAr.Trim();
                                db.Language.Add(LangSp);
                                db.SaveChanges();
                            }
                        }
                    }
                }
                if (AddCount > 0)
                {
                    for (int i = 1; i <= AddCount; i++)
                    {
                        if (Convert.ToString(Request["AinfoKEn" + i]).Trim().Length > 0)
                        {
                            Language LangAd = new Language();
                            String AddKeyEn = Convert.ToString(Request["AinfoKEn" + i]);
                            String AddValEn = Convert.ToString(Request["AinfoVEn" + i]);
                            String AddKeyAr = Convert.ToString(Request["AinfoKAr" + i]);
                            String AddValAr = Convert.ToString(Request["AinfoVAr" + i]);

                            if (!String.IsNullOrEmpty(AddValEn))
                            {
                                ProductMeta pm = new ProductMeta();
                                pm.ProductID = ProductID;
                                pm.ProductTypeKey = "AdditionalInformation";
                                pm.ProductKey = AddKeyEn;
                                pm.ProductValue = AddValEn;
                                db.ProductMeta.Add(pm);
                                db.SaveChanges();


                                LangAd.Keys = ProductID.ToString();
                                LangAd.en = (AddKeyEn.Trim());
                                LangAd.ar = AddKeyAr.Trim();
                                db.Language.Add(LangAd);
                                db.SaveChanges();

                                LangAd.Keys = ProductID.ToString();
                                LangAd.en = AddValEn.Trim();
                                LangAd.ar = AddValAr.Trim();
                                db.Language.Add(LangAd);
                                db.SaveChanges();
                            }
                        }
                    }
                }
                /*-----------------------------------*/


                fun.productupdate();

                response = Responsedata(true, msgs, db.Products.Where(h => h.ProductID == ProductID));
            }
            return new JsonResult { Data = response };
        }

        /*-----------------Product-----------------------*/

        [AllowJsonGet]
        public JsonResult Brand()
        {
            Object response = 0;

            var p = db.ProductBrand.Where(h => h.BrandStatus > -2 && h.BrandName != "null" && h.BrandName != "").ToList();
            if (p.Count() > 0)
            {
                response = Responsedata(true, "All Brands List", p);
            }
            else
            {
                response = Responsedata(false, "No Brand Found", null);
            }
            return new JsonResult { Data = response };
        }

        [AllowJsonGet]
        public JsonResult Category()
        {
            Object response = 0;

            var p = db.ProductCategory.Where(h => h.CategoryStatus >-2 && h.CategoryName!= "null" && h.CategoryName != "").ToList();

            if (p.Count() > 0)
            {
                response = Responsedata(true, "All Category List", p);
            }
            else
            {
                response = Responsedata(false, "No Category Found", null);
            }
            return new JsonResult { Data = response };
        }


        [AllowJsonGet]
        public JsonResult OrdersShow()
        {
            String Msg = "";
            Object response = 0;
            List<ReverseCart> ReverseORDERD = new List<ReverseCart>();
            ReverseCart RO = new ReverseCart();

            
            int Page = 0;
            int PageC;
                PageC = 5;
            if (Request["p"] != null)
            {
                Page = Convert.ToInt32(Request["p"]) - 1;
                if (Page < 0)
                {
                    Page = 0;
                }
            }
            else
            {
                PageC = 5000;
            }



            List<OrderBandal> ORDERBANDAL = new List<OrderBandal>();

            Int32 type = Convert.ToInt32(Request["type"]);
            Int32 uid = Convert.ToInt32(Request["user"]);

            Int32 Pcount = PageC * Page;
            var v = db.ProductBundle.Where(x => x.VendorID == uid && x.OrderSummary != null).OrderByDescending(x => x.VendorID).Skip(Pcount).Take(PageC); ;

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
               
                if (!String.IsNullOrEmpty(v1.OrderSummary)) { 
                    O.MainCartdata = JsonConvert.DeserializeObject<CartData>(v1.OrderSummary);
                    O.MainCartdata.OrderStatus = O.OrderStatusMsg;
                    O.MainCartdata.pickanddeliverStatus = v1.pickanddeliverStatus;
                    O.MainCartdata.OrderCreatedDate = v1.CreatedDate.ToString();
                    O.MainCartdata.ProductSubtotal = (Convert.ToDouble(O.MainCartdata.Product.ActualAmount) * O.MainCartdata.ProductPurchaseQun) + Convert.ToDouble(0.00);
                    O.MainCartdata.Discount = Convert.ToDouble(O.MainCartdata.Product.adminoffer) + Convert.ToDouble(O.MainCartdata.Product.vendoroffer) + Convert.ToDouble(0.00);
                    O.MainCartdata.Discount = (O.MainCartdata.ProductSubtotal * O.MainCartdata.Discount / 100);
                    O.MainCartdata.Shipping = Convert.ToDouble(O.MainCartdata.ShippingCost);
                    O.MainCartdata.OrderTotal = O.MainCartdata.ProductSubtotal + O.MainCartdata.Shipping - O.MainCartdata.Discount+ Convert.ToDouble(0.00);
                    O.CancleImage = v1.cancelImage;
                    O.CancleMsg = v1.cancelMsg;
                    O.CustomizeImage = v1.customizationImage;
                    O.Customizemsg=v1.customizationmsg;

                }
                O.OrderID = v1.ProductOrderID;
                if (type == 1)
                { Msg = "All Order"; }
                if (type == 2)
                { Msg = "Pending Order"; }
                if (type == 3)
                { Msg = "Complete Order"; }
                if (type == 4)
                { Msg = "Cancel Order"; }

                if (type == 1)
                {
                    
                    ORDERBANDAL.Add(O);
                }
                else if (type == 2 && v1.pickanddeliverStatus <= 5 && v1.pickanddeliverStatus >= -1) {
                    ORDERBANDAL.Add(O);
                    
                }
                else if (type == 3 && v1.pickanddeliverStatus > 5)
                {
                   
                    ORDERBANDAL.Add(O);
                }
                else if (type == 4 && (v1.pickanddeliverStatus == -2 || v1.pickanddeliverStatus == -3 || v1.pickanddeliverStatus == -4))
                {
                    ORDERBANDAL.Add(O);
                    
                }

            }


            response = Responsedata(true, Msg, ORDERBANDAL);
            return new JsonResult { Data = response };
        }

        [AllowJsonGet]
        public JsonResult OrdersShowSingle()
        {
            String Msg = "";
            Object response = 0;
            List<ReverseCart> ReverseORDERD = new List<ReverseCart>();
            ReverseCart RO = new ReverseCart();


            List<OrderBandal> ORDERBANDAL = new List<OrderBandal>();

            Int32 type = 1;
            String OID = Convert.ToString(Request["orderid"]);
            var v = db.ProductBundle.Where(x => x.ProductOrderID.Trim() == OID.Trim() && x.OrderSummary != null).ToList();

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
        public JsonResult OrderApprove()
        {
            Boolean flag = true;
            String Msg = "";
            Object response = 0;
            String Id=Request["Order"].ToString();
            var order=db.ProductBundle.Where(h => h.ProductOrderID.Equals(Id)).Select(y=>y).FirstOrDefault();
            
            if (order!=null && order.pickanddeliverStatus == -1)
            {
                order.pickanddeliverStatus = 0;
                db.SaveChanges();
                Msg = "Order Approved";

                IDictionary<string, string> ShippingInfo = new Dictionary<string, string>() {
                                                    { "%#Ref#%", order.ProductOrderID},
                                                };

                Format Ship1 = new Format(18, ShippingInfo, db.Company.Where(x => x.ID == order.ShippingCompanyID).FirstOrDefault().shippingemail);

            }
            else {
                Msg = "Order not Approved";
                flag = false;
            }
            
            response = Responsedata(flag, Msg, order);
            return new JsonResult { Data = response };
        }

        [AllowJsonGet]
        public JsonResult transaction()
        {
            Int64 type = Convert.ToInt64(Request["type"]);
            Int64 Id = Convert.ToInt64(Request["vendor"]);
            String Msg = "";
            Double TotalAmount;
            Object response = 0;
            List<transaction> TRANSACTION = new List<transaction>();
            List<ProductBundle> Fin = new List<ProductBundle>(); ;
            String status = "";
            if (Id > 0)
            {
                if (type == 1)
                {
                    Fin = db.ProductBundle.Where(h => h.VendorID == Id && ( h.pickanddeliverStatus != -2 || h.pickanddeliverStatus != -3 || h.pickanddeliverStatus != -4 ) ).OrderBy(h=>h.Id).ToList();
                    status = "Dr";
                }
                else if (type == 2)
                {
                    status = "Dr";
                    Fin = db.ProductBundle.Where(h => h.payable == 0 && h.VendorID == Id && (h.pickanddeliverStatus != -2 || h.pickanddeliverStatus != -3 || h.pickanddeliverStatus != -4) ).OrderBy(h => h.Id).ToList();
                }
                else if (type == 3)
                {
                    status = "Cr";
                    Fin = db.ProductBundle.Where(h => h.payable == 1 && h.VendorID == Id && (h.pickanddeliverStatus != -2 || h.pickanddeliverStatus != -3 || h.pickanddeliverStatus != -4) ).OrderBy(h => h.Id).ToList();
                }
                Double mainBal = 0;
                Int64 I = 0;
                foreach (ProductBundle v in Fin)
                {
                    I++;
                    transaction T = new transaction();
                    CartData detailsdata = JsonConvert.DeserializeObject<CartData>(v.OrderSummary);
                    T.id = v.Id; 
                    T.dates =  v.CreatedDate.ToString();
                    T.Status = status;
                    T.TotalAmount = v.ProductPricing.ToString();
                    T.Shipping = detailsdata.ShippingCost.ToString();
                    T.AdminAmount = Common.ApplyAdminAmountFormula(v.ProductPricing).ToString(); 
                    T.PayableAmount = Common.ApplyPayableAmountFormula(v.ProductPricing , Convert.ToDouble(T.Shipping) , Convert.ToDouble(T.AdminAmount ) ).ToString();
                    T.OrderId = v.ProductOrderID;
                    T.Title = detailsdata.Product.ProductTitle;
                    T.Decription = detailsdata.Product.ProductTitle + " - Order #" + T.OrderId + " Gift Tin";
                    mainBal = (mainBal + Convert.ToDouble(T.PayableAmount) + Convert.ToDouble(0.00));
                    T.Balance = mainBal.ToString();
                    TRANSACTION.Add(T);
                }
                if (type == 1)
                {
                    response = Responsedata(true, "All Transaction", TRANSACTION.OrderByDescending(x => x.id).ToList());
                }
                else if (type == 2)
                {
                    response = Responsedata(true, "Pending Transaction", TRANSACTION.OrderByDescending(x => x.id).ToList());
                }
                else if (type == 3)
                {
                    response = Responsedata(true, "WithDrawal Transaction", TRANSACTION.OrderByDescending(x => x.id).ToList());
                }
                else
                {
                    response = Responsedata(false, "Please Enter Valid Type", "");
                }
            }
            else
            {
                response = Responsedata(false, "Please Enter valid Vendor ID", "");
            }
            return new JsonResult { Data = response };
        }



        [AllowJsonGet]
        public JsonResult transactionDetails()
        {
            Int64 ID = Convert.ToInt64(Request["ID"]);
            
            String Msg = "";
            Double TotalAmount;
            Object response = 0;
            List<transaction> TRANSACTION = new List<transaction>();
            List<ProductBundle> Fin = new List<ProductBundle>(); ;
            String status = "";
            Fin = db.ProductBundle.Where(h => h.pickanddeliverStatus >=-1 && h.Id== ID).OrderBy(h => h.Id).ToList();
            if (Fin.Count() > 0) { 
            Double mainBal = 0;
                Int64 I = 0;
                foreach (ProductBundle v in Fin)
                {
                    I++;
                    transaction T = new transaction();
                    CartData detailsdata = JsonConvert.DeserializeObject<CartData>(v.OrderSummary);
                    T.id = I;
                    T.dates = v.CreatedDate.ToString();
                    if (v.payable>0)
                    {
                        status = "Cr";
                    }
                    else
                    {
                        status = "Dr";
                    }
                    T.Status = status;
                    T.TotalAmount = v.ProductPricing.ToString();
                    T.Shipping = detailsdata.ShippingCost.ToString();
                    T.AdminAmount = Common.ApplyAdminAmountFormula(v.ProductPricing).ToString();
                    T.PayableAmount = Common.ApplyPayableAmountFormula(v.ProductPricing, Convert.ToDouble(T.Shipping), Convert.ToDouble(T.AdminAmount)).ToString();
                    T.OrderId = v.ProductOrderID;
                    T.Title = detailsdata.Product.ProductTitle;
                    T.Decription = detailsdata.Product.ProductTitle + " - Order #" + T.OrderId + " Gift Tin";
                    mainBal = (mainBal + Convert.ToDouble(T.PayableAmount) + Convert.ToDouble(0.00));
                    T.Balance = mainBal.ToString();
                    TRANSACTION.Add(T);
                }
                response = Responsedata(true, "Transaction Details", TRANSACTION.ToList());

            }
            else
            {
                response = Responsedata(false, "Please Enter valid Vendor ID", "");
            }
            return new JsonResult { Data = response };
        }







        [AllowJsonGet]
        public JsonResult ShipingCityList()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();

            //var citys = db.cities.Where(g => g.state_id == 292223 || g.state_id == 290594).ToList();
            var citys = db.cities.ToList();


            Object response = 0;
            response = Responsedata(true, "Shipping City Data", citys);
            return new JsonResult { Data = response};
        }

        [AllowJsonGet]
        public JsonResult sendsuggestion()
        {

            Emails E = new Emails();
            var u=Convert.ToInt32(Request["user"]);
            var userdata=db.user.Where(h => h.id == u).FirstOrDefault();
            E.Msg       = Convert.ToString(Request["message"]);
            E.Subject   = Convert.ToString(Request["subject"]);
            E.From      = userdata.username;
            E.To        = "admin@sweetness.ae";
            db.Emails.Add(E);
            db.SaveChanges();
            Object response = 0;
            response = Responsedata(true, "Message Sent", "");
            return new JsonResult { Data = response };
        }







        [AllowJsonGet]
        public JsonResult settingdata()
        {
                Int32 VID = 0;
                if (Request["vendorID"] != null)
                {
                    VID = Convert.ToInt32(Request["vendorID"]);
                }
                else
                {
                    VID = Convert.ToInt32(Session["vendorloginID"]);
                }
                List<useruserdata> USERDATA = new List<useruserdata>();
                useruserdata ud = new useruserdata();
                var udd = db.user.Where(x => x.id == VID).FirstOrDefault();
                ud.fname        =      udd.fname;
                ud.lname        =      udd.lname;
                ud.username     =   udd.username;
                ud.mobileno     =   udd.mobileno;
                ud.Country      =    udd.Country;
                ud.City         =       udd.City;
                ud.id           =         udd.id;
                ud.status = udd.status;
            ud.usertype = udd.usertype;
            var usermeta = db.Usersmeta.Where(x => x.userid == VID).ToList();
                foreach (Usersmeta um in usermeta)
                {
                    switch (um.metakey)
                    {
                        case "add":
                            ud.Address = um.metavalue;
                        break;
                        case "About":
                            ud.BusinessAbout = um.metavalue;
                        break;
                        case "Dec":
                            ud.BusinessDec = um.metavalue;
                        break;
                        case "Business":
                            ud.BusinessName = um.metavalue;
                        break;
                    case "Accountholder":
                        ud.Accountholder = um.metavalue;
                        break;
                    case "Accountnumber":
                        ud.Accountnumber = um.metavalue;
                        break;
                    case "IBAN":
                        ud.IBAN = um.metavalue;
                        break;
                    case "Swiftcode":
                        ud.Swiftcode = um.metavalue;
                        break;
                    case "Bankname":
                        ud.Bankname = um.metavalue;
                        break;
                    case "Bankcity":
                        ud.Bankcity = um.metavalue;
                        break;
                    case "Bankcountry":
                        ud.Bankcountry = um.metavalue;
                        break;
                    case "Vatnumber":
                        ud.Vatnumber = um.metavalue;
                        break;
                }
                }
                USERDATA.Add(ud);
                
            Object response = 0;
            response = Responsedata(true, "business info", USERDATA.FirstOrDefault());
            return new JsonResult { Data = response };
        }

        [AllowJsonGet]
        public JsonResult Userupdate()
        {

            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int64 uid = Convert.ToInt64(Request["id"]);
            String u = Convert.ToString(Request["u"]);
            String up = Convert.ToString(Request["p"]);
            var users=db.user.Where(h => h.id == uid && h.usertype==2).FirstOrDefault();
            users.mobileno = u;
            users.password = up;
            db.SaveChanges();


            Object response = 0;
            response = Responsedata(true, "business info", db.user.Where(h => h.id == uid).FirstOrDefault());
            return new JsonResult { Data = response };
        }

        [AllowJsonGet]
        public JsonResult AddBrandAndCat()
        {
            Object response = 0;
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            Int32 Uid = Convert.ToInt32(Request["user"]);
            String Typ = Convert.ToString(Request["type"]);
            String Name = Convert.ToString(Request["name"]);
            if (Uid > 0)
            {
                var users = db.user.Where(h => h.id == Uid && h.usertype == 2).ToList();
                if (users.Count() > 0)
                {
                    if (Typ == "Category" || Typ == "Brand")
                    {
                        if (Name != null && Name!="null")
                        {
                            if (Typ == "Category")
                            {
                               ProductCategory pc = new ProductCategory();
                                pc.CategoryName = Name;
                                pc.CategorySlug = Name;
                                pc.UserID = Uid;
                                pc.CategoryStatus = 0;
                                pc.ParentCategoryID = "0";
                                db.ProductCategory.Add(pc);
                                db.SaveChanges();
                                response = Responsedata(true, "Add new Category", "");

                            }
                            if (Typ == "Brand")
                            {
                                ProductBrand pcs = new ProductBrand();
                                pcs.BrandName = Name;
                                pcs.Brandslug = Name;
                                pcs.UserID = Uid;
                                pcs.BrandStatus = 0;
                                db.ProductBrand.Add(pcs);
                                db.SaveChanges();
                                response = Responsedata(true, "Add new Brand", "");
                            }

                        }
                        else {
                            response = Responsedata(false, "Please Enter Valid Name", "");
                        }
                    }
                    else {
                        response = Responsedata(false, "Please Enter Valid TYpe", "");
                    }
                }
                else {
                    response = Responsedata(false, "This UserID NOt FOund", "");
                }

            }
            else {
                response = Responsedata(false, "Please Enter Valid UserID", "");

            }

            return new JsonResult { Data = response };
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



            user user = db.user.Where(h => h.id == UID).FirstOrDefault();
            user.fname = Fname;
            user.lname = lName;
            user.City = City;
            user.Country = Country;
            user.billing = add;
            db.SaveChanges();

            abcd.Select("delete from [dbo].[Usersmeta] where userid='" + UID + "'");

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
            /*---------------------------------*/

            D.metakey = "Vatnumber";
            D.userid = UID;
            D.metavalue = Vatnumber;
            db.Usersmeta.Add(D);
            db.SaveChanges();













            Object response = 0;

            if (op.Count() > 2)
            {
                if (np.Count() > 2)
                {
                    if (np == cnp)
                    {
                        var user2 = db.user.Where(h => h.id == UID && h.password == cnp).FirstOrDefault();
                        if (user2 != null)
                        {
                            user user1 = db.user.Where(h => h.id == UID).FirstOrDefault();
                            user1.password = np;
                            db.SaveChanges();
                            response = Responsedata(true, "Update Profile", "");
                        }
                        else
                        {
                            response = Responsedata(false, "Your Password Doesn't match Our Database", "");

                        }

                    }
                    else
                    {
                        response = Responsedata(false, "Password Mismatch", "");


                    }
                }
                else
                {
                    response = Responsedata(false, "Please Enter More Then 6 Charecter", "");

                }
            }
            else {
                response = Responsedata(true, "Update Profile", "");
            }

            
            return new JsonResult { Data = response };
        }
        public string CreateThumbnail(int maxWidth, int maxHeight, string path)
        {
            string directory = System.Web.HttpContext.Current.Server.MapPath("~/");
            String npath = path;
            if (System.IO.File.Exists(directory+path))
            {
                
            path = (directory + path);
            maxWidth = 500;
            maxHeight = 500;
            var image = System.Drawing.Image.FromFile(path);
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics thumbGraph = Graphics.FromImage(newImage);

            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            thumbGraph.DrawImage(image, 0, 0, newWidth, newHeight);
            image.Dispose();

            string fileRelativePath = "newsizeimages/" + maxWidth + "/" + Path.GetFileName(path);
            newImage.Save(Server.MapPath(npath), newImage.RawFormat);
            }

            return npath;
        }


        public String LanguageChangeP(String text, int ID)
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





        public String LanguageChange(String text)
        {
            String lang;
            lang = "ar";
            String la = Convert.ToString(Request["lang"]);
            if (la != null)
            {
                lang = la;
            }
            var data = db.Language.Where(h => h.en.Contains(text)).FirstOrDefault();
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


        [AllowJsonGet]
        public JsonResult PasswordSetMobile()
        {
            List<apiresponse> APIRES = new List<apiresponse>();
            apiresponse m = new apiresponse();
            String Mobile = cfn.mobliefilter(Convert.ToString(Request["mobile"]));
            String Pass = Convert.ToString(Request["password"]);
            var q = db.user.Where(h => h.mobileno == Mobile && h.usertype == 2).FirstOrDefault();
            if (!String.IsNullOrEmpty(q.mobileno))
            {
                q.password = Pass;
                db.SaveChanges();
                m.flag = true;
                m.message = ("Password Reset");
                m.result = (q);
            }
            else
            {
                m.flag = false;
                m.message = ("Mobile Number Not Found");
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
            var q = db.user.Where(h => h.mobileno == Mobile && h.usertype == 2).ToList();

            if (q.Count() > 0)
            {

                String OTP = GenerateRandomText(6, true);
                String OTPN = OTP;
                OTP = "Use " + OTP + " Sweetness Vendor account password reset code";
                MOBILE.MobileM(OTP, Mobile);

                m.flag = true;
                m.message = ("OTP has been sent");
                m.result = (OTPN);
            }
            else
            {
                m.flag = false;
                m.message = ("Mobile Number Not Found");
                m.result = "";
            }
            APIRES.Add(m);
            return new JsonResult { Data = APIRES.FirstOrDefault() };
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

        private String Getnoimg(String i)
        {
            string directory = System.Web.HttpContext.Current.Server.MapPath("~/");
            if (!System.IO.File.Exists(directory+i))
            {
                i = "/img/Product/imgs.jpg";
            }
            return i;
        }

    }
}
