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
using System.Web.Script.Serialization;
using Newtonsoft.Json; 

namespace sweetnes18.Areas.administrator.Controllers
{
    [RedirectingAction]
    public class ProductOffersController : Controller
    {
        private conn db = new conn();

        // GET: Vendor/ProductOffers
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["vendorloginID"]);
            return View(db.ProductOffers.Where(x => x.OfferAddUserID == id).ToList());
        }

        // GET: Vendor/ProductOffers/Details/5
        public  ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOffer productOffer = db.ProductOffers.Find(id);
            if (productOffer == null)
            {
                return HttpNotFound();
            }
            return View(productOffer);
        }

        // GET: Vendor/ProductOffers/Create
        public ActionResult Create()
        {
            int id = Convert.ToInt32(Session["vendorloginID"]);
            ViewData["ID"] = id;
            return View();
        }

        // POST: Vendor/ProductOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "productID,OfferTitle,numberofuse,OfferID,OfferCode,OfferType,OfferAmount,OfferStartDate,OfferDescription,OfferEndDate,OfferAddUserID,OfferStatus,OfferUseType")] ProductOffer productOffer)
        {
            if (ModelState.IsValid)
            {
                db.ProductOffers.Add(productOffer);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productOffer);
        }

        // GET: Vendor/ProductOffers/Edit/5
        public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOffer productOffer =  db.ProductOffers.Find(id);
            if (productOffer == null)
            {
                return HttpNotFound();
            }
            return View(productOffer);
        }

        // POST: Vendor/ProductOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "OfferID,OfferCode,OfferType,OfferAmount,OfferStartDate,OfferDescription,OfferEndDate,OfferAddUserID,OfferStatus")] ProductOffer productOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productOffer).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productOffer);
        }

        // GET: Vendor/ProductOffers/Delete/5
        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOffer productOffer =  db.ProductOffers.Find(id);
            if (productOffer == null)
            {
                return HttpNotFound();
            }
            return View(productOffer);
        }

        // POST: Vendor/ProductOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult DeleteConfirmed(int id)
        {
            ProductOffer productOffer =  db.ProductOffers.Find(id);
            db.ProductOffers.Remove(productOffer);
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

        



    }
}
