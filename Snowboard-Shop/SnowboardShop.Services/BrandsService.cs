using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<ListBrandsViewModel> GetAll() {
            return this.context.Brands.Select(b => new ListBrandsViewModel { Id = b.Id, Name = b.Name }).ToList();
        }
    }
}
