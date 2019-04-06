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

        /// <param name="context">Application DbContext</param>
        private SnowboardShopDbContext context;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="context">Application DbContext</param>
        public SnowboardsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        /// <summary>
        /// Creates a snowboard and adds it to the database
        /// </summary>
        /// <param name="name">Snowboard name</param>
        /// <param name="imagePath">Snowboard image path</param>
        /// <param name="price">Snowboard price</param>
        /// <param name="size">Snowboard size in cm</param>
        /// <param name="description">Snowboard description</param>
        /// <param name="brandId">Snowboard brand id</param>
        /// <param name="profile">Snowboard profile</param>
        /// <param name="flex">Snowboard flex rating</param>
        /// <returns>Snowboard id</returns>
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

        /// <summary>
        /// Maps a snowboard to SnowboardDetailsViewModel, which contains its Id, Name, ImagePath, Size, BrandName, Description, Flex, Price and Profile
        /// </summary>
        /// <param name="id">The snowboard's id</param>
        /// <returns>The created SnowboardDetailsViewModel</returns>
        public SnowboardDetailsViewModel GetDetailsViewModel(int id) {
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
