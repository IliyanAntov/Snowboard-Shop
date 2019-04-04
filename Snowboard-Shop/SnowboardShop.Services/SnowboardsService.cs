using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services {
    public class SnowboardsService : ISnowboardsService {

        private SnowboardShopDbContext context;

        public SnowboardsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        public int CreateSnowboard(string name, decimal price, float size, string description, int brandId, char profile, int flex) {
            var snowboard = new Snowboard() {
                Name = name,
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
    }
}
