using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services;
using SnowboardShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Tests {
    public class ProductsServiceTests {

        [SetUp]
        public void Setup() {
        }

        [TestCase]
        public void GetSingleProductViewModel() {
            var service = new Mock<ProductsService>(null);

            var list = new List<ListProductViewModel>();
            list.Add(
                new ListProductViewModel() {
                    Id = 1,
                    Name = "test",
                    ImageName = "test.jpg",
                    Price = 1
                });
            list.Add(
                new ListProductViewModel() {
                    Id = 2,
                    Name = "test2",
                    ImageName = "test2.jpg",
                    Price = 2
                });

        }
    }
}