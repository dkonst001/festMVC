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
    public class CategoriesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        [OverrideAuthorization]
        [AllowAnonymous]

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        //GetCategoryFestivals
        [OverrideAuthorization]
        [AllowAnonymous]
        public ActionResult CategoryFestivals(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            List<CategoryFestivalViewModel> categoryFestivals = new List<CategoryFestivalViewModel>();


            if (category.Festivals.Count() > 0)
            {

                foreach (var festival in category.Festivals)
                {
                    CategoryFestivalViewModel categoryFestival = new CategoryFestivalViewModel(festival.Id, festival.Name, festival.FestivalManager,
                        festival.Description, festival.Location, festival.Category, festival.StartDate, festival.EndDate);
                    if (festival.Events.Count() > 0)
                    {
                        foreach (var e in festival.Events)
                        {
                            if (e.EventImages.Count > 0)
                            {
                                foreach (var eI in e.EventImages)
                                {
                                    categoryFestival.Images.Add(eI.Name);
                                }
                            }
                        }
                    }
                    if (categoryFestival.Images.Count() == 0)
                    {
                        categoryFestival.Images.Add("No Image Found");
                    }
                    categoryFestivals.Add(categoryFestival);
                }

            }
            //For the time line
            List<CategoryFestivalViewModel> SortedCategoryFestivals = categoryFestivals.OrderBy(o => o.StartDate).ToList();
            return View(SortedCategoryFestivals);
        }


        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
