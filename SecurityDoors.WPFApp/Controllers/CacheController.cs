using SecurityDoors.WPFApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.WPFApp.Controllers
{
	public class CacheController
	{
		/// <summary>
		/// Локер для доступа к файлу
		/// </summary>
		private object locker;
		private List<Person> people = new List<Person>();
		private List<Door> doors = new List<Door>();

		public List<Door> Doors {
			get
			{
				LoadCachedDataAsync();
				return doors;
			}
			set => doors = value;
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
		public async void LoadCachedDataAsync ()
		{
			await Task.Run(() => LoadCacheData());
		}

		/// <summary>
		/// Загружает данные из файла
		/// </summary>
		/// <returns>В случае успеха возвращает true</returns>
		private bool LoadCacheData ()
		{
			lock (locker)
			{
				var formatter = new BinaryFormatter();
				using (var fs = new FileStream("People.dat", FileMode.Open, FileAccess.Read))
				{
					if (fs.Length > 0 && formatter.Deserialize(fs) is List<Person> result)
					{
						people = result;
					}
				}
				using (var fs = new FileStream("Doors.dat", FileMode.Open, FileAccess.Read))
				{
					if (fs.Length > 0 && formatter.Deserialize(fs) is List<Door> result)
					{
						Doors = result;
					}
				}
			}
			return true;
		}
		/// <summary>
		/// Сохраняет данные в файл кэша
		/// </summary>
		public async void SaveCacheDataAsync ()
		{
			await Task.Run(() => SaveCachedata());
		}
		private	bool SaveCachedata ()
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
					formatter.Serialize(fs, Doors);
				}
			}
			return true;
		}
		/// <summary>
		/// Очищает файл кэша
		/// </summary>
		public async void ClearCacheFileAsync ()
		{
			await Task.Run(() => ClearCacheFile());
		}
		private bool ClearCacheFile ()
		{
			///TODO: Реализовать
			return true;
		}
	}
}
