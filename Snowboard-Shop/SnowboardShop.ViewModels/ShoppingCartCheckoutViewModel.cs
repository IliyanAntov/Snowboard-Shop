using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class ShoppingCartCheckoutViewModel {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public int ShoppingCartId { get; set; }

        public string Username { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
