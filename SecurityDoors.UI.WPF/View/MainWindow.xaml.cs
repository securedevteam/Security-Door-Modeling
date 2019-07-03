﻿using SecurityDoors.BLL.Controllers;
using SecurityDoors.DAL.Models;
using SecurityDoors.DAL.ViewModels;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace SecurityDoors.UI.WPF.View
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{		
		//TODO: Исправить именование класса на более понятное
		private DataGridViewModel dataGridView = new DataGridViewModel();
		private DoorViewModel doorsViewModel = new DoorViewModel();
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


			var isServerAvailable = TCPController.CheckServerAvailability();
			if (isServerAvailable)
			{
				var listOfCards = TCPController.GetListOfStringCardsFromAPI();
				var listOfDoors = TCPController.GetListOfDoorsFromAPI();
				doorsViewModel.Doors.AddRange(listOfDoors);

				///Так как было решено ограничиться только передачей карт и дверей, для наглядности люди будут генерироваться случайным образом, с присвоением им реальных карт.
				var rnd = new DataRandomiserController();
				rnd.MakeRandomData();
				var listOfPeole = rnd.randomPeople;

				int i = 0;
				foreach (var person in listOfPeole)
				{
					person.CardUniqueNumber = listOfCards[i];
					var newPerson = new Person()
					{
						CardUniqueNumber = person.CardUniqueNumber,
						FirstName = person.FirstName,
						SecondName = person.SecondName,
						LastName = person.LastName
					};
					dataGridView.PeopleAndCardsList.Add(newPerson);
					if (i >= listOfCards.Count + 1)
					{
						i = 0;
					}
					else
					{
						i++;
					}
				}

				//Записать скачанное в кэш
				var cacheController = new CacheController
				{
					Doors = listOfDoors,
					People = listOfPeole
				};
				cacheController.SaveCacheData();
			}
			else
			{
				var cacheController = new CacheController();
				cacheController.LoadCacheData();
				foreach (var person in cacheController.People)
				{
					dataGridView.PeopleAndCardsList.Add(new Person() { CardUniqueNumber = person.CardUniqueNumber, FirstName = person.FirstName, SecondName = person.SecondName, LastName = person.LastName });
				}
				foreach (var door in cacheController.Doors)
				{
					doorsViewModel.Doors.Add(new Door() { Name = door.Name });
				}
			}
		}
		/// <summary>
		/// обработчик кнопки "запустить"
		/// </summary>
		private void Btn_run_Click(object sender, RoutedEventArgs e)
		{
			var listofMessages = new List<Message>();
			foreach (var row in dataGridView.PeopleAndCardsList)
			{
				if (row.Use && comboBox_door.SelectedValue != null)
				{
					listofMessages.Add(new Message() {PersonCard = row.CardUniqueNumber, DoorName = comboBox_door.SelectedValue.ToString()});
				}
			}
			TCPController.SendMessages(listofMessages);
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