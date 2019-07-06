using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.UI.ConsoleApp
{
    class Program
    {
        private static ConnectionSettings _cs;


        static void Main(string[] args)
        {
            ConfigurationSetting();
            var result = _cs.CheckSettings();



            Console.ReadLine();

            // Самотестирование.
            // Указать: файл с данными, файл с подключением, повтор: кол-во и период.
            // Отправка сформированных рандомных значений. Сообхение об этом. Асинхронность.
        }


        private static void ConfigurationSetting()
        {
            Console.Write("Enter IP address: ");
            var ip = Console.ReadLine();

            Console.Write("Enter port: ");
            var port = int.Parse(Console.ReadLine());

            Console.Write("Enter API port: ");
            var portAPI = int.Parse(Console.ReadLine());

            Console.Write("Enter secret key: ");
            var key = Console.ReadLine();

            _cs = new ConnectionSettings(ip, port, portAPI, key);


        }
    }
}
