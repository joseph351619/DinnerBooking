using DinnerBooking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Repository
{
    public class CuisineRepository : GenericRepository<Cuisine>
    {
        public CuisineRepository(DbContext context) : base(context)
        {
        }
    }
}
