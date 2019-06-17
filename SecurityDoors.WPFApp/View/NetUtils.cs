using System.Net;

namespace SecurityDoors.BL.Windows
{
    public class NetUtils
    {
        public static bool isSettingValid(string host, int port)
        {
            return isPortValid(port) && IsAddressValid(host);
        }

        private const int MAX_NUMBER_PORT = 65_535;
        /// <summary>
        /// проверяет валидность ввеедного порта
        /// </summary>
        /// <param name="port">порт для проверка</param>
        /// <returns></returns>
        public static bool isPortValid(int port)
        {
            if (port > MAX_NUMBER_PORT || port == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// проверка валидности ip адресса
        /// </summary>
        /// <param name="addrString">строка содержащая ip адресс валидность которого надо проверить</param>
        /// <returns></returns>
        public static bool IsAddressValid(string addrString)
        {
            IPAddress address;
            return IPAddress.TryParse(addrString, out address);
        }
    }
}
