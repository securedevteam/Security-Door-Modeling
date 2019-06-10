using System.Net;
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

        /// <summary>
        /// обработчик кнопки проверить соединение
        /// </summary>
        private void Btn_checkNetwork_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// обработчик для кнопки сохранить
        /// </summary>
        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(field_port.Text);
            string host = field_host.Text;
            if (CheckNetworkSetting(host, port))
            {

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
        /// метод проверяет валидность введенных настроек сети
        /// </summary>
        /// <param name="host">ip адресс сервера</param>
        /// <param name="port">порт сервера</param>
        /// <returns></returns>
        private bool CheckNetworkSetting(string host, int port)
        {
            if (!IsAddressValid(host))
            {
                MessageBox.Show("введен некоректный ip адресс");
                return false;
            }

            if (port > 65_535 && port == 0)
            {
                MessageBox.Show("введен некоректный порт.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// проверка валидности ip адресса
        /// </summary>
        /// <param name="addrString">строка содержащая ip адресс валидность которого надо проверить</param>
        /// <returns></returns>
        public bool IsAddressValid(string addrString)
        {
            IPAddress address;
            return IPAddress.TryParse(addrString, out address);
        }

        /// <summary>
        /// проверка того что в полне <c>field_host</c> введены только цифры и точка
        /// иначе обработка ввода игнорируется
        /// </summary>
        private void Field_host_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        }

        /// <summary>
        /// проверка того что в полне <c>field_port</c> введены только цифры
        /// иначе обработка ввода игнорируется
        /// </summary>
        private void Field_port_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        }
    }
}
