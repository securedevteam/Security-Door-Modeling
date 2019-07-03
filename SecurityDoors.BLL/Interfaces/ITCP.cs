﻿using SecurityDoors.DAL.Models;

namespace SecurityDoors.BLL.Interfaces
{
    interface ITCP
    {
        /// <summary>
        /// Отправить сообщение на DoorController.
        /// </summary>
        /// <param name="message">сообщение.</param>
        bool SendMessage(TCPMessage message);
    }
}
