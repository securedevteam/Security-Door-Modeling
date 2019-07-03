using SecurityDoors.Core;
using SecurityDoors.DAL.Models;
using System;
using System.Net.Sockets;
using System.Text;

namespace SecurityDoors.BLL.Controllers
{
    public class TCP
    {
        private ConnectionSettings _cs;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public TCP()
        {
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="connectionSettings">настройки.</param>
        public TCP(ConnectionSettings connectionSettings)
        {
            _cs = connectionSettings;
        }

        /// <inheritdoc/>
        public void SendMessage(Message message)
        {
            if (message == null || _cs.Port == null)
            {
                return;
            }
                
            try
            {
                var data = new byte[256];
                var messageBody = $"{_cs.SecretKey}${message.PersonCard}${message.DoorName}";
                var serverResponse = new StringBuilder();
                var client = new TcpClient();

                client.Connect(_cs.IP, _cs.Port.Value);

                if (client.Connected)
                {
                    var stream = client.GetStream();

                    data = Encoding.UTF8.GetBytes(messageBody);
                    stream.Write(data, 0, data.Length);

                    do
                    {
                        var bytes = stream.Read(data, 0, data.Length);
                        serverResponse.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Logger.Log = e.ToString() ?? Constants.SETTING_SAVE_FAILED;
            }

            Logger.Log = null ?? Constants.SETTING_SAVE_SUCCESSED;
        }
    }
}
