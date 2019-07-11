using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using System;
using System.Threading.Tasks;

// TODO: В константы.

namespace SecurityDoors.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Data modeling Application v1.0";

            GreetingMessage();

            var mainController = new MainController();

            var connectionSettings = mainController.ConfigurationSetting();
            var result = connectionSettings.CheckSettings(connectionSettings.IP, connectionSettings.Port, connectionSettings.PortAPI, connectionSettings.SecretKey);

            if (result == default)
            {
                Logger.Log = Constants.CONNECTION_ESTABLISHED;

                var t = Task.Run(() => StartProgram(mainController, connectionSettings));
                t.Wait();

                Console.WriteLine(Logger.Log);
            }
            else
            {
                Logger.Log = result;
                Console.WriteLine(Logger.Log);
                Console.WriteLine(Constants.SOFTWARE_OPERATION_FAILED);
            }

            Console.ReadLine();
        }

        private static async Task StartProgram(MainController mainController, ConnectionSettings cs)
        {
            Console.Write(Constants.ENTER_DOWNLOADING_BY_API);
            var result = Console.ReadLine();

            Console.WriteLine();

            switch (result)
            {
                case "n":
                case "N":
                    {
                        var load = await mainController.LoadDataAsync();

                        if (load)
                        {
                            await mainController.SendDataAsync(cs);

                            Logger.Log = Constants.SENDING_MESSAGE_ENDED;
                            Console.WriteLine($"{Constants.SOFTWARE_OPERATION_SUCCESSFULLY}\n");
                        } 
                        else
                        {
                            Logger.Log = Constants.SENDING_MESSAGE_FAILED;
                            Console.WriteLine($"{Constants.SOFTWARE_OPERATION_FAILED}\n");
                        }
                    }
                    break;

                case "y":
                case "Y":
                    {
                        Logger.Log = Constants.DATA_API_DOWNLOADING_STARTED;

                        var download = await mainController.DownloadDataAsync(cs);

                        if (download)
                        {
                            Logger.Log = Constants.DATA_API_SUCCESSED;

                            await mainController.SendDataAsync(cs);

                            Logger.Log = Constants.SENDING_MESSAGE_ENDED;
                            Console.WriteLine($"{Constants.SOFTWARE_OPERATION_SUCCESSFULLY}\n");
                        }
                        else
                        {
                            Logger.Log = Constants.DATA_API_FAILED;
                            Console.WriteLine($"{Constants.SOFTWARE_OPERATION_FAILED}\n");
                        }
                    }
                    break;

                default:
                    {
                        Console.WriteLine($"{Constants.SOFTWARE_OPERATION_EXIT}\n");
                    }
                    break;
            }
        }

        private static void GreetingMessage()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wellcome to data modeling system!\n");
            Console.ResetColor();
        }
    }
}
