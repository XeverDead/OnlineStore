using System;
using System.Collections.Generic;

namespace OnlineStore.Common.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public List<Product> Products { get; set; }

        public string Address { get; set; }

        public User User { get; set; }
    }
}
