using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Data.Models {
    public class Order {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
