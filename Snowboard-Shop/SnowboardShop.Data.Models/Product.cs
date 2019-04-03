using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Data.Models {
    public class Product {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public float Size { get; set; }

        public string Description { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

    }
}
