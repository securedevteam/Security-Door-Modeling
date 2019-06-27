using Newtonsoft.Json;
using SecurityDoor.BL.Controllers;
using SecurityDoors.BL.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SecurityDoors.BL.Controllers
{
	public static class TCPController
	{
		public const int DefaultPort = 1234;
		public const string DefaultServer = "127.0.0.1";
		private static int port = SecurityDoor.BL.Properties.Settings.Default.Port;
		private static string server = SecurityDoor.BL.Properties.Settings.Default.IP;

		private static TcpClient client;// = new TcpClient();

		public static void ConfigureTCPController(int port, string server)
		{
			TCPController.port = port;
			TCPController.server = server;
		}

		/// <summary>
		/// Проверяет доступность сервера
		/// </summary>
		/// <returns>True - если подключение возможно</returns>
		public static bool CheckServerAvailability()
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
		public static void SendMessages(List<Message> messages)
		{
			if (messages == null)
			{
				return;
			}

			foreach (var message in messages)
			{
				SendMessage(message);
			}
		}

		/// <summary>
		/// Отправляет сообщение на сервер
		/// </summary>
		/// <param name="message">Строка сообщения</param>
		public static void SendMessage(Message message)
		{
			if (message == null)
				return;

			byte[] data = new byte[256];
			var secretKey = SecurityDoor.BL.Properties.Settings.Default.SecretKey;
			var messageBody = $"{secretKey}${message.PersonCard}${message.DoorName}";
			StringBuilder serverResponse = new StringBuilder();
			client = new TcpClient();
			client.Connect(server, port);
			if (client.Connected)
			{
				NetworkStream stream = client.GetStream();

				data = Encoding.UTF8.GetBytes(messageBody);
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
			}
		}

		public static List<string> GetListOfStringDoorsFromAPI(string url = "http://localhost:49883/api/doors")
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
			catch (WebException)
			{
				return new List<string>();
			}
		}

		public static List<Door> GetListOfDoorsFromAPI(string url = "http://localhost:49883/api/doors")
		{
			try
			{
				using (var webClient = new WebClient())
				{
					webClient.Encoding = Encoding.UTF8;
					var response = webClient.DownloadString(url);
					var listOfDoors = JsonConvert.DeserializeObject<List<Door>>(response);
					return listOfDoors;
				}
			}
			catch (WebException)
			{
				return new List<Door>();
			}
		}
		public static List<string> GetListOfStringCardsFromAPI(string url = "http://localhost:49883/api/cards")
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
			catch (WebException)
			{
				return new List<string>();
			}
		}

		public static List<Card> GetListOfCardsFromAPI()
		{
			string url = $"http://localhost:{SettingsController.PortApi}/api/cards";
			try
			{
				using (var webClient = new WebClient())
				{
					webClient.Encoding = Encoding.UTF8;
					var response = webClient.DownloadString(url);
					var listOfDoors = JsonConvert.DeserializeObject<List<Card>>(response);
					return listOfDoors;
				}
			}
			catch (WebException)
			{
				return new List<Card>();
			}
		}

		public static List<Person> GetListOfPeopleFromAPI()
		{
			string url = $"http://localhost:{SettingsController.PortApi}/api/cards";
			try
			{
				using (var webClient = new WebClient())
				{
					webClient.Encoding = Encoding.UTF8;
					var response = webClient.DownloadString(url);
					var listOfCards = JsonConvert.DeserializeObject<List<Card>>(response);
					var listOfPeople = new List<Person>();

					var dataRnd = new DataRandomiserController();
					dataRnd.MakeRandomData();
					var listOfRandomPeople = dataRnd.randomPeople;

					int i = 0;
					foreach (var randomPerson in listOfRandomPeople)
					{
						if (i >= listOfCards.Count - 1)
							i = 0;

						randomPerson.CardUniqueNumber = listOfCards[i].UniqueNumber;
					}
					listOfPeople.AddRange(listOfRandomPeople);
					return listOfPeople;
				}
			}
			catch (WebException)
			{
				return new List<Person>();
			}
		}
	}
}
