using FestMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestMVC.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            List<HomeCategoryViewModel> homeCategories = new List<HomeCategoryViewModel>();
            if (db.Categories.ToList().Count()>0)
            {
                foreach (var category in db.Categories.ToList())
                {
                    HomeCategoryViewModel homeCategory = new HomeCategoryViewModel(category.Id,category.Name,category.Description);
                    if (category.Festivals.Count() > 0)
                    {
                        foreach (var festival in category.Festivals)
                        {
                            if (festival.Events.Count()>0)
                            {
                                foreach (var e in festival.Events)
                                {
                                    if (e.EventImages.Count>0)
                                    {
                                        foreach (var eI in e.EventImages)
                                        {
                                            homeCategory.Images.Add(eI.Name);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (homeCategory.Images.Count()==0)
                    {
                        homeCategory.Images.Add("No Image Found");
                    }
                    homeCategories.Add(homeCategory);
                }
            }
            return View(homeCategories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}