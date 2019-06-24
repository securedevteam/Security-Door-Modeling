using SecurityDoor.BL.Controllers;
using SecurityDoors.BL.Controllers;
using SecurityDoors.BL.Models;
using SecurityDoors.BL.Models.ViewModels;
using SecurityDoors.BL.Windows;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace SecurityDoors.UI.View
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{		
		//TODO: Исправить именование класса на более понятное
		private DataGridViewModel dataGridView = new DataGridViewModel();
		private DoorsViewModel doorsViewModel = new DoorsViewModel();
		public MainWindow()
		{
			InitializeComponent();
			InitializeData();
		}

		/// <summary>
		/// Метод для заполнения формы данными с сервера или файла
		/// </summary>
		private void InitializeData()
		{
			dataGrid_persons.ItemsSource = dataGridView.PeopleAndCardsList;
			comboBox_door.ItemsSource = doorsViewModel.Doors;

			var tCPController = new TCPController();


			var isServerAvailable = tCPController.CheckServerAvailability();
			if (/*isServerAvailable*/ false)
			{
				///TODO: Отправить сообщение на сервер и запросить новые данные
			}
			else
			{
				var rnd = new DataRandomiserController();
				rnd.MakeRandomData();

				var listOfPeole = rnd.randomPeople;
				var listOfDoors = rnd.randomDoors;

				foreach (var person in listOfPeole)
				{
					var newPerson = new PeopleAndCardsViewModel()
					{
						Name = $"{person.FirstName} {person.SecondName} {person.LastName}",
						CardNumber = person.CardUniqueNumber
					};
					dataGridView.PeopleAndCardsList.Add(newPerson);
				}

				foreach (var door in listOfDoors)
				{
					doorsViewModel.Doors.Add(door.Name);
				}

				//var cacheController = new CacheController();
				//Заполнить кэш случайными данными
				//cacheController.People = listOfPeole;
				//cacheController.Doors = listOfDoors;
			}
		}
		/// <summary>
		/// обработчик кнопки "запустить"
		/// </summary>
		private void Btn_run_Click(object sender, RoutedEventArgs e)
		{
			//TODO: Реализовать получение списка действий и передать их на сервер в виде ФИО#Номер карты#Название двери
			var messages = new List<Message>();
			foreach (var item in textBox_testSet.Text)
			{
				var newMessage = new Message()
				{
					PersonCard = "",
					DoorName = ""
				};
				messages.Add(newMessage);
			}
			//messageController.SendMessages(messages);

			//TODO: Удалить после приведения кода в порядок

			var randomMessageSender = new RandomMessagesGenerator();
			randomMessageSender.MakeRandomMesages();
		}

		/// <summary>
		/// обработчик кнопки "настроить сеть"
		/// </summary>
		private void Btn_configureNetwork_Click(object sender, RoutedEventArgs e)
		{
			ConfigureNetwork configureNetwork = new ConfigureNetwork();
			configureNetwork.ShowDialog();
		}

		private List<Action> actionList = new List<Action>();
		/// <summary>
		/// обработчик кнопки "добавить действие"
		/// происходит добавление всех сотрудников отмеченых для проведения тестирования 
		/// в <c>Action</c> и добавление этого действия в колекцию действий
		/// </summary
		private void Btn_addInTest_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// проверка ввода в полне <c>field_pause</c> на то что введены только цифры и точка
		/// иначе ввод игнорируется 
		/// </summary>
		private void TextBox_pause_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
		}

		/// <summary>
		/// проверка ввода в полне <c>field_repeat</c> на то что введены только цифры
		/// иначе ввод игнорируется 
		/// </summary>
		private void TextBox_repeat_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
		}
	}
}
