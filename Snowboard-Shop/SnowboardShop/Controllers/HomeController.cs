using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;

namespace SnowboardShop.Controllers {
    public class HomeController : Controller {

        /// <param name="productsService">Products service</param>
        private IProductsService productsService;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="productsService">Products service</param>
        public HomeController(IProductsService productsService) {
            this.productsService = productsService;
        }

        /// <summary>
        /// Returns the Index view
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// Creates a ShopPageViewModel and returns the Shop view
        /// </summary>
        /// <returns>Shop view</returns>
        public IActionResult Shop() {
            var model = new ShopPageViewModel() { Products = productsService.GetAllProductsViewModel()};
            return View(model);
        }

        /// <summary>
        /// Returns the About view
        /// </summary>
        /// <returns>About view</returns>
        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Returns the Contact view
        /// </summary>
        /// <returns>Contact view</returns>
        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Returns the Privacy view
        /// </summary>
        /// <returns>Privacy view</returns>
        public IActionResult Privacy() {
            return View();
        }

        /// <summary>
        /// Returns the Success view
        /// </summary>
        /// <returns>Success view</returns>
        public IActionResult Success() {
            return View();
        }

        /// <summary>
        /// Creates an ErrorViewModel and returns the Error view
        /// </summary>
        /// <returns>Error view</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
