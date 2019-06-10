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

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (IsAddressValid(field_host.Text))
            {
                
            } else
            {
                MessageBox.Show("введен некоректный ip адресс");
                return;
            }
            if (int.Parse(field_port.Text) > 65_535){
                MessageBox.Show("введен некоректный порт.");
                return;
            }
        }

        public bool IsAddressValid(string addrString)
        {
            IPAddress address;
            return IPAddress.TryParse(addrString, out address);
        }

        private void Field_host_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        }

        private void Field_port_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
        }
    }
}
