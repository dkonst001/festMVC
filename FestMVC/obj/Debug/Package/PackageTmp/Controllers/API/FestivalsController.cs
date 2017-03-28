using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FestMVC.Models;

namespace FestMVC.Controllers.API
{
    public class FestivalsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Festivals
        public IQueryable<Festival> GetFestivals()
        //public IHttpActionResult GetFestivals()
        {
            return db.Festivals;
        }

        // GET: api/Festivals/5
        [ResponseType(typeof(Festival))]
        public IHttpActionResult GetFestival(long id)
        {
            Festival festival = db.Festivals.Find(id);
            if (festival == null)
            {
                return NotFound();
            }

            return Ok(festival);
        }

        public IHttpActionResult GetFestEvents(long Id)
        {
            Festival fest = db.Festivals.Find(Id);
            if (fest == null)
                return NotFound();
            return Ok(fest.Events);
        }

        public IHttpActionResult GetUserFestEvents(long Id)
        {
            Festival fest = db.Festivals.Find(Id);
            if (fest == null)
                return NotFound();
            return Ok(fest.Events);
        }



        // PUT: api/Festivals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFestival(long id, Festival festival)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != festival.Id)
            {
                return BadRequest();
            }

            db.Entry(festival).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FestivalsApi
        [ResponseType(typeof(Festival))]
        public IHttpActionResult PostFestival(Festival festival)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Festivals.Add(festival);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = festival.Id }, festival);
        }

        // DELETE: api/FestivalsApi/5
        [ResponseType(typeof(Festival))]
        public IHttpActionResult DeleteFestival(long id)
        {
            Festival festival = db.Festivals.Find(id);
            if (festival == null)
            {
                return NotFound();
            }

            db.Festivals.Remove(festival);
            db.SaveChanges();

            return Ok(festival);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FestivalExists(long id)
        {
            return db.Festivals.Count(e => e.Id == id) > 0;
        }
    }
}