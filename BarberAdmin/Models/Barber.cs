using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberAdmin.Models
{
    public class Barber
    {
        [Key]
        public int BarberID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Picture")]
        public byte[] PhotoFile { get; set; }
        [DataType(DataType.MultilineText)]
        public string ImageMimeType { get; set; }
        public string About { get; set; }
        [DisplayName("Days Available")]
        public virtual ICollection<Day> Days { get; set; }
        public virtual ICollection<BookingBarber> BookingBarber { get; set; }
    }
}