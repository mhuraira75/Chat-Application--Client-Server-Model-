using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClientApp
{
    class ChatClient
    {
        static void Main()
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();

            Thread receiveThread = new Thread(() => ReceiveMessages(client));
            receiveThread.Start();

            while (true)
            {
                string message = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(message))
                    continue;

                string fullMessage = $"{userName}: {message}";
                byte[] buffer = Encoding.ASCII.GetBytes(fullMessage);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        static void ReceiveMessages(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(message);
            }
        }
    }
}
