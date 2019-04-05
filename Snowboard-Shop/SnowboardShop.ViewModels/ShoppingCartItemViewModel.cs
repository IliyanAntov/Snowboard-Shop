using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class ShoppingCartItemViewModel {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
