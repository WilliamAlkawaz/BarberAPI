using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberAdmin.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        [DisplayName("Customer Phone No.")]
        public string CustomerPhone { get; set; }
        public string Description { get; set; }
        [Range(1, 4)]
        public int No_of_Barbers { get; set; }
        public int No_of_Haricuts { get; set; }
        public bool Confirmed { get; set; }
        [DisplayName("Booking Date")]
        public DateTime BookingDate { get; set; }
        public virtual ICollection<BookingBarber> BookingBarber { get; set; }
    }
}