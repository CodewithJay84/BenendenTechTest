using Benenden.Core.DAL;
using Benenden.Core.Models;
using Benenden.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemberTests
{
    [TestClass]
    public class UnitTest2
    {
        DbContextOptions<BenendenContext> options;
        public UnitTest2()
        {
            var builder = new DbContextOptionsBuilder<BenendenContext>();
            builder.UseInMemoryDatabase("Test");
            options = builder.Options;
        }
        [TestMethod]
        public void TestMethod1()
        {
            // AAA(Arrange, Act, Assert)
            // Arrange
            var Product1 = new Product
            {
                Name = "HealthCare",
                Cost = 100.00f
            };
            var context = new BenendenContext(options);
            context.Add(Product1);
            context.SaveChanges();
            //Act
            var p = new ProductRepository(context);
            var result = p.Get(1);
            //Assert
            Assert.AreEqual("HealthCare", result.Name);
        }
    }
}
