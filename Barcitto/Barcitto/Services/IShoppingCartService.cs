﻿using Barcitto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barcitto.Services
{
    public interface IShoppingCartService
    {
        public Cart GetCartById(int Id);

        public Cart GetCartByUserId(string userId);

        public Cart UpdateShoppingCartItem(int itemId);

        public ShoppingCartItem AddToCart(int productId);
       
    }
}
