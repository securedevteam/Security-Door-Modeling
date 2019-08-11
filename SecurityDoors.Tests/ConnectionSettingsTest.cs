using SecurityDoors.BLL;
using SecurityDoors.DAL.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityDoorModeling.Tests;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;

namespace SecurityDoorsModelingUnitTests
{
    [TestClass]
    public class ConnectionSettingsTest : ServiceFixture
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;

        private readonly Random rnd = new Random();
       
        public ConnectionSettingsTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
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

            var actual = _dataManagerService.ConnectionSettings.SaveProperties();

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