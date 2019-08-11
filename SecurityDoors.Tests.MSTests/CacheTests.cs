using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityDoors.BLL.Interfaces;
using SecurityDoors.BLL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.Tests
{
    [TestClass()]
    public class CacheTests
    {
        [TestMethod()]
        public void LoadCacheDataTest()
        {
            // Arrange
            ICache cache = new Cache();

            // Act
            var result = cache.LoadCacheData();

            // Assert
            Assert.IsTrue(result);
        }
    }
}