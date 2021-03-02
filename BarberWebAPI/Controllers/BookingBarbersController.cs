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
using BarberWebAPI.Models;

namespace BarberWebAPI.Controllers
{
    public class BookingBarbersController : ApiController
    {
        private BarberAdminDB db = new BarberAdminDB();

        // GET: api/BookingBarbers
        public IQueryable<BookingBarber> GetBookingsBarbers()
        {
            return db.BookingsBarbers;
        }

        // GET: api/BookingBarbers/5
        [ResponseType(typeof(BookingBarber))]
        public IHttpActionResult GetBookingBarber(int id)
        {
            BookingBarber bookingBarber = db.BookingsBarbers.Find(id);
            if (bookingBarber == null)
            {
                return NotFound();
            }

            return Ok(bookingBarber);
        }

        // PUT: api/BookingBarbers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookingBarber(int id, BookingBarber bookingBarber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingBarber.BerberID)
            {
                return BadRequest();
            }

            db.Entry(bookingBarber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingBarberExists(id))
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

        // POST: api/BookingBarbers
        [ResponseType(typeof(BookingBarber))]
        public IHttpActionResult PostBookingBarber(BookingBarber bookingBarber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookingsBarbers.Add(bookingBarber);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BookingBarberExists(bookingBarber.BerberID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookingBarber.BerberID }, bookingBarber);
        }

        // DELETE: api/BookingBarbers/5
        [ResponseType(typeof(BookingBarber))]
        public IHttpActionResult DeleteBookingBarber(int id)
        {
            BookingBarber bookingBarber = db.BookingsBarbers.Find(id);
            if (bookingBarber == null)
            {
                return NotFound();
            }

            db.BookingsBarbers.Remove(bookingBarber);
            db.SaveChanges();

            return Ok(bookingBarber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingBarberExists(int id)
        {
            return db.BookingsBarbers.Count(e => e.BerberID == id) > 0;
        }
    }
}