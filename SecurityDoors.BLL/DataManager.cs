using SecurityDoors.BLL.Interfaces;

namespace SecurityDoors.BLL
{
    public class DataManager
    {
        private readonly ICache _cache;
        private readonly IConnectionSettings _connectionSettings;
        private readonly IDataOperations _dataOperations;
        private readonly ITCP _tcp;
        private readonly IWebConnection _webConnection;

        public DataManager(ICache cache, IConnectionSettings connectionSettings, IDataOperations dataOperations, ITCP tcp, IWebConnection webConnection)
        {
            _cache = cache;
            _connectionSettings = connectionSettings;
            _dataOperations = dataOperations;
            _tcp = tcp;
            _webConnection = webConnection;
        }

        public ICache Cache { get { return _cache; } }

        public IConnectionSettings ConnectionSettings { get { return _connectionSettings; } }

        public IDataOperations DataOperations { get { return _dataOperations; } }

        public ITCP TCP { get { return _tcp; } }

        public IWebConnection WebConnection { get { return _webConnection; } }
    }
}
