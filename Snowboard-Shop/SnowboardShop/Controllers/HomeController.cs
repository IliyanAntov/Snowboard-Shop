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

        private IProductsService productsService;

        public HomeController(IProductsService productsService) {
            this.productsService = productsService;
        }

        public IActionResult Index() {
            return View();
        }
        
        public IActionResult Shop() {
            var model = new ShopPageViewModel() { Products = productsService.GetAll()};
            return View(model);
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Success() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
