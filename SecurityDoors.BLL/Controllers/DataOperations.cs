using SecurityDoors.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Controllers
{
    /// <summary>
    /// Операции с данными.
    /// </summary>
    public class DataOperations : IDataOperations
    {
        private readonly ConnectionSettings _cs;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataOperations()
        {
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="connectionSettings">настройки.</param>
        public DataOperations(ConnectionSettings connectionSettings)
        {
            _cs = connectionSettings;
        }

        /// <inheritdoc/>
        public async Task<(bool status, List<string> cards, List<string> doors)> LoadDataAsync()
        {
            var result = (status: false, listOfCards: new List<string>(), listOfDoors: new List<string>());
            
            var cache = new Cache();
            var cacheResult = await cache.LoadCacheDataAsync();

            if (cacheResult.Item1.Count != 0 || cacheResult.Item2.Count != 0)
            {
                result.listOfCards = cacheResult.Item1;
                result.listOfDoors = cacheResult.Item2;
                result.status = true;

                return result;
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<bool> DownloadDataFromAPIAsync()
        {
            var webConnection = new WebConnection(_cs);

            var listOfCards = await webConnection.GetDataFromAPIAsync("cards");
            var listOfDoors = await webConnection.GetDataFromAPIAsync("doors");

            if (listOfDoors.Count != 0 || listOfCards.Count != 0)
            {
                var cache = new Cache(listOfCards, listOfDoors);

                await cache.ClearCacheFileAsync();
                await cache.SaveCacheDataAsync();

                return true;
            }

            return false;
        }
    }
}
