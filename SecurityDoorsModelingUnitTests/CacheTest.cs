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
    public class CacheTest : ServiceFixture
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;

        public CacheTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
        }

        [TestMethod]
        public void LoadCacheDataAsync_Return_True()
        {

            var listCards = new List<Card>();
            var expectedCards = 10;

            for (int i = 0; i < expectedCards; i++)
            {
                listCards.Add(new Card()
                {
                    UniqueNumber = Guid.NewGuid().ToString(),
                    Use = false
                });
            }

            var listDoors = new List<Door>();
            var expectedDoors = 10;

            for (int i = 0; i < expectedDoors; i++)
            {
                listDoors.Add(new Door()
                {
                    Name = Guid.NewGuid().ToString(),
                });
            }

        }

        [TestMethod]
        public void SaveCacheDataAsync_Return_True()
        {

            var expectedCards = new Card
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Use = false
            };

            var expectedDoors = new Door
            {
                Name = Guid.NewGuid().ToString()
            };

        }

        [TestMethod]
        public void ClearCacheFileAsync_Return_True()
        {

            var expectedCards = new Card
            {
                UniqueNumber = Guid.NewGuid().ToString(),
                Use = false
            };

            var expectedDoors = new Door
            {
                Name = Guid.NewGuid().ToString()
            };

        }
    }
}
