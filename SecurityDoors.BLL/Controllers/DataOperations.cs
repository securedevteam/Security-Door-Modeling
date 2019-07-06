using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Controllers
{
    /// <summary>
    /// Операции с данными.
    /// </summary>
    public class DataOperations
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataOperations()
        {
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
            else
            {
                result.listOfCards = null;
                result.listOfDoors = null;

                return result;
            }
        }
    }
}
