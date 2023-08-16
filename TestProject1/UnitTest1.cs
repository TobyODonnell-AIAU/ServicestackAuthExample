using Microsoft.AspNetCore.Http;
using ServiceStack;
using WebApplication.UnitTests.Controllers;
using WebApplication1.Controllers;

namespace TestProject1
{
    public class Tests
    {
        private static ServiceStackHost _appHost;

        [SetUp]
        public void Setup()
        {
            _appHost = new TestAppHost();
            _appHost.Init();
        }

        [Test]
        public void TestPrivacyPage()
        {
            var sut = _appHost.Resolve<HomeController>();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ServiceStackRequest.Items[Keywords.Session] = new AuthUserSession();

            var result = sut.Privacy();
            Assert.IsNotNull(result);
        }
    }
}