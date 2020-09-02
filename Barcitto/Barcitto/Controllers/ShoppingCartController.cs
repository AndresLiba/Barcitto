using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Barcitto.Data;
using Barcitto.Services;

namespace Barcitto.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly BarcittoContext barcittoContext;
        private readonly IShoppingCartService shoppingCartService;
        public ShoppingCartController(BarcittoContext barcittoContext, IShoppingCartService shoppingCartService)
        {
            this.barcittoContext = barcittoContext;
            this.shoppingCartService = shoppingCartService;
        }
        public IActionResult Cart()
        {
            //use the current user's ID to get the cart
            var cart = shoppingCartService.GetCartByUserId("8d669a27-5d19-4ad3-b262-8c3b76564562");
            return View(cart);
        }
        public IActionResult AddtoCart(int productId)
        {
            shoppingCartService.AddToCart(productId);
            return RedirectToAction("Cart");
        }
    }
}