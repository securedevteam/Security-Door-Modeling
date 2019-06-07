using System;
using System.Collections.Generic;
using System.Linq;
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
			///TODO: Реализовать
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
			///TODO: Реализовать
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
