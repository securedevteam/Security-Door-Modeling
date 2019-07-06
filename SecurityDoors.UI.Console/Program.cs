using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using SecurityDoors.DAL.Models;
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
        private static List<string> listOfDoors = new List<string>();
        private static List<string> listOfCards = new List<string>();
        private static TCP tcp;

        static void Main(string[] args)
        {
            ConfigurationSetting();
            var result = _cs.CheckSettings();

            var t = Task.Run(() => LoadDataAsync());
            t.Wait();

            //var s = Task.Run(() => DownloadDataAsync());
            //s.Wait();

            var d = Task.Run(() => SendDataAsync());
            d.Wait();

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

        private static async Task LoadDataAsync()
        {
            Logger.Log = Constants.DATA_READING_STARTED;
            Console.WriteLine(Logger.Log);

            var dataOperation = new DataOperations();
            (bool status, List<string> cards, List<string> doors) = await dataOperation.LoadDataAsync();

            if (status)
            {
                listOfCards = cards;
                listOfDoors = doors;

                Logger.Log = Constants.DATA_READING_ENDED;
                Console.WriteLine(Logger.Log);
            }
            else
            {
                Logger.Log = Constants.DATA_READING_FAILED;
                Console.WriteLine(Logger.Log);
            }
        }

        private static async Task DownloadDataAsync()
        {
            Logger.Log = Constants.DATA_API_DOWNLOADING_STARTED;

            try
            {
                var dataOperation = new DataOperations(_cs);
                var result = await dataOperation.DownloadDataFromAPIAsync();

                if (result)
                {
                    await LoadDataAsync();

                    Logger.Log = Constants.DATA_API_SUCCESSED;
                }
                else
                {
                    Logger.Log = Constants.DATA_API_FAILED;
                }
            }
            catch
            {
                Logger.Log = Constants.DATA_API_FAILED;
            }
        }


        private static async Task SendDataAsync()
        {
            Console.Write("Enter count of message list: ");
            var count = int.Parse(Console.ReadLine());

            Console.Write("Enter repeat: ");
            var repeat = int.Parse(Console.ReadLine());

            Console.Write("Enter delay: ");
            var delay = int.Parse(Console.ReadLine());

            var result = false;

            if (listOfCards != null && listOfDoors != null)
            {
                var rnd = new Random();
                tcp = new TCP(_cs);

                var listOfMessages = new List<TCPMessage>();

                for (int i = 0; i < count; i++)
                {
                    var cardIndex = rnd.Next(0, listOfCards.Count);
                    var doorIndex = rnd.Next(0, listOfDoors.Count);

                    var message = new TCPMessage()
                    {
                        PersonCard = listOfCards[cardIndex],
                        DoorName = listOfDoors[doorIndex]
                    };

                    listOfMessages.Add(message);
                }

                result = await tcp.SendMessagesAsync(listOfMessages, delay, repeat);

                if (result)
                {
                    Logger.Log = Constants.SENDING_MESSAGE_ENDED;
                }
                else
                {
                    Logger.Log = Constants.SENDING_MESSAGE_FAILED;
                }
            }
            else
            {
                Logger.Log = Constants.SENDING_MESSAGE_FAILED;
            }
        }
    }
}
