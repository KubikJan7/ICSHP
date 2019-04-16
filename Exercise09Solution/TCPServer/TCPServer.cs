using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServerExample
{
    class TCPServer
    {
        public const string DefaultIPAddress = "127.0.0.1";
        public const int DefualtPort = 1200;
        public const int ListenerCount = 1;
        Socket socket;

        private IMessageProcessor processor;

        public TCPServer(IMessageProcessor processor, string ipAddress, int port)
        {
            this.processor = processor;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            processor?.Process($"TCP Server listening on {endPoint.ToString()}");
            socket.Bind(endPoint);      //  bind socketu na poslouchani tohoto endPointu

            socket.Listen(ListenerCount);
        }

        public void Listen()
        {
            Socket acceptedSocket = socket.Accept();
            byte[] recivedData = new byte[acceptedSocket.SendBufferSize];
            while (true)
            {
                int bufferCount = acceptedSocket.Receive(recivedData);
                byte[] data = new byte[bufferCount];
                for (int i = 0; i < bufferCount; i++)
                {
                    data[i] = recivedData[i];
                }
                string message = Encoding.Default.GetString(data);
                if (message.Equals("exit"))
                {
                    Environment.Exit(0);
                }
                processor?.Process(message);
            }
        }
    }
}
