using System.Windows;
using System.Windows.Input;

namespace client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text != "" && ChatIPaddress.Text != "")
            {
                ClientChat clientChat = new ClientChat(Username.Text, ChatIPaddress.Text);
                clientChat.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void ChatIPaddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && e.Text != ".") e.Handled = true;
        }
    }
}