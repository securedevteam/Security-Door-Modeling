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
        private List<string> selectedListOfCards = new List<string>();

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

                    await LoadDataFromFilesAsync();

                    Logger.Log = Constants.DATA_API_SUCCESSED;
                }
            }
            catch 
            {
                Logger.Log = Constants.DATA_API_FAILED;
            }
        }

        // Полностью готово и реализовано (Занести выбранные данные в selectedList..)
        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            Logger.Log = Constants.SENDING_MESSAGE_STARTED;

            //selectedListOfCards = выбранные из грида

            var parseCountSuccess = int.TryParse(numericUpDownRepeatCount.Value.ToString(), out int count);
            var parseDelaySuccess = int.TryParse(numericUpDownDelay.Value.ToString(), out int delay);
            var result = false;

            if (selectedListOfCards != null && !string.IsNullOrWhiteSpace(comboBoxDoors.SelectedItem.ToString()))
            {
                if (parseCountSuccess && parseDelaySuccess)
                {
                    foreach (var data in selectedListOfCards)
                    {
                        var message = new TCPMessage()
                        {
                            PersonCard = data,
                            DoorName = comboBoxDoors.SelectedItem.ToString()
                        };

                        var tcp = new TCP(_cs);
                        result = tcp.SendMessage(message);

                        if (!result)
                        {
                            break;
                        }

                        count--;

                        if (count == 0)
                        {
                            break;
                        }

                        await Task.Delay(delay);
                    }

                    if(result)
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

            dataGridViewPeoplesAndCards.DataSource = listOfCards;
            dataGridViewPeoplesAndCards.AutoGenerateColumns = true;
            dataGridViewPeoplesAndCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewPeoplesAndCards.Columns[0].ReadOnly = true;
        }

        // Полностью готово и реализовано (Добавить выборку из Grid)
        private async Task LoadDataFromFilesAsync()
        {
            Logger.Log = Constants.DATA_READING_STARTED;

            var cache = new Cache();
            var result = await cache.LoadCacheDataAsync();

            if (result.Item1.Count != 0 || result.Item1.Count != 0)
            {
                listOfCards = result.Item1;
                listOfDoors = result.Item2;

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
