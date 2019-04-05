using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardShop.Services {
    public class CartsService : ICartsService {

        private SnowboardShopDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public CartsService(SnowboardShopDbContext context, UserManager<IdentityUser> userManager) {
            this.context = context;
            this.userManager = userManager;
        }

        public int AddItem(int productId, string username) {

            string userId = userManager.Users.FirstOrDefault(u => u.UserName == username).Id;

            if (this.context.ShoppingCarts.FirstOrDefault(c => c.UserId == userId) == null) {
                this.context.ShoppingCarts.Add(new ShoppingCart {
                    User = this.context.Users.FirstOrDefault(u => u.UserName == username),
                    UserId = userId
                });
                context.SaveChanges();
            }
            var shoppingCartId = this.context.ShoppingCarts.FirstOrDefault(c => c.UserId == userId).Id;

            CartItem item = this.context.CartItems.Where(i => i.ShoppingCartId == shoppingCartId).FirstOrDefault(i => i.ProductId == productId);

            if (item == null) {
                var newItem = new CartItem() {
                    ProductId = productId,
                    ShoppingCart = this.context.ShoppingCarts.FirstOrDefault(c => c.Id == shoppingCartId),
                    ShoppingCartId = shoppingCartId,
                    Quantity = 1
                };
                this.context.CartItems.Add(newItem);
            }
            else {
                item.Quantity++;
            }

            context.SaveChanges();
            return shoppingCartId;
        }

        public int RemoveItem(int id) {
            var item = this.context.CartItems.FirstOrDefault(i => i.Id == id);
            this.context.Remove(item);
            context.SaveChanges();
            return item.Id;
        }

        public List<ShoppingCartItemViewModel> GetAll() {
            return this.context.CartItems
                .Select(i => new ShoppingCartItemViewModel() {
                    Id = i.Id,
                    Name = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = Math.Round(i.Product.Price, 2)
                }).ToList();


            
        }
    }
}
