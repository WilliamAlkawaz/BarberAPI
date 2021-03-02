using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarberAdmin.Models
{
    public class BookingBarber
    {
        [Key]
        [Column(Order = 1)]
        public int BerberID { get; set; }
        public virtual Barber Barber { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BookingID { get; set; }
        public virtual Booking Booking { get; set; }
    }
}