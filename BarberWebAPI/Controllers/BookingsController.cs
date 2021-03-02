using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BarberWebAPI.Models;

namespace BarberWebAPI.Controllers
{
    public class BookingsController : ApiController
    {
        private BarberAdminDB db = new BarberAdminDB();

        // GET: api/Bookings
        public IQueryable<Booking> GetBookings()
        {
            return db.Bookings;
        }

        // GET: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult GetBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(int id, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.BookingID)
            {
                return BadRequest();
            }

            db.Entry(booking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        [ResponseType(typeof(Booking))]
        public IHttpActionResult PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.Bookings.Add(booking);
                db.SaveChanges();

                return CreatedAtRoute("PostBookingApi", new { id = booking.BookingID }, booking);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest(); 
            }
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult DeleteBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.Bookings.Remove(booking);
            db.SaveChanges();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int id)
        {
            return db.Bookings.Count(e => e.BookingID == id) > 0;
        }
    }
}