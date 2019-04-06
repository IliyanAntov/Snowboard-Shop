using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class ShoppingCartCheckoutViewModel {

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "A phone number should only contain digits")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        public int ShoppingCartId { get; set; }

        public string Username { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
