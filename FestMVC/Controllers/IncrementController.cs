using FestMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestMVC.Controllers
{
    public class IncrementController : Controller
    {
        // GET: Increment
        public ActionResult Index()
        {
            return View();
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Increment(Increment number)
        {
            Random rand = new Random();
            System.Threading.Thread.Sleep(4000);
            IncrementedViewModel increment = new IncrementedViewModel();


            //if (ModelState.IsValid)
            //{
                //increment.Incremented = number.Number + rand.Next(1, 10); // minimum = 1, maximum = 10
                increment.Incremented = rand.Next(1, 100);
                return PartialView("_Incremented", increment);


            //}
            //return View(number);
        }
    }
}