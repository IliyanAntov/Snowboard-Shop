using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnowboardShop.Services {
    public class ProductsService : IProductsService {

        private SnowboardShopDbContext context;

        public ProductsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        public List<ListProductViewModel> GetAll() {
            var snowboards = GetViewModel(new List<Product>(this.context.Snowboards));
            var bindings = GetViewModel(new List<Product>(this.context.Bindings));
            var boots = GetViewModel(new List<Product>(this.context.Boots));

            var result = snowboards.Concat(bindings).Concat(boots).ToList();

            return result;
        }

        private List<ListProductViewModel> GetViewModel(List<Product> products) {
            return products
                .Select(b =>
                    new ListProductViewModel {
                        Id = b.Id,
                        Name = b.Name,
                        ImageName = Path.GetFileName(b.ImagePath),
                        Price = Math.Round(b.Price,2) })
                .ToList();
        }

    }
}
