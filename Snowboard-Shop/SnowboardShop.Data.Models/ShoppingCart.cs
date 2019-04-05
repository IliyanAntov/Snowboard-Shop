using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Data.Models {
    public class ShoppingCart {

        public int Id { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
