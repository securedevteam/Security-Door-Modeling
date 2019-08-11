using System;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using SecurityDoors.BLL.Interfaces;
using Xunit;

namespace SecurityDoors.Tests.Implementations
{
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
        
        [Fact]
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

            Assert.Equal(actual, Constants.SETTING_SAVE_SUCCESSED);
        }

        [Fact]
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