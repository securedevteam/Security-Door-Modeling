using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SecurityDoors.WPFApp.Controllers
{
    public class TCPController
    {
        public const int DefaultPort = 1234;
        public const string DefaultServer = "127.0.0.1";
        private int port;
        private string server;

        private TcpClient client = new TcpClient();

        public TCPController(int? port, string server)
        {
            if (port == null && server == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.port = (int)port;
                this.server = server;
            }
        }

        public TCPController()
        {
            port = Properties.Settings.Default.port;
            server = Properties.Settings.Default.host;
        }

        /// <summary>
        /// Проверяет возможность доступность сервера
        /// </summary>
        /// <returns>True - если подключение возможно</returns>
        public bool CheckServerAvailability()
        {
            try
            {
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
            StringBuilder serverResponse = new StringBuilder();
            if (string.IsNullOrEmpty(message))
            {
                return "Получено пустое сообщение.";
            }

            client.Connect(server, port);
            if (client.Connected)
            {
                byte[] data = new byte[256];
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
    }
}
