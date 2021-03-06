using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BarberWebAPI.Models;

namespace BarberWebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class BarbersController : ApiController
    {
        private BarberAdminDB db = new BarberAdminDB();

        // GET: api/Barbers
        public List<Barber> GetBarbers()
        {
            var jjj = db.Barbers.ToList();
            return db.Barbers.ToList();
        }
        public HttpResponseMessage GetImage(int id)
        {
            Barber barber = db.Barbers.Find(id);
            // return File(barber.PhotoFile, barber.ImageMimeType);
            var stream = new MemoryStream(barber.PhotoFile);

            // Compose a response containing the image and return to the user.
            var result = new HttpResponseMessage();

            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue(barber.ImageMimeType);

            return result;
        }

        // GET: api/Barbers/5
        [ResponseType(typeof(Barber))]
        public IHttpActionResult GetBarber(int id)
        {
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        [ResponseType(typeof(Barber))]
        public IHttpActionResult GetBarberByName(string Name)
        {
            Barber barber = db.Barbers.Where(x=>x.Name==Name).FirstOrDefault();
            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        // PUT: api/Barbers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBarber(int id, Barber barber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != barber.BarberID)
            {
                return BadRequest();
            }

            db.Entry(barber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarberExists(id))
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

        // POST: api/Barbers
        [ResponseType(typeof(Barber))]
        public IHttpActionResult PostBarber(Barber barber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Barbers.Add(barber);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = barber.BarberID }, barber);
        }

        // DELETE: api/Barbers/5
        [ResponseType(typeof(Barber))]
        public IHttpActionResult DeleteBarber(int id)
        {
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return NotFound();
            }

            db.Barbers.Remove(barber);
            db.SaveChanges();

            return Ok(barber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BarberExists(int id)
        {
            return db.Barbers.Count(e => e.BarberID == id) > 0;
        }
    }
}