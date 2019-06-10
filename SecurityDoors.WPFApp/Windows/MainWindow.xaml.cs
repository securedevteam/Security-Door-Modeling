using SecurityDoors.WPFApp.Models;
using SecurityDoors.WPFApp.Windows;
using System.Text.RegularExpressions;
using System.Windows;

namespace SecurityDoors.ModellingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
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
