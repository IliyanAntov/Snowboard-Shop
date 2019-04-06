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
    public class OrderController : Controller
    {
        private IOrdersService ordersService;

        public OrderController(IOrdersService ordersService) {
            this.ordersService = ordersService;
        }

        [Authorize]
        public IActionResult Orders()
        {
            var model = new OrderListViewModel() {
                 Orders = ordersService.GetViewModel() };
            return View(model);
        }
    }
}