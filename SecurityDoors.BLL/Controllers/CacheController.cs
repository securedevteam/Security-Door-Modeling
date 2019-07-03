using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SecurityDoors.BLL.Controllers
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
                LoadCacheData();
                return doors;
            }
            set
            {
                doors = value;
                SaveCacheData();
            }
        }
        public List<Person> People
        {
            get
            {
                LoadCacheData();
                return people;
            }
            set
            {
                people = value;
                SaveCacheData();
            }
        }

        /// <summary>
        /// Загружает данные из файла
        /// </summary>
        public async void LoadCacheDataAsync()
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
            await Task.Run(() => SaveCacheData());
        }

        public bool SaveCacheData()
        {
            lock (locker)
            {
				try
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
				catch (Exception)
				{
					return false;
				}
				return true;
			}
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
				try
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
				catch (Exception)
				{
					return false;
				}
				return true;
            }
        }
    }
}
