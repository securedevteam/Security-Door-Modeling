using SecurityDoors.BL.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BL.Controllers
{
    public class MessageController
    {
        public int CountOfMessages { get; set; }

        public MessageController()
        {
			
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
			var secretKey = SecurityDoor.BL.Properties.Settings.Default.SecretKey;
            var messageBody = $"{secretKey}${message.PersonCard}${message.DoorName}";
        }
    }
}
