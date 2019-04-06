using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnowboardShop.Data.Models {
    public class Product {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public float Size { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

    }
}
