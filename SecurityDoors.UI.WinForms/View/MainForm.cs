﻿using SecurityDoors.BL.Controllers;
using SecurityDoors.BL.Models.ViewModels;
using SecurityDoors.UI.WinForms.Controllers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityDoors.UI.WinForms.View
{
	public partial class MainForm : Form
	{
		private DataGridViewModel dataGridViewModel = new DataGridViewModel();
		private DoorsViewModel doorsViewModel = new DoorsViewModel();

		public MainForm()
		{
			InitializeComponent();

			UpdateDataSource();
		}

		/// <summary>
		/// Обновляет данные на форме
		/// </summary>
		private void UpdateDataSource()
		{
			LoggerController.Log = "Устанавливаю привязки к форме";

			dataGridViewPeoplesAndCards.DataSource = dataGridViewModel.PeopleAndCardsList;
			dataGridViewPeoplesAndCards.AutoGenerateColumns = true;
			dataGridViewPeoplesAndCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			dataGridViewPeoplesAndCards.Columns[0].ReadOnly = true;
			dataGridViewPeoplesAndCards.Columns[1].ReadOnly = true;
			dataGridViewPeoplesAndCards.Columns[2].ReadOnly = true;
			dataGridViewPeoplesAndCards.Columns[3].ReadOnly = true;

			comboBoxDoors.DataSource = doorsViewModel.Doors;
			comboBoxDoors.DisplayMember = "Name";
			comboBoxDoors.ValueMember = "Name";
		}

		private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoggerController.Log = "Открываю окно настроек";
			var settings = new Settings();
			settings.ShowDialog();
		}

		/// <summary>
		/// Выполняет загрузку данных из файла
		/// </summary>
		private void LoadDataFromFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoggerController.Log = "Начата загрузка данных из файла";
			var cacheController = new CacheController();

			doorsViewModel.Doors = cacheController.Doors;
			dataGridViewModel.PeopleAndCardsList = cacheController.People;

			UpdateDataSource();

			LoggerController.Log = "Загрузка из файла закончена";
		}
		/// <summary>
		/// Сохраняет данные в файл
		/// </summary>
		private void SaveDataToFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoggerController.Log = "Начато сохранение данных в файл";
			var cacheController = new CacheController();

			cacheController.Doors = doorsViewModel.Doors;
			cacheController.People = dataGridViewModel.PeopleAndCardsList;

			cacheController.SaveCacheData();

			LoggerController.Log = "Сохранение данных в файл закончено";
		}

		/// <summary>
		/// Выполняет загрузку данных из API
		/// </summary>
		private void UpdateThroughtAPIToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoggerController.Log = "Начата загрузка данных из API";

			var listOfPeopleAndCards = TCPController.GetListOfPeopleFromAPI();
			var lisrOfDoors = TCPController.GetListOfDoorsFromAPI();
			if (lisrOfDoors.Count != 0 || listOfPeopleAndCards.Count != 0)
			{
				LoggerController.Log = "Загрузка данных из API прошла успешно";
				dataGridViewModel.PeopleAndCardsList = listOfPeopleAndCards;
				doorsViewModel.Doors = lisrOfDoors;
				UpdateDataSource();
			}
			else
			{
				LoggerController.Log = "Загрузка данных из API неудачна";
			}
		}
		/// <summary>
		/// Запускает/останавливает тесты.
		/// </summary>
		private void ButtonStart_Click(object sender, EventArgs e)
		{
			var parseCountSuccess = int.TryParse(numericUpDownRepeatCount.Value.ToString(), out int count);
			var parseDelaySuccess = int.TryParse(numericUpDownDelay.Value.ToString(), out int delay);

			if (parseCountSuccess && parseDelaySuccess)
			{
				do
				{
					var messages = new List<BL.Models.Message>();
					foreach (var row in dataGridViewModel.PeopleAndCardsList)
					{
						if (row.Use)
						{
							messages.Add(new BL.Models.Message() { DoorName = comboBoxDoors.SelectedValue.ToString(), PersonCard = row.CardUniqueNumber });
						}
					}
					TCPController.SendMessages(messages);
					Thread.Sleep(new TimeSpan(0, 0, delay));
					count--;
				} while (count > 0);
			}
			else
			{
				LoggerController.Log = "Ошибка при конвертации";
			}
		}
		private void TimerUpdateLog_Tick(object sender, EventArgs e)
		{
			textBoxLog.Text = LoggerController.Log;
		}
	}
}
