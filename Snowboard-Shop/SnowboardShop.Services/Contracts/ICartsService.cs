using SnowboardShop.Data.Models;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services.Contracts {
    public interface ICartsService {

        int GetShoppingCartId(string username);

        int AddItem(int productId, string username);

        int RemoveItem(int id);

        List<ShoppingCartItemViewModel> GetViewModel(int cartId);

        List<CartItem> GetAllItemsInCart(int cartId);

        int PlaceOrder(string firstName, string lastName, string phoneNumber, string city, string address, int shoppingCartId, string username);
    }
}
