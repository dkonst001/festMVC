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
    [Authorize(Roles = "Admin")]
    public class FestivalManagersController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FestivalManagers
        public ActionResult Index()
        {
            var festivalManagers = db.FestivalManagers.Include(f => f.User);
            return View(festivalManagers.ToList());
        }

        // GET: FestivalManagers/Details/5
        [OverrideAuthorization]
        [AllowAnonymous]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FestivalManager festivalManager = db.FestivalManagers.Find(id);
            if (festivalManager == null)
            {
                return HttpNotFound();
            }
            return View(festivalManager);
        }

        // GET: FestivalManagers/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: FestivalManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId")] FestivalManager festivalManager)
        {
            if (ModelState.IsValid)
            {
                db.FestivalManagers.Add(festivalManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalManager.UserId);
            return View(festivalManager);
        }

        // GET: FestivalManagers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FestivalManager festivalManager = db.FestivalManagers.Find(id);
            if (festivalManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalManager.UserId);
            return View(festivalManager);
        }

        // POST: FestivalManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId")] FestivalManager festivalManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(festivalManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalManager.UserId);
            return View(festivalManager);
        }

        // GET: FestivalManagers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FestivalManager festivalManager = db.FestivalManagers.Find(id);
            if (festivalManager == null)
            {
                return HttpNotFound();
            }
            return View(festivalManager);
        }

        // POST: FestivalManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FestivalManager festivalManager = db.FestivalManagers.Find(id);
            db.FestivalManagers.Remove(festivalManager);
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
