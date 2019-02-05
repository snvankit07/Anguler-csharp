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
    //[RedirectingAction]
    public class CMSController : Controller
    {
        private conn db = new conn();

        // GET: administrator/CMS
        public async Task<ActionResult> Index()
        {
            return View(await db.CMS.ToListAsync());
        }

        // GET: administrator/CMS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS cMS = await db.CMS.FindAsync(id);
            if (cMS == null)
            {
                return HttpNotFound();
            }
            return View(cMS);
        }

        // GET: administrator/CMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/CMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,PageTitle,PageDec,PageStatus")] CMS cMS)
        {
            if (ModelState.IsValid)
            {
                db.CMS.Add(cMS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cMS);
        }

        // GET: administrator/CMS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS CMS = await db.CMS.FindAsync(id);
            if (CMS == null)
            {
                return HttpNotFound();
            }
            return View(CMS);
        }

        // POST: administrator/CMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,PageTitle,PageDec,PageStatus")] CMS cMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cMS);
        }

        // GET: administrator/CMS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS cMS = await db.CMS.FindAsync(id);
            if (cMS == null)
            {
                return HttpNotFound();
            }
            return View(cMS);
        }

        // POST: administrator/CMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CMS cMS = await db.CMS.FindAsync(id);
            db.CMS.Remove(cMS);
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
