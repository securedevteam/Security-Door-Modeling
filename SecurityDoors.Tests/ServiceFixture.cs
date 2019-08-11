using SecurityDoors.BLL;
using SecurityDoors.BLL.Controllers;
using SecurityDoors.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace SecurityDoors.Tests
{
    public class ServiceFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public ServiceFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<ICache, Cache>();
            serviceCollection.AddScoped<IConnectionSettings, ConnectionSettings>();
            serviceCollection.AddScoped<IDataOperations, DataOperations>();
            serviceCollection.AddScoped<ITCP, TCP>();
            serviceCollection.AddScoped<IWebConnection, WebConnection>();

            serviceCollection.AddScoped<DataManager>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
