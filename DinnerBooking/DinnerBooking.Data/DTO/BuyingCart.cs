using DinnerBooking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinnerBooking.Data.DTO
{
    public class BuyingCart
    {
        public BuyingCart()
        {
            Cuisines = new List<Cuisine>();
        }
        public List<Cuisine> Cuisines { get; set; }
        public int Count => Cuisines.Sum(a => a.Count);
        public int Total => Cuisines.Sum(a => a.Count * a.Price);
    }
}