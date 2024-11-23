using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public string ServerIP
        {
            get { return urlTextBox.Text; }
        }

        public int ServerPort
        {
            get
            {
                string portText = portTextBox.Text;
                if (string.IsNullOrWhiteSpace(portText))
                {
                    throw new FormatException("Поле порта не должно быть пустым.");
                }

                if (int.TryParse(portText, out int port) && port > 0 && port <= 65535)
                {
                    return port;
                }
                else
                {
                    throw new FormatException("Введите корректный порт сервера (от 1 до 65535).");
                }
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}