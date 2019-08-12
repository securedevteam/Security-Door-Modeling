using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityDoors.BLL.Controllers;
using SecurityDoors.BLL.Interfaces;

namespace SecurityDoors.Tests
{
    [TestClass()]
    public class WebConnectionTests
    {
        [TestMethod()]
        public void CheckConnectionAsyncTest()
        {
            // Arrange
            IWebConnection webConnection = new WebConnection();

            // Act
            var task = webConnection.CheckConnectionAsync(1234);
            task.Wait();

            var result = task.Result;

            // Assert
            Assert.IsFalse(result);
        }
    }
}