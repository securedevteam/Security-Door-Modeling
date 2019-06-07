﻿using SecurityDoors.WPFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.WPFApp.Controllers
{
	public class MessageController
	{
		private readonly SocketController socketController;
		public int CountOfMessages { get; set; }

		public MessageController()
		{
			socketController = new SocketController(1234, "127.0.0.1");
		}

		/// <summary>
		/// Отправляет список сообщений
		/// </summary>
		/// <param name="messages"></param>
		public void SendMessages (List<Message> messages)
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
		public void SendMessage (Message message)
		{
			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			CountOfMessages++;

			var messageBody = $"{message.PersonName}#{message.PersonCard}#{message.DoorId}#{message.DoorAccessLevel}";
			socketController.SendMessage(messageBody);
		}
	}
}
