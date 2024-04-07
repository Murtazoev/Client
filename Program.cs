using System;
using System.Net;
using System.Net.Sockets;

namespace chat
{
    internal static class Program
    {
        public static Socket client;
        public static IPEndPoint ipEND = new IPEndPoint(IPAddress.Parse("127.0.0.7"), 1234);
        static void Main()
        {
            client = new Socket(AddressFamily.InterNetwork , SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(ipEND);
            }
            catch
            {
                Console.WriteLine("Unable to Connect to Server !");
                return;
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());   
        }
    }
}