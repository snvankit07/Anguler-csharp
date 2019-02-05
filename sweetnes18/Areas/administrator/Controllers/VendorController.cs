using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Areas.administrator.Models;
using System.IO;
using sweetnes18.AhelperClass;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace sweetnes18.Areas.administrator.Controllers
{
    //[RedirectingAction]
    public class VendorController : Controller
    {
        private conn db = new conn();

        // GET: administrator/Products
        public ActionResult Index()
        { 
           
            return View();
        }
      

        // GET: administrator/Products/Details/5
        public ActionResult Details(int? id)
        {
            ViewData["VendorID"] = id;
            return View();
        }

        // GET: administrator/Products/Create
        public ActionResult Create()
        {
            Response.Write("");
            DatabaseConnection abcd = new DatabaseConnection();
            DataSet dsc = abcd.Select("select * from [dbo].[ProductCategory] where [categorystatus]=1");
            DataSet dsb = abcd.Select("select * from [dbo].[ProductBrand] where [BrandStatus]=1");
            DataSet dsu = abcd.Select("select * from [dbo].[user] where [status]=1 and [usertype]=2");




            //Category List Fetch
            IList<ProductCategory> CategoryList = new List<ProductCategory>();
            for (int x = 0; x < dsc.Tables[0].Rows.Count; x++)
            {
                CategoryList.Add(new ProductCategory() { CategoryName = dsc.Tables[0].Rows[x]["CATEGORYNAME"].ToString(), ID = (int)dsc.Tables[0].Rows[x]["ID"] });
            }
            //Brand List Fetch
            IList<ProductBrand> ProductBrands = new List<ProductBrand>();
            for (int x = 0; x < dsb.Tables[0].Rows.Count; x++)
            {
                ProductBrands.Add(new ProductBrand() { BrandName= dsb.Tables[0].Rows[x]["BrandName"].ToString(), ID = (int)dsb.Tables[0].Rows[x]["ID"] });
            }
            //User List Fetch
            IList<user> UseerTable = new List<user>();
            for (int x = 0; x < dsu.Tables[0].Rows.Count; x++)
            {
                UseerTable.Add(new user() { fname = dsu.Tables[0].Rows[x]["fname"].ToString(), id = (int)dsu.Tables[0].Rows[x]["id"] });
            }

            ViewData["Category"] = CategoryList;
            ViewData["Brand"] = ProductBrands;
            ViewData["Vendor"] = UseerTable;


            return View();
        }


        // POST: administrator/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SKU,ProductID,ProductTitle,ProductDec,ProductSalePrice,ProductRegulerPrice,ProductQun,ProductImg,ProductImage,CatID,USERID,BrandID,productStatus")] Products products )
        { 
            DatabaseConnection abcd = new DatabaseConnection();
            string[] Specificationskey = Request.Form.GetValues("Specificationskey[]");
            string[] Specificationsvalue = Request.Form.GetValues("Specificationsvalue[]");
            string[] AdditionalInformationkey = Request.Form.GetValues("AdditionalInformationkey[]");
            string[] AdditionalInformationvalue = Request.Form.GetValues("AdditionalInformationvalue[]");
            

            
            
             if (ModelState.IsValid)
            {

                if (products != null)
                {
                    string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");

                    if (Request.Files.Count > 0)
                    {

                        HttpPostedFileBase file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            file.SaveAs(Path.Combine(directory, fileName));
                            products.productimg = products.productimage = "/images/" + fileName;
                            Path.Combine(directory, fileName);
                           }
                    }

                }





                db.Products.Add(products);
                db.SaveChanges();
                var productID = products.ProductID;

                /*-------------------Specifications-----------------------*/

                int jj = 0;
                foreach (String x in Specificationskey)
                {
                    string values = Specificationsvalue[jj];
                    DataSet dssc = abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID+ "','specifications','" + x + "','" + values + "');");
                    jj++;
                }
                /*-------------------Specifications-----------------------*/
                /*-------------------AdditionalInformation-----------------------*/
                int kk = 0;
                foreach (String x in AdditionalInformationkey)
                {
                    string values = AdditionalInformationvalue[kk];
                    DataSet dssc = abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','AdditionalInformation','" + x + "','" + values + "');");
                    kk++;
                }
                /*-------------------AdditionalInformation-----------------------*/

                /*-------------------AdditionalIMages-----------------------*/

                for (int i = 0; i < Request.Files.Count; i++)
                {

                    if (products != null)
                    {
                        string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");

                        if (Request.Files.Count > 0)
                        {

                            HttpPostedFileBase file = Request.Files[i];
                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                file.SaveAs(Path.Combine(directory, fileName));
                                string imagepath = "/images/" + fileName;
                                string v = Path.Combine(directory, fileName);
                                DataSet dssc = abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','Images','gallery','" + imagepath + "');");
                            }
                        }

                    }


                    
                    
                }



                return RedirectToAction("Index");
            }
            

            return View(products);
        }

        

        // GET: administrator/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewData["VendorID"] = id;
            return View();
        }

        // POST: administrator/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SKU,ProductID,ProductTitle,ProductDec,ProductSalePrice,ProductRegulerPrice,ProductQun,ProductImg,ProductImage,CatID,USERID,BrandID,productStatus")] Products products)
        {
            if (ModelState.IsValid)
            {
                
                    string directory = System.Web.HttpContext.Current.Server.MapPath("~/images");

                    if (Request.Files.Count > 0)
                    {

                        HttpPostedFileBase file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = new Random().Next(100000, 999999) + "-" + DateTime.Now.Millisecond + "-" + Path.GetFileName(file.FileName);
                            file.SaveAs(Path.Combine(directory, fileName));
                            products.productimage = "../images/" + fileName;
                            products.productimg = Path.Combine(directory, fileName);
                        }
                    }

                


                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: administrator/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }

            DatabaseConnection abcd = new DatabaseConnection();
            
            DataSet dsc = abcd.Select("update [dbo].[Products] set [productStatus]=-2 where [ProductID]="+id);

            return RedirectToAction("Index");

            
        }

        // POST: administrator/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
