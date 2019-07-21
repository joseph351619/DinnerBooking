using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Price { get; set; }
        public string Detail { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
