using Benenden.Core.DAL;
using Benenden.Core.Models;
using Benenden.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        DbContextOptions<BenendenContext> options;
        public UnitTest1()
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
            var Member1 = new Member
            {
                Forename = "Frank",
                Surname = "Thomas"
            };
            var context = new BenendenContext(options);
            context.Add(Member1);
            context.SaveChanges();
            //Act
            var p = new MemberRepository(context);
            var result = p.Get(1);
            //Assert
            Assert.AreEqual("Frank", result.Forename);
        }
    }
}