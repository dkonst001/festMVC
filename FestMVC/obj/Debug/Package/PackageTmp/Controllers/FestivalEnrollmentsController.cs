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
    public class FestivalEnrollmentsController : BaseController
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

        // GET: FestivalEnrollments
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            List<FestivalEnrollment> festivalEnrollments;


            festivalEnrollments = db.FestivalEnrollments.Include(f => f.Festival).Include(f => f.User).ToList();

            return View(festivalEnrollments);
        }

        [Authorize(Roles = "User, Admin, FestivalManager")]
        public ActionResult UserIndex()
        {

            List<FestivalEnrollment> festivalEnrollments;
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser applicationUser = UserManager.FindById(User.Identity.GetUserId());
                if (applicationUser == null)
                {
                    return HttpNotFound();
                }
                festivalEnrollments = applicationUser.FestivalEnnrollments.ToList();
                return View("Index", festivalEnrollments);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [Authorize(Roles = "User, Admin, FestivalManager")]
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

        [Authorize(Roles = "User, Admin, FestivalManager")]
        // GET: FestivalEnrollments/Create
        public ActionResult Create(long? id)
        {
            Session["returnAfterCreate"] = ControllerContext.HttpContext.Request.UrlReferrer.AbsolutePath;

            if (id != null)
            {
                Festival festival = db.Festivals.Find(id);

                if (festival == null)
                {
                    return HttpNotFound();
                }
                FestivalEnrollment festivalEnrollment = new FestivalEnrollment();

                festivalEnrollment.UserId = User.Identity.GetUserId();
                festivalEnrollment.FestivalId = festival.Id;
                festivalEnrollment.Festival = festival;
                festivalEnrollment.User = UserManager.FindById(User.Identity.GetUserId());
                ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", festival.Id);
                ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalEnrollment.UserId);
                return View(festivalEnrollment);
            }
            else
            {
                ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name");
                ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
                return View();
            }

        }

        [Authorize(Roles = "User, Admin, FestivalManager")]
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
                string returnAfterCreate = Session["returnAfterCreate"].ToString();
                return Redirect(returnAfterCreate);
            }

            ViewBag.FestivalId = new SelectList(db.Festivals, "Id", "Name", festivalEnrollment.FestivalId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", festivalEnrollment.UserId);
            return View(festivalEnrollment);
        }

        [Authorize(Roles = "Admin, FestivalManager")]
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

        [Authorize(Roles = "Admin, FestivalManager")]
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

        [Authorize(Roles = "User, Admin, FestivalManager")]
        // GET: FestivalEnrollments/Delete/5
        public ActionResult Delete(long? id)
        {
            Session["returnAfterCreate"] = ControllerContext.HttpContext.Request.UrlReferrer.AbsolutePath;

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
        [Authorize(Roles = "User, Admin, FestivalManager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FestivalEnrollment festivalEnrollment = db.FestivalEnrollments.Find(id);
            db.FestivalEnrollments.Remove(festivalEnrollment);
            db.SaveChanges();
            string returnAfterCreate = Session["returnAfterCreate"].ToString();
            return Redirect(returnAfterCreate);
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
