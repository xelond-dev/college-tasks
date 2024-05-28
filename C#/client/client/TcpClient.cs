using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace client
{
    public class TcpClient
    {
        private Socket server;
        private ClientChat chat;
        private string user;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Task receiveTask;

        public TcpClient(string ip, ClientChat clientChat, string _user)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (TryConnect(ip, 8888, 5000)) //попытка подключения
            {
                chat = clientChat;
                user = _user;
                receiveTask = ReceiveMessage(cts.Token);
                SendMessage($"[{_user}] подключился {DateTime.Now.ToString("G")}"); //информируем сервер о подкл. пользователе
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к серверу.");
            }
        }
        
        private async Task ReceiveMessage(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(bytes, SocketFlags.None, token);
                string message = Encoding.UTF8.GetString(bytes);

                //обработка сообщения от сервера
                if (message.StartsWith("[") && message.Contains(" подключился"))
                {
                    string userConnected = message.Substring(1, message.IndexOf("] подключился") - 1); //получаем от сервера подкл. пользователя
                    chat.ListOfUsers.Items.Add(userConnected);
                }
                else if (message.StartsWith("[") && message.Contains(" отключился"))
                {
                    string userDisconnected = message.Substring(1, message.IndexOf("] отключился") - 1); //получаем от сервера откл. пользователя
                    chat.ListOfUsers.Items.Remove(userDisconnected);
                }
                else
                {
                    chat.UserMessages.Items.Add(message);
                }
            }
        }

        public async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await server.SendAsync(bytes, SocketFlags.None);
        }

        public async Task Disconnect()
        {
            cts.Cancel();
            SendMessage($"[{user}] отключился {DateTime.Now.ToString("G")}"); //информируем сервер о откл. пользователе
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            await receiveTask;
        }

        private bool TryConnect(string ip, int port, int timeout)
        {
            try
            {
                var result = server.BeginConnect(ip, port, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(timeout, true);
                if (success)
                {
                    server.EndConnect(result);
                }
                return success;
            }
            catch
            {
                return false;
            }
        }
    }
}
