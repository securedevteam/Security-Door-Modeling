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

        private void Btn_run_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {

        }

        private void Btn_configureNetwork_Click(object sender, RoutedEventArgs e)
        {
            ConfigureNetwork configureNetwork = new ConfigureNetwork();
            configureNetwork.ShowDialog();
        }

        private void TextBox_pause_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        }

        private void TextBox_repeat_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
