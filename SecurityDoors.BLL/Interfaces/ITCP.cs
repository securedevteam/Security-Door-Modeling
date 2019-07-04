using SecurityDoors.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Interfaces
{
    interface ITCP
    {
        /// <summary>
        /// Отправить сообщение на DoorController.
        /// </summary>
        /// <param name="message">сообщение.</param>
        bool SendMessage(TCPMessage message);

        /// <summary>
        /// Запуск асинхронного метода отправки сообщений.
        /// </summary>
        /// <param name="messages">сообщение.</param>
        /// <param name="delay">пауза.</param>
        /// <param name="count">повтор.</param>
        /// <returns></returns>
		Task<bool> SendMessagesAsync(List<TCPMessage> messages, int delay, int count);
    }
}
