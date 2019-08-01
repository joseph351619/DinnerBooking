using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
