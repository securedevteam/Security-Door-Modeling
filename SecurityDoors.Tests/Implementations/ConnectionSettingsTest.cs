using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using SecurityDoors.BLL.Interfaces;

namespace SecurityDoors.Tests.Implementations
{
    [TestClass]
    public class ConnectionSettingsTest : ServiceFixture
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnectionSettings _connectionSettings;

        private readonly Random rnd = new Random();
       
        public ConnectionSettingsTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _connectionSettings = _serviceProvider.GetRequiredService<IConnectionSettings>();
        }
        
        [TestMethod]
        public void SaveProperties_Return_True()
        {
            var expected = new ConnectionSettings()
            {
                IP = Guid.NewGuid().ToString(),
                Port = rnd.Next(),
                PortAPI = rnd.Next(),
                SecretKey = Guid.NewGuid().ToString()
            };

            var actual = _connectionSettings.SaveProperties();

            Assert.Equals(actual, Constants.SETTING_SAVE_SUCCESSED);
        }

        [TestMethod]
        public void SetDefaultProperties_Return_True()
        {
            var expected = new ConnectionSettings()
            {
                IP = Guid.NewGuid().ToString(),
                Port = rnd.Next(),
                PortAPI = rnd.Next(),
                SecretKey = Guid.NewGuid().ToString()
            };
           
        }
        
    }
}