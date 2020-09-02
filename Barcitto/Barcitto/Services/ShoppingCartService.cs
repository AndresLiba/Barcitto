using Microsoft.EntityFrameworkCore;
using Barcitto.Data;
using Barcitto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barcitto.Services;

namespace Barcitto.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly BarcittoContext barcittoContext;
        public ShoppingCartService(BarcittoContext barcittoContext)
        {
            this.barcittoContext = barcittoContext;
        }
        public Cart GetCartById(int Id)
        {
            var cart = barcittoContext.Carts
               .Include(s => s.ItemsList).ThenInclude(p => p.CartItemProduct)
                   .FirstOrDefault(m => m.Id == Id);
            return cart;
        }
        public Cart GetCartByUserId(string userId)
        {
            var cart = barcittoContext.Carts
                .Include(s => s.ItemsList)
                    .ThenInclude(p => p.CartItemProduct)
                .FirstOrDefault(c => c.UserId == userId);
            return cart;
        }
        public Cart UpdateShoppingCartItem(int itemId)
        {
            throw new NotImplementedException();
        }
        public ShoppingCartItem AddToCart(int productId)
        {
            //code to get the current userId 
            var cart = GetCartByUserId("8d669a27-5d19-4ad3-b262-8c3b76564562");
            if (cart == null)
            {
                //create new cart for current user. 
                cart = CreateCart();
            }
            //after adding the qty field check if the item already exists in the cart. If so increase the qty;
            //Create shopping cart item
            ShoppingCartItem shoppingCartItem = null;
            if (cart.ItemsList != null)
            {
                if (cart.ItemsList.Count()>0)
                shoppingCartItem = cart.ItemsList.FirstOrDefault(i => i.ProductId == productId);
                if (shoppingCartItem != null)
                {
                    //cart.ItemsList.FirstOrDefault(i => i == existingItem).Quantity++;
                    shoppingCartItem.Quantity++;
                    barcittoContext.Update(shoppingCartItem);
                    barcittoContext.SaveChanges();
                }
                else
                {
                    shoppingCartItem = new ShoppingCartItem();
                    shoppingCartItem.ProductId = productId;
                    shoppingCartItem.ShoppingCartId = cart.Id;
                    shoppingCartItem.Quantity = 1;
                    
                    //save SCI to database
                    barcittoContext.Add(shoppingCartItem);
                    barcittoContext.SaveChanges();
                }
            }
            return shoppingCartItem;
        }
        private Cart CreateCart()
        {
            var cart = new Cart();
            cart.UserId = Guid.NewGuid().ToString();
            barcittoContext.Add(cart);
            barcittoContext.SaveChanges();
            return cart;
        }
    }
}