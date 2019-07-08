using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Threading;

namespace SecurityDoors.UI.WPF.View
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DispatcherTimer timer;
		private ConnectionSettings _cs = new ConnectionSettings();
		public MainWindow()
		{
			InitializeComponent();
			InterfaceUpdate();

			timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
			timer.Tick += InterfaceUpdate;
			timer.Start();
		}

		/// <summary>
		/// Метод для обновления данных на форме
		/// </summary>
		private void InterfaceUpdate(object sender = null, object e = null)
		{
			textBox_log.Text = Logger.Log != null ? Logger.Log : string.Empty;
		}

		/// <summary>
		/// Метод для заполнения формы данными с сервера или файла
		/// </summary>
		private void InitializeData()
		{

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
			Logger.Log = Constants.SETTING_OPENING_WINDOW;
			ConfigureNetwork configureNetwork = new ConfigureNetwork(_cs);
			configureNetwork.ShowDialog();
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
