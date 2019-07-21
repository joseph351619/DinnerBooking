using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException("context");
        }
        public IQueryable<TEntity> ReadAll()
        {
            return _context.Set<TEntity>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
