using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.Core
{    
    public static class Parser
    {
        /// <summary>
        /// Преобразует значение введеное с консоли
        /// </summary>
        /// <param name="messege">значение для вывода на консоль</param>
        /// <returns>Преобразованое значение</returns>
        public static T ParseValueFromConsole<T>(string messege) where T : IConvertible
        {
            while (true)
            {
                Console.Write(messege);
                if (typeof(T) == typeof(int))
                {
                    if (int.TryParse(Console.ReadLine(), out int result))
                    {
                        return (T)Convert.ChangeType(result, typeof(T));
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (typeof(T) == typeof(double))
                {
                    if (double.TryParse(Console.ReadLine(), out double result))
                    {
                        return (T)Convert.ChangeType(result, typeof(T));
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    return default;
                }
            }

        }

    }
}
