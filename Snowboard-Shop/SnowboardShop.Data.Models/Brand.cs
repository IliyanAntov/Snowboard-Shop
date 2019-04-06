using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnowboardShop.Data.Models {
    public class Brand {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}