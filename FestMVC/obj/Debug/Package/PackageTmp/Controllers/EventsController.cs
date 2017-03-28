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
    [Authorize(Roles = "Admin,FestivalManager")]
    public class EventsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(f => f.Festival).Include(f => f.Instructor).Include(f => f.Room);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        [OverrideAuthorization]
        [AllowAnonymous]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            EventViewModel @eventViewModel = new EventViewModel(@event.Id, @event.Name, @event.Description, @event.FestivalId,
                    @event.InstructorId, @event.RoomId, @event.StartDate, @event.EndDate,@event.Festival,@event.Room,@event.Instructor);
            return View(@eventViewModel);
        }


        // GET: Events/Details/5
        [OverrideAuthorization]
        [AllowAnonymous]
        public ActionResult CategoryFestivalEventDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            EventViewModel @eventViewModel = new EventViewModel(@event.Id, @event.Name, @event.Description, @event.FestivalId,
                    @event.InstructorId, @event.RoomId, @event.StartDate, @event.EndDate, @event.Festival, @event.Room, @event.Instructor);
            return View(@eventViewModel);
        }

        // GET: Events/Create
        [OverrideAuthorization]
        [Authorize(Roles = "Admin, FestivalManager, User")]
        public ActionResult Create()
        {
            //ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name");
            PopulateDropDownList();
            //ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OverrideAuthorization]
        [Authorize(Roles = "Admin, FestivalManager, User")]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate,StartTime,EndTime,FestivalId,InstructorId,RoomId")] EventViewModel @eventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event @event = new Event(@eventViewModel.Id, @eventViewModel.Name, @eventViewModel.Description, @eventViewModel.FestivalId,
                    @eventViewModel.InstructorId, @eventViewModel.RoomId,
                    @eventViewModel.StartDate, @eventViewModel.StartTime, @eventViewModel.EndTime);
                //Event @event = new Event();

                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", eventViewModel.FestivalId);
            PopulateDropDownList(@eventViewModel.InstructorId, @eventViewModel.FestivalId, @eventViewModel.RoomId);
            //ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", eventViewModel.RoomId);
            return View(@eventViewModel);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            EventViewModel @eventViewModel = new EventViewModel(@event.Id, @event.Name, @event.Description, @event.FestivalId,
                    @event.InstructorId, @event.RoomId,@event.StartDate,@event.EndDate, @event.Festival, @event.Room, @event.Instructor);
            //ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", @event.FestivalId);
            PopulateDropDownList(@event.InstructorId, @event.FestivalId, @event.RoomId);
            //ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", @event.RoomId);
            return View(@eventViewModel);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDate,StartTime,EndTime,FestivalId,InstructorId,RoomId")] EventViewModel @eventViewModel)
        {
            if (ModelState.IsValid)
            {

                Event @event = new Event(@eventViewModel.Id, @eventViewModel.Name, @eventViewModel.Description, @eventViewModel.FestivalId,
                    @eventViewModel.InstructorId, @eventViewModel.RoomId,
                    @eventViewModel.StartDate, @eventViewModel.StartTime, @eventViewModel.EndTime);

                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", @event.FestivalId);
            PopulateDropDownList(@eventViewModel.InstructorId, @eventViewModel.FestivalId, @eventViewModel.RoomId);
            //ViewBag.InstructorId = new SelectList(db.Instructors, "Id", "UserId", @event.InstructorId);
            //ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", @event.RoomId);
            return View(@eventViewModel);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            EventViewModel @eventViewModel = new EventViewModel(@event.Id,@event.Name,@event.Description, @event.FestivalId,
                    @event.InstructorId, @event.RoomId, @event.StartDate, @event.EndDate,@event.Festival, @event.Room, @event.Instructor);
            return View(@eventViewModel);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
        private void PopulateDropDownList(object selectedUser = null, object selectedFestival = null, object selectedRoom = null)
        {
            var usersQuery = from d in db.Instructors
                             orderby d.User.Name
                             select (new { d.Id, d.User.Name });
            ViewBag.InstructorId = new SelectList(usersQuery, "Id", "Name", selectedUser);
            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", selectedFestival);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", selectedRoom);


        }
    }
}

