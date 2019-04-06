using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class SnowboardsService : ISnowboardsService {

        private SnowboardShopDbContext context;

        public SnowboardsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        public int CreateSnowboard(string name, string imagePath, decimal price, float size, string description, int brandId, Profile profile, byte flex) {
            var snowboard = new Snowboard() {
                Name = name,
                ImagePath = imagePath,
                Price = price,
                Size = size,
                Description = description,
                BrandId = brandId,
                Profile = profile,
                Flex = flex
            };

            context.Snowboards.Add(snowboard);
            context.SaveChanges();

            return snowboard.Id;
        }

        public SnowboardDetailsViewModel GetDetails(int id) {
            var snowboard = this.context.Snowboards.FirstOrDefault(b => b.Id == id);
            var brand = this.context.Brands.FirstOrDefault(b => b.Id == snowboard.BrandId).Name;
            var model = new SnowboardDetailsViewModel {
                Id = id,
                Name = snowboard.Name,
                ImagePath = Path.GetFileName(snowboard.ImagePath),
                Size = snowboard.Size,
                BrandName = brand,
                Description = snowboard.Description,
                Flex = snowboard.Flex,
                Price = Math.Round(snowboard.Price, 2),
                Profile = snowboard.Profile.ToString()
            };
            return model;
        }
    }
}
