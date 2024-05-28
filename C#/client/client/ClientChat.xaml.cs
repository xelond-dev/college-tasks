using System.Windows;

namespace client
{
    public partial class ClientChat : Window
    {
        private string user;
        private TcpClient tcpClient;
        public ClientChat(string _user, string ip)
        {
            InitializeComponent();
            tcpClient = new TcpClient(ip, this, _user);
            user = _user;
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageTBX.Text != "")
            {
                if (MessageTBX.Text == "/disconnect")
                {
                    Close();
                }
                else
                {
                    string message = $"[{user}] [{DateTime.Now.ToString("G")}]: {MessageTBX.Text}";
                    tcpClient.SendMessage(message);
                }
            }
        }

        private void Exit()
        {
            tcpClient.Disconnect();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Exit();
        }
    }
}
