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
    public class ArenasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Arenas
        public ActionResult Index()
        {
            var arenas = db.Arenas.Include(a => a.Festival);
            return View(arenas.ToList());
        }

        // GET: Arenas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arena arena = db.Arenas.Find(id);
            if (arena == null)
            {
                return HttpNotFound();
            }
            return View(arena);
        }

        // GET: Arenas/Create
        public ActionResult Create()
        {
            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name");
            return View();
        }

        // POST: Arenas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FestivalId")] Arena arena)
        {
            if (ModelState.IsValid)
            {
                db.Arenas.Add(arena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", arena.FestivalId);
            return View(arena);
        }

        // GET: Arenas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arena arena = db.Arenas.Find(id);
            if (arena == null)
            {
                return HttpNotFound();
            }
            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", arena.FestivalId);
            return View(arena);
        }

        // POST: Arenas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FestivalId")] Arena arena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", arena.FestivalId);
            return View(arena);
        }

        // GET: Arenas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arena arena = db.Arenas.Find(id);
            if (arena == null)
            {
                return HttpNotFound();
            }
            return View(arena);
        }

        // POST: Arenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Arena arena = db.Arenas.Find(id);
            db.Arenas.Remove(arena);
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
