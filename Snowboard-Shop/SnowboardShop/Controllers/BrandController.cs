using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnowboardShop.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace SnowboardShop.Controllers
{
    public class BrandController : Controller
    {
        private IBrandsService service;

        public BrandController(IBrandsService service) {
            this.service = service;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(string name) {

            this.service.CreateBrand(name);
            return this.RedirectToAction("Success", "Home");
        }
    }
}