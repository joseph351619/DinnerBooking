using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Data.Entities;

namespace DinnerBooking.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
