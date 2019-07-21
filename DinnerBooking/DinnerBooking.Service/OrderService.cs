using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Data.Entities;
using DinnerBooking.Repository;

namespace DinnerBooking.Service
{
    public class OrderService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly CuisineRepository _orderRepository;
        public OrderService(DbContext context)
        {
            _orderRepository = new CuisineRepository(context);
            _categoryRepository = new CategoryRepository(context);
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.ReadAll().ToList();
        }
        public List<Cuisine> GetCuisinesInCategory(int categoryId)
        {
            return _orderRepository.ReadAll().Where(a => a.CategoryId == categoryId).ToList();
        }

    }
}
