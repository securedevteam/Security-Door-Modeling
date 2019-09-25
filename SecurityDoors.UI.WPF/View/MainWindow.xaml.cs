using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using SecurityDoors.DAL.Models;
using SecurityDoors.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SecurityDoors.UI.WPF.View
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DispatcherTimer timer;
		private readonly ConnectionSettings _cs = new ConnectionSettings();
		private List<string> listOfCards;
		private List<string> listOfDoors;
		private readonly CardsUsingViewModel cardsUsingViewModel = new CardsUsingViewModel();

		public MainWindow()
		{
			InitializeComponent();

			timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
			timer.Tick += InterfaceUpdate;
			timer.Start();

            _ = LoadDataFromFilesAsync();
		}

		/// <summary>
		/// Метод для обновления данных на форме
		/// </summary>
		private void InterfaceUpdate(object sender = null, object e = null)
		{
			textBox_log.Text = Logger.Log ?? string.Empty;
		}

		/// <summary>
		/// обработчик кнопки "запустить"
		/// </summary>
		private async void Btn_run_Click(object sender, RoutedEventArgs e)
		{
			Logger.Log = Constants.SENDING_MESSAGE_STARTED;

			var selectedListOfCards = new List<string>();

			foreach (var card in cardsUsingViewModel.Cards)
			{
				if (card.Use)
				{
					selectedListOfCards.Add(card.UniqueNumber);
				}
			}

			var parseCountSuccess = int.TryParse(textBox_repeat.Text, out int count);
			var parseDelaySuccess = int.TryParse(textBox_pause.Text, out int delay);
			var selectedDoor = comboBox_door.SelectedItem.ToString();

			if (selectedListOfCards != null && !string.IsNullOrWhiteSpace(selectedDoor))
			{
				if (parseCountSuccess && parseDelaySuccess)
				{
					var tcp = new TCP(_cs);

					var listOfMessages = new List<TCPMessage>();

					foreach (var card in selectedListOfCards)
					{
						var message = new TCPMessage()
						{
							PersonCard = card,
							DoorName = selectedDoor
						};

						listOfMessages.Add(message);
					}

					var result = await tcp.SendMessagesAsync(listOfMessages, delay, count);

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

		/// <summary>
		/// обработчик кнопки "настроить сеть"
		/// </summary>
		private void Btn_configureNetwork_Click(object sender, RoutedEventArgs e)
		{
			Logger.Log = Constants.SETTING_OPENING_WINDOW;
			ConfigureNetwork configureNetwork = new ConfigureNetwork(_cs);
			configureNetwork.ShowDialog();
		}

		private async void Btn_loadFromApi_Click(object sender, RoutedEventArgs e)
		{
			Logger.Log = Constants.DATA_API_DOWNLOADING_STARTED;

			try
			{
				var dataOperation = new DataOperations(_cs);
				var result = await dataOperation.DownloadDataFromAPIAsync();

				if (result)
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

		private async Task LoadDataFromFilesAsync()
		{
			Logger.Log = Constants.DATA_READING_STARTED;

			var dataOperation = new DataOperations(_cs);
			(bool status, List<string> cards, List<string> doors) = await dataOperation.LoadDataAsync();

			if (status)
			{
				listOfCards = cards;
				listOfDoors = doors;

				UpdateDataSource();

				Logger.Log = Constants.DATA_READING_ENDED;
			}
			else
			{
				comboBox_door.Items.Add(Constants.COMBOBOX_EMPTY);
				comboBox_door.SelectedItem = Constants.COMBOBOX_EMPTY;

				Logger.Log = Constants.DATA_READING_FAILED;
			}
		}

		private void UpdateDataSource()
		{
			comboBox_door.Items.Clear();
			foreach (var door in listOfDoors)
			{
				comboBox_door.Items.Add(door);
			}
			comboBox_door.SelectedIndex = 0;

			cardsUsingViewModel.Cards.Clear();
			foreach (var card in listOfCards)
			{
				cardsUsingViewModel.Cards.Add(new DAL.Models.Card() { UniqueNumber = card , Use = false });
			}
			dataGrid_persons.ItemsSource = cardsUsingViewModel.Cards;
		}

		private async void Btn_SaveToFile_Click(object sender, RoutedEventArgs e)
		{
			await LoadDataFromFilesAsync();
		}

		/// <summary>
		/// проверка ввода в полне <c>field_pause</c> и <c>field_repeat</c> на то что введены только цифры
		/// иначе ввод игнорируется 
		/// </summary>
		private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
		}
	}
}
