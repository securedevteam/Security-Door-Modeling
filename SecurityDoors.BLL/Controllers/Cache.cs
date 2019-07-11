using SecurityDoors.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Controllers
{
    public class Cache : ICache
    {
        /// <summary>
        /// Локер для доступа к файлу
        /// </summary>
        private static object locker = new object();

        private List<string> _cards = new List<string>();
        private List<string> _doors = new List<string>();

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Cache()
        {
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="cards">карты.</param>
        /// <param name="doors">двери.</param>
        public Cache(List<string> cards, List<string> doors)
        {
            _cards = cards;
            _doors = doors;
        }

        /// <inheritdoc/>
        public async Task<(List<string>, List<string>)> LoadCacheDataAsync()
        {
            await Task.Run(() => LoadCacheData());

            return (_cards, _doors);
        }

        /// <inheritdoc/>
        public bool LoadCacheData()
        {
            lock (locker)
            {
                var formatter = new BinaryFormatter();

                if (File.Exists("Cards.dat"))
                {
                    using (var fs = new FileStream("Cards.dat", FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        if (fs.Length > 0 && formatter.Deserialize(fs) is List<string> result)
                        {
                            _cards = result;
                        }
                    }
                }

                if (File.Exists("Doors.dat"))
                {
                    using (var fs = new FileStream("Doors.dat", FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        if (fs.Length > 0 && formatter.Deserialize(fs) is List<string> result)
                        {
                            _doors = result;
                        }
                    }
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public async Task SaveCacheDataAsync()
        {
            await Task.Run(() => SaveCacheData());
        }

        /// <inheritdoc/>
        public bool SaveCacheData()
        {
            lock (locker)
            {
                try
                {
                    var formatter = new BinaryFormatter();

                    using (var fs = new FileStream("Cards.dat", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        formatter.Serialize(fs, _cards);
                    }

                    using (var fs = new FileStream("Doors.dat", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        formatter.Serialize(fs, _doors);
                    }
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        /// <inheritdoc/>
        public async Task ClearCacheFileAsync()
        {
            await Task.Run(() => ClearCacheFile());
        }

        /// <inheritdoc/>
        public bool ClearCacheFile()
        {
            lock (locker)
            {
                try
                {
                    if (File.Exists("Cards.dat"))
                    {
                        File.Delete("Cards.dat");
                    }
                    if (File.Exists("Doors.dat"))
                    {
                        File.Delete("Doors.dat");
                    }
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
