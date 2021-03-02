using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BarberAdmin.Models
{
    public class BarberAdminDB : DbContext
    {
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingBarber> BookingsBarbers { get; set; }
    }
}