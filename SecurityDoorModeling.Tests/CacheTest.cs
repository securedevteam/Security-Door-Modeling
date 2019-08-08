using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BLL;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;

using Xunit;

namespace SecurityDoorModeling.Tests
{
    public class CacheTest : IClassFixture<ServiceFixture> 
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly DataManager _dataManagerService;

        public CacheTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dataManagerService = _serviceProvider.GetRequiredService<DataManager>();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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
