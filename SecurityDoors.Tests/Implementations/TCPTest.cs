using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BLL.Interfaces;

namespace SecurityDoors.Tests.Implementations
{
    [TestClass]
    public class TCPTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly ITCP _tcp;

        public TCPTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _tcp = _serviceProvider.GetRequiredService<ITCP>();
        }

        [TestMethod]
        public void SendMessage_Return_True()
        {
            
        }

        [TestMethod]
        public void SendMessagesAsync_Return_True()
        {

        }
    }
}
