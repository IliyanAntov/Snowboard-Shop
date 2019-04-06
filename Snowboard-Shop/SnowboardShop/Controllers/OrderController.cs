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
        /// <param name="ordersService">Orders service</param>
        private IOrdersService ordersService;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="ordersService">Orders service</param>
        public OrderController(IOrdersService ordersService) {
            this.ordersService = ordersService;
        }


        /// <summary>
        /// Creates an OrderListViewModel and returns the Orders view
        /// </summary>
        /// <returns>OrdersView</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Orders()
        {
            var model = new OrderListViewModel() {
                 Orders = ordersService.GetOrderViewModel() };
            return View(model);
        }
    }
}