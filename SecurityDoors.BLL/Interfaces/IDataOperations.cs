using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Interfaces
{
    public interface IDataOperations
    {
        /// <summary>
        /// Загрузить данные с файлов.
        /// </summary>
        /// <returns>Статус операции. Список карт. Список дверей.</returns>
        Task<(bool status, List<string> cards, List<string> doors)> LoadDataAsync();

        /// <summary>
        /// Загрузить данные с WebAPI.
        /// </summary>
        /// <returns>Результат операции.</returns>
        Task<bool> DownloadDataFromAPIAsync();
    }
}
