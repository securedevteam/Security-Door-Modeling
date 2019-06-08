using SecurityDoors.WPFApp.Models;
using SecurityDoors.WPFApp.Windows;
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
    }
}
