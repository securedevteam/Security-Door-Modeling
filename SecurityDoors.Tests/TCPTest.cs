using SecurityDoors.BLL;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityDoorModeling.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace SecurityDoorsModelingUnitTests
{
   
    [TestClass]
    public class TCPTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;

        public TCPTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
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
