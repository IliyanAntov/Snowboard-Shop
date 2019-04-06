using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardShop.Services {
    public class CartsService : ICartsService {

        private SnowboardShopDbContext context;

        public CartsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        public int AddItem(int productId, string username) {

            if (this.context.ShoppingCarts.FirstOrDefault(c => c.User.UserName == username) == null) {
                CreateCart(username);
            }

            var shoppingCartId = this.context.ShoppingCarts.FirstOrDefault(c => c.User.UserName == username).Id;

            CartItem item = this.context.CartItems.Where(i => i.ShoppingCartId == shoppingCartId).FirstOrDefault(i => i.ProductId == productId);

            if (item == null || item.Placed == true) {
                var newItem = new CartItem() {
                    ProductId = productId,
                    ShoppingCart = this.context.ShoppingCarts.FirstOrDefault(c => c.Id == shoppingCartId),
                    ShoppingCartId = shoppingCartId,
                    Quantity = 1
                    
                };
                this.context.CartItems.Add(newItem);
            }
            else {
                item.Quantity++;
            }

            context.SaveChanges();
            return shoppingCartId;
        }

        public int RemoveItem(int id) {
            var item = this.context.CartItems.FirstOrDefault(i => i.Id == id);
            this.context.Remove(item);
            context.SaveChanges();
            return item.Id;
        }

        public List<ShoppingCartItemViewModel> GetViewModel(int cartId) {
            return this.context.CartItems.Where(c => c.ShoppingCartId == cartId && c.Placed == false)
                .Select(i => new ShoppingCartItemViewModel() {
                    Id = i.Id,
                    Name = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = Math.Round(i.Product.Price, 2)
                }).ToList();

        }

        public int GetShoppingCartId(string username) {

            if (this.context.ShoppingCarts.FirstOrDefault(c => c.User.UserName == username) == null) {
                CreateCart(username);
            }
            return this.context.ShoppingCarts.FirstOrDefault(c => c.User.UserName == username).Id;
        }

        public List<CartItem> GetAllItemsInCart(int cartId) {
            return this.context.CartItems.Include(i => i.Product).Where(i => i.ShoppingCartId == cartId).Where(i => i.Placed == false).ToList();

        }

        public int PlaceOrder(string firstName, string lastName, string phoneNumber, string city, string address, int shoppingCartId, string username) {

            var order = new Order() {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                City = city,
                Address = address,
                OrderDate = DateTime.UtcNow,
                ShoppingCartId = shoppingCartId,
                ShoppingCart = this.context.ShoppingCarts.FirstOrDefault(c => c.Id == shoppingCartId)
            };
            var items = GetAllItemsInCart(shoppingCartId);
            foreach (var item in items) {
                item.Placed = true;
                this.context.Update(item);
            }

            var userCart = this.context.ShoppingCarts.Include(c => c.User).FirstOrDefault(c => c.User.UserName == username);
            CreateCart(userCart.User.UserName);
            userCart.User = null;
            userCart.UserId = null;

            this.context.Update(userCart);

            this.context.Orders.Add(order);
            context.SaveChanges();
            return order.Id;
        }

        private void CreateCart(string username) {

            IdentityUser user = this.context.Users.FirstOrDefault(u => u.UserName == username);
            this.context.ShoppingCarts.Add(new ShoppingCart {
                User = this.context.Users.FirstOrDefault(u => u.UserName == username),
                UserId = user.Id
            });
            context.SaveChanges();

        }


    }
}
