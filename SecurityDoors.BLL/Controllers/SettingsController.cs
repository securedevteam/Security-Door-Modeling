using SecurityDoors.Core;
using System;
using System.Text.RegularExpressions;

namespace SecurityDoors.BLL.Controllers
{
	public class SettingsController
	{
		private string iP = Properties.Settings.Default.IP;
		private int port = Properties.Settings.Default.Port;
		private int portApi = Properties.Settings.Default.PortApi;
		private string secretKey = Properties.Settings.Default.SecretKey;

		public string IP { get => iP; set => iP = value; }
		public int Port { get => port; set => port = value; }
		public int PortApi { get => portApi; set => portApi = value; }
		public string SecretKey { get => secretKey; set => secretKey = value; }

		/// <summary>
		/// Проверяет и сохраняет настроки, если они прошли проверку
		/// </summary>
		/// <returns>null в случае успеха или ошибку</returns>
		public string SaveProperties()
		{
			var checkResult = CheckSettings(iP, port, portApi, secretKey);
			if (checkResult == null)
			{
				Properties.Settings.Default.IP = IP;
				Properties.Settings.Default.Port = Port;
				Properties.Settings.Default.PortApi = PortApi;
				Properties.Settings.Default.SecretKey = SecretKey;
				Properties.Settings.Default.Save();
				return null;
			}
			else
				return checkResult;
		}


		public string SetDefaultProperties()
		{
			IP = Constants.DEFAULT_IP;
			Port = Constants.DEFAULT_PORT;
			PortApi = Constants.DEFAULT_PORT_API;
			SecretKey = Constants.DEFAULT_SECRET_KEY;
			var result = SaveProperties();
			return result;
		}

		/// <summary>
		/// Выполняет проверку настроек
		/// </summary>
		/// <param name="ip">IP-адрес</param>
		/// <param name="port">Порт</param>
		/// <param name="portApi">Порт API</param>
		/// <param name="secretKey">Секретный ключ</param>
		/// <returns>null в случае успеха или ошибку</returns>
		public static string CheckSettings(string ip, int? port, int? portApi, string secretKey)
		{
			if (string.IsNullOrEmpty(ip) || string.IsNullOrWhiteSpace(ip))
			{
				return new ArgumentException("Получен null или пустая строка", nameof(ip)).ToString();
			}

			if (port == null)
			{
				return new ArgumentNullException("Получен null", nameof(port)).ToString();
			}

			if (portApi == null)
			{
				return new ArgumentNullException("Получен null", nameof(portApi)).ToString();
			}

			if (string.IsNullOrEmpty(secretKey))
			{
				return new ArgumentException("Получен null", nameof(secretKey)).ToString();
			}

			if (port < 0)
			{
				return "Порт не может быть отрицательным";
			}

			if (portApi < 0)
			{
				return "Порт не может быть отрицательным";
			}

			Regex rgx = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
			if (ip.ToLower() != "localhost" && !rgx.Match(ip).Success)
			{
				return "IP введен неправильно";
			}
			return default;
		}
	}
}
