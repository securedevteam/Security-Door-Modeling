using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BLL.Interfaces;

namespace SecurityDoors.Tests.Implementations
{
    [TestClass]
    public class WebConnectionTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IWebConnection _webConnection;

        public WebConnectionTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _webConnection = _serviceProvider.GetRequiredService<IWebConnection>();
        }

        [TestMethod]
        public void GetDataFromAPIAsync_Return_True()
        {

        }

        [TestMethod]
        public void CheckConnectionAsync_Return_True()
        {

        }
    }
}
