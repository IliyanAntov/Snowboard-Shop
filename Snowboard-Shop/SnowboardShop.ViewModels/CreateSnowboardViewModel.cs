using Microsoft.AspNetCore.Http;
using SnowboardShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class CreateSnowboardViewModel {

        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public float Size { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public char Profile { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "{0} value must be between {1} and {2}")]
        public byte Flex { get; set; }

        [Required]
        public int BrandId { get; set; }

        public List<ListBrandsViewModel> Brands { get; set; }

    }
}
