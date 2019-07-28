using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DinnerBooking.Data.Entities
{
    public class Cuisine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Count { get; set; }
        [NotMapped] public int Limit { get; set; }
        public int Price { get; set; }
        public string Detail { get; set; }
        [ForeignKey("CategoryId")] public Category Category { get; set; }

        public static Cuisine GetNewCuisine(Cuisine cuisine)
        {
            return new Cuisine()
            {
                Id = cuisine.Id,
                CategoryId = cuisine.CategoryId,
                Name = cuisine.Name,
                Count = 1,
                Limit = cuisine.Count,
                Price = cuisine.Price,
                Detail = cuisine.Detail
            };
        }
        public static Cuisine operator- (Cuisine inShop, Cuisine inCart)
        {
            int inCartCount = 0;
            if (inShop == null)
                throw new ArgumentNullException();
            if (inCart != null)
                inCartCount = inCart.Count;
            inShop.Count -= inCartCount;
            return inShop;
        }
        public static Cuisine operator ++(Cuisine cuisine)
        {
            if (cuisine.Count < cuisine.Limit)
                cuisine.Count++;
            return cuisine;
        }
    }
}
