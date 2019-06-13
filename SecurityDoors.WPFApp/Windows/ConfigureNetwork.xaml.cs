using SecurityDoors.WPFApp.Controllers;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace SecurityDoors.WPFApp.Windows
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
            field_host.Text = (string)Properties.Settings.Default.host;
            field_port.Text = Properties.Settings.Default.port.ToString();
        }

        private int port;
        private string host;
        /// <summary>
        /// обработчик кнопки "проверить соединение"
        /// </summary>
        private void Btn_checkNetwork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                port = int.Parse(field_port.Text);
            } catch (FormatException)
            {
                port = 0;
            }
            host = field_host.Text;
            if (setErrorStyle(host, port))
            {
                TCPController tCPController = new TCPController(port, host);
                if (tCPController.CheckServerAvailability())
                {
                    MessageBox.Show("подключение установлено");
                } else
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
                int port = int.Parse(field_port.Text);
            }
            catch (FormatException)
            {
                port = 0;
            }
            host = field_host.Text;
            if (!setErrorStyle(host, port))
            {
                Properties.Settings.Default["host"] = field_host.Text;
                Properties.Settings.Default["port"] = int.Parse(field_port.Text);
                Properties.Settings.Default.Save();
                Console.WriteLine("1");
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
                field_host.Text = "127.0.0.1";
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
            field_host.IsEnabled = true;
            checkBox_isLocalhost.IsChecked = false;
            resetStyle();
        }

        private void Btn_reset_Click(object sender, RoutedEventArgs e)
        {
            resetStyle();
            field_host.Text = TCPController.DefaultServer;
            field_port.Text = TCPController.DefaultPort.ToString();
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

        private bool setErrorStyle(string host, int port)
        {
            if (!NetUtils.IsAddressValid(host))
            {
                field_host.Style = (Style)field_host.FindResource("textBox_error");
            }
            if (NetUtils.isPortValid(port))
            {
                field_port.Style = (Style)field_port.FindResource("textBox_error");
            }
            return NetUtils.isSettingValid(host, port);
        }

        private void resetStyle()
        {
            field_host.Style = (Style)field_host.FindResource("textBox_main");
            field_port.Style = (Style)field_port.FindResource("textBox_main");
        }
    }
}
