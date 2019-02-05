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
    public class OrderController : Controller
    {
        private conn db = new conn();

        // GET: Vendor/Order
        public async Task<ActionResult> Index()
        {
            int id = Convert.ToInt32(Session["vendorloginID"]);
            ViewData["ID"] = id;
            return View(await db.Orders.ToListAsync());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["VendorID"] = Request["orderid"];
            return View();
        }

        // GET: Vendor/Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderID,Shipping,Billing,TransactionId,ModeOfPayment")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Vendor/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            int USERID = Convert.ToInt32(Session["vendorloginID"]);
            ViewData["id"] = USERID;
            ViewData["status"] = id;
            return View();
        }

        // POST: Vendor/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrderID,Shipping,Billing,TransactionId,ModeOfPayment")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Vendor/Order/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Vendor/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            db.Orders.Remove(order);
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
