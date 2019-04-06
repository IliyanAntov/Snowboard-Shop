using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data.Models;
using System;

namespace SnowboardShop.Data {
    public class SnowboardShopDbContext : IdentityDbContext<IdentityUser,IdentityRole, string> {
        public SnowboardShopDbContext(DbContextOptions<SnowboardShopDbContext> options)
            : base(options) {
        }

        public DbSet<Snowboard> Snowboards { get; set; }

        public DbSet<Boot> Boots { get; set; }

        public DbSet<Binding> Bindings { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
