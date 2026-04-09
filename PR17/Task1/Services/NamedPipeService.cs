using System;
using System.IO.Pipes;
using System.Text;
using System.Windows;

namespace CrmDemo.Services
{
    public class NamedPipeService
    {
        private const string PipeName = "crm_pipe";

        public void SendMessage(string message)
        {
            try
            {
                using (var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
                {
                    pipeClient.Connect(5000);
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    pipeClient.Write(messageBytes, 0, messageBytes.Length);
                    pipeClient.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки сообщения: {ex.Message}", "Ошибка");
            }
        }

        public void StartServer(Action<string> onMessageReceived)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        using (var pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.In))
                        {
                            pipeServer.WaitForConnection();
                            byte[] buffer = new byte[4096];
                            int bytesRead = pipeServer.Read(buffer, 0, buffer.Length);
                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                            Application.Current.Dispatcher.Invoke(() => onMessageReceived(message));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Pipe error: {ex.Message}");
                    }
                }
            });
        }
    }
}