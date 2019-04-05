using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services.Contracts {
    public interface ICartsService {

        List<ShoppingCartItemViewModel> GetAll();

        int AddItem(int productId, string username);

        int RemoveItem(int id);
    }
}
