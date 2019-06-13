using SecurityDoors.WPFApp.Controllers;
using SecurityDoors.WPFApp.Windows;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace SecurityDoors.ModellingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		private WPFApp.Controllers.TCPController tCPController;
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
			///TODO: Подставить данные из ConfigureNetwork
			tCPController = new WPFApp.Controllers.TCPController(1234,"localhost");
			var isServerAvailable = tCPController.CheckServerAvailability();
			if (isServerAvailable)
			{
				///TODO: Отправить сообщение на сервер и запросить новые данные
			}
			else
			{
				// Раскоментировать для получения списков случайных людей/карт/дверей
				//var rnd = new DataRandomiserController();
				//rnd.MakeRandomData();

				//var listOfPeole = rnd.randomPeople;
				//var listOfDoors = rnd.randomDoors;
				//var listOfCards = rnd.randomCards;
				
				///TODO: Заполнить представление данными из кэша
				using (var cacheController = new WPFApp.Controllers.CacheController())
				{
					//Заполнить кэш случайными данными
					//cacheController.People = listOfPeole;
					//cacheController.Doors = listOfDoors;
					
					var listOfPeople = cacheController.People;
					var listOfDoord = cacheController.Doors;
				}

				
			}
		}
        /// <summary>
        /// обработчик кнопки "запустить"
        /// </summary>
        private void Btn_run_Click(object sender, RoutedEventArgs e)
        {
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

        private void Window_Initialized(object sender, System.EventArgs e)
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
