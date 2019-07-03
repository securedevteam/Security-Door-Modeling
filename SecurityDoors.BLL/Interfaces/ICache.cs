using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Interfaces
{
    interface ICache
    {
        /// <summary>
        /// Запуск загрузки данных из файлов.
        /// </summary>
        void LoadCacheDataAsync();

        /// <summary>
        /// Загрузка данных из файлов.
        /// </summary>
        /// <returns>Результат операции.</returns>
        bool LoadCacheData();

        /// <summary>
        /// Запуск сохренения данных в файлах.
        /// </summary>
        void SaveCacheDataAsync();

        /// <summary>
        /// Сохранение данных в файлах.
        /// </summary>
        /// <returns>Результат операции.</returns>
        bool SaveCacheData();

        /// <summary>
        /// Запуск очистки данных в файлах.
        /// </summary>
        void ClearCacheFileAsync();

        /// <summary>
        /// Очистка данных в определенных файлах.
        /// </summary>
        /// <returns>Результат операции.</returns>
        bool ClearCacheFile();
    }
}
