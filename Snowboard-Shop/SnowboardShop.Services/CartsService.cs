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

        /// <param name="context">Application DbContext</param>
        private SnowboardShopDbContext context;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="context">Application DbContext</param>
        public CartsService(SnowboardShopDbContext context) {
            this.context = context;
        }

        /// <summary>
        /// Adds an item to the user's cart
        /// </summary>
        /// <param name="productId">The product's id</param>
        /// <param name="username">The user's username</param>
        /// <returns>Shopping cart id</returns>
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

        /// <summary>
        /// Removes an item from the user's cart
        /// </summary>
        /// <param name="productId">The id of the product to be removed</param>
        /// <returns>The item's id</returns>
        public int RemoveItem(int productId) {
            var item = this.context.CartItems.FirstOrDefault(i => i.Id == productId);
            this.context.Remove(item);
            context.SaveChanges();
            return item.Id;
        }

        /// <summary>
        /// Maps all items in a cart to ShoppingCartItemViewModel, which contains their Id, Name, Quantity and Price
        /// </summary>
        /// <param name="cartId">Cart id</param>
        /// <returns>A list of ShoppingCartItemViewModel, containing info about all items in a cart</returns>
        public List<ShoppingCartItemViewModel> GetViewModel(int cartId) {
            return this.context.CartItems.Where(c => c.ShoppingCartId == cartId && c.Placed == false)
                .Select(i => new ShoppingCartItemViewModel() {
                    Id = i.Id,
                    Name = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = Math.Round(i.Product.Price, 2)
                }).ToList();

        }

        /// <summary>
        /// Gets a user's cart id or creates a cart if one is not present
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <returns>User's cart id</returns>
        public int GetShoppingCartId(string username) {

            if (this.context.ShoppingCarts.FirstOrDefault(c => c.User.UserName == username) == null) {
                CreateCart(username);
            }
            return this.context.ShoppingCarts.FirstOrDefault(c => c.User.UserName == username).Id;
        }

        /// <summary>
        /// Gets a list of all items in a cart 
        /// </summary>
        /// <param name="cartId">Cart id</param>
        /// <returns>A list of CartItem, containing all items in a cart</returns>
        public List<CartItem> GetAllItemsInCart(int cartId) {
            return this.context.CartItems.Include(i => i.Product).Where(i => i.ShoppingCartId == cartId).Where(i => i.Placed == false).ToList();

        }

        /// <summary>
        /// Places an order containing all of the items in a user's cart and emptying it
        /// </summary>
        /// <param name="firstName">Orderer's first name</param>
        /// <param name="lastName">Orderer's last name</param>
        /// <param name="phoneNumber">Orderer's phone number</param>
        /// <param name="city">Orderer's city</param>
        /// <param name="address">Orderer's address</param>
        /// <param name="shoppingCartId">User's shopping cart id</param>
        /// <param name="username">User's username</param>
        /// <returns>Order id</returns>
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

        /// <summary>
        /// Creates a cart for the given user and saves it to the database
        /// </summary>
        /// <param name="username">User's username</param>
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
