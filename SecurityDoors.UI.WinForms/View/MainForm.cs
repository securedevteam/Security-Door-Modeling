using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityDoors.UI.WinForms.View
{
	public partial class MainForm : Form
	{
        private ConnectionSettings _cs;
        private List<string> listOfDoors = new List<string>();
        private List<string> listOfCards = new List<string>();

		public MainForm()
		{
			InitializeComponent();

            _cs = new ConnectionSettings();
		}

        // Полностью готово и реализовано
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log = Constants.SETTING_OPENING_WINDOW;
            var settings = new SettingForm(_cs);
            settings.ShowDialog();
        }

        // Полностью готово и реализовано
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutProjectForm();
            aboutForm.ShowDialog();
        }

        // Полностью готово и реализовано
        private async void UpdateThroughtAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log = Constants.DATA_API_DOWNLOADING_STARTED;

            try
            {
                var webConnection = new WebConnection(_cs);

                var listOfCards = await webConnection.GetDataFromAPIAsync("cards");
                var listOfDoors = await webConnection.GetDataFromAPIAsync("doors");

                if (listOfDoors.Count != 0 || listOfCards.Count != 0)
                {
                    var cache = new Cache(listOfCards, listOfDoors);

                    await cache.ClearCacheFileAsync();
                    await cache.SaveCacheDataAsync();

                    Logger.Log = Constants.DATA_API_SUCCESSED;
                }
            }
            catch 
            {
                Logger.Log = Constants.DATA_API_FAILED;
            }
        }












		private void LoadDataFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log = Constants.DATA_READING_STARTED;

            // TODO: Загрузка на форму
            
            Logger.Log = Constants.DATA_READING_ENDED;
        }















        /// <summary>
        /// Обновляет данные на форме
        /// </summary>
        private void UpdateDataSource()
		{
			Logger.Log = Constants.SETTING_BINDING_FORM;

			//dataGridViewPeoplesAndCards.DataSource = dataGridViewModel.PeopleAndCardsList;
			//dataGridViewPeoplesAndCards.AutoGenerateColumns = true;
			//dataGridViewPeoplesAndCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			//dataGridViewPeoplesAndCards.Columns[0].ReadOnly = true;
			//dataGridViewPeoplesAndCards.Columns[1].ReadOnly = true;
			//dataGridViewPeoplesAndCards.Columns[2].ReadOnly = true;
			//dataGridViewPeoplesAndCards.Columns[3].ReadOnly = true;

			//comboBoxDoors.DataSource = doorsViewModel.Doors;
			//comboBoxDoors.DisplayMember = "Name";
			//comboBoxDoors.ValueMember = "Name";
		}

		









		/// <summary>
		/// Запускает отправку тестов.
		/// </summary>
		private async void ButtonStart_Click(object sender, EventArgs e)
		{
			var parseCountSuccess = int.TryParse(numericUpDownRepeatCount.Value.ToString(), out int count);
			var parseDelaySuccess = int.TryParse(numericUpDownDelay.Value.ToString(), out int delay);

            if (listOfCards != null)
            {
			    if (parseCountSuccess && parseDelaySuccess)
			    {
                    foreach(var data in listOfCards)
                    {
                        var message = new TCPMessage()
                        {
                            PersonCard = "",
                            DoorName = ""
                        };

                        var tcp = new TCP(_cs);
                        tcp.SendMessage(message);

                        count--;

                        if(count == 0)
                        {
                            break;
                        }

                        await Task.Delay(delay);
                    }
                }
                else
                {
                    Logger.Log = Constants.CONVERSION_ERROR;
                }
            }
			else
			{
                // TODO: Сообщение, что невозможно.
            }
        }















		private void TimerUpdateLog_Tick(object sender, EventArgs e)
		{
			textBoxLog.Text = Logger.Log;
		}

		

        private void ConnectionSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_cs.IP + " " + _cs.Port + " " + _cs.PortAPI + " " + _cs.SecretKey);
        }
    }
}
