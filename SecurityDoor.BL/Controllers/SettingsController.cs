using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoor.BL.Controllers
{
	public static class SettingsController
	{
		private static string iP = Properties.Settings.Default.IP;
		private static int port = Properties.Settings.Default.Port;
		private static int portApi = Properties.Settings.Default.PortApi;
		private static string secretKey = Properties.Settings.Default.SecretKey;

		public static string IP { get => iP; set => iP = value; }
		public static int Port { get => port; set => port = value; }
		public static int PortApi { get => portApi; set => portApi = value; }
		public static string SecretKey { get => secretKey; set => secretKey = value; }

		/// <summary>
		/// Проверяет и сохраняет настроки, если они прошли проверку
		/// </summary>
		/// <returns>null в случае успеха или ошибку</returns>
		public static string SaveProperties()
		{
			var checkResult = CheckSettings(iP, port, portApi, secretKey);
			if (checkResult == null)
			{
				Properties.Settings.Default.IP = iP;
				Properties.Settings.Default.Port = port;
				Properties.Settings.Default.PortApi = portApi;
				Properties.Settings.Default.SecretKey = secretKey;
				Properties.Settings.Default.Save();
				return null;
			}
			else
				return checkResult;
		}

		/// <summary>
		/// Выполняет проверку настроек
		/// </summary>
		/// <param name="ip">IP-адрес</param>
		/// <param name="port">Порт</param>
		/// <param name="portApi">Порт API</param>
		/// <param name="secretKey">Секретный ключ</param>
		/// <returns>null в случае успеха или ошибку</returns>
		public static string CheckSettings (string ip, int? port, int? portApi, string secretKey)
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

			if (string.IsNullOrEmpty(secretKey) || string.IsNullOrWhiteSpace(secretKey))
			{
				return new ArgumentException("Получен null или пустая строка", nameof(secretKey)).ToString();
			}

			if (port < 0)
			{
				return "Порт не может быть отрицательным";
			}

			if (portApi < 0)
			{
				return "Порт не может быть отрицательным";
			}
			return null;
		}
	}
}
