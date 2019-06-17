using SecurityDoors.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SecurityDoors.BL.Controllers
{
    public class CacheController
    {
        /// <summary>
        /// Локер для доступа к файлу
        /// </summary>
        private object locker = new object();
        private List<Person> people = new List<Person>();
        private List<Door> doors = new List<Door>();

        public List<Door> Doors
        {
            get
            {
                LoadCachedDataAsync();
                return doors;
            }
            set
            {
                doors = value;
                SaveCacheDataAsync();
            }
        }
        public List<Person> People
        {
            get
            {
                LoadCachedDataAsync();
                return people;
            }
            set
            {
                people = value;
                SaveCacheDataAsync();
            }
        }

        /// <summary>
        /// Загружает данные из файла
        /// </summary>
        public async void LoadCachedDataAsync()
        {
            await Task.Run(() => LoadCacheData());
        }

        /// <summary>
        /// Загружает данные из файла
        /// </summary>
        /// <returns>В случае успеха возвращает true</returns>
        public bool LoadCacheData()
        {
            lock (locker)
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream("People.dat", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    if (fs.Length > 0 && formatter.Deserialize(fs) is List<Person> result)
                    {
                        people = result;
                    }
                }
                using (var fs = new FileStream("Doors.dat", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    if (fs.Length > 0 && formatter.Deserialize(fs) is List<Door> result)
                    {
                        doors = result;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Сохраняет данные в файл кэша
        /// </summary>
        public async void SaveCacheDataAsync()
        {
            await Task.Run(() => SaveCachedata());
        }
        public bool SaveCachedata()
        {
            lock (locker)
            {
                var formatter = new BinaryFormatter();

                using (var fs = new FileStream("People.dat", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    formatter.Serialize(fs, people);
                }
                using (var fs = new FileStream("Doors.dat", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    formatter.Serialize(fs, doors);
                }
            }
            return true;
        }
        /// <summary>
        /// Очищает файл кэша
        /// </summary>
        public async void ClearCacheFileAsync()
        {
            await Task.Run(() => ClearCacheFile());
        }
        public bool ClearCacheFile()
        {
            lock (locker)
            {
                if (File.Exists("People.dat"))
                {
                    File.Delete("People.dat");
                }
                if (File.Exists("Doors.dat"))
                {
                    File.Delete("Doors.dat");
                }
            }
            return true;
        }
    }
}
