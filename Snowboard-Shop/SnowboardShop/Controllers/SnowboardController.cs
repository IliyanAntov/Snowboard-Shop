using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;

namespace SnowboardShop.Controllers
{
    public class SnowboardController : Controller
    {
        private ISnowboardsService snowboardsService;
        private IBrandsService brandsService;
        private readonly IHostingEnvironment hostingEnvironment;

        public SnowboardController(ISnowboardsService snowboardsService, IBrandsService brandsService, IHostingEnvironment hostingEnvironment) {
            this.snowboardsService = snowboardsService;
            this.brandsService = brandsService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [Authorize]
        public IActionResult Create() {
            var model = new CreateSnowboardViewModel() { Brands = brandsService.GetAll()};
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(string name, [FromForm] IFormFile image, decimal price, float size, string description, int brandId, Profile profile, byte flex) {

            var imagePath = Path.Combine(hostingEnvironment.WebRootPath + "\\images", Path.GetFileName(image.FileName));
            image.CopyTo(new FileStream(imagePath, FileMode.Create));
            
            var snowboard = snowboardsService.CreateSnowboard(name, imagePath, price, size, description, brandId, profile, flex);
            return this.RedirectToAction("Success", "Home");
           
        }
    }
}