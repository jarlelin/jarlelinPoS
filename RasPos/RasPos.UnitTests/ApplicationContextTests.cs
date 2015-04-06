using System.Linq;
using NUnit.Framework;
using RaspPos.BackgroundAgents;

namespace RasPos.UnitTests
{
    [TestFixture]
    public class ApplicationContextTests
    {
        [Test]
        public void GetProductsTest()
        {
            var app = new ApplicationContext();
            var p = app.Products;

            Assert.IsTrue(p.Any());
        }
    }
}