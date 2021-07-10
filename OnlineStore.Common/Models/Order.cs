﻿using OnlineStore.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Common.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public List<Product> Products { get; set; }

        public string Address { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public OrderState State { get; set; }
    }
}
