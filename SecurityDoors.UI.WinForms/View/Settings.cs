using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using System;
using System.Windows.Forms;

namespace SecurityDoors.UI.WinForms.View
{
	public partial class Settings : Form
	{
		private SettingsController settings = new SettingsController();
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

			if (result == null)
			{
				MessageBox.Show(Constants.SETTING_CORRECT);
			}
			else
			{
				MessageBox.Show(Constants.SETTING_INCORRECT);
			}
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			settings.IP = textBoxIP.Text;
			settings.Port = int.Parse(maskedTextBoxPort.Text);
			settings.PortApi = int.Parse(maskedTextBoxPortAPI.Text);
			settings.SecretKey = textBoxSecretKey.Text;

			var result = settings.SaveProperties();

			if (result != null)
			{
				MessageBox.Show(result);
			}
		}

		private void SetDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			textBoxIP.Text = Constants.DEFAULT_IP;
			maskedTextBoxPort.Text = Constants.DEFAULT_PORT.ToString();
			maskedTextBoxPortAPI.Text = Constants.DEFAULT_PORT_API.ToString();
            textBoxSecretKey.Text = Constants.STRING_EMPTY;
			settings.SetDefaultProperties();
		}

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			textBoxIP.Text = settings.IP;
			maskedTextBoxPort.Text = settings.Port.ToString();
			maskedTextBoxPortAPI.Text = settings.PortApi.ToString();
			textBoxSecretKey.Text = settings.SecretKey;
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
