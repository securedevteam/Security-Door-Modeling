using SecurityDoor.BL.Controllers;
using SecurityDoors.BL.Controllers;
using SecurityDoors.UI.WinForms.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityDoors.UI.WinForms.View
{
	public partial class Settings : Form
	{
		public Settings()
		{
			InitializeComponent();
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var about = new About();
			about.ShowDialog();
		}

		private void ButtonCheckSettings_Click(object sender, EventArgs e)
		{
			string ip = textBoxIP.Text;
			int port = int.Parse(maskedTextBoxPort.Text);
			int portApi = int.Parse(maskedTextBoxPortAPI.Text);
			string secretKey = textBoxSecretKey.Text;

			var result = SettingsController.CheckSettings(ip, port, portApi, secretKey);

			LoggerController.Log = result != null ? result : "Введенные настройки корректны";

			if (result != null)
			{
				MessageBox.Show(result);
			}
			else
			{
				MessageBox.Show("Введенные настройки корректны");
			}
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsController.IP = textBoxIP.Text;
			SettingsController.Port = int.Parse(maskedTextBoxPort.Text);
			SettingsController.PortApi = int.Parse(maskedTextBoxPortAPI.Text);
			SettingsController.SecretKey = textBoxSecretKey.Text;
			var result = SettingsController.SaveProperties();
			if (result != null)
			{
				MessageBox.Show(result);
			}
		}

		private void SetDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			textBoxIP.Text = "127.0.0.1";
			maskedTextBoxPort.Text = "1234";
			maskedTextBoxPortAPI.Text = "80";
			textBoxSecretKey.Text = "";
		}

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			textBoxIP.Text = SettingsController.IP;
			maskedTextBoxPort.Text = SettingsController.Port.ToString();
			maskedTextBoxPortAPI.Text = SettingsController.PortApi.ToString();
			textBoxSecretKey.Text = SettingsController.SecretKey;
		}

		private void Settings_FormClosed(object sender, FormClosedEventArgs e)
		{
			SettingsController.SetDefaultProperties();
		}

		private void ButtonConnectionTest_Click(object sender, EventArgs e)
		{
			//int.TryParse(maskedTextBoxPort.Text, );
			var server = textBoxIP.Text;
			var result = TCPController.CheckServerAvailability();
			if (result == true)
			{
				MessageBox.Show("Соединение установлено");
				LoggerController.Log = "Соединение установлено";
			}
			else
			{
				MessageBox.Show("Соединение не установлено");
				LoggerController.Log = "Соединение не установлено";
			}
		}
	}
}
