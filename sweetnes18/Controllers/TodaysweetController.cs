using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using sweetnes18.AhelperClass;
using sweetnes18.Models;
using Newtonsoft.Json;
namespace Sweetnes18.Controllers
{
    public class FilterObject
    {
        public  String Category_option { get; set; }
        public  String pricing_max { get; set; }
        public  String pricing_min { get; set; }
        public  String Brand_option { get; set; }
    }

    public class UserSearchViewModel
    {

    }
    [LaunchingAction]
    public class TodaysweetController : Controller
    {
        private conn db = new conn();
        public ActionResult Index()
        {
            var a = Request["category"];
            var b = Request["brand"];
            ViewData["category"] = a;
            ViewData["brand"] = b;
            return View();
        }
       
        [AllowJsonGet]
        public JsonResult filter( )
        {
            String[] Category_option1; int[] Category_option = new int[0]; ;
            //List<String> Category_option = new List<string>();
            if (!String.IsNullOrWhiteSpace(Request["Category_option"]))
            {
                Category_option1 = HttpUtility.UrlDecode(Request["Category_option"]).Split(','); 
                Category_option = Array.ConvertAll(Category_option1, s => int.Parse(s));
            } 
            String Brand_option = Request.QueryString["Brand_option"];
            String pricing_min = Request.QueryString["pricing_min"];
            String pricing_max = Request.QueryString["pricing_max"];
            String option = Request.QueryString["option"];
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
                    query += " AND createdDate <= '" +a+"' AND createdDate >= '"+b+"'";
                }
                 
                p = db.Database.SqlQuery<Products>(query);
            }

            // int cat = Convert.ToInt32(Category_option); 
            if (Category_option.Length > 0)
            {   
                p = p.Where(x => Category_option.Contains(x.CatID) ); 
            }

            p = p.Where(x => bid.Contains(x.BrandID));
            p = p.Where(x => cid.Contains(x.CatID));

            int brand = Convert.ToInt32(Brand_option);
            if (brand > 0 )
            {
                p = p.Where(x => x.BrandID == brand);
            }
             
            switch(option)
            {
                case "TrandingSweet":
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
            json = JsonConvert.SerializeObject(p.ToList());
            return new JsonResult { Data = p.ToList() }; 
        } 

        [AllowJsonGet]
        public JsonResult Brands()
        {
            
            string json = JsonConvert.SerializeObject(db.ProductBrand.Where(x=>x.BrandStatus==1).ToList());
            return new JsonResult { Data = json };
        }
        [AllowJsonGet]
        public JsonResult Categories()
        {
            string json = JsonConvert.SerializeObject(db.ProductCategory.Where(x => x.CategoryStatus == 1).ToList());
            return new JsonResult { Data = json };
        }
        //private int GetTotalPages(user users)
        //{
        //    var filteredCount = users.Count();
        //    return Convert.ToInt32(Math.Ceiling((decimal)filteredCount / (decimal)PageSize));
        //}



        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();// new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
