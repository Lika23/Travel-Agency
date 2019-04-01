using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class ResortsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resorts
        public ActionResult Index()
        {
            var resorts = db.Resorts.Include(r => r.Country);
            return View(resorts.ToList());
        }

        // GET: Resorts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            return View(resort);
        }

        // GET: Resorts/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            return View();
        }

        // POST: Resorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResortId,Name,Infrastructure,Description,History,CountryId")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                db.Resorts.Add(resort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", resort.CountryId);
            return View(resort);
        }

        // GET: Resorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", resort.CountryId);
            return View(resort);
        }

        // POST: Resorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResortId,Name,Infrastructure,Description,History,CountryId")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", resort.CountryId);
            return View(resort);
        }

        // GET: Resorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            return View(resort);
        }

        // POST: Resorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resort resort = db.Resorts.Find(id);
            db.Resorts.Remove(resort);
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
