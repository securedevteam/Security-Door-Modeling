using SecurityDoor.BL.Controllers;
using SecurityDoors.BL.Controllers;
using SecurityDoors.DAL.ViewModels;
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
		private DoorViewModel doorsViewModel = new DoorViewModel();

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
			var cacheController = new CacheController
			{
				Doors = doorsViewModel.Doors,
				People = dataGridViewModel.PeopleAndCardsList
			};

			cacheController.SaveCacheData();

			LoggerController.Log = "Сохранение данных в файл закончено";
		}

		/// <summary>
		/// Выполняет загрузку данных из API
		/// </summary>
		private async void UpdateThroughtAPIToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoggerController.Log = "Начата загрузка данных из API";

			var webConnection = new WebConnectionController();
			var listOfPeopleAndCards = await webConnection.GetPeopleFromAPIAsync();
			var listOfDoors = await webConnection.GetDoorsFromAPIAsync();
			if (listOfDoors.Count != 0 || listOfPeopleAndCards.Count != 0)
			{
				LoggerController.Log = "Загрузка данных из API прошла успешно";
				dataGridViewModel.PeopleAndCardsList = listOfPeopleAndCards;
				doorsViewModel.Doors = listOfDoors;
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
		private async void ButtonStart_Click(object sender, EventArgs e)
		{
			var parseCountSuccess = int.TryParse(numericUpDownRepeatCount.Value.ToString(), out int count);
			var parseDelaySuccess = int.TryParse(numericUpDownDelay.Value.ToString(), out int delay);

			if (parseCountSuccess && parseDelaySuccess)
			{
				do
				{
					var webConnection = new WebConnectionController();
					await webConnection.SendMessageAsync(dataGridViewModel.PeopleAndCardsList, comboBoxDoors.SelectedValue.ToString());
					
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

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var about = new About();
			about.ShowDialog();
		}
	}
}
