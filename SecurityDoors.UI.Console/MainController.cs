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
    public class MainController
    {
        private TCP tcp;

        private List<string> listOfDoors = new List<string>();
        private List<string> listOfCards = new List<string>();



        public MainController()
        {
        }


        // TODO: в Task
        public ConnectionSettings ConfigurationSetting()
        {
            Console.Write("Please enter IP Address: ");
            var ip = Console.ReadLine();

            Console.Write("Please enter port number: ");
            var port = int.Parse(Console.ReadLine());

            Console.Write("Please enter API port number: ");
            var portAPI = int.Parse(Console.ReadLine());

            Console.Write("Please enter secret key: ");
            var key = Console.ReadLine();

            Console.WriteLine();

            var connectionSettings = new ConnectionSettings(ip, port, portAPI, key);

            return connectionSettings;
        }


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




        public async Task<bool> SendDataAsync(ConnectionSettings connectionSettings)
        {
            Console.Write("Enter count of message list: ");
            var count = int.Parse(Console.ReadLine());

            Console.Write("Enter repeat: ");
            var repeat = int.Parse(Console.ReadLine());

            Console.Write("Enter delay: ");
            var delay = int.Parse(Console.ReadLine());

            Console.WriteLine();

            var result = false;

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

                result = await tcp.SendMessagesAsync(listOfMessages, delay, repeat);

                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
