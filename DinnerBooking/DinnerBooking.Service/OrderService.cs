using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Data.DTO;
using DinnerBooking.Data.Entities;
using DinnerBooking.Repository;

namespace DinnerBooking.Service
{
    public class OrderService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly CuisineRepository _cuisineRepository;
        public OrderService(DbContext context)
        {
            _cuisineRepository = new CuisineRepository(context);
            _categoryRepository = new CategoryRepository(context);
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.ReadAll().ToList();
        }
        public Cuisine GetCuisineById(int id)
        {
            return _cuisineRepository.ReadAll().FirstOrDefault(a => a.Id == id);
        }

        public bool PurchaseCuisine(Cuisine purchasedCuisine, BuyingCart buyingCart, out string message)
        {
            try
            {
                message = string.Empty;
                var buyingCuisine = buyingCart.Cuisines.Find(a => a.Id == purchasedCuisine.Id);
                if (buyingCuisine == null)
                {
                    buyingCuisine = new Cuisine()
                    {
                        Id = purchasedCuisine.Id,
                        CategoryId = purchasedCuisine.CategoryId,
                        Count = 0,
                        Name = purchasedCuisine.Name,
                        Price = purchasedCuisine.Price
                    };
                    buyingCart.Cuisines.Add(buyingCuisine);
                }
                if (buyingCuisine.Count < purchasedCuisine.Count)
                {
                    buyingCuisine.Count++;
                    purchasedCuisine.Count -= buyingCuisine.Count;
                }
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        public List<Cuisine> GetCuisinesInCategory(int categoryId, BuyingCart buyingCart)
        {
            var cuisines = _cuisineRepository.ReadAll().Where(a => a.CategoryId == categoryId).ToList();
            cuisines.ForEach(a =>
            {
                var bought = buyingCart.Cuisines.FirstOrDefault(b => b.Id == a.Id);
                if (bought != null)
                {
                    a.Count -= bought.Count;
                }
            });
            return cuisines;
        }

        public void CheckOutPurchase(int cuisineId, bool? addOne, BuyingCart buyingCart)
        {
            var cuisineLeft = _cuisineRepository.ReadAll().FirstOrDefault(a => a.Id == cuisineId);
            if (cuisineLeft == null)
            {
                return;
            }
            var buyingCuisine = buyingCart.Cuisines.Find(a => a.Id == cuisineId);
            if (!addOne.HasValue)
                buyingCart.Cuisines.Remove(buyingCuisine);
            else
            {
                if (addOne.Value)
                {
                    if(buyingCuisine.Count > cuisineLeft.Count)
                        buyingCuisine.Count++;
                }
                else
                {
                    if(buyingCuisine.Count >1)
                        buyingCuisine.Count--;
                    else
                    {
                        buyingCart.Cuisines.Remove(buyingCuisine);
                    }
                }
            }
        }
    }
}
