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

        /// <param name="context">Application DbContext</param>
        private SnowboardShopDbContext context;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="context">Application DbContext</param>
        public ProductsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        /// <summary>
        /// Maps all products to ListProductViewModel, which contains their Id, Name, ImageName and Price
        /// </summary>
        /// <returns>A list of ListProductViewModel, containing info about all products</returns>
        public List<ListProductViewModel> GetAllProductsViewModel() {
            var snowboards = GetSingleProductViewModel(new List<Product>(this.context.Snowboards));
            var bindings = GetSingleProductViewModel(new List<Product>(this.context.Bindings));
            var boots = GetSingleProductViewModel(new List<Product>(this.context.Boots));

            var result = snowboards.Concat(bindings).Concat(boots).ToList();

            return result;
        }

        /// <summary>
        /// Maps every instance of a certain type of product to ListProductViewModel
        /// </summary>
        /// <param name="products">Products to map</param>
        /// <returns>A list of ListProductViewModel, containing info about all products of a certain type</returns>
        private List<ListProductViewModel> GetSingleProductViewModel(List<Product> products) {
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
