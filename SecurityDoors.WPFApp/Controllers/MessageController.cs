using SecurityDoors.WPFApp.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.WPFApp.Controllers
{
    public class MessageController
    {
        private readonly TCPController tCPController;
        public int CountOfMessages { get; set; }

        public MessageController()
        {
			tCPController = new TCPController(1234, "127.0.0.1");
        }

        /// <summary>
        /// Отправляет список сообщений
        /// </summary>
        /// <param name="messages"></param>
        public void SendMessages(List<Message> messages)
        {
            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            foreach (var message in messages)
            {
                SendMessage(message);
            }
        }
        /// <summary>
        /// Отправляет сообщение на сервер
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            CountOfMessages++;

            var messageBody = $"{message.PersonName}#{message.PersonCard}#{message.DoorName}";
			tCPController.SendMessage(messageBody);
        }
    }
}
