using System.Security.Policy;
using NUnit.Framework;
using RasPos.Rest.Modules;

namespace RasPos.UnitTests
{
    [TestFixture]
    public class ModuleHelperTests
    {
        [Test, Category("Unit")]
        public void GetAbsoluteUrlTest()
        {
            var str = ModuleHelper.GetAbsoluteUrl("relativeUrl");
            var url = new Url(str);
            Assert.IsNotNull(url);
        }
    }
}