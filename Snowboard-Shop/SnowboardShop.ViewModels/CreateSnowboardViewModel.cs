using Microsoft.AspNetCore.Http;
using SnowboardShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class CreateSnowboardViewModel {

        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public decimal Price { get; set; }

        public float Size { get; set; }

        public string Description { get; set; }

        public char Profile { get; set; }

        public byte Flex { get; set; }

        public int BrandId { get; set; }

        public List<ListBrandsViewModel> Brands { get; set; }

    }
}
