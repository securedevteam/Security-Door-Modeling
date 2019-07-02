using System;

namespace SecurityDoors.Core
{
    /// <summary>
    /// Хранит данные лога для текущего запуска программы
    /// </summary>
    public static class Logger
    {
        private static string log;

        public static string Log
        {
            get => log;
            set
            {
                log = $"{DateTime.Now} {value + Environment.NewLine}{log}";
            }
        }
    }
}
