﻿using System.Collections.Generic;

namespace OnlineStore.Common.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public List<Order> Orders { get; set; }
    }
}
