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
namespace sweetnes18.Areas.administrator.Controllers
{
    [RedirectingAction]
    public class CustomerProfilesController : Controller
    {
        private conn db = new conn();

        // GET: administrator/CustomerProfiles
        public async Task<ActionResult> Index()
        {
            return View(await db.CustomerProfiles.ToListAsync());
        }

        // GET: administrator/CustomerProfiles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            if (customerProfile == null)
            {
                return HttpNotFound();
            }
            return View(customerProfile);
        }

        // GET: administrator/CustomerProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/CustomerProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerID,CustomerBillingAdd,CustomerShippingAdd,CustomerEmailID,CustomerMobileNumber")] CustomerProfile customerProfile)
        {
            if (ModelState.IsValid)
            {
                db.CustomerProfiles.Add(customerProfile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customerProfile);
        }

        // GET: administrator/CustomerProfiles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            if (customerProfile == null)
            {
                return HttpNotFound();
            }
            return View(customerProfile);
        }

        // POST: administrator/CustomerProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerID,CustomerBillingAdd,CustomerShippingAdd,CustomerEmailID,CustomerMobileNumber")] CustomerProfile customerProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerProfile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customerProfile);
        }

        // GET: administrator/CustomerProfiles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            if (customerProfile == null)
            {
                return HttpNotFound();
            }
            return View(customerProfile);
        }

        // POST: administrator/CustomerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            db.CustomerProfiles.Remove(customerProfile);
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
