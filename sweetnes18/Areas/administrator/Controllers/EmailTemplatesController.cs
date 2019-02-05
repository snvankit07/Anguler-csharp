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
    public class EmailTemplatesController : Controller
    {
        private conn db = new conn();

        // GET: administrator/EmailTemplates
        public async Task<ActionResult> Index()
        {
            return View(await db.EmailTemplates.ToListAsync());
        }

        // GET: administrator/EmailTemplates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplates = await db.EmailTemplates.FindAsync(id);
            if (emailTemplates == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplates);
        }

        // GET: administrator/EmailTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrator/EmailTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TemplateId,TemplateName,TemplateData,NotificationType")] EmailTemplates emailTemplates)
        {
            if (ModelState.IsValid)
            {
                db.EmailTemplates.Add(emailTemplates);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emailTemplates);
        }

        // GET: administrator/EmailTemplates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplates = await db.EmailTemplates.FindAsync(id);
            if (emailTemplates == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplates);
        }

        // POST: administrator/EmailTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TemplateId,TemplateName,TemplateData,NotificationType")] EmailTemplates emailTemplates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailTemplates).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emailTemplates);
        }

        // GET: administrator/EmailTemplates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplates = await db.EmailTemplates.FindAsync(id);
            if (emailTemplates == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplates);
        }

        // POST: administrator/EmailTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmailTemplates emailTemplates = await db.EmailTemplates.FindAsync(id);
            db.EmailTemplates.Remove(emailTemplates);
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
