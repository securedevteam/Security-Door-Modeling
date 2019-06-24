﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace SecurityDoors.BL.Controllers
{
    public class TCPController
    {
        public const int DefaultPort = 1234;
        public const string DefaultServer = "127.0.0.1";
        private readonly int port;
        private readonly string server;

		private TcpClient client;// = new TcpClient();

        public TCPController(int? port, string server)
        {
            if (port == null || string.IsNullOrWhiteSpace(server))
            {
                throw new ArgumentNullException($"port {port}, server {server}");
            }
            else
            {
                this.port = (int)port;
                this.server = server;
            }
		}

		/// <summary>
		/// TODO: Перенести настройки по умолчанию из UI в BL
		/// </summary>
        public TCPController()
        {
            port = SecurityDoor.BL.Properties.Settings.Default.port;
            server = SecurityDoor.BL.Properties.Settings.Default.host;
        }

        /// <summary>
        /// Проверяет доступность сервера
        /// </summary>
        /// <returns>True - если подключение возможно</returns>
        public bool CheckServerAvailability()
        {
            try
            {
				client = new TcpClient();
				client.Connect(server, port);
                if (client.Connected)
                {
                    client.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Отправляет список сообщений на сервер
        /// </summary>
        /// <param name="messages">Список сообщений</param>
        /// <returns>Список ответов</returns>
        [Obsolete]
        public List<string> SendMessages(List<string> messages)
        {
            if (messages == null)
            {
                return new List<string>() { };
            }

            var responses = new List<string>() { };
            string response;
            foreach (var message in messages)
            {
                response = SendMessage(message);
                responses.Add(response);
            }
            return responses;
        }

        /// <summary>
        /// Отправляет сообщение на сервер
        /// </summary>
        /// <param name="message">Строка сообщения</param>
        /// <returns>Ответ сервера</returns>
        public string SendMessage(string message)
        {
			byte[] data = new byte[256];

			StringBuilder serverResponse = new StringBuilder();
            if (string.IsNullOrEmpty(message))
            {
                return "Получено пустое сообщение.";
            }
			client = new TcpClient();
            client.Connect(server, port);
            if (client.Connected)
            {
				NetworkStream stream = client.GetStream();

				data = Encoding.UTF8.GetBytes(message);
				stream.Write(data, 0, data.Length);

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    serverResponse.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable); // пока данные есть в потоке

                // Закрываем потоки
                stream.Close();
                client.Close();
                return serverResponse.ToString();
            }
            else
            {
                return "Connection failed.";
            }
        }

		public List<string> GetDoorsFromAPI (string url = "http://localhost:49883/api/doors")
		{
			try
			{
				using (var webClient = new WebClient())
				{
					webClient.Encoding = Encoding.UTF8;
					var response = webClient.DownloadString(url);
					var listOfDoors = JsonConvert.DeserializeObject<List<string>>(response);
					return listOfDoors;
				}
			}
			catch (WebException webExc)
			{
				return new List<string>();
			}
		}

		public List<string> GetCardsFromAPI (string url = "http://localhost:49883/api/cards")
		{
			try
			{
				using (var webClient = new WebClient())
				{
					webClient.Encoding = Encoding.UTF8;
					var response = webClient.DownloadString(url);
					var listOfDoors = JsonConvert.DeserializeObject<List<string>>(response);
					return listOfDoors;
				}
			}
			catch (WebException webExc)
			{
				return new List<string>();
			}
		}
	}
}
