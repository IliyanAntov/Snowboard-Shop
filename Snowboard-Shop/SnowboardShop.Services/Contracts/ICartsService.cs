using SnowboardShop.Data.Models;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services.Contracts {
    public interface ICartsService {

        int GetShoppingCartId(int itemId);

        List<ShoppingCartItemViewModel> GetAll();

        int AddItem(int productId, string username);

        int RemoveItem(int id);

        List<CartItem> GetAllItemsInCart(int cartId);

        int PlaceOrder(string firstName, string lastName, string phoneNumber, string city, string address, int shoppingCartId);
    }
}
