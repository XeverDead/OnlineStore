using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Common.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Category { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<Order> Orders { get; set; }
    }
}
