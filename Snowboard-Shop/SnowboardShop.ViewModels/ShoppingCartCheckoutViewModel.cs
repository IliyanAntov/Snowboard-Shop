using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class ShoppingCartCheckoutViewModel {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public int ShoppingCartId { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
