using DinnerBooking.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DinnerBooking.Core
{
    public class Cart
    {
        public Cart()
        {
            Cuisines = new List<Cuisine>();
        }

        public enum Disposition
        {
            PutIn,
            Throw,
            ThrowAll
        }
        
        public List<Cuisine> Cuisines { get; set; }
        public int Count => Cuisines.Sum(a => a.Count);
        public int Total => Cuisines.Sum(a => a.Count * a.Price);
        private Cuisine _cuisineInDb;
        public Cuisine CurrentCuisine { get; private set; }

        public void Clear()
        {
            Cuisines = new List<Cuisine>();
        }
        public void PickCuisine(Cuisine cuisine, Disposition disposition)
        {
            _cuisineInDb = cuisine;
            CurrentCuisine = Cuisines.SingleOrDefault(a => a.Id == _cuisineInDb.Id);
            bool isInCart = CurrentCuisine!=null;
            switch (disposition)
            {
                case Disposition.PutIn:
                    PutInCart();
                    break;
                case Disposition.Throw when isInCart:
                    ThrowFromCart();
                    break;
                case Disposition.ThrowAll when isInCart:
                    Cuisines.Remove(CurrentCuisine);
                    break;
            }
        }
        private void PutInCart()
        {
            if (CurrentCuisine == null )
            {
                CurrentCuisine = Cuisine.GetNewCuisine(_cuisineInDb);
                 Cuisines.Add(CurrentCuisine);
            }
            else
            {
                CurrentCuisine++;
            }
        }

        private void ThrowFromCart()
        {
            if (CurrentCuisine.Count > 1)
            {
                CurrentCuisine.Count--;
            }
            else
            {
                Cuisines.Remove(CurrentCuisine);
            }
        }
    }
}