using SecurityDoors.BLL;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityDoorModeling.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace SecurityDoors.Tests.Implementations
{
    [TestClass]
    public class DataOperationsTest 
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;

        public DataOperationsTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
        }

        [TestMethod]
        public void LoadDataAsync_Return_True()
        {

        }

        [TestMethod]
        public void DownloadDataFromAPIAsync_Return_True()
        {

        }
    }
}
