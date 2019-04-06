using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class CreateBrandViewModel {

        [Required]
        [Display(Name = "Brand name")]
        public string Name { get; set; }

    }
}
