using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardShop.Services {
    public class CartsService : ICartsService{

        private SnowboardShopDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public CartsService(SnowboardShopDbContext context, UserManager<IdentityUser> userManager) {
            this.context = context;
            this.userManager = userManager;
        }

        public int AddItem(int productId, string username) {

            string userId = userManager.Users.FirstOrDefault(u => u.UserName == username).Id;

            if(this.context.ShoppingCarts.FirstOrDefault(c => c.UserId == userId) == null) {
                this.context.ShoppingCarts.Add(new ShoppingCart {
                    UserId = userId
                });
                context.SaveChanges();
            }
            var shoppingCartId = this.context.ShoppingCarts.FirstOrDefault(c => c.UserId == userId).Id;

            var item = new CartItem() {
                ProductId = productId,
                ShoppingCartId = shoppingCartId
            };

            this.context.CartItems.Add(item);
            context.SaveChanges();
            return item.Id;
        }

        public int RemoveItem(int id) {
            throw new NotImplementedException();
        }

    }
}
