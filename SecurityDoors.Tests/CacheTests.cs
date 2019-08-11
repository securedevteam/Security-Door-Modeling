using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityDoors.BLL.Interfaces;
using SecurityDoors.BLL.Controllers;

namespace SecurityDoors.Tests
{
    [TestClass()]
    public class CacheTests
    {
        [TestMethod()]
        public void LoadCacheDataTest_Return_True()
        {
            // Arrange
            ICache cache = new Cache();

            // Act
            var result = cache.LoadCacheData();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void SaveCacheDataTest_Return_True()
        {
            // Arrange
            ICache cache = new Cache();

            // Act
            var result = cache.SaveCacheData();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ClearCacheFileTest_Return_True()
        {
            // Arrange
            ICache cache = new Cache();

            // Act
            var result = cache.ClearCacheFile();

            // Assert
            Assert.IsTrue(result);
        }
    }
}