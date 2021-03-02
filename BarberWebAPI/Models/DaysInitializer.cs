using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BarberWebAPI.Models
{
    public class DaysInitializer : DropCreateDatabaseIfModelChanges<BarberAdminDB>
    {
        
    }
}