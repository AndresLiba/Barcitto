﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Barcitto.Models
{
    public class Cart
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public IEnumerable<ShoppingCartItem> ItemsList { get; set; }
    }
}
