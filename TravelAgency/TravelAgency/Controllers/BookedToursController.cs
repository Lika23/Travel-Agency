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
    public class BookedToursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookedTours
        public ActionResult Index()
        {
            return View(db.BookedTours.ToList());
        }

        // GET: BookedTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedTour bookedTour = db.BookedTours.Find(id);
            if (bookedTour == null)
            {
                return HttpNotFound();
            }
            return View(bookedTour);
        }

        // GET: BookedTours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookedTours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookedTourId")] BookedTour bookedTour)
        {
            if (ModelState.IsValid)
            {
                db.BookedTours.Add(bookedTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookedTour);
        }

        // GET: BookedTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedTour bookedTour = db.BookedTours.Find(id);
            if (bookedTour == null)
            {
                return HttpNotFound();
            }
            return View(bookedTour);
        }

        // POST: BookedTours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookedTourId")] BookedTour bookedTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookedTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookedTour);
        }

        // GET: BookedTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedTour bookedTour = db.BookedTours.Find(id);
            if (bookedTour == null)
            {
                return HttpNotFound();
            }
            return View(bookedTour);
        }

        // POST: BookedTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookedTour bookedTour = db.BookedTours.Find(id);
            db.BookedTours.Remove(bookedTour);
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
