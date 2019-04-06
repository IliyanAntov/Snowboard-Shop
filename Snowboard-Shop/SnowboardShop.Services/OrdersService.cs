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

        private SnowboardShopDbContext context;

        public OrdersService(SnowboardShopDbContext context) {
            this.context = context;
        }

        public List<OrderSingleViewModel> GetViewModel() {

            List<OrderSingleViewModel> orders = new List<OrderSingleViewModel>();
            foreach (var order in this.context.Orders) {
                var items = GetItems(order.ShoppingCartId);
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

        private List<OrderItemViewModel> GetItems(int cartId) {
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
