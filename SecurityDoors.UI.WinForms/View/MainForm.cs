using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
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

        private ConnectionSettings _cs;

		public MainForm()
		{
			InitializeComponent();

            _cs = new ConnectionSettings();
			UpdateDataSource();
		}

		/// <summary>
		/// Обновляет данные на форме
		/// </summary>
		private void UpdateDataSource()
		{
			Logger.Log = Constants.SETTING_BINDING_FORM;

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
			Logger.Log = Constants.SETTING_OPENING_WINDOW;
			var settings = new SettingForm(_cs);
			settings.ShowDialog();
		}

















		/// <summary>
		/// Выполняет загрузку данных из файла
		/// </summary>
		private void LoadDataFromFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Logger.Log = Constants.DATA_READING_STARTED;
			var cacheController = new CacheController();

			doorsViewModel.Doors = cacheController.Doors;
			dataGridViewModel.PeopleAndCardsList = cacheController.People;

			UpdateDataSource();

			Logger.Log = Constants.DATA_READING_ENDED;
		}
		/// <summary>
		/// Сохраняет данные в файл
		/// </summary>
		private void SaveDataToFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Logger.Log = Constants.DATA_SAVING_STARTED;
			var cacheController = new CacheController
			{
				Doors = doorsViewModel.Doors,
				People = dataGridViewModel.PeopleAndCardsList
			};

			cacheController.SaveCacheData();

			Logger.Log = Constants.DATA_SAVING_COMPLETED;
		}

		/// <summary>
		/// Выполняет загрузку данных из API
		/// </summary>
		private async void UpdateThroughtAPIToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Logger.Log = Constants.DATA_API_DOWNLOADING_STARTED;

			var webConnection = new WebConnectionController();
			var listOfPeopleAndCards = await webConnection.GetPeopleFromAPIAsync();
			var listOfDoors = await webConnection.GetDoorsFromAPIAsync();
			if (listOfDoors.Count != 0 || listOfPeopleAndCards.Count != 0)
			{
				Logger.Log = Constants.DATA_API_SUCCESSED;
				dataGridViewModel.PeopleAndCardsList = listOfPeopleAndCards;
				doorsViewModel.Doors = listOfDoors;
				UpdateDataSource();
			}
			else
			{
				Logger.Log = Constants.DATA_API_FAILED;
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
				Logger.Log = Constants.CONVERSION_ERROR;
			}
		}
		private void TimerUpdateLog_Tick(object sender, EventArgs e)
		{
			textBoxLog.Text = Logger.Log;
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var aboutForm = new AboutProjectForm();
			aboutForm.ShowDialog();
		}

        private void ConnectionSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_cs.IP + " " + _cs.Port + " " + _cs.PortAPI + " " + _cs.SecretKey);
        }
    }
}
