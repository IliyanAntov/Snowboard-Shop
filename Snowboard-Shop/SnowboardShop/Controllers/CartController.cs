using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;

namespace SnowboardShop.Controllers
{
    public class CartController : Controller {

        /// <param name="cartsService">Carts service</param>
        private ICartsService cartsService;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="cartsService">Carts service</param>
        public CartController(ICartsService cartsService) {
            this.cartsService = cartsService;
        }

        /// <summary>
        /// Adds an item to the cart and returns the shop view
        /// </summary>
        /// <param name="id">Shopping cart id</param>
        /// <returns>Shop view</returns>
        [Authorize]
        public IActionResult AddToCart(int id) {
            var username = this.User.Identity.Name;
            cartsService.AddItem(id, username);
            return RedirectToAction("Shop", "Home");
        }

        /// <summary>
        /// Creates a ShoppingCartViewModel and returns the Cart view
        /// </summary>
        /// <returns>Cart view</returns>
        [Authorize]
        public IActionResult Cart() {
            var cartId = cartsService.GetShoppingCartId(this.User.Identity.Name);
            var model = new ShoppingCartViewModel() {
                Items = cartsService.GetViewModel(cartId)
            };
            model.CartId = cartId;
            return View(model);
        }

        /// <summary>
        /// Creates a ShoppingCartCheckoutViewModel and returns the Checkout view
        /// </summary>
        /// <param name="id">Shopping cart id</param>
        /// <returns>Checkout view</returns>
        [Authorize]
        public IActionResult Checkout(int id) {
            var totalPrice = cartsService.GetAllItemsInCart(id).Sum(i => i.Product.Price * i.Quantity); 
            var model = new ShoppingCartCheckoutViewModel() {
                ShoppingCartId = id,
                Username = this.User.Identity.Name,
                TotalPrice = Math.Round(totalPrice, 2)
            };
            return View(model);
        }

        /// <summary>
        /// Places an order and redirects the user to their cart
        /// </summary>
        /// <param name="firstName">Orderer's first name</param>
        /// <param name="lastName">Orderer's last name</param>
        /// <param name="phoneNumber">Orderer's phone number</param>
        /// <param name="city">Orderer's city</param>
        /// <param name="address">Orderer's address</param>
        /// <param name="shoppingCartId">User's shopping cart id</param>
        /// <param name="username">User's username</param>
        /// <returns>Cart view</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Checkout(string firstName, string lastName, string phoneNumber, string city, string address, int shoppingCartId, string username) {

            cartsService.PlaceOrder(firstName, lastName, phoneNumber, city, address, shoppingCartId, username);
            return RedirectToAction("Cart", "Cart");
        }

        /// <summary>
        /// Removes an item from the user's cart and redirects the user to their cart
        /// </summary>
        /// <param name="id">Cart id</param>
        /// <returns>Cart view</returns>
        [Authorize]
        public IActionResult Remove(int id) {
            cartsService.RemoveItem(id);
            return RedirectToAction("Cart", "Cart");
        }
    }
}
