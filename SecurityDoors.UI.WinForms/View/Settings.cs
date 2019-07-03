using SecurityDoors.BLL.Controllers;
using SecurityDoors.Core;
using System;
using System.Windows.Forms;

namespace SecurityDoors.UI.WinForms.View
{
	public partial class Settings : Form
	{
        private ConnectionSettings _cs;

		public Settings(ConnectionSettings connectionSettings)
		{
			InitializeComponent();
            _cs = connectionSettings;
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var aboutForm = new About();
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
            textBoxSecretKey.Text = Constants.STRING_EMPTY;
			settings.SetDefaultProperties();
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
                MessageBox.Show(checkResult);
                Logger.Log = checkResult;
            }
            else
            {
                var webConnection = new WebConnectionController(server, port, portAPI, secretKey);

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
