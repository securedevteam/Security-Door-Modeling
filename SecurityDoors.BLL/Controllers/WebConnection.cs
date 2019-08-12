using Newtonsoft.Json;
using SecurityDoors.BLL.Interfaces;
using SecurityDoors.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Controllers
{
    public class WebConnection : IWebConnection
    {
        private ConnectionSettings _cs;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public WebConnection()
        {
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="connectionSettings">настройки.</param>
        public WebConnection(ConnectionSettings connectionSettings)
        {
            _cs = connectionSettings;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetDataFromAPIAsync(string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"http://localhost:{_cs.PortAPI}");

                var response = string.Empty;
                var listOfData = new List<string>();
                var responseMessage = await httpClient.GetAsync($"/api/{path}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await responseMessage.Content.ReadAsStringAsync();
                    listOfData = JsonConvert.DeserializeObject<List<string>>(response);
                }

                return listOfData;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> CheckConnectionAsync(int port)
        {
            try
            {
				TcpClient client = new TcpClient();
				await client.ConnectAsync(_cs.IP, port);

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
            catch (Exception e)
            {
				Logger.Log = e.ToString();
                return false;
            }
        }
    }
}
