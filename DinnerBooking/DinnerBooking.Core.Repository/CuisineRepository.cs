using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DinnerBooking.Repository
{
    public class CuisineRepository : GenericRepository<Cuisine>
    {
        public CuisineRepository(DbContext context) : base(context)
        {
        }
    }
}
