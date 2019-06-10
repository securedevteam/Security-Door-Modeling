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

        private void Btn_checkNetwork_Click(object sender, RoutedEventArgs e)
        {

        }

        private IPAddress ip;
        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (IPAddress.TryParse(field_host.Text, out ip))
            {

            }
        }

        private void Field_host_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.-]+").IsMatch(e.Text);
        }

        private void Field_host_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }
    }
}
