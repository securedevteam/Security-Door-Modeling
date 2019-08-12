using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Interfaces
{
    public interface ICache
    {
        /// <summary>
        /// Запуск загрузки данных из файлов.
        /// </summary>
        Task<(List<string>, List<string>)> LoadCacheDataAsync();

        /// <summary>
        /// Загрузка данных из файлов.
        /// </summary>
        /// <returns>Результат операции.</returns>
        bool LoadCacheData();

        /// <summary>
        /// Запуск сохренения данных в файлах.
        /// </summary>
        Task SaveCacheDataAsync();

        /// <summary>
        /// Сохранение данных в файлах.
        /// </summary>
        /// <returns>Результат операции.</returns>
        bool SaveCacheData();

        /// <summary>
        /// Запуск очистки данных в файлах.
        /// </summary>
        Task ClearCacheFileAsync();

        /// <summary>
        /// Очистка данных в определенных файлах.
        /// </summary>
        /// <returns>Результат операции.</returns>
        bool ClearCacheFile();
    }
}
