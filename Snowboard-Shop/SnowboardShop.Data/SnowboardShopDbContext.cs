using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace SnowboardShop.Data {
    public class SnowboardShopDbContext : IdentityDbContext {
        public SnowboardShopDbContext(DbContextOptions<SnowboardShopDbContext> options)
            : base(options) {
        }
    }
}
