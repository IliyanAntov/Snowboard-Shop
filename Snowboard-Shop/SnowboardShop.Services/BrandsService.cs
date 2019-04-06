using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowboardShop.Services {
    public class BrandsService : IBrandsService {

        /// <param name="context">Application DbContext</param>
        private SnowboardShopDbContext context;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="context">Application DbContext</param>
        public BrandsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        /// <summary>
        /// Creates a brand and adds it to the database
        /// </summary>
        /// <param name="name">Brand name</param>
        /// <returns>Brand id</returns>
        public int CreateBrand(string name) {
            
            var brand = new Brand() { Name = name };
            this.context.Brands.Add(brand);
            this.context.SaveChanges();

            return brand.Id;
        }

        /// <summary>
        /// Maps all brands to ListBrandsViewModel, which contains their Id and Name
        /// </summary>
        /// <returns>A list of ListBrandsViewModel, containing info about all brands</returns>
        public List<ListBrandsViewModel> GetAllBrandsViewModel() {
            return this.context.Brands.Select(b => new ListBrandsViewModel { Id = b.Id, Name = b.Name }).ToList();
        }
    }
}
