using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServerApp
{
    class ChatServer
    {
        private static List<TcpClient> clients = new List<TcpClient>();
        private static TcpListener listener;
        private static readonly object lockObject = new object();

        static void Main()
        {
            StartServer();
        }

        static void StartServer()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Server started on port 5000...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                lock (lockObject)
                {
                    clients.Add(client);
                }
                Console.WriteLine("New client connected.");
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + message);
                BroadcastMessage(message, client);
            }

            lock (lockObject)
            {
                clients.Remove(client);
            }
            client.Close();
        }

        static void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            lock (lockObject)
            {
                foreach (var client in clients)
                {
                    if (client != sender)
                    {
                        client.GetStream().Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
