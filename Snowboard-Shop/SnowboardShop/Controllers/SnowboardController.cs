using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;

namespace SnowboardShop.Controllers
{
    public class SnowboardController : Controller
    {
        private ISnowboardsService snowboardsService;
        private IBrandsService brandsService;

        public SnowboardController(ISnowboardsService snowboardsService, IBrandsService brandsService) {
            this.snowboardsService = snowboardsService;
            this.brandsService = brandsService;
        }

        [Authorize]
        public IActionResult Create() {
            var model = new CreateSnowboardViewModel() { Brands = brandsService.GetAll()};
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(string name, decimal price, float size, string description, int brandId, char profile, int flex) {
            var snowboard = snowboardsService.CreateSnowboard(name, price, size, description, brandId, profile, flex);
            return this.RedirectToAction("Success", "Home");
        }
    }
}