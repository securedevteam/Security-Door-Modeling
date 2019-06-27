﻿using System;

namespace SecurityDoors.UI.WinForms.Controllers
{
	/// <summary>
	/// Хранит данные лога для текущего запуска программы
	/// </summary>
	public static class LoggerController
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
