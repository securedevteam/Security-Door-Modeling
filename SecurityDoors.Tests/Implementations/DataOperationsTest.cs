using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BLL.Interfaces;

namespace SecurityDoors.Tests.Implementations
{
    [TestClass]
    public class DataOperationsTest 
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IDataOperations _dataOperations;

        public DataOperationsTest(ServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _dataOperations = _serviceProvider.GetRequiredService<IDataOperations>();
        }

        [TestMethod]
        public void LoadDataAsync_Return_True()
        {

        }

        [Fact]
        public void DownloadDataFromAPIAsync_Return_True()
        {

        }
    }
}
