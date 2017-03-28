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

namespace FestMVC.Controllers
{
    public class EnrollmentsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EnrollmentsApi
        public IQueryable<Enrollment> GetEnrollments()
        {
            return db.Enrollments;
        }

        // GET: api/EnrollmentsApi/5
        [ResponseType(typeof(Enrollment))]
        public IHttpActionResult GetEnrollment(long id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        // PUT: api/EnrollmentsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnrollment(long id, Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enrollment.Id)
            {
                return BadRequest();
            }

            db.Entry(enrollment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(id))
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

        // POST: api/EnrollmentsApi
        [ResponseType(typeof(Enrollment))]
        public IHttpActionResult PostEnrollment(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enrollments.Add(enrollment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enrollment.Id }, enrollment);
        }

        // DELETE: api/EnrollmentsApi/5
        [ResponseType(typeof(Enrollment))]
        public IHttpActionResult DeleteEnrollment(long id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            db.Enrollments.Remove(enrollment);
            db.SaveChanges();

            return Ok(enrollment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollmentExists(long id)
        {
            return db.Enrollments.Count(e => e.Id == id) > 0;
        }
    }
}