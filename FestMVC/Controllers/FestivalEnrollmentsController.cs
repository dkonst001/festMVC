using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FestMVC.Models;

namespace FestMVC.Controllers
{
    public class FestivalEnrollmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FestivalEnrollments
        public ActionResult Index()
        {
            var festivalEnrollments = db.FestivalEnrollments.Include(f => f.Festival).Include(f => f.User);
            return View(festivalEnrollments.ToList());
        }

        // GET: FestivalEnrollments/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FestivalEnrollment festivalEnrollment = db.FestivalEnrollments.Find(id);
            if (festivalEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(festivalEnrollment);
        }

        // GET: FestivalEnrollments/Create
        public ActionResult Create()
        {
            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: FestivalEnrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,FestivalId,NumOfTickets")] FestivalEnrollment festivalEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.FestivalEnrollments.Add(festivalEnrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", festivalEnrollment.FestivalId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalEnrollment.UserId);
            return View(festivalEnrollment);
        }

        // GET: FestivalEnrollments/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FestivalEnrollment festivalEnrollment = db.FestivalEnrollments.Find(id);
            if (festivalEnrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", festivalEnrollment.FestivalId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalEnrollment.UserId);
            return View(festivalEnrollment);
        }

        // POST: FestivalEnrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,FestivalId,NumOfTickets")] FestivalEnrollment festivalEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(festivalEnrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", festivalEnrollment.FestivalId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalEnrollment.UserId);
            return View(festivalEnrollment);
        }

        // GET: FestivalEnrollments/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FestivalEnrollment festivalEnrollment = db.FestivalEnrollments.Find(id);
            if (festivalEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(festivalEnrollment);
        }

        // POST: FestivalEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FestivalEnrollment festivalEnrollment = db.FestivalEnrollments.Find(id);
            db.FestivalEnrollments.Remove(festivalEnrollment);
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
