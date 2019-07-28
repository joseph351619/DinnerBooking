using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Data.Entities;

namespace DinnerBooking.Data
{
    public class BaseEntities : DbContext
    {
        public BaseEntities() : base("BaseEntities") { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
