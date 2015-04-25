using System.Linq;
using NUnit.Framework;
using RaspPos.BackgroundAgents;

namespace RasPos.UnitTests
{
    [TestFixture]
    public class ApplicationContextTests
    {
        [Test, Category("Unit")]
        public void GetProductsTest()
        {
            var ctx = new ApplicationContext("test");
            var p = ctx.Products;

            Assert.IsTrue(p.Any());

            Assert.AreEqual("test", ctx.Name);
        }
    }
}