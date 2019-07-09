using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.Core
{
    /// <summary>
    /// Класс для преобразавания
    /// </summary>
    public class Parser
    {     
        /// <summary>
        /// Преобразует значение введеное с консоли
        /// </summary>
        /// <typeparam name="T">тип в который надо преобразовать</typeparam>
        /// <param name="message">значение для вывода на консоль</param>
        /// <returns>Преобразованое значение</returns>
        public T ParseValueFromConsole<T>(string message) where T : IConvertible
        {
            while (true)
            {
                Console.Write(message);
                
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
                else if (typeof(T) == typeof(long))
                {                    
                    if (long.TryParse(Console.ReadLine(), out long result))
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
