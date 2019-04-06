using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.ViewModels {
    public class ShoppingCartViewModel {

        public int CartId { get; set; }

        public List<ShoppingCartItemViewModel> Items { get; set; }
    }
}
