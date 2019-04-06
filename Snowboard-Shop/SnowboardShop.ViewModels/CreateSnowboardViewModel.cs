using Microsoft.AspNetCore.Http;
using SnowboardShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class CreateSnowboardViewModel {

        [Required]
        [Display(Name = "Snowboard name")]
        public string Name { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Snowboard size (in cm)")]
        public float Size { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Profile")]
        public char Profile { get; set; }

        [Required]
        [Display(Name = "Flex rating")]
        [Range(1, 10, ErrorMessage = "{0} value must be between {1} and {2}")]
        public byte Flex { get; set; }

        [Required]
        public int BrandId { get; set; }

        public List<ListBrandsViewModel> Brands { get; set; }

    }
}
