using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DinnerBooking.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
