using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.Core
{
    //TODO: реализовать  Generic иначе перезагрузку методов
    public static class Parse
    {
        /// <summary>
        /// Преобразует значение введеное с консоли
        /// </summary>
        /// <param name="output">значение для вывода на консоль</param>
        /// <returns>Преобразованое значение</returns>
        public static int ParseValueFromConsole(string output)
        {
            while (true)
            {
                Console.Write(output);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                {
                    continue;
                }
            }

        }

    }
}
