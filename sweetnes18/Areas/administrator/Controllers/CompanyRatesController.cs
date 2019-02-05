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

namespace sweetnes18.Areas.administrator.Controllers
{
    public class CompanyRatesController : Controller
    {
        private conn db = new conn();

        // GET: administrator/CompanyRates
        public async Task<ActionResult> Index()
        {
            
            var v = db.CompanyRate.ToList();
            foreach (CompanyRate vv in v)
            {

                var Company = db.CompanyRate.Where(x => x.ID == vv.ID).FirstOrDefault();
                if (Company != null)
                {
                    var citys = db.cities.Where(h=>h.id==Company.sourcecode).FirstOrDefault();
                    Company.source = citys.name;
                    var citys1 = db.cities.Where(h => h.id == Company.destinationcode).FirstOrDefault();
                    Company.destination = citys1.name;

                    db.Entry(Company).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            return View(await db.CompanyRate.ToListAsync());
        }

        // GET: administrator/CompanyRates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRate companyRate = await db.CompanyRate.FindAsync(id);
            if (companyRate == null)
            {
                return HttpNotFound();
            }
            var v=db.CompanyRate.Where(h => h.ID == id).FirstOrDefault();
            ViewData["sou"] = v.sourcecode;
            ViewData["des"] = v.destinationcode;
            return View(companyRate);
        }

        // GET: administrator/CompanyRates/Create
        public ActionResult Create()
        {
            ViewData["ID"]=Request["id"];
            return View();
        }

        // POST: administrator/CompanyRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CID,sourcecode,destinationcode,price,ExtraQuntityprice,sourcecode,destinationcode")] CompanyRate companyRate)
        {
            if (ModelState.IsValid)
            {
                companyRate.SameVendorProductprice = Convert.ToInt32(companyRate.price);
                db.CompanyRate.Add(companyRate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(companyRate);
        }

        // GET: administrator/CompanyRates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRate companyRate = await db.CompanyRate.FindAsync(id);
            if (companyRate == null)
            {
                return HttpNotFound();
            }
            var v = db.CompanyRate.Where(h => h.ID == id).FirstOrDefault();
            ViewData["sou"] = v.sourcecode;
            ViewData["des"] = v.destinationcode;
            return View(companyRate);
        }

        // POST: administrator/CompanyRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CID,source,destination,sourcecode,destinationcode,price,ExtraQuntityprice,SameVendorProductprice")] CompanyRate companyRate)
        {
            if (ModelState.IsValid)
            {
                companyRate.SameVendorProductprice = Convert.ToInt32(companyRate.price);
                db.Entry(companyRate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companyRate);
        }

        // GET: administrator/CompanyRates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRate companyRate = await db.CompanyRate.FindAsync(id);
            if (companyRate == null)
            {
                return HttpNotFound();
            }
            return View(companyRate);
        }

        // POST: administrator/CompanyRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CompanyRate companyRate = await db.CompanyRate.FindAsync(id);
            db.CompanyRate.Remove(companyRate);
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
