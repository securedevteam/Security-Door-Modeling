using SecurityDoor.BL.Interfaces;
using SecurityDoors.BL.Properties;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SecurityDoors.BL.Controllers;
using SecurityDoors.Core;

namespace SecurityDoor.BL.Controllers
{
	public class WebConnectionController : IWebConnection
	{
		private int port = Settings.Default.Port;
		private int portAPI = Settings.Default.PortApi;
		private string server = Settings.Default.IP;
		private string secretKey = Settings.Default.SecretKey;

		public int Port { get => port; set => port = value; }
		public int PortAPI { get => portAPI; set => portAPI = value; }
		public string Server { get => server; set => server = value; }
		public string SecretKey { get => secretKey; set => secretKey = value; }

		private TcpClient client = new TcpClient();

		public WebConnectionController(string server, int port, int portAPI, string secretKey)
		{
			Port = port;
			PortAPI = portAPI;
			if (string.IsNullOrWhiteSpace(server))
			{
				throw new ArgumentNullException(nameof(server));
			}
			if (string.IsNullOrEmpty(secretKey))
			{
				throw new ArgumentNullException(nameof(secretKey));
			}
			Server = server;
			SecretKey = secretKey;
		}

		public WebConnectionController()
		{

		}

		public async Task<bool> CheckServerConnectionAsync()
		{
			var result = await CheckServerConnectionAsync(Server, Port);
			if (result)
			{
				return true;
			}
			else
			{
				///TODO: если запущено веб-приложение, то не может проверить соединение с ним
				///нужно поправить
				result = await CheckServerConnectionAsync(Server, PortAPI);
				if (result)
				{
					return true;
				}
			}
			return false;
		}
		private async Task<bool> CheckServerConnectionAsync(string server, int port)
		{
			try
			{
				await client.ConnectAsync(server, port);
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

		public async Task<List<Door>> GetDoorsFromAPIAsync()
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri($"http://localhost:{PortAPI}");
				string response = default;
				var listOfStringDoors = new List<string>();
				var listOfDoors = new List<Door>();

				HttpResponseMessage responseMessage = await httpClient.GetAsync("/api/doors");
				if (responseMessage.IsSuccessStatusCode)
				{
					response = await responseMessage.Content.ReadAsStringAsync();
					listOfStringDoors = JsonConvert.DeserializeObject<List<string>>(response);
				}
				foreach (var door in listOfStringDoors)
				{
					listOfDoors.Add(new Door() { Name = door });
				}
				return listOfDoors;
			}
		}

		public async Task<List<Person>> GetPeopleFromAPIAsync()
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri($"http://localhost:{PortAPI}");
				string response = default;
				var listOfCards = new List<string>();
				var listOfPeople = new List<Person>();
				var dataRnd = new DataRandomiserController();
				dataRnd.MakeRandomData();
				var listOfRandomPeople = dataRnd.randomPeople;

				HttpResponseMessage responseMessage = await httpClient.GetAsync("/api/cards");
				if (responseMessage.IsSuccessStatusCode)
				{
					response = await responseMessage.Content.ReadAsStringAsync();
					listOfCards = JsonConvert.DeserializeObject<List<string>>(response);
				}

				int i = 0;
				foreach (var randomPerson in listOfRandomPeople)
				{
					if (i >= listOfCards.Count - 1)
						i = 0;

					randomPerson.CardUniqueNumber = listOfCards[i];
					i++;
				}
				listOfPeople.AddRange(listOfRandomPeople);
				return listOfPeople;
			}
		}

		public async Task<string> SendMessageAsync(string message)
		{
			if (string.IsNullOrEmpty(message))
				return default;
			try
			{
				byte[] data = new byte[256];
				StringBuilder serverResponse = new StringBuilder();
				client = new TcpClient();
				await client.ConnectAsync(server, port);

				if (client.Connected)
				{
					NetworkStream stream = client.GetStream();

					data = Encoding.UTF8.GetBytes(message);
					await stream.WriteAsync(data, 0, data.Length);

					do
					{
						int bytes = await stream.ReadAsync(data, 0, data.Length);
						serverResponse.Append(Encoding.UTF8.GetString(data, 0, bytes));
					}
					while (stream.DataAvailable); 

					stream.Close();
					client.Close();
				}
				return serverResponse.ToString();
			}
			catch (Exception e)
			{
				Logger.Log = e.ToString();
				return e.ToString();
			}
		}

		public async Task<string> SendMessageAsync(List<Person> people, string door)
		{
			if (people == null)
			{
				Logger.Log = new ArgumentNullException(nameof(people)).ToString();
				return default;
			}

			if (string.IsNullOrEmpty(door))
			{
				Logger.Log = new ArgumentException("message", nameof(door)).ToString();
				return default;
			}

			foreach (var person in people)
			{
				var message = $"{SecretKey}${person.CardUniqueNumber}${door}";
				var result = await SendMessageAsync(message);
				Logger.Log = result;
				return result;
			}
			return default;
		}
	}
}
