using SecurityDoors.BLL.Interfaces;
using System;

namespace SecurityDoors.BLL.Controllers
{
    public class ConnectionSettings : IConnectionSettings
    {
        /// <summary>
        /// IP адрес.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Порт.
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// API порт.
        /// </summary>
        public int? PortAPI { get; set; }
        
        /// <summary>
        /// Секретный ключ.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ConnectionSettings()
        {
            IP = Properties.Settings.Default.IP;
            Port = Properties.Settings.Default.Port;
            PortAPI = Properties.Settings.Default.PortApi;
            SecretKey = Properties.Settings.Default.SecretKey;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="ip">IP адрес.</param>
        /// <param name="port">порт.</param>
        /// <param name="portAPI">API порт.</param>
        /// <param name="key">секретный ключ.</param>
        public ConnectionSettings(string ip, int port, int portAPI, string key)
        {
            IP = ip;
            Port = port;
            PortAPI = portAPI;
            SecretKey = key;
        }

        /// <inheritdoc/>
        public string SaveProperties()
        {
            var checkResult = CheckSettings();

            if (checkResult == null)
            {
                Properties.Settings.Default.IP = IP;
                Properties.Settings.Default.Port = Port.Value;
                Properties.Settings.Default.PortApi = PortAPI.Value;
                Properties.Settings.Default.SecretKey = SecretKey;
                Properties.Settings.Default.Save();

                return "Операция выполнена успешно.";
            }

            return checkResult;           
        }

        /// <inheritdoc/>
        public void SetDefaultProperties()
        {
            IP = Properties.Settings.Default.IP;
            Port = Properties.Settings.Default.Port;
            PortAPI = Properties.Settings.Default.PortApi;
            SecretKey = Properties.Settings.Default.SecretKey;
        }

        /// <inheritdoc/>
        public string CheckSettings()
        {
            if (string.IsNullOrEmpty(IP) || string.IsNullOrWhiteSpace(IP))
            {
                return new ArgumentException("Получен null или пустая строка", nameof(IP)).ToString();
            }

            if (Port == null)
            {
                return new ArgumentNullException("Получен null", nameof(Port)).ToString();
            }

            if (PortAPI == null)
            {
                return new ArgumentNullException("Получен null", nameof(PortAPI)).ToString();
            }

            if (string.IsNullOrEmpty(SecretKey))
            {
                return new ArgumentException("Получен null", nameof(SecretKey)).ToString();
            }

            if (Port < 0)
            {
                return "Порт не может быть отрицательным";
            }

            if (PortAPI < 0)
            {
                return "Порт не может быть отрицательным";
            }

            return null;
        }

        /// <inheritdoc/>
        public string CheckSettings(string ip, int? port, int? portApi, string secretKey)
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

            return default;
        }
    }
}
