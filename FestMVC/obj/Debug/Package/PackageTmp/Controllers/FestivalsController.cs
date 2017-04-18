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
using FestMVC.App_Code;

namespace FestMVC.Controllers
{
    [Authorize(Roles = "Admin,FestivalManager")]
    public class FestivalsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Festivals
        public ActionResult Index()
        {
            //var festivals = db.Festivals.Include(f => f.Category).Include(f => f.Location).Include(f => f.FestivalManager).ToList<IbaseModel>();

            var festivals = Utilities.FilterFestivalManager(
                db.Festivals.Include(f => f.Category).Include(f => f.Location).Include(f => f.FestivalManager).ToList<IbaseModel>(), User);

            //return View(festivals.ConvertAll(o => (Festival)o));
            return View(festivals.OfType<Festival>());
        }

        // GET: Festivals/Details/5
        [OverrideAuthorization]
        [AllowAnonymous]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = db.Festivals.Find(id);
            if (festival == null)
            {
                return HttpNotFound();
            }
            return View(festival);
        }

        //Get Festival Events
        [OverrideAuthorization]
        [AllowAnonymous]
        public ActionResult FestivalEvents(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = db.Festivals.Find(id);
            if (festival == null)
            {
                return HttpNotFound();
            }
            List<FestivalEventViewModel> festivalEvents = new List<FestivalEventViewModel>();

            if (festival.Events.Count() > 0)
            {
                foreach (var e in festival.Events)
                {
                    FestivalEventViewModel festivalEvent = new FestivalEventViewModel(e.Id, e.Name,
                        e.Description, e.StartDate, e.StartDate, e.EndDate, e.Festival, e.Instructor, e.Room);
                    if (e.EventImages.Count > 0)
                    {
                        foreach (var eI in e.EventImages)
                        {
                            festivalEvent.Images.Add(eI.Name);
                        }
                        if (festivalEvent.Images.Count() == 0)
                        {
                            festivalEvent.Images.Add("No Image Found");
                        }
                        festivalEvents.Add(festivalEvent);
                    }
                }

            }


            //For the time line
            List<FestivalEventViewModel> sortedFestivalEvents = festivalEvents.OrderBy(o => o.StartDate).ToList();
            return View(sortedFestivalEvents);
        }

        [HttpPost]
        public ActionResult GetFestivalRooms(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = db.Festivals.Find(Int64.Parse(id));
            if (festival == null)
            {
                return HttpNotFound();
            }
            
            //List<SelectListItem> festivalRooms = new List<SelectListItem>();
            //foreach (Room room in festival.Location.Rooms.ToList())
            //{
            //    festivalRooms.Add(new SelectListItem { Text = room.Name, Value = ""+room.Id });
            //}

            //Creates a Json list with Value=Room.Id and Text=Room.Name
            return Json(new SelectList(festival.Location.Rooms.ToList(), "Id", "Name"));
        }

        // GET: Festivals/Create
        [OverrideAuthorization]
        [Authorize(Roles = "Admin, FestivalManager, User")]
        public ActionResult Create()
        {
            PopulateDropDownList();
            return View();
        }

        // POST: Festivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[OverrideAuthorization]
        //[Authorize(Roles = "Admin,FestivalManager,User")]
        public ActionResult Create([Bind(Include = "Id,Name,FestivalManagerId,Description,LocationId,CategoryId,StartDate,EndDate")] Festival festival)
        {
            if (ModelState.IsValid)
            {
                FestivalManager festivalManager = db.FestivalManagers.Find(festival.FestivalManagerId);

                if (Utilities.IsForbidden(festivalManager, User))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                db.Festivals.Add(festival);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDropDownList(festival.FestivalManagerId, festival.CategoryId, festival.LocationId);
            return View(festival);
        }

        // GET: Festivals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Festival festival = db.Festivals.Find(id);

            if (festival == null)
            {
                return HttpNotFound();
            }

            if (Utilities.IsForbidden(festival, User))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            PopulateDropDownList(festival.FestivalManagerId, festival.CategoryId, festival.LocationId);
            return View(festival);
        }

        // POST: Festivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FestivalManagerId,Description,LocationId,CategoryId,StartDate,EndDate")] Festival festival)
        {
            if (ModelState.IsValid)
            {

                if (Utilities.IsForbidden(festival, User))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                db.Entry(festival).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", festival.CategoryId);
            PopulateDropDownList(festival.FestivalManagerId, festival.CategoryId, festival.LocationId);
            return View(festival);
        }

        // GET: Festivals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = db.Festivals.Find(id);
            if (festival == null)
            {
                return HttpNotFound();
            }

            if (Utilities.IsForbidden(festival, User))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            return View(festival);
        }

        // POST: Festivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Festival festival = db.Festivals.Find(id);

            if (Utilities.IsForbidden(festival, User))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            db.Festivals.Remove(festival);
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

        private void PopulateDropDownList(object selectedUser = null, object selectedCategory = null, object selectedLocation = null)
        {
            var festivalManagers = Utilities.FilterFestivalManager(db.FestivalManagers.ToList<IbaseModel>(), User);

            var usersQuery = from d in festivalManagers.OfType<FestivalManager>()
                             orderby d.User.Name
                             select (new { d.Id, d.User.Name });


            ViewBag.FestivalManagerId = new SelectList(usersQuery, "Id", "Name", selectedUser);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", selectedCategory);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", selectedLocation);
        }

        
    }
}
