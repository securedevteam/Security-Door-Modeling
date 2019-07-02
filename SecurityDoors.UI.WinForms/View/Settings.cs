using SecurityDoor.BL.Controllers;
using SecurityDoors.BL.Controllers;
using SecurityDoors.Core;
using System;
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
			var aboutForm = new About();
            aboutForm.ShowDialog();
		}

		private void ButtonCheckSettings_Click(object sender, EventArgs e)
		{
			string ip = textBoxIP.Text;
			int port = int.Parse(maskedTextBoxPort.Text);
			int portApi = int.Parse(maskedTextBoxPortAPI.Text);
			string secretKey = textBoxSecretKey.Text;

			var result = SettingsController.CheckSettings(ip, port, portApi, secretKey);

			Logger.Log = result ?? Constants.SETTING_CORRECT;

			if (result != null)
			{
				MessageBox.Show(result);
			}
			else
			{
				MessageBox.Show(Constants.SETTING_INCORRECT);
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
			textBoxIP.Text = Constants.DEFAULT_IP;
			maskedTextBoxPort.Text = Constants.DEFAULT_PORT;
			maskedTextBoxPortAPI.Text = Constants.DEFAULT_PORT_API;
            textBoxSecretKey.Text = Constants.STRING_EMPTY;
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

		private async void ButtonConnectionTest_Click(object sender, EventArgs e)
		{
			string server = textBoxIP.Text;
			int port = int.Parse(maskedTextBoxPort.Text);
			int portApi = int.Parse(maskedTextBoxPortAPI.Text);
			string secretKey = textBoxSecretKey.Text;

			var checkResult = SettingsController.CheckSettings(server, port, portApi, secretKey);

            if (checkResult != default)
			{
				MessageBox.Show(checkResult);
				Logger.Log = checkResult;
			}
			else
			{
				var webConnection = new WebConnectionController(server, port, portApi, secretKey);

				var result = await webConnection.CheckServerConnectionAsync();

				if (result == true)
				{
					MessageBox.Show(Constants.CONNECTION_ESTABLISHED);
					Logger.Log = Constants.CONNECTION_ESTABLISHED;
				}
				else
				{
					MessageBox.Show(Constants.CONNECTION_NOT_ESTABLISHED);
					Logger.Log = Constants.CONNECTION_NOT_ESTABLISHED;
				}
			}
		}
	}
}
