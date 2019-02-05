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
    public class vendor_profileController : Controller
    {
        private conn db = new conn();

        // GET: Vendor/vendor_profile
        public ActionResult Index()
        {
            
            ViewData["userid"] = Session["vendorloginID"];
            return View();
        }

        // GET: Vendor/vendor_profile/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vendor_profile vendor_profile = await db.vendor_profile.FindAsync(id);
            if (vendor_profile == null)
            {
                return HttpNotFound();
            }
            return View(vendor_profile);
        }

        // GET: Vendor/vendor_profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/vendor_profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VENDOR_ID,vendor_REG_ID,VendorCustomerNo,CompanyName,PHNumber,Address,City,pincode,toSentMail,BusinessName,AboutCompany,ComapnyDec,CategoryIDs,CoverImages")] vendor_profile vendor_profile)
        {
            if (ModelState.IsValid)
            {
                db.vendor_profile.Add(vendor_profile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vendor_profile);
        }

        // GET: Vendor/vendor_profile/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vendor_profile vendor_profile = await db.vendor_profile.FindAsync(id);
            if (vendor_profile == null)
            {
                return HttpNotFound();
            }
            return View(vendor_profile);
        }

        // POST: Vendor/vendor_profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VENDOR_ID,vendor_REG_ID,VendorCustomerNo,CompanyName,PHNumber,Address,City,pincode,toSentMail,BusinessName,AboutCompany,ComapnyDec,CategoryIDs,CoverImages")] vendor_profile vendor_profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor_profile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vendor_profile);
        }

        // GET: Vendor/vendor_profile/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vendor_profile vendor_profile = await db.vendor_profile.FindAsync(id);
            if (vendor_profile == null)
            {
                return HttpNotFound();
            }
            return View(vendor_profile);
        }

        // POST: Vendor/vendor_profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            vendor_profile vendor_profile = await db.vendor_profile.FindAsync(id);
            db.vendor_profile.Remove(vendor_profile);
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
