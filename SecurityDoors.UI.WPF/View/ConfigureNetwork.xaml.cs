using SecurityDoors.BL.Controllers;
using SecurityDoors.BL.Windows;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SecurityDoors.UI.WPF.View
{
	/// <summary>
	/// Interaction logic for ConfigureNetwork.xaml
	/// </summary>
	public partial class ConfigureNetwork : Window
	{
		public ConfigureNetwork()
		{
			InitializeComponent();
		}

		private void ConfigureNetwork_Initialized(object sender, System.EventArgs e)
		{
			field_host.Text = SecurityDoors.BL.Properties.Settings.Default.IP;
			field_port.Text = SecurityDoors.BL.Properties.Settings.Default.Port.ToString();
			field_secretKey.Text = SecurityDoors.BL.Properties.Settings.Default.SecretKey;

		}

		private int port;
		private string host;
		private string secretKey;
		/// <summary>
		/// обработчик кнопки "проверить соединение"
		/// </summary>
		private async void Btn_checkNetwork_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				port = int.Parse(field_port.Text);
			}
			catch (FormatException)
			{
				port = 0;
			}
			host = field_host.Text;
			if (SetErrorStyle(host, port))
			{
				bool isAviable = await Task.Run(() => TCPController.CheckServerAvailability());
				if (isAviable)
				{
					MessageBox.Show("подключение установлено");
				}
				else
				{
					MessageBox.Show("сервер не доступен");
				}
			}
		}

		/// <summary>
		/// обработчик для кнопки "сохранить"
		/// </summary>
		private void Btn_save_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				port = int.Parse(field_port.Text);
			}
			catch (FormatException)
			{
				port = 0;
			}
			host = field_host.Text;
			secretKey = field_secretKey.Text;
			if (SetErrorStyle(host, port))
			{
				Properties.Settings.Default.SaveNetworkSetting(host, port, secretKey);
			}
		}

		/// <summary>
		/// обработчик для checkBox localhost
		/// </summary>
		private void CheckBox_isLocalhost_Click(object sender, RoutedEventArgs e)
		{
			if ((bool)checkBox_isLocalhost.IsChecked)
			{
				field_host.IsEnabled = false;
				field_host.Text = TCPController.DefaultServer;
			}
			else
			{
				field_host.IsEnabled = true;
			}
		}

		/// <summary>
		/// обработчик кнопки "очистить"
		/// очищает текст в полях <c>field_host</c> и <c>field_port</c>
		/// </summary>
		private void Btn_clear_Click(object sender, RoutedEventArgs e)
		{
			field_host.Text = "";
			field_port.Text = "";
			field_secretKey.Text = "";
			field_host.IsEnabled = true;
			checkBox_isLocalhost.IsChecked = false;
			ResetStyle();
		}

		private void Btn_reset_Click(object sender, RoutedEventArgs e)
		{
			ResetStyle();
			field_host.Text = TCPController.DefaultServer;
			field_port.Text = TCPController.DefaultPort.ToString();
			field_secretKey.Text = "";
		}

		/// <summary>
		/// проверка того что в полне <c>field_host</c> введены только цифры и точка
		/// иначе обработка ввода игнорируется
		/// </summary>
		private void Field_host_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			field_host.Style = (Style)field_host.FindResource("textBox_main");
			e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
		}

		/// <summary>
		/// проверка того что в полне <c>field_port</c> введены только цифры
		/// иначе обработка ввода игнорируется
		/// </summary>
		private void Field_port_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			field_port.Style = (Style)field_port.FindResource("textBox_main");
			e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
		}

		private void Field_secretKey_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			field_secretKey.Style = (Style)field_secretKey.FindResource("textBox_main");
		}

		private bool SetErrorStyle(string host, int port)
		{
			if (!NetUtils.IsAddressValid(host))
			{
				field_host.Style = (Style)field_host.FindResource("textBox_error");
			}
			if (!NetUtils.IsPortValid(port))
			{
				field_port.Style = (Style)field_port.FindResource("textBox_error");
			}
			if (field_secretKey.Text == "")
			{
				field_secretKey.Style = (Style)field_secretKey.FindResource("textBox_error");
			}
			return NetUtils.IsSettingValid(host, port);
		}

		private void ResetStyle()
		{
			field_host.Style = (Style)field_host.FindResource("textBox_main");
			field_port.Style = (Style)field_port.FindResource("textBox_main");
		}
	}
}
