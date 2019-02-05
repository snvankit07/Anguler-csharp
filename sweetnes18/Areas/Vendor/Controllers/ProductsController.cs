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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace sweetnes18.Areas.Vendor.Controllers
{
    [RedirectingVendor] 
    public class ProductsController : Controller
    {
        private conn db = new conn();
        private ProductUpdate fun = new ProductUpdate();
        DatabaseConnection abcd = new DatabaseConnection();
        // GET: Vendor/Products
        
        public ActionResult Index()
        {
            fun.productupdate();
            int id = Convert.ToInt32(Session["vendorloginID"]);
            ViewData["userid"] = Session["vendorloginID"];
            return View();
        }

        // GET: Vendor/Products/Details/5
        public ActionResult Details(int? id)
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
            fun.productupdate();
            return View(products);
        }

        // GET: Vendor/Products/Create
        public ActionResult Create()
        {
            Response.Write("");
            
            int UID= Convert.ToInt32(Session["vendorloginID"]);
            var dsc = db.ProductCategory.Where(h => h.CategoryStatus==1 || (h.CategoryStatus==0 && h.UserID==UID)).ToList(); //abcd.Select("select * from [dbo].[ProductCategory] where [categorystatus]=1 or (UserID=UID and [categorystatus]=0)");
            var dsb = db.ProductBrand.Where(h => h.BrandStatus == 1 || (h.BrandStatus == 0 && h.UserID == UID)).ToList();//abcd.Select("select * from [dbo].[ProductBrand] where [BrandStatus]=1 or (UserID=UID and [BrandStatus]=0)");
            DataSet dsu = abcd.Select("select * from [dbo].[user] where [status]=1 and [usertype]=2");
              //Category List Fetch
            IList<ProductCategory> CategoryList = new List<ProductCategory>();
            foreach (ProductCategory pc in dsc)
            {
                ProductCategory c = new ProductCategory();
                c.CategoryName = pc.CategoryName;
                c.CategorySlug = pc.CategorySlug;
                c.CategoryImage = pc.CategoryImage;
                c.UserID = pc.UserID;
                c.ID = pc.ID;
                CategoryList.Add(c);

            }

            List<ProductBrand> ProductBrands = new List<ProductBrand>();
            foreach (ProductBrand pb in dsb)
            {
                ProductBrand b = new ProductBrand();
                b.ID = pb.ID;
                b.BrandName = pb.BrandName;
                ProductBrands.Add(b);
            }
            
            ViewData["Category"] = CategoryList;
            ViewData["Brand"] = ProductBrands;
            ViewData["Vendor"] = Session["vendorloginID"];
            ViewData["userid"] = Session["vendorloginID"];
            return View();
        }


        // POST: administrator/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SKU,ProductID,ProductTitle,ProductDec,ProductSalePrice,ProductRegulerPrice,ProductQun,ProductImg,ProductImage,CatID,USERID,BrandID,productStatus,vendoroffer,IsCustomized")] Products products)
        {

            
            string[] Specificationskey = Request.Form.GetValues("Specificationskey[]");
            string[] Specificationsvalue = Request.Form.GetValues("Specificationsvalue[]");
            string[] AdditionalInformationkey = Request.Form.GetValues("AdditionalInformationkey[]");
            string[] AdditionalInformationvalue = Request.Form.GetValues("AdditionalInformationvalue[]");

            string[] SpecificationskeyAr = Request.Form.GetValues("SpecificationskeyArabic[]");
            string[] SpecificationsvalueAr = Request.Form.GetValues("SpecificationsvalueArabic[]");
            string[] AdditionalInformationkeyAr = Request.Form.GetValues("AdditionalInformationkeyAr[]");
            string[] AdditionalInformationvalueAr = Request.Form.GetValues("AdditionalInformationvalueAr[]");



            if (ModelState.IsValid)
            {

                if (products != null)
                {
                    string directory = System.Web.HttpContext.Current.Server.MapPath("~/img/Product");

                    if (Request.Files.Count > 0)
                    {

                        HttpPostedFileBase file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            
                            var fileName = Path.GetFileName(file.FileName);
                            fileName = DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss")+"0";
                            var Ext = Path.GetExtension(file.FileName);
                            fileName = fileName + Ext;

                            file.SaveAs(Path.Combine(directory, fileName));
                            products.productimg = products.productimage = this.CreateThumbnail(0,0, "/img/Product/" + fileName);
                            Path.Combine(directory, fileName);
                        }
                    }

                }
                String PreperationTime = Request["PreperationTime"];
                if (PreperationTime == null || PreperationTime.Trim().Length == 0)
                {
                    products.PreperationTime = 0;
                }
                else {
                    if (products.IsCustomized == 1)
                    {
                        products.PreperationTime = Convert.ToInt32(PreperationTime);
                    }
                    

                }
                int id = Convert.ToInt32(Session["vendorloginID"]);
                products.UserID = id;
                products.vendoroffer= Convert.ToInt32(Request["vendoroffer"]);
                products.IsCustomized = Convert.ToInt32(Request["IsCustomized"]);
                products.PreperationTime = 0;
                products.ProductTitle = Convert.ToString(Request["ProductTitle"]).Trim();
                products.ProductDec = Convert.ToString(Request["ProductDec"]).Trim();
                products.ActualAmount = (products.ProductRegulerPrice);
                
                if (products.vendoroffer > 0)
                {
                    products.ProductSalePrice = products.ActualAmount;
                    products.ProductRegulerPrice= Convert.ToString(Convert.ToDecimal(products.ActualAmount)-((Convert.ToDecimal(products.ActualAmount) * Convert.ToDecimal(products.vendoroffer))/100));
                }
                else {
                    products.ProductSalePrice = 0.ToString();
                    products.ProductRegulerPrice = products.ActualAmount;

                }
                products.productStatus = 1;
               int BID = Convert.ToInt32(Request["BrandID"]);
               int CID = Convert.ToInt32(Request["CatID"]);
               if (db.ProductBrand.Where(h => h.ID == BID).FirstOrDefault().BrandStatus != 1){
                   products.productStatus = 0;
                }
                if (db.ProductCategory.Where(h => h.ID == CID).FirstOrDefault().CategoryStatus != 1) {
                   products.productStatus = 0;
                }
                

                db.Products.Add(products);
                db.SaveChanges();
                var productID = products.ProductID;
                abcd.Select("update Products set [SKU]='SWEET-" + productID + "' where [ProductID]='" + productID + "'");

                String TitleA       = Request["ProductTitleArabic"].Trim();
                String TitleEn      = Request["ProductTitle"].Trim();

                String ContentA     = Request["ProductDecArabic"].Trim();
                String ContentEn    = Request["ProductDec"].Trim();
                if (TitleA == "")
                {
                    TitleA = TitleEn;
                }
                if (ContentA == "")
                {
                    ContentA = ContentEn;
                }
                Language Lang = new Language();
                Lang.Keys=productID.ToString();
                Lang.en = TitleEn.Trim();
                Lang.ar = TitleA.Trim();
                db.Language.Add(Lang);
                db.SaveChanges();
                Lang.Keys = productID.ToString();
                Lang.en = (ContentEn.Trim());
                Lang.ar = ContentA.Trim();
                db.Language.Add(Lang);
                db.SaveChanges();

                /*-------------------Specifications-----------------------*/
                int jj = 0;
                foreach (String x in Specificationskey)
                {

                    if (SpecificationskeyAr[jj] != null)
                    {
                        ContentEn = Specificationskey[jj].Trim();
                        ContentA = SpecificationskeyAr[jj].Trim();
                    }
                    else {
                        ContentEn = Specificationskey[jj].Trim();
                        ContentA = Specificationskey[jj].Trim();
                    }
                    Lang.Keys = productID.ToString();
                    Lang.en = ContentEn.Trim();
                    Lang.ar = ContentA.Trim();
                    db.Language.Add(Lang);
                    db.SaveChanges();

                    if (SpecificationsvalueAr[jj] != null)
                    {
                        ContentEn = Specificationsvalue[jj].Trim();
                        ContentA = SpecificationsvalueAr[jj].Trim();
                    }
                    else {
                        ContentEn = Specificationsvalue[jj].Trim();
                        ContentA = Specificationsvalue[jj].Trim();
                    }

                    Lang.Keys = productID.ToString();
                    Lang.en = ContentEn.Trim();
                    Lang.ar = ContentA.Trim();
                    db.Language.Add(Lang);
                    db.SaveChanges();


                    string values = Specificationsvalue[jj];
                    DataSet dssc = abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','specifications','" + x + "','" + values + "');");
                    jj++;
                }


                int sp = 0;
                foreach (String x in AdditionalInformationkey)
                {
                    if (AdditionalInformationkeyAr[sp].Trim().Length > 0)
                    {
                        if (AdditionalInformationkeyAr[sp] != null)
                        {
                            ContentEn = AdditionalInformationkey[sp].Trim();
                            ContentA = AdditionalInformationkeyAr[sp].Trim();

                            Lang.Keys = productID.ToString();
                            Lang.en = ContentEn.Trim();
                            Lang.ar = ContentA.Trim();
                            db.Language.Add(Lang);
                            db.SaveChanges();
                        }


                        if (AdditionalInformationvalueAr[sp] != null)
                        {
                            ContentEn = AdditionalInformationvalue[sp].Trim();
                            ContentA = AdditionalInformationvalueAr[sp].Trim();

                            Lang.Keys = productID.ToString();
                            Lang.en = ContentEn.Trim();
                            Lang.ar = ContentA.Trim();
                            db.Language.Add(Lang);
                            db.SaveChanges();
                        }
                    }
                    sp++;
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

                for (int i =1; i < Request.Files.Count; i++)
                {
                    string imagepath = "/img/Product/imgs.jpg";
                    if (products != null)
                    {
                        string directory = System.Web.HttpContext.Current.Server.MapPath("~/img/Product");

                        if (Request.Files.Count > 0)
                        {
                            HttpPostedFileBase file = Request.Files[i];
                            
                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName="";
                                var fileName1 = "";
                                fileName = Path.GetFileName(file.FileName);
                                fileName = DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss")+i;
                                var Ext1 = Path.GetExtension(file.FileName);
                                fileName1 = fileName + Ext1;

                                file.SaveAs(Path.Combine(directory, fileName1));
                                imagepath = CreateThumbnail(0,0, "/img/Product/" + fileName1);
                                string v = Path.Combine(directory, fileName1);
                                
                            }
                            //DataSet dssc = abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','Images','gallery','" + imagepath + "');");
                          
                            
                        }

                    }
                    fun.UpdateProductMeta(productID, "gallery", "Images", imagepath);
                }
                fun.productupdate();
                return RedirectToAction("Index");
            }
            
            return View(products);
        }


        // GET: administrator/Products/Edit/5
        public ActionResult Edit(int? id)
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


            int UID = Convert.ToInt32(Session["vendorloginID"]);
            var dsc = db.ProductCategory.Where(h => h.CategoryStatus == 1 || (h.CategoryStatus == 0 && h.UserID == UID)).ToList(); //abcd.Select("select * from [dbo].[ProductCategory] where [categorystatus]=1 or (UserID=UID and [categorystatus]=0)");
            var dsb = db.ProductBrand.Where(h => h.BrandStatus == 1 || (h.BrandStatus == 0 && h.UserID == UID)).ToList();//abcd.Select("select * from [dbo].[ProductBrand] where [BrandStatus]=1 or (UserID=UID and [BrandStatus]=0)");
            DataSet dsu = abcd.Select("select * from [dbo].[user] where [status]=1 and [usertype]=2");
            //Category List Fetch
            IList<ProductCategory> CategoryList = new List<ProductCategory>();
            foreach (ProductCategory pc in dsc)
            {
                ProductCategory c = new ProductCategory();
                c.CategoryName = pc.CategoryName;
                c.CategorySlug = pc.CategorySlug;
                c.CategoryImage = pc.CategoryImage;
                c.UserID = pc.UserID;
                c.ID = pc.ID;
                CategoryList.Add(c);

            }

            List<ProductBrand> ProductBrands = new List<ProductBrand>();
            foreach (ProductBrand pb in dsb)
            {
                ProductBrand b = new ProductBrand();
                b.ID = pb.ID;
                b.BrandName = pb.BrandName;
                ProductBrands.Add(b);
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
            ViewData["catid"] = (int)products.CatID;
            ViewData["ID"] = id;
            ViewData["userid"] = Session["vendorloginID"];
            return View(products);
        }


        


        // POST: administrator/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SKU,ProductID,ProductTitle,ProductDec,ProductSalePrice,ProductRegulerPrice,ProductQun,ProductImg,ProductImage,CatID,USERID,BrandID,productStatus,ActualAmount,vendoroffer")] Products products)
        {
            if (ModelState.IsValid)
            {

               
                string[] Specificationskey = Request.Form.GetValues("Specificationskey[]");
                string[] Specificationsvalue = Request.Form.GetValues("Specificationsvalue[]");
                string[] AdditionalInformationkey = Request.Form.GetValues("AdditionalInformationkey[]");
                string[] AdditionalInformationvalue = Request.Form.GetValues("AdditionalInformationvalue[]");

                string[] SpecificationskeyAr = Request.Form.GetValues("SpecificationskeyArabic[]");
                string[] SpecificationsvalueAr = Request.Form.GetValues("SpecificationsvalueArabic[]");
                string[] AdditionalInformationkeyAr = Request.Form.GetValues("AdditionalInformationkeyAr[]");
                string[] AdditionalInformationvalueAr = Request.Form.GetValues("AdditionalInformationvalueAr[]");

                string[] imagefiles = Request.Form.GetValues("imgfiles[]");



                string directory = System.Web.HttpContext.Current.Server.MapPath("~/img/Product");

                if (Request.Files.Count > 0)
                {

                    HttpPostedFileBase file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName1 = Path.GetFileName(file.FileName);
                        fileName1 = DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss")+"0";
                        var Ext1 = Path.GetExtension(file.FileName);
                        fileName1 = fileName1 + Ext1;
                        file.SaveAs(Path.Combine(directory, fileName1));
                        products.productimg=products.productimage = this.CreateThumbnail(0,0, "/img/Product/" + fileName1);
                        
                    }
                    else
                    {
                        products.productimage = products.productimg = Request["proimage"];
                    } 
                }
                int Iscustomization = Convert.ToInt32(Request["customization"]);
                int customization_days = Convert.ToInt32(Request["customization_days"]);
                products.NumberofVisit = Convert.ToInt32(Request["ProductVisits"]);

                products.IsCustomized = Iscustomization;
                products.PreperationTime = 0;
                if (products.IsCustomized == 1)
                {
                    products.PreperationTime = customization_days;
                }
                products.ProductTitle = Convert.ToString(Request["ProductTitle"]).Trim();
                products.ProductDec = Convert.ToString(Request["ProductDec"]).Trim();

                
                if((products.adminoffer + products.vendoroffer) > 0)
                {
                    products.ProductSalePrice = products.ActualAmount;
                    products.ProductRegulerPrice = Convert.ToString(Convert.ToDouble(products.ActualAmount)-(Convert.ToDouble(products.ActualAmount) * Convert.ToDouble(products.adminoffer + products.vendoroffer) / 100));
                }
                else {
                    products.ProductSalePrice = Convert.ToString(0);
                    products.ProductRegulerPrice = products.ActualAmount;
                }
                
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                 

                var productID = products.ProductID;
                abcd.Select("update Products set [SKU]='SWEET-" + productID + "' where [ProductID]='" + productID + "'");


                fun.DeleteProductMeta(productID);


                int sp = 0;
                String Keys = productID.ToString();

                var v = db.Language.Where(h => h.Keys.Contains(Keys)).ToList();
                foreach (Language h in v)
                {
                    db.Language.Remove(h);
                }
                db.SaveChanges();

                /*------------------------Language-----------------------------*/
                String TitleA = Convert.ToString(Request["ProductTitleArabic"]).Trim();
                String TitleEn = Convert.ToString(Request["ProductTitle"]).Trim(); 

                String ContentA = Convert.ToString(Request["ProductDecArabic"]).Trim();
                String ContentEn = Convert.ToString(Request["ProductDec"]).Trim();
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

                /*-------------------Specifications-----------------------*/
                

                foreach (String x in Specificationskey)
                {
                    if(SpecificationskeyAr[sp].Trim().Length>0)
                    { 
                    if (SpecificationskeyAr[sp] != null)
                    {
                        ContentEn = Specificationskey[sp].Trim();
                        ContentA = SpecificationskeyAr[sp].Trim();
                    }
                    Lang.Keys = productID.ToString();
                    Lang.en = ContentEn.Trim();
                    Lang.ar = ContentA.Trim();
                    db.Language.Add(Lang);
                    db.SaveChanges();

                    if (SpecificationsvalueAr[sp] != null)
                    {
                        ContentEn = Specificationsvalue[sp].Trim();
                        ContentA = SpecificationsvalueAr[sp].Trim();
                    }
                    else
                    {
                        ContentEn = Specificationsvalue[sp].Trim();
                        ContentA = Specificationsvalue[sp].Trim();
                    }

                    Lang.Keys = productID.ToString();
                    Lang.en = ContentEn.Trim();
                    Lang.ar = ContentA.Trim();
                    db.Language.Add(Lang);
                    db.SaveChanges();
                    }
                    sp++;
                }

                sp = 0;
                foreach (String x in AdditionalInformationkey)
                {
                    if (AdditionalInformationkeyAr[sp].Trim().Length > 0)
                    {
                        if (AdditionalInformationkeyAr[sp] != null)
                        {
                            ContentEn = AdditionalInformationkey[sp].Trim();
                            ContentA = AdditionalInformationkeyAr[sp].Trim();

                            Lang.Keys = productID.ToString();
                            Lang.en = ContentEn.Trim();
                            Lang.ar = ContentA.Trim();
                            db.Language.Add(Lang);
                            db.SaveChanges();
                        }


                        if (AdditionalInformationvalueAr[sp] != null)
                        {
                            ContentEn = AdditionalInformationvalue[sp].Trim();
                            ContentA = AdditionalInformationvalueAr[sp].Trim();

                            Lang.Keys = productID.ToString();
                            Lang.en = ContentEn.Trim();
                            Lang.ar = ContentA.Trim();
                            db.Language.Add(Lang);
                            db.SaveChanges();
                        }
                    }
                    sp++;
                }



                /*------------------------Language-----------------------------*/




                /*-------------------Specifications-----------------------*/
                // abcd.Select("delete from [dbo].[ProductMeta] where CONVERT(VARCHAR, ProductTypeKey)='specifications' and ProductID='" + productID + "'");
                int jj = 0;
                foreach (String x in Specificationskey)
                {
                    if (Specificationsvalue[jj] != null) { 
                        string values = Specificationsvalue[jj];
                        if (values.Trim().Length > 0) { 
                    abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','specifications','" + x + "','" + values + "');");
                        }
                    }
                    jj++;
                }
                /*-------------------Specifications-----------------------*/
                /*-------------------AdditionalInformation-----------------------*/
                //abcd.Select("delete from [dbo].[ProductMeta] where CONVERT(VARCHAR, ProductTypeKey)='AdditionalInformation' and ProductID='" + productID + "'");
                int kk = 0;
                foreach (String x in AdditionalInformationkey)
                {
                    string values = AdditionalInformationvalue[kk];
                    if (values != "")
                    {
                        String QQ = "insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','AdditionalInformation','" + x + "','" + values + "')";
                        abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','AdditionalInformation','" + x + "','" + values + "')");
                    }
                    kk++;
                }
                /*-------------------AdditionalInformation-----------------------*/

                /*-------------------AdditionalIMages-----------------------*/
                int j = 0;
                for (int i = 1; i < Request.Files.Count-1; i++)
                {

                    HttpPostedFileBase file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        j++;
                    }

                }
                
                for (int i = 1; i < Request.Files.Count; i++)
                {

                    String imagepath="";

                    if (products != null)
                    {
                        string directorynew = System.Web.HttpContext.Current.Server.MapPath("~/img/Product");

                        if (Request.Files.Count > 0)
                        {

                            HttpPostedFileBase file = Request.Files[i];
                            if (file != null && file.ContentLength > 0)
                            {
                                //var fileName = Path.GetFileName(file.FileName);
                                //var fileName = "LocalPC_"+new Random().Next(100000, 999999) + "-" + DateTime.Now.Millisecond + "-" + Path.GetFileName(file.FileName);
                                var fileName = "";
                                var fileName1 = Path.GetFileName(file.FileName);
                                fileName1 = DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss") + DateTime.Now.ToString("HHmmss")+i;
                                var Ext = Path.GetExtension(file.FileName);
                                
                                fileName = fileName1 + Ext;


                                file.SaveAs(Path.Combine(directorynew, fileName));
                                imagepath = "/img/Product/" + fileName;
                                String vv = Path.Combine(directorynew, fileName);
                               
                                //abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','Images','gallery','" + imagepath + "');");
                            }
                            else {
                                imagepath = imagefiles[i];
                                if (imagefiles[i] == null)
                                {
                                    imagepath = "/images/proBg/bgtrns.gif";
                                }
                               
                                //abcd.Select("insert into [dbo].[ProductMeta]([dbo].[ProductID],[dbo].[ProductTypeKey],[dbo].[ProductKey],[dbo].[ProductValue])values('" + productID + "','Images','gallery','"+ imagepath + "')");
                            }
                        }

                    }
                    fun.UpdateProductMeta(productID, "gallery", "Images", imagepath);
                }


                var newl = db.Language.ToList();
                foreach (Language hp in newl)
                {
                    if (hp.ar.Trim().Length == 0)
                    {
                        db.Language.Remove(hp);
                    }
                }
                db.SaveChanges();


                fun.productupdate(productID);
                Session["MSG"] = "Product Update Successfull";
                return RedirectToAction("Index");
            }
            return View();
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

            

            DataSet dsc = abcd.Select("update [dbo].[Products] set [productStatus]=-2 where [ProductID]=" + id);

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

        public string CreateThumbnail(int maxWidth, int maxHeight, string path)
        {
            string directory = System.Web.HttpContext.Current.Server.MapPath("~/");
            String npath = path;
            if (System.IO.File.Exists(directory + path))
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

    }
}
