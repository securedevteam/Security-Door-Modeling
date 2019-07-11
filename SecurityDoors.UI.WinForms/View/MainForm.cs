using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: Баг - не обновляет список, если данные в файле изменились!

namespace SecurityDoors.UI.WinForms.View
{
	public partial class MainForm : Form
	{
        private ConnectionSettings _cs;
        private List<string> listOfDoors = new List<string>();
        private List<string> listOfCards = new List<string>();
        private List<string> selectedListOfCards;
		private TCP tcp;

		public MainForm()
		{
			InitializeComponent();

            _cs = new ConnectionSettings();
		}

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log = Constants.SETTING_OPENING_WINDOW;
            var settings = new SettingForm(_cs);
            settings.ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutProjectForm();
            aboutForm.ShowDialog();
        }

        private async void UpdateThroughtAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log = Constants.DATA_API_DOWNLOADING_STARTED;

            try
            {
                var dataOperation = new DataOperations(_cs);
                var result = await dataOperation.DownloadDataFromAPIAsync();

                if(result)
                {
                    await LoadDataFromFilesAsync();

                    Logger.Log = Constants.DATA_API_SUCCESSED;
                }
                else
                {
                    Logger.Log = Constants.DATA_API_FAILED;
                }
            }
            catch 
            {
                Logger.Log = Constants.DATA_API_FAILED;
            }
        }

        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            Logger.Log = Constants.SENDING_MESSAGE_STARTED;

            selectedListOfCards = new List<string>();

			foreach (DataGridViewRow row in dataGridViewPeoplesAndCards.Rows)
			{
				if ((bool?)row.Cells[1].Value == true)
				{
					selectedListOfCards.Add(row.Cells[0].Value.ToString());
				}
			}

            var parseCountSuccess = int.TryParse(numericUpDownRepeatCount.Value.ToString(), out int count);
            var parseDelaySuccess = int.TryParse(numericUpDownDelay.Value.ToString(), out int delay);
            var result = false;
			
            if (selectedListOfCards != null && !string.IsNullOrWhiteSpace(comboBoxDoors.SelectedItem.ToString()))
            {
                if (parseCountSuccess && parseDelaySuccess)
                {
					tcp = new TCP(_cs);

					var listOfMessages = new List<TCPMessage>();

					foreach (var card in selectedListOfCards)
					{
						var message = new TCPMessage()
						{
							PersonCard = card,
							DoorName = comboBoxDoors.SelectedItem.ToString()
						};

						listOfMessages.Add(message);
					}

					result = await tcp.SendMessagesAsync(listOfMessages, delay, count);

					if (result)
                    {
                        Logger.Log = Constants.SENDING_MESSAGE_ENDED;
                    }
                    else
                    {
                        Logger.Log = Constants.SENDING_MESSAGE_FAILED;
                    }
                }
                else
                {
                    Logger.Log = Constants.CONVERSION_ERROR;
                }
            }
            else
            {
                Logger.Log = Constants.SENDING_MESSAGE_FAILED;
            }
        }

        private void UpdateDataSource()
        {
            Logger.Log = Constants.SETTING_BINDING_FORM;

            foreach (var card in listOfCards)
			{
				dataGridViewPeoplesAndCards.Rows.Add(card);
			}
        }

        private async Task LoadDataFromFilesAsync()
        {
            Logger.Log = Constants.DATA_READING_STARTED;

            var dataOperation = new DataOperations();
            (bool status, List<string> cards, List<string> doors) = await dataOperation.LoadDataAsync();

            if (status)
            {
                listOfCards = cards;
                listOfDoors = doors;

                comboBoxDoors.DataSource = listOfDoors;
                UpdateDataSource();

                Logger.Log = Constants.DATA_READING_ENDED;
            }
            else
            {
                comboBoxDoors.Items.Add(Constants.COMBOBOX_EMPTY);
                comboBoxDoors.SelectedItem = Constants.COMBOBOX_EMPTY;

                Logger.Log = Constants.DATA_READING_FAILED;
            }
        }

		private async void LoadDataFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LoadDataFromFilesAsync();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataFromFilesAsync();
        }

		private void TimerUpdateLog_Tick(object sender, EventArgs e)
		{
			textBoxLog.Text = Logger.Log;
		}
    }
}
