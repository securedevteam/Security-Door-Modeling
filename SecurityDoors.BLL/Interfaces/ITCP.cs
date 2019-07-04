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
		Task<bool> SendMessagesAsync(List<TCPMessage> messages, int delay, int count);
    }
}
