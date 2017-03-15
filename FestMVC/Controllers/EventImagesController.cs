using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FestMVC.Models;
using System.IO;


namespace FestMVC.Controllers
{
    public class EventImagesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventImages
        public ActionResult Index()
        {
            var eventImages = db.EventImages.Include(e => e.Event);
            return View(eventImages.ToList());
        }

        // GET: EventImages/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventImage eventImage = db.EventImages.Find(id);
            if (eventImage == null)
            {
                return HttpNotFound();
            }

            return View(eventImage);
        }

        // GET: EventImages/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name");
            return View();
        }

        // POST: EventImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,File,EventId")] EventImage eventImage)
        {
            if (ModelState.IsValid)
            {
                if (eventImage.File != null && eventImage.File.ContentLength > 0)
                {
                    string path = OtherClasses.Utilities.GetRelativeFilePath(eventImage.File.FileName, "Images", "Events", eventImage.EventId);
                    eventImage.Name = path;
                    if (FindEventImage(path) == 0)//Image doesn't exist for the event
                    {
                        OtherClasses.Utilities.SaveFile(path, eventImage.File, Server);
                        db.EventImages.Add(eventImage);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventImage.EventId);
            return View(eventImage);
        }

        // GET: EventImages/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventImage eventImage = db.EventImages.Find(id);
            if (eventImage == null)
            {
                return HttpNotFound();
            }

            if (eventImage.Name != null)
            {
                ViewBag.FileName = Path.Combine("~", eventImage.Name);
                eventImage.Name = Path.GetFileName(eventImage.Name);
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventImage.EventId);
            return View(eventImage);
        }

        // POST: EventImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,File,EventId")] EventImage eventImage)
        {
            if (ModelState.IsValid)
            {
                if (eventImage.File != null && eventImage.File.ContentLength > 0)
                {
                    string previousPath = OtherClasses.Utilities.GetRelativeFilePath(eventImage.Name, "Images", "Events", eventImage.EventId);
                    string path = OtherClasses.Utilities.GetRelativeFilePath(eventImage.File.FileName, "Images", "Events", eventImage.EventId);
                    eventImage.Name = path;
                    if (FindEventImage(path) == 0)//Selected image doesn't exist for the event
                    {
                        OtherClasses.Utilities.DeleteFile(previousPath, Server);//Delete the previous image
                        OtherClasses.Utilities.SaveFile(path, eventImage.File, Server);
                        db.Entry(eventImage).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventImage.EventId);
            return View(eventImage);
        }

        // GET: EventImages/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventImage eventImage = db.EventImages.Find(id);
            if (eventImage == null)
            {
                return HttpNotFound();
            }

            

            return View(eventImage);
        }

        // POST: EventImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            EventImage eventImage = db.EventImages.Find(id);
            string previousPath = OtherClasses.Utilities.GetRelativeFilePath(eventImage.Name, "Images", "Events", eventImage.EventId);
            OtherClasses.Utilities.DeleteFile(previousPath, Server);//Delete the phisical image
            db.EventImages.Remove(eventImage);
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

        protected long FindEventImage(string path)
        {
            foreach (var item in db.EventImages.AsNoTracking())
            {
                if (item.Name == path) { return item.Id; }
            }
            return 0;
        }
    }
}
