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

namespace sweetnes18.Controllers
{


    public class ShowProductsByID {
        public Products Productdetails { get; set; }
        public user VendorDetails { get; set; }
        public IEnumerable<ProductReview>  Review { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public ProductCategory category { get; set; }
        public ProductBrand Brand { get; set; }
        public IEnumerable<ProductMeta>  Extradata { get; set; }
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
        public String CreatedDate { get; set; }
        public String UpdateDate { get; set; }
        public int NumberofVisit { get; set; }
    }
    public class wishlistObject
    {
        public Products productdetail;
    }


    public class ajaxresponse {
        public Boolean flag { get; set; }
        public String message { get; set; }
        public Object Result { get; set; }

    }

    public class CartObject
    {
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public Products productdetail;
        public user vendor;
    }

    
    public class AjaxController : Controller
    {

        private conn db = new conn();
        private Common cfn = new Common();
        [AllowJsonGet]
        public JsonResult updateProfile() {
            string Fname = Request["fn"];
            string Lname = Request["ln"];
            string ADD1 = Request["add1"];
            string ADD2 = Request["add2"];
            string EMAIL = Request["email"];
            int COUNTRY = Convert.ToInt32(Request["country"]);
            string ZIP = Request["postal"];
            int STATE = Convert.ToInt32(Request["state"]);
            int CITY = Convert.ToInt32(Request["city"]);
            string PHONE = Request["contact"];
            DatabaseConnection abcd = new DatabaseConnection();
            //string Q = "UPDATE [dbo].[user] SET [fname] = '" + Fname + "', [lname] = '" + Lname + "',[Country]='" + COUNTRY + "',[State]='" + STATE + "',[City]='" + CITY + "',[Postalcode]='" + ZIP + "' WHERE [mobileno]='" + PHONE + "'";
            string Q = "";
            DataSet dsc = abcd.Select(Q);
            String json = "1";
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult CreateNewUser()
        {
            List<ajaxresponse> AJAXR = new List<ajaxresponse>();
            ajaxresponse a = new ajaxresponse();
           

            user u = new user();
            String phone = cfn.mobliefilter(Request["mobile"]);
            String email = Request["email"];
            var us=db.user.Where(h => h.mobileno == phone && h.username == email).FirstOrDefault();
            if (us == null) {
                
                u.fname     = Request["fname"];
                u.lname     = Request["lname"];
                u.mobileno  = cfn.mobliefilter(Request["mobile"]);
                u.username  = Request["email"];
                u.password  = Request["pass"];
                u.usertype  = Convert.ToInt32(Request["type"]);
                u.status = 1; 
                db.user.Add(u);
                db.SaveChanges();
                int IDataAdapter = db.user.Where(h => h.mobileno == phone && h.username == email).FirstOrDefault().id; ;
                cfn.RegisterShippingStatus(IDataAdapter);
                a.flag = true;
                a.message = "Your Account Successfully Created";
                a.Result = "";
            }
            else {
                a.flag = false;
                a.message = "This User Already Saved PLease Fill Other Information";
                a.Result = "";
            }
            AJAXR.Add(a);
            var json = AJAXR.FirstOrDefault();
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult productSearch()
        {
            DatabaseConnection abcd = new DatabaseConnection();
            string data = (Request["product"]);
            DataSet product = abcd.Select("select TOP 50 * from[dbo].[Products] where [productStatus] = 1 and [ProductTitle] Like '" + data + "%'");
            string json = JsonConvert.SerializeObject(product);
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult mobilenochk()
        {
            string data = cfn.mobliefilter(Request["mobile"]);
            var phone = (db.user.Where(d => d.mobileno == data).FirstOrDefault());
            return new JsonResult { Data = phone };
        }


        [AllowJsonGet]
        public JsonResult emailidchk()
        {
            string data = cfn.mobliefilter(Request["email"]);
            var email = (db.user.Where(d => d.username == data).FirstOrDefault());
            return new JsonResult { Data = email };
        }

        [AllowJsonGet]
        public JsonResult mobileEmailchk()
        {
            string m = cfn.mobliefilter(Request["mobile"]);
            string e = (Request["email"]);
            var phone = (db.user.Where(d =>(d.mobileno.Trim() == m || d.username.Trim() == e) && d.usertype == 1).FirstOrDefault());
            return new JsonResult { Data = phone };
        }


        [AllowJsonGet]
        public JsonResult Login()
        {
            string u = cfn.mobliefilter(Request["username"]);
            string p = Request["password"];
            var exist = db.user.Where(x => x.username == u && x.password == p && x.status == 1).FirstOrDefault();
            Session["login"] = "y";
            Session["userdetail"] = exist;
            return new JsonResult { Data = new { Status = "true", Message = exist } };
        }




        [AllowJsonGet]
        public JsonResult bycatproduct()
        {
            DatabaseConnection abcd = new DatabaseConnection();

            List<ProductsData> PROD = new List<ProductsData>();
            int CatID = Convert.ToInt32(Request["CatID"]);
            var prod = db.Products.Where(x => x.CatID == CatID && x.productStatus == 1).Take(6);
            foreach (Products i in prod)
            {
                ProductsData p = new ProductsData();
                p.BrandID = i.BrandID;
                p.CatID = i.CatID;
                
                p.NumberofVisit = i.NumberofVisit;
                p.ProductDec = i.ProductDec;
                p.ProductID = i.ProductID;
                string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");
                string curFile = directory + "/" + System.IO.Path.GetFileName(i.productimage);

                string directory1 = System.Web.HttpContext.Current.Server.MapPath("~/img/Product");
                string curFile1 = directory1 + "/" + System.IO.Path.GetFileName(i.productimage);
                if (System.IO.File.Exists(curFile) || System.IO.File.Exists(curFile1))
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
                
                p.UserID = i.UserID;
                PROD.Add(p);
            }

            
            return new JsonResult { Data = PROD.ToList() };
        }

        [AllowJsonGet]
        public JsonResult getreviewdata()
        {
            
            String trans = Request["orderID"];
            var json = db.Order.Where(d => d.TransactionId == trans && d.reviews == 0).First();
            return new JsonResult { Data = json };
    
        }

        [AllowJsonGet]
        public JsonResult submitreviewdata() 
        {
            ProductReview pr = new ProductReview();
            pr.Token      = Request["token"];
            pr.Reviewmsg  = Request["review"];
            pr.StarRating = Convert.ToInt32(Request["rating"]);
            pr.ProductID  = Convert.ToInt32(Request["ProductID"]);

            var json1 = db.Order.Where(d => d.TransactionId == pr.Token).First();
            pr.CustomerID = json1.customerID;
            db.ProductReview.Add(pr);
            db.SaveChanges();

            DatabaseConnection abcd = new DatabaseConnection();
            string Q = "UPDATE [dbo].[Order] SET [reviews] = 1 Where  TransactionId ='" + pr.Token+"'";
            DataSet dsc = abcd.Select(Q);

            var json2 = db.ProductReview.Where(d => d.Token == pr.Token).First();
            var json = json2;
            return new JsonResult { Data = json2 };
        }



        [AllowJsonGet]
        public JsonResult createaccount()
        {
            string password = this.GenerateRandomText(10);
            user u = new user();
            u.fname = Request["fname"];
            u.lname = Request["lname"]; ;
            u.mobileno = Request["mobile"];
            u.username= Request["email"];
            u.billing = Request["billing"];
            u.shipping = 0;
            u.status = 1;
            u.usertype = 1;
            u.password = password;
            db.user.Add(u);
            db.SaveChanges();
            IDictionary<string, string> keys1 = new Dictionary<string, string>() {
                                                                                    { "{{name}}",Request["fname"]},
                                                                                    { "{{password}}", password },
                                                                                    { "{{username}}", Request["email"]},
                                                                                    { "{{url}}", "https://www.sweetness.ae"}
                                                                                };
            Format a2 = new Format(9, keys1, Request["email"]);
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet userlist = abcd.Select("select * from[dbo].[user] where [usertype] = 0");
            for (int x = 0; x < userlist.Tables[0].Rows.Count; x++)
            {
                string email = (userlist.Tables[0].Rows[x]["username"]).ToString();
                IDictionary<string, string> keys2 = new Dictionary<string, string>() {
                                                                                { "{{name}}",Request["fname"]},
                                                                                { "{{password}}", password },
                                                                                { "{{username}}", Request["email"]}
                                                                                };
                Format a3 = new Format(14, keys2, email);
            }
            string a = string.Empty;
            String json = password;
            return new JsonResult { Data = json };
        }




        [AllowJsonGet]
        public JsonResult country()
        {
            
            string json = JsonConvert.SerializeObject(db.countries.ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult state()
        {
            int id = int.Parse(Request["Cid"]);
            string json = JsonConvert.SerializeObject(db.states.Where(d => d.country_id == id).ToList());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult TrackOrder()
        {
            string data = (Request["OrderID"]);
            string json = JsonConvert.SerializeObject(db.Order.Where(d => d.TransactionId == data).ToList());
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult cities()
        {
            int id = int.Parse(Request["Cid"]);
            string json = JsonConvert.SerializeObject(db.cities.Where(d => d.state_id == id).ToList());
            return new JsonResult { Data = json };
        }




        [AllowJsonGet]
        public JsonResult CheckLogin()
        {
            if (Convert.ToString(Session["login"]) == "y")
            {
                return new JsonResult { Data = new { Message = "Alreadylogin", Status = true, result= Session["userdetail"] } };
            }
            else {
                return new JsonResult { Data = new { Message = "Not Login", Status = false, result = "" } };
            }
           
            
        }

        [AllowJsonGet]
        public JsonResult AllOrder()
        {
            var id=Request["userID"];
            int type = int.Parse(Request["type"]);
            String json = "";
            if (type == 0)
            {
                 json = JsonConvert.SerializeObject(db.Order.Where(d => d.userID == id).OrderByDescending(x => x.userID).ToList());
            }
            else {
                 json = JsonConvert.SerializeObject(db.Order.Where(d => d.userID == id && d.orderstatus == type).OrderByDescending(x => x.userID).ToList());
            }
            
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult Userdetails()
        {
            int id = 0;
            if (Request["userID"] != null)
            {
                 id = int.Parse(Request["userID"]);
            }
            else { 
                user u = new user();
                u = (user)Session["userdetail"];
                id = (u.id);
            }
            string json = JsonConvert.SerializeObject(db.user.Where(d => d.id == id).ToList());
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult addwishlist()
        {
            ProductWishlist p = new ProductWishlist();
            p.UserID        = Convert.ToInt32(Request["uid"]);
            p.ProductID     = Convert.ToInt32(Request["pid"]);
            int UId         = Convert.ToInt32(Request["uid"]);
            int PId         = Convert.ToInt32(Request["pid"]);
            DatabaseConnection abcd = new DatabaseConnection();
            //Response.Write("DELETE FROM [dbo].[ProductWishlist] WHERE [UserID]='"+UId+"' and [ProductID]='"+PId+"'");
            DataSet dsc = abcd.Select("DELETE FROM [dbo].[ProductWishlist] WHERE [UserID]='"+UId+"' and [ProductID]='"+PId+"'");
            db.ProductWishlist.Add(p);
            db.SaveChanges();
            string json = JsonConvert.SerializeObject(db.ProductWishlist.Where(d => d.UserID == UId).ToList());
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult removewishlist()
        {
            int UId = Convert.ToInt32(Request["uid"]);
            int PId = Convert.ToInt32(Request["pid"]);
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet dsc = abcd.Select("DELETE FROM [dbo].[ProductWishlist] WHERE [UserID]='" + UId + "' and [ProductID]='" + PId + "'");
            string json = "[{staus:1}]";
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult featchwishlist()
        {
            String json = String.Empty;
            int UId = Convert.ToInt32(Request["uid"]);
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet widhlist = abcd.Select("select * from [dbo].[ProductWishlist] where [ProductID]!=0 and [UserID]='" + UId +"'");
            List<wishlistObject> wishlists = new List<wishlistObject>();
            
            for (int x = 0; x < widhlist.Tables[0].Rows.Count; x++)
            {
                wishlistObject a = new wishlistObject();
                int PID = Convert.ToInt32(widhlist.Tables[0].Rows[x]["ProductID"]);
                //Response.Write(PID+"--------------"+db.Products.SingleOrDefault(d => d.ProductID == PID));
                a.productdetail = (db.Products.SingleOrDefault(d => d.ProductID == PID && d.productStatus==1));
                if (a.productdetail != null) { 
                wishlists.Add(a);
                }
            }
            
            json = JsonConvert.SerializeObject(wishlists);
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult NewProducts()
        {
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet TOdays = abcd.Select("select TOP 6 * from [dbo].[Products] where [productStatus]=1 ORDER BY [ProductID] DESC");
            String json = JsonConvert.SerializeObject(TOdays);
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult TodaySweet()
        {
            //DateTime a = DateTime.Today.AddDays(3).AddTicks(-1).TimeOfDay.Ticks;
            //DateTime b = DateTime.Today.TimeOfDay.Ticks;
            //DatabaseConnection abcd = new DatabaseConnection();
            //String q= ("select TOP 6 * from [dbo].[Products] where [productStatus]=1 AND createdDate <='" + a + "' AND createdDate >= '" + b + "'  ORDER BY [ProductID] DESC");
            //DataSet TOdays = abcd.Select(q);
            String json = null;
           // json = "select TOP 6 * from [dbo].[Products] where [productStatus]=1 AND createdDate <='" + a + "' AND createdDate >= '" + b + "'";
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult Brand()
        {
            DateTime a = DateTime.Today.AddDays(1).AddTicks(-1);
            DateTime b = DateTime.Today;
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet TOdays = abcd.Select("select TOP 6 * from [dbo].[ProductBrand] where [BrandStatus]=1 ORDER BY [ID] DESC");
            String json = JsonConvert.SerializeObject(TOdays);
            // json = "select TOP 6 * from [dbo].[Products] where [productStatus]=1 AND createdDate <='" + a + "' AND createdDate >= '" + b + "'";
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult Lastview()
        {
          
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet TOdays = abcd.Select("select TOP 6 * from [dbo].[Products] where [productStatus]=1 ORDER BY [UpdateDate] DESC");
            String json = JsonConvert.SerializeObject(TOdays);
            // json = "select TOP 6 * from [dbo].[Products] where [productStatus]=1 AND createdDate <='" + a + "' AND createdDate >= '" + b + "'";
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult TrandingSweet()
        {
            DateTime a = DateTime.Today.AddDays(1).AddTicks(-1);
            DateTime b = DateTime.Today;
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet TOdays = abcd.Select("select TOP 6 * from [dbo].[Products] where [productStatus]=1 ORDER BY NumberofVisit DESC");

            String json = JsonConvert.SerializeObject(TOdays);
            // json = "select TOP 6 * from [dbo].[Products] where [productStatus]=1 AND createdDate <='" + a + "' AND createdDate >= '" + b + "'";
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult Email()
        {
            string to =  Request["to"];
            string msg = Request["msg"];
            string sub = Request["sub"];
            
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("hr@snvinfotech.com", "SNV.ANKIT@162");
            
            MailMessage mm = new MailMessage(to, "snv.ankit@gmail.com", sub, msg);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm); 
            var json = mm;
            //json = JsonConvert.SerializeObject(json);
            return new JsonResult { Data = json };
        }

        [AllowJsonGet]
        public JsonResult GetCustomerDetailDetails() {

            int ID = Convert.ToInt32(Request["userID"]);
            var json = db.CustomerProfiles.Where(x=>x.CustomerID==ID).ToList(); 
            return new JsonResult { Data = json };
        }


        [AllowJsonGet]
        public JsonResult ProductDetails()
        {

            List<ShowProductsByID> PROD = new List<ShowProductsByID>();
            ShowProductsByID p = new ShowProductsByID();


            int ProductID = Convert.ToInt32(Request["Product"]);

            var Productdetails = db.Products.Where(h => h.ProductID == ProductID).FirstOrDefault();
            if (Productdetails != null)
            {
                p.Productdetails = Productdetails;
            }
            var VendorDetails = db.user.Where(h => h.id == p.Productdetails.UserID).FirstOrDefault();
            if (VendorDetails != null)
            {
                p.VendorDetails = VendorDetails;
            }
            var category=db.ProductCategory.Where(h=>h.ID==p.Productdetails.CatID).FirstOrDefault();
            if (category != null)
            {
                p.category = category;
            }
            var Brand=db.ProductBrand.Where(h=>h.ID==p.Productdetails.BrandID).FirstOrDefault();
            if (Brand != null)
            {
                p.Brand = Brand;
            }
            var Extradata = db.ProductMeta.Where(h => h.ProductID == p.Productdetails.ProductID).ToList();
            List<ProductMeta> PM = new List<ProductMeta>();
            ProductMeta pm1 = new ProductMeta();
            pm1.ProductID = p.Productdetails.ProductID;
            pm1.ProductKey = "gallery";
            pm1.ProductTypeKey = "Images";
            pm1.ProductValue = p.Productdetails.productimage;
            PM.Add(pm1);
            if (Extradata.Count() > 0)
            {
                
                foreach (ProductMeta ex in Extradata)
                {
                    if(ex.ProductValue.Trim().Length>0)
                    { 
                    ProductMeta pm = new ProductMeta();
                    pm.ProductID = p.Productdetails.ProductID;
                    pm.ProductKey = ex.ProductKey;
                    pm.ProductTypeKey = ex.ProductTypeKey;
                    pm.ProductValue = ex.ProductValue;
                    PM.Add(pm);
                    }
                }


            }
            
            

            p.Extradata = PM.ToList();
            var Review = db.ProductReview.Where(h => h.ProductID == p.Productdetails.ProductID).ToList();
            if (Review != null && Review.Count()>0)
            {
                p.Review = Review;
                double rat = 0;
                int i = 0;
                foreach (ProductReview r in p.Review)
                {

                    String name=db.CustomerProfiles.Where(d=>d.CustomerID==r.CustomerID).FirstOrDefault().CustomerFullName;
                    var q=p.Review.Where(h => h.CustomerID == r.CustomerID).FirstOrDefault();
                    q.Token = name;
                    
                    rat = rat + r.StarRating;
                    i++;
                }
                p.Rating = rat / p.Review.Count();
                p.ReviewCount = p.Review.Count();
            }
            
             

            PROD.Add(p);
            return new JsonResult { Data = PROD.FirstOrDefault() };
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

        //[AllowJsonGet]
        //public JsonResult Registrationmail()
        //{
        //user result =  db.user.Where(x => x.id == 1).First();
        //IDictionary<string, string> keys = new Dictionary<string, string>() { { "{name}", result.lname + result.fname },
        //    { "{email}", result.username } };
        //Format e = new Format(9, keys);  
        //CMS cmsobj = e.Formaxt();
        //String json = JsonConvert.SerializeObject(json);
        //return new JsonResult { Data = json };
        //}
    } 
}