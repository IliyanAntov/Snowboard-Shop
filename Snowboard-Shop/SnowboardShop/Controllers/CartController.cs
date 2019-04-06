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
        private ICartsService cartsService;

        public CartController(ICartsService cartsService) {
            this.cartsService = cartsService;
        }

        [Authorize]
        public IActionResult AddToCart(int id) {
            var username = this.User.Identity.Name;
            cartsService.AddItem(id, username);
            return RedirectToAction("Cart", "Cart");
        }

        [Authorize]
        public IActionResult Cart() {
            var cartId = cartsService.GetShoppingCartId(this.User.Identity.Name);
            var model = new ShoppingCartViewModel() {
                Items = cartsService.GetViewModel(cartId)
            };
            model.CartId = cartId;
            return View(model);
        }

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

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(string firstName, string lastName, string phoneNumber, string city, string address, int shoppingCartId, string username) {

            cartsService.PlaceOrder(firstName, lastName, phoneNumber, city, address, shoppingCartId, username);
            return RedirectToAction("Cart", "Cart");
        }

        [Authorize]
        public IActionResult Remove(int id) {
            cartsService.RemoveItem(id);
            return RedirectToAction("Cart", "Cart");
        }
    }
}
