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
        /// <param name="snowboardsService">Snowboards service</param>
        private ISnowboardsService snowboardsService;
        /// <param name="brandsService">Brands service</param>
        private IBrandsService brandsService;
        /// <param name="hostingEnvironment">Hosting environment</param>
        private readonly IHostingEnvironment hostingEnvironment;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="snowboardsService">Snowboards service</param>
        /// <param name="brandsService">Brands service</param>
        /// <param name="hostingEnvironment">Hosting environment</param>
        public SnowboardController(ISnowboardsService snowboardsService, IBrandsService brandsService, IHostingEnvironment hostingEnvironment) {
            this.snowboardsService = snowboardsService;
            this.brandsService = brandsService;
            this.hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Creates a CreateSnowboardViewModel and returns the Create view
        /// </summary>
        /// <returns>Create view</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Create() {
            var model = new CreateSnowboardViewModel() { Brands = brandsService.GetAllBrandsViewModel()};
            return View(model);
        }

        /// <summary>
        /// Retrieves a SnowboardDetailsViewModel and returns the Details view
        /// </summary>
        /// <param name="id">The snowboard's id</param>
        /// <returns>Details view</returns>
        public IActionResult Details(int id) {
            var model = snowboardsService.GetDetailsViewModel(id);
            return this.View(model);
        }

        /// <summary>
        /// Saves the snowboard image to the wwwroot/images directory, creates a snowboard and returns the Success view
        /// </summary>
        /// <param name="name">Snowboard name</param>
        /// <param name="imagePath">Snowboard image path</param>
        /// <param name="price">Snowboard price</param>
        /// <param name="size">Snowboard size in cm</param>
        /// <param name="description">Snowboard description</param>
        /// <param name="brandId">Snowboard brand id</param>
        /// <param name="profile">Snowboard profile</param>
        /// <param name="flex">Snowboard flex rating</param>
        /// <returns>Success view</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(string name, [FromForm] IFormFile image, decimal price, float size, string description, int brandId, Profile profile, byte flex) {

            var imagePath = Path.Combine(hostingEnvironment.WebRootPath + "\\images", Path.GetFileName(image.FileName));
            image.CopyTo(new FileStream(imagePath, FileMode.Create));

            if (ModelState.IsValid) {
                var snowboard = snowboardsService.CreateSnowboard(name, imagePath, price, size, description, brandId, profile, flex);
            }
            return this.RedirectToAction("Success", "Home");
           
        }
    }
}