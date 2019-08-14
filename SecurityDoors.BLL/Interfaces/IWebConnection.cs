using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Interfaces
{
	public interface IWebConnection
	{
        /// <summary>
        /// Получить данные по API.
        /// </summary>
        /// <param name="path">путь.</param>
        /// <returns>Список данных.</returns>
        Task<List<string>> GetDataFromAPIAsync(string path);

        /// <summary>
        /// Проверить возможность подключения.
        /// </summary>
        /// <param name="port">порт.</param>
        /// <returns>Результат проверки соединения.</returns>
        Task<bool> CheckConnectionAsync(int port);
    }
}
