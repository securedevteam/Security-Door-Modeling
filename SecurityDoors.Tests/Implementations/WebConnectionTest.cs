using SecurityDoors.BLL;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;

namespace SecurityDoors.Tests.Implementations
{
    [TestClass]
    public class WebConnectionTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;

        public WebConnectionTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
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
