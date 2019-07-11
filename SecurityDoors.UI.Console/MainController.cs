using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.UI.ConsoleApp
{
    /// <summary>
    /// Класс для вспомогательных действий класса Program.
    /// </summary>
    public class MainController
    {
        private TCP tcp;
        private Parser Parser;

        private List<string> listOfDoors = new List<string>();
        private List<string> listOfCards = new List<string>();

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainController()
        {
        }

        // TODO: в Task
        /// <summary>
        /// Заполнить настройки подключения данными.
        /// </summary>
        /// <returns>Настройки подключения.</returns>
        public ConnectionSettings ConfigurationSetting()
        {
            Console.Write("Please enter IP Address: ");
            var ip = Console.ReadLine();

            var port = Parser.ParseValueFromConsole<int>("Please enter port number: ");

            var portAPI = Parser.ParseValueFromConsole<int>("Please enter API port number: ");

            Console.Write("Please enter secret key: ");
            var key = Console.ReadLine();

            Console.WriteLine();

            var connectionSettings = new ConnectionSettings(ip, port, portAPI, key);
            return connectionSettings;
        }

        /// <summary>
        /// Загрузить данные с файла.
        /// </summary>
        /// <returns>Результат операции.</returns>
        public async Task<bool> LoadDataAsync()
        {
            Logger.Log = Constants.DATA_READING_STARTED;

            var dataOperation = new DataOperations();
            (bool status, List<string> cards, List<string> doors) = await dataOperation.LoadDataAsync();

            if (status)
            {
                listOfCards = cards;
                listOfDoors = doors;

                Logger.Log = Constants.DATA_READING_ENDED;

                return true;
            }
            else
            {
                Logger.Log = Constants.DATA_READING_FAILED;

                return false;
            }
        }

        /// <summary>
        /// Загрузить данные с API и с файла.
        /// </summary>
        /// <param name="connectionSettings">настройки подключения.</param>
        /// <returns>Результат операции.</returns>
        public async Task<bool> DownloadDataAsync(ConnectionSettings connectionSettings)
        {
            try
            {
                var dataOperation = new DataOperations(connectionSettings);
                var result = await dataOperation.DownloadDataFromAPIAsync();

                if (result)
                {
                    await LoadDataAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Отправить данные на сервер.
        /// </summary>
        /// <param name="connectionSettings">настройки подключения.</param>
        /// <returns>Результат операции.</returns>
        public async Task<bool> SendDataAsync(ConnectionSettings connectionSettings)
        {
            var count = Parser.ParseValueFromConsole<int>("Please enter a count of the message list: ");

            var repeat = Parser.ParseValueFromConsole<int>("Please enter a number to repeat the operation: ");

            var delay = Parser.ParseValueFromConsole<int>("Please enter a number to delay the operation: ");

            Console.WriteLine();

            if (listOfCards != null && listOfDoors != null)
            {
                var rnd = new Random();
                tcp = new TCP(connectionSettings);

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

                var result = await tcp.SendMessagesAsync(listOfMessages, delay, repeat);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
