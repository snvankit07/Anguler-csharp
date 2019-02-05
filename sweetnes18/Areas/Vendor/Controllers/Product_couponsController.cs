using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Areas.Vendor.Models;
using sweetnes18.AhelperClass;

namespace sweetnes18.Areas.Vendor.Controllers
{
    [RedirectingVendor]
    public class Product_couponsController : Controller
    {
        private conn db = new conn();

        // GET: Vendor/Product_coupons
        public async Task<ActionResult> Index()
        {
            return View(await db.Product_coupons.ToListAsync());
        }

        // GET: Vendor/Product_coupons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_coupons product_coupons = await db.Product_coupons.FindAsync(id);
            if (product_coupons == null)
            {
                return HttpNotFound();
            }
            return View(product_coupons);
        }

        // GET: Vendor/Product_coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Product_coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ProductID,ProductCouponCode,ProductCouponDec,ProductOffterType,ProductOffetAmount")] Product_coupons product_coupons)
        {
            if (ModelState.IsValid)
            {
                db.Product_coupons.Add(product_coupons);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product_coupons);
        }

        // GET: Vendor/Product_coupons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_coupons product_coupons = await db.Product_coupons.FindAsync(id);
            if (product_coupons == null)
            {
                return HttpNotFound();
            }
            return View(product_coupons);
        }

        // POST: Vendor/Product_coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ProductID,ProductCouponCode,ProductCouponDec,ProductOffterType,ProductOffetAmount")] Product_coupons product_coupons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_coupons).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product_coupons);
        }

        // GET: Vendor/Product_coupons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_coupons product_coupons = await db.Product_coupons.FindAsync(id);
            if (product_coupons == null)
            {
                return HttpNotFound();
            }
            return View(product_coupons);
        }

        // POST: Vendor/Product_coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product_coupons product_coupons = await db.Product_coupons.FindAsync(id);
            db.Product_coupons.Remove(product_coupons);
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
