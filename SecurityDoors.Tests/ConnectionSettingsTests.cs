using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityDoors.BLL.Controllers;
using SecurityDoors.BLL.Interfaces;

namespace SecurityDoors.Tests
{
    [TestClass()]
    public class ConnectionSettingsTests
    {
        [TestMethod()]
        public void SavePropertiesTest_Return_ResultString()
        {
            // Arrange
            IConnectionSettings connectionSettings = new ConnectionSettings("ip", 1234, 1234, "key");
            var operationResult = "Операция выполнена успешно.";

            // Act
            var result = connectionSettings.SaveProperties();

            // Assert
            Assert.AreEqual(operationResult, result);
        }

        [TestMethod()]
        public void CheckSettingsTest_Return_Null()
        {
            // Arrange
            IConnectionSettings connectionSettings = new ConnectionSettings("ip", 1234, 1234, "key");

            // Act
            var result = connectionSettings.CheckSettings();

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void CheckSettingsWithParamsTest_Return_Default()
        {
            // Arrange
            IConnectionSettings connectionSettings = new ConnectionSettings();

            // Act
            var result = connectionSettings.CheckSettings("ip", 1234, 1234, "key");

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}