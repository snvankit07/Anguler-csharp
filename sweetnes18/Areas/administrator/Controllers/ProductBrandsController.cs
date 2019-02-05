using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Areas.administrator.Models;
using System.IO;
using sweetnes18.AhelperClass;

namespace sweetnes18.Areas.administrator.Controllers
{
    [RedirectingAction]
    public class ProductBrandsController : Controller
    {
        private conn db = new conn();

        // GET: administrator/ProductBrands
        public ActionResult Index()
        {
            return View(db.ProductBrand.Where(x => x.BrandStatus != -2).ToList());
        }
        

        // GET: administrator/ProductBrands/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = await db.ProductBrand.FindAsync(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            return View(productBrand);
        }

        // GET: administrator/ProductBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/ProductBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,BrandName,Brandslug,BrandImage,BrandStatus")] ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                if (productBrand != null)
                {
                    
                    
                    if (Request.Files.Count > 0)
                    {
                        string directory = System.Web.HttpContext.Current.Server.MapPath("~/images/Brand");
                        HttpPostedFileBase file = Request.Files["BrandImage"];
                        
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            file.SaveAs(Path.Combine(directory, fileName));
                            productBrand.BrandImage = "/images/Brand/" + fileName;
                            Path.Combine(directory, fileName);
                        }

                        string directory1 = System.Web.HttpContext.Current.Server.MapPath("~/images/Brand/Big");
                        HttpPostedFileBase file1 = Request.Files["BrandBgImage"];
                        if (file1 != null && file.ContentLength > 0) {
                            var fileName1 = Path.GetFileName(file1.FileName);
                            file1.SaveAs(Path.Combine(directory1, fileName1));
                            productBrand.BrandBgImage = "/images/Brand/Big/" + fileName1;
                            Path.Combine(directory1, fileName1);

                        }
                    }

                }

                db.ProductBrand.Add(productBrand);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productBrand);
        }

        // GET: administrator/ProductBrands/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand productBrand = await db.ProductBrand.FindAsync(id);
            if (productBrand == null)
            {
                return HttpNotFound();
            }
            return View(productBrand);
        }

        // POST: administrator/ProductBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,BrandName,Brandslug,BrandImage,BrandBgImage,BrandStatus")] ProductBrand productBrand)
        { 
            if (ModelState.IsValid)
            {
               if (productBrand != null)
                {
                    string directory = System.Web.HttpContext.Current.Server.MapPath("~/images/Brand");
                    string directory1 = System.Web.HttpContext.Current.Server.MapPath("~/images/Brand/Big");
                     if (Request.Files.Count > 0)
                        {
                           HttpPostedFileBase file = Request.Files["BrandImages"];
                           if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                file.SaveAs(Path.Combine(directory, fileName));
                                productBrand.BrandImage = "/images/Brand/" + fileName;
                                Path.Combine(directory, fileName);
                            }
                        HttpPostedFileBase file1 = Request.Files["BrandBgImages"];
                        if (file1 != null && file1.ContentLength > 0)
                        {
                            var fileName1 = Path.GetFileName(file1.FileName);
                            file1.SaveAs(Path.Combine(directory1, fileName1));
                            productBrand.BrandBgImage = "/images/Brand/Big/" + fileName1;
                            Path.Combine(directory1, fileName1);
                        }
                     }
                }
                db.Entry(productBrand).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productBrand);
        }

        // GET: administrator/ProductBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBrand ProductBrand = db.ProductBrand.Find(id);
            if (ProductBrand == null)
            {
                return HttpNotFound();
            }

            DatabaseConnection abcd = new DatabaseConnection();

            DataSet dsc = abcd.Select("update [dbo].[ProductBrand] set [BrandStatus]=-2 where [ID]=" + id);

            return RedirectToAction("Index");
        }

        // POST: administrator/ProductBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductBrand productBrand = await db.ProductBrand.FindAsync(id);
            db.ProductBrand.Remove(productBrand);
            await db.SaveChangesAsync();
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
