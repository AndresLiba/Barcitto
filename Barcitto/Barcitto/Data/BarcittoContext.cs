using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barcitto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Barcitto.Data
{
    public class BarcittoContext : IdentityDbContext
    {
        public BarcittoContext (DbContextOptions<BarcittoContext> options)
            : base(options)
        {
        }

        public DbSet<Barcitto.Models.Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }









        
    }
}
