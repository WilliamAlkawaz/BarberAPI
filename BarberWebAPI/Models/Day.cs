using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberWebAPI.Models
{
    public class Day
    {
        [Key]
        public int DayID { get; set; }
        public string day { get; set; }
        public virtual Barber Barber { get; set; }
    }
}