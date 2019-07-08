using SecurityDoors.BLL.Controllers;
using SecurityDoors.BL.Windows;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using SecurityDoors.Core;

namespace SecurityDoors.UI.WPF.View
{
	/// <summary>
	/// Interaction logic for ConfigureNetwork.xaml
	/// </summary>
	public partial class ConfigureNetwork : Window
	{
		private ConnectionSettings _cs;
		public ConfigureNetwork(ConnectionSettings _cs)
		{
			this._cs = _cs;
			InitializeComponent();
			RestoreSettings();
		}


		/// <summary>
		/// Устанавливает в поля данные из сохраненных параметров
		/// </summary>
		private void RestoreSettings()
		{
			field_ip.Text = _cs.IP;
			field_port.Text = _cs.Port.ToString();
			field_portApi.Text = _cs.PortAPI.ToString();
			field_secretKey.Text = _cs.SecretKey;
		}

		/// <summary>
		/// обработчик кнопки "проверить соединение"
		/// </summary>
		private async void Btn_checkNetwork_ClickAsync(object sender, RoutedEventArgs e)
		{
			var ip = field_ip.Text;
			int.TryParse(field_port.Text, out int port);
			int.TryParse(field_portApi.Text, out int portApi);
			var secretKey = field_secretKey.Text;

			var checkResult = _cs.CheckSettings(ip, port, portApi, secretKey);
			if (checkResult != default)
			{
				MessageBox.Show(checkResult);
			}
			else
			{
				_cs.IP = ip;
				_cs.Port = port;
				_cs.PortAPI = portApi;
				_cs.SecretKey = secretKey;

				var webConnection = new WebConnection(_cs);
				var isApiAvailable = await webConnection.CheckConnectionAsync(portApi);
				var isServerAvailable = await webConnection.CheckConnectionAsync(port);
				//TODO: поправить
				string serversAvailability = "";
				serversAvailability += isApiAvailable ? Constants.CONNECTION_API_SUCCESSED : Constants.CONNECTION_API_FAILED;
				serversAvailability += Environment.NewLine;
				serversAvailability += isServerAvailable ? Constants.CONNECTION_DOOR_CONTROLLER_SUCCESSED : Constants.CONNECTION_DOOR_CONTROLLER_FAILED;


				if (isServerAvailable || isApiAvailable)
				{
					Logger.Log = Constants.CONNECTION_ESTABLISHED;
					MessageBox.Show(serversAvailability);
				}
				else
				{
					Logger.Log = Constants.CONNECTION_NOT_ESTABLISHED;
					MessageBox.Show(serversAvailability);
				}
			}
		}

		/// <summary>
		/// обработчик для кнопки "сохранить"
		/// </summary>
		private void Btn_save_Click(object sender, RoutedEventArgs e)
		{
			var ip = field_ip.Text;
			int.TryParse(field_port.Text, out int port);
			int.TryParse(field_portApi.Text, out int portApi);
			var secretKey = field_secretKey.Text;

			_cs.IP = ip;
			_cs.Port = port;
			_cs.PortAPI = portApi;
			_cs.SecretKey = secretKey;

			var checkResult = _cs.SaveProperties();
			if (checkResult != default)
			{
				MessageBox.Show(checkResult);
			}
			else
			{
				Logger.Log = "Настройки успешно сохранены";
			}
		}

		/// <summary>
		/// обработчик кнопки "очистить"
		/// очищает текст в полях <c>field_host</c> и <c>field_port</c>
		/// </summary>
		private void Btn_check_Click(object sender, RoutedEventArgs e)
		{
			var ip = field_ip.Text;
			int.TryParse(field_port.Text, out int port);
			int.TryParse(field_portApi.Text, out int portApi);
			var secretKey = field_secretKey.Text;

			var checkResult = _cs.CheckSettings(ip, port, portApi, secretKey);
			if (checkResult != default)
			{
				MessageBox.Show(checkResult);
			}
			else
			{
				MessageBox.Show("Данные корректны");
			}

			ResetStyle();
		}

		/// <summary>
		/// Устанавливает настройки по умолчанию и выводит их в поля на форме
		/// </summary>
		private void Btn_reset_Click(object sender, RoutedEventArgs e)
		{
			ResetStyle();

			_cs.SetDefaultProperties();
			RestoreSettings();
		}

		/// <summary>
		/// проверка того что в полне <c>field_host</c> введены только цифры и точка
		/// иначе обработка ввода игнорируется
		/// </summary>
		private void Field_host_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			field_ip.Style = (Style)field_ip.FindResource("textBox_main");
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
				field_ip.Style = (Style)field_ip.FindResource("textBox_error");
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
			field_ip.Style = (Style)field_ip.FindResource("textBox_main");
			field_port.Style = (Style)field_port.FindResource("textBox_main");
		}
	}
}
