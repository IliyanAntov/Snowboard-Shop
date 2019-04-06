using SnowboardShop.Data;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SnowboardShop.Services {
    public class OrdersService : IOrdersService {

        /// <param name="context">Application DbContext</param>
        private SnowboardShopDbContext context;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="context">Application DbContext</param>
        public OrdersService(SnowboardShopDbContext context) {
            this.context = context;
        }

        /// <summary>
        /// Maps all orders to OrderSingleViewModel, which contains the orderer's First name, Last name, Address, City, Phone number and the order's Total price and Items
        /// </summary>
        /// <returns>A list of OrderSingleViewModel, containing info about all orders</returns>
        public List<OrderSingleViewModel> GetOrderViewModel() {

            List<OrderSingleViewModel> orders = new List<OrderSingleViewModel>();
            foreach (var order in this.context.Orders) {
                var items = GetItemsViewModel(order.ShoppingCartId);
                var model = new OrderSingleViewModel() {
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    Address = order.Address,
                    City = order.City,
                    PhoneNumber = order.PhoneNumber,
                    TotalPrice = Math.Round(items.Sum(i => i.Price * i.Quantity), 2),
                    Items = items
                };
                orders.Add(model);
            }

            return orders;
        }

        /// <summary>
        /// Maps all items to OrderItemViewModel, which contains their Name, Price and Quantity
        /// </summary>
        /// <param name="cartId">The cart's id</param>
        /// <returns>A list of OrderItemViewModel, containing info about all items in a cart</returns>
        private List<OrderItemViewModel> GetItemsViewModel(int cartId) {
            var items = this.context.CartItems
                                  .Where(i => i.ShoppingCartId == cartId)
                                  .Include(i => i.Product)
                                  .Select(i => new OrderItemViewModel() {
                                      Name = i.Product.Name,
                                      Price = Math.Round(i.Product.Price, 2),
                                      Quantity = i.Quantity
                                  }).ToList();
            return items;
        }
    }
}
