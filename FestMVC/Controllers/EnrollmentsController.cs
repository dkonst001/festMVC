using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FestMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FestMVC.Controllers
{
    public class EnrollmentsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

        }

        // GET: Enrollments
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Event).Include(e => e.User);
            return View(enrollments.ToList());
        }

        // GET: Enrollments
        [Authorize(Roles = "User,FestivalManager,Admin")]
        public ActionResult UserFestivalIndex(long? id)
        {
            List<Enrollment> enrollments;
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser applicationUser = UserManager.FindById(User.Identity.GetUserId());
                if (applicationUser == null)
                {
                    return HttpNotFound();
                }
                enrollments = applicationUser.Ennrollments.ToList();
                return View("Index",enrollments.FindAll(X => X.Event.FestivalId == id));
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Enrollments/Details/5
        [Authorize(Roles = "User,FestivalManager,Admin")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        [Authorize(Roles = "User,FestivalManager,Admin")]
        public ActionResult Create(long? id)
        {

            if (id != null)
            {
                Event e = db.Events.Find(id);

                if (e == null)
                {
                    return HttpNotFound();
                }
                Enrollment enrollment = new Enrollment();

                enrollment.UserId = User.Identity.GetUserId();
                enrollment.EventId = e.Id;
                enrollment.Event = e;
                enrollment.User = UserManager.FindById(User.Identity.GetUserId());
                ViewBag.EventId = new SelectList(db.Events, "Id", "Name", e.Id);
                ViewBag.UserId = new SelectList(db.Users, "Id", "Name", enrollment.UserId);
                Session["returnAfterCreate"] = ControllerContext.HttpContext.Request.UrlReferrer.T‌​oString();
                return View(enrollment);
            }
            else
            {
                ViewBag.EventId = new SelectList(db.Events, "Id", "Name");
                ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
                return View();
            }
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User,FestivalManager,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,EventId,NumOfTickets")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                string returnAfterCreate = Session["returnAfterCreate"].ToString();
                return RedirectToAction(returnAfterCreate);
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", enrollment.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", enrollment.UserId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        [Authorize(Roles = "FestivalManager,Admin")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", enrollment.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", enrollment.UserId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "FestivalManager,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,EventId,NumOfTickets")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", enrollment.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", enrollment.UserId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        [Authorize(Roles = "User,FestivalManager,Admin")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [Authorize(Roles = "User,FestivalManager,Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
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
