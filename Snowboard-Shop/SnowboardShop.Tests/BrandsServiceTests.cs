using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SnowboardShop.Data;
using SnowboardShop.Data.Models;
using SnowboardShop.Services;
using System.Collections.Generic;
using System.Linq;

namespace Tests {
    public class Tests {

        SnowboardShopDbContext context;

        [SetUp]
        public void Setup() {
            var mock = new Mock<SnowboardShopDbContext>();
        }

        [TestCase]
        public void CreateBrandShouldAddToDb() {
            //var mock = new Mock<SnowboardShopDbContext>();
            //mock.Setup(x => x.Set<IdentityUser>())
            //    .Returns(new FakeDbSet<IdentityUser> {
            //        new IdentityUser { Id = "asd" }
            //    });
            //Assert.Pass();

            var brands = new List<Brand>{
                new Brand()
              }.AsQueryable();

            brands.First().Name = "asd";

            var brandsMock = new Mock<DbSet<Brand>>();
            brandsMock.As<IQueryable<Brand>>().Setup(m => m.Provider).Returns(brands.Provider);
            brandsMock.As<IQueryable<Brand>>().Setup(m => m.Expression).Returns(brands.Expression);
            brandsMock.As<IQueryable<Brand>>().Setup(m => m.ElementType).Returns(brands.ElementType);
            brandsMock.As<IQueryable<Brand>>().Setup(m => m.GetEnumerator()).Returns(brands.GetEnumerator());

            var mockContext = new Mock<SnowboardShopDbContext>();
            mockContext.Setup(c => c.Brands).Returns(brandsMock.Object);

            var service = new BrandsService(mockContext.Object);

            var id = service.CreateBrand("asd");

            Assert.AreEqual(brands.First().Id, id);

        }
    }
}