using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.WPFApp.Controllers
{
	public class SocketController
	{
		private int port = 1234;
		private string ip = "127.0.0.1";

		public SocketController(int? port, string ip)
		{
			if (port == null && ip == null)
			{
				throw new ArgumentNullException();
			}
			else
			{
				this.port = (int)port;
				this.ip = ip;
			}
		}

		/// <summary>
		/// Отправляет список сообщений на сервер
		/// </summary>
		/// <param name="messages">Список сообщений</param>
		/// <returns>Список ответов</returns>
		[Obsolete]
		public List<string> SendMessages (List<string> messages)
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
		public string SendMessage (string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				return "Получено пустое сообщение.";
			}

			IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			StringBuilder serverResponse = new StringBuilder();

			socket.Connect(ipPoint);
			if (socket.Connected)
			{
				byte[] data = Encoding.Unicode.GetBytes(message);
				socket.Send(data);

				data = new byte[256];

				do
				{
					int bytes = socket.Receive(data, data.Length, 0);
					serverResponse.Append(Encoding.Unicode.GetString(data, 0, bytes));
				}
				while (socket.Available > 0);

				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
				return serverResponse.ToString();
			}
			else
			{
				return "Сервер не отвечает";
			}
		}
	}
}
