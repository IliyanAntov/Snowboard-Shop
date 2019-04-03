﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data.Models;
using System;

namespace SnowboardShop.Data {
    public class SnowboardShopDbContext : IdentityDbContext {
        public SnowboardShopDbContext(DbContextOptions<SnowboardShopDbContext> options)
            : base(options) {
        }

        public DbSet<Snowboard> Snowboards { get; set; }

        public DbSet<Boot> Boots { get; set; }

        public DbSet<Binding> Bindings { get; set; }

    }
}
