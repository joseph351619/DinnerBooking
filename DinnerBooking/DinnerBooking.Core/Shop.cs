using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Data.Entities;
using DinnerBooking.Repository;

namespace DinnerBooking.Core
{
    public class Shop
    {
        private readonly Cart _cart;
        private readonly CategoryRepository _categoryRepository;
        private readonly CuisineRepository _cuisineRepository;
        private readonly BookingRepository _bookingRepository;

        public delegate void AfterBookingEventHandler(Booking booking);

        public event AfterBookingEventHandler AfterBooking;
        public Shop(Cart cart, DbContext context, Common.IValidationDictionary validationDictionary)
        {
            _cart = cart;
            _cuisineRepository = new CuisineRepository(context);
            _categoryRepository = new CategoryRepository(context);
            _bookingRepository = new BookingRepository(context);
            ValidationDictionary = validationDictionary;
        }
        public Common.IValidationDictionary ValidationDictionary { get; private set; }

        public List<Cuisine> DisplayByCategory(int categoryId)
        {
            return (from all in _cuisineRepository.ReadAll().Where(a => a.CategoryId == categoryId).ToList()
                join inCart in _cart.Cuisines
                    on all.Id equals inCart.Id
                    into result
                from inCart in result.DefaultIfEmpty()
                select all - inCart).ToList(); ;
        }
        public List<Category> GetCuisineCategories()
        {
            return _categoryRepository.ReadAll().ToList();
        }

        public void PurchaseById(int cuisineId)
        {
            try
            {
                _cart.PickCuisine(_cuisineRepository.ReadAll().Single(a => a.Id == cuisineId), Cart.Disposition.PutIn);
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        public void CheckOutPurchase(int cuisineId, Cart.Disposition disposition)
        {
            try
            {
                var cuisine = _cuisineRepository.ReadAll().FirstOrDefault(a => a.Id == cuisineId);
                _cart.PickCuisine(cuisine, disposition);
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }

        public void CheckOut(Booking booking)
        {
            try
            {
                PurchaseCuisine();
                _bookingRepository.Add(booking);
                _bookingRepository.Save();
                AfterBooking?.Invoke(booking);
            }
            catch (Exception ex)
            {
                ValidationDictionary.AddGeneralError(ex.Message);
            }
        }
        
        
        public void PurchaseCuisine()
        {
            (from all in _cuisineRepository.ReadAll().ToList()
                join inCart in _cart.Cuisines
                    on all.Id equals inCart.Id
                    into result
                from inCart in result.DefaultIfEmpty()
                select all - inCart).ToList();
        }
    }
}
