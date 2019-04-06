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
        /// <param name="service">Brands service</param>
        private IBrandsService service;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="service">Brands service</param>
        public BrandController(IBrandsService service) {
            this.service = service;
        }

        /// <summary>
        /// Returns the Create view
        /// </summary>
        /// <returns>Create View</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a brand and returns the Success view
        /// </summary>
        /// <param name="name">Brand name</param>
        /// <returns>Success view</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(string name) {

            this.service.CreateBrand(name);
            return this.RedirectToAction("Success", "Home");
        }
    }
}