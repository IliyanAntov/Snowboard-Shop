using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using System;

namespace SnowboardShop.Services {
    public class BrandsService : IBrandsService {

        private SnowboardShopDbContext context;

        public BrandsService(SnowboardShopDbContext context) {
            this.context = context;
        }
        public int CreateBrand(string name) {

            var brand = new Brand() { Name = name };
            context.Brands.Add(brand);
            context.SaveChanges();

            return brand.Id;
        }

    }
}
