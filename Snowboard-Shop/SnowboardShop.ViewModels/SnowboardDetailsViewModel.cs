using SnowboardShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class SnowboardDetailsViewModel {

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public float Size { get; set; }

        public string Description { get; set; }

        public string BrandName { get; set; }

        public string Profile { get; set; }

        public byte Flex { get; set; }
    }
}
