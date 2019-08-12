using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using System;
using System.Windows.Forms;

namespace SecurityDoors.UI.WinForms.View
{
	public partial class SettingForm : Form
	{
        private ConnectionSettings _cs;

		public SettingForm(ConnectionSettings connectionSettings)
		{
			InitializeComponent();
            _cs = connectionSettings;
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var aboutForm = new AboutProjectForm();
            aboutForm.ShowDialog();
		}

		private void ButtonCheckSettings_Click(object sender, EventArgs e)
		{
            _cs.IP = textBoxIP.Text;

            if(!string.IsNullOrWhiteSpace(maskedTextBoxPort.Text))
            {
                _cs.Port = int.Parse(maskedTextBoxPort.Text);
            }
            else
            {
                _cs.Port = null;
            }

            if (!string.IsNullOrWhiteSpace(maskedTextBoxPortAPI.Text))
            {
                _cs.PortAPI = int.Parse(maskedTextBoxPortAPI.Text);
            }
            else
            {
                _cs.PortAPI = null;
            }

            _cs.SecretKey = textBoxSecretKey.Text;

			var result = _cs.CheckSettings();

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
            _cs.IP = textBoxIP.Text;
            _cs.Port = int.Parse(maskedTextBoxPort.Text);
            _cs.PortAPI = int.Parse(maskedTextBoxPortAPI.Text);
            _cs.SecretKey = textBoxSecretKey.Text;

            var result = _cs.SaveProperties();

			if (result != null)
			{
				MessageBox.Show(result);
			}
            else
            {
                MessageBox.Show(Constants.SETTING_INCORRECT);
            }
        }

		private void SetDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			textBoxIP.Text = Constants.DEFAULT_IP;
			maskedTextBoxPort.Text = Constants.DEFAULT_PORT.ToString();
			maskedTextBoxPortAPI.Text = Constants.DEFAULT_PORT_API.ToString();
            textBoxSecretKey.Text = Constants.DEFAULT_SECRET_KEY;

			_cs.SetDefaultProperties();
		}

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			textBoxIP.Text = _cs.IP;
			maskedTextBoxPort.Text = _cs.Port.ToString();
			maskedTextBoxPortAPI.Text = _cs.PortAPI.ToString();
			textBoxSecretKey.Text = _cs.SecretKey;
		}

		private void Settings_FormClosed(object sender, FormClosedEventArgs e)
		{
			_cs.SetDefaultProperties();
		}

		private async void ButtonConnectionTest_Click(object sender, EventArgs e)
		{
            string server = textBoxIP.Text;
            int port = int.Parse(maskedTextBoxPort.Text);
            int portAPI = int.Parse(maskedTextBoxPortAPI.Text);
            string secretKey = textBoxSecretKey.Text;

            var checkResult = _cs.CheckSettings(server, port, portAPI, secretKey);

            if (checkResult != default)
            {
                Logger.Log = checkResult;
                MessageBox.Show(checkResult);
            }
            else
            {
                var webConnection = new WebConnection(_cs);

				var isApiAvailable = await webConnection.CheckConnectionAsync(portAPI);
				var isServerAvailable = await webConnection.CheckConnectionAsync(port);

				var serversAvailability = string.Empty;
				serversAvailability += isApiAvailable ? Constants.CONNECTION_API_SUCCESSED : Constants.CONNECTION_API_FAILED;
				serversAvailability += Environment.NewLine;
				serversAvailability += isServerAvailable ? Constants.CONNECTION_DOOR_CONTROLLER_SUCCESSED : Constants.CONNECTION_DOOR_CONTROLLER_FAILED;
				

				if (isServerAvailable || isApiAvailable)
                {
                    Logger.Log = Constants.CONNECTION_ESTABLISHED;
                    MessageBox.Show(serversAvailability);
                }
                else
                {
                    Logger.Log = Constants.CONNECTION_NOT_ESTABLISHED;
                    MessageBox.Show(serversAvailability);
                }
            }
        }
	}
}
