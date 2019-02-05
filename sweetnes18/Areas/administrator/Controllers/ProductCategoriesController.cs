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
using sweetnes18.AhelperClass;
using System.IO;

namespace sweetnes18.Areas.administrator.Controllers
{
    [RedirectingAction]
    public class ProductCategoriesController : Controller
    {
        private conn db = new conn();

        // GET: administrator/ProductCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductCategory.ToListAsync());
        }

        // GET: administrator/ProductCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: administrator/ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CategoryName,CategorySlug,ParentCategoryID,CategoryStatus")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategory.Add(productCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }

        // GET: administrator/ProductCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: administrator/ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CategoryName,CategorySlug,ParentCategoryID,CategoryStatus,CategoryImage,CategoryImg")] ProductCategory productCategory)
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
                        productCategory.CategoryImage = "../images/" + fileName;
                        productCategory.CategoryImg = Path.Combine(directory, fileName);
                    }
                }
                db.Entry(productCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
               
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: administrator/ProductCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: administrator/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
            db.ProductCategory.Remove(productCategory);
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
