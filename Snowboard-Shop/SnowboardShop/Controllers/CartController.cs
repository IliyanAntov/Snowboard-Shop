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
    public class CartController : Controller
    {
        private ICartsService cartsService;

        public CartController(ICartsService cartsService) {
            this.cartsService = cartsService;
    }

        [Authorize]
        public IActionResult AddToCart(int id)
        {
            var username = this.User.Identity.Name;
            cartsService.AddItem(id, username);
            return RedirectToAction("Cart", "Cart");
        }

        [Authorize]
        public IActionResult Cart() {
            var model = new ShoppingCartViewModel() {
                Items = cartsService.GetAll()
            };
            return View(model);
        }

        [Authorize]
        public IActionResult Remove(int id) {
            cartsService.RemoveItem(id);
            return RedirectToAction("Cart", "Cart");
        }
    }
}