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
        public const string DefaultIpAddress = "127.0.0.1";
        public const int DefaultPort = 1200;

        private IMessageProcessor processor;
        private int ListenerCount = 1;
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public TCPServer(IMessageProcessor processor, string ipAddress, int port)
        {
            this.processor = processor;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            processor?.Process($"TCP Server listening on {endPoint.ToString()}");
            socket.Bind(endPoint);

            socket.Listen(ListenerCount);

            
        }

        public void Listen()
        {
            Socket acceptedSocket = socket.Accept();
            Byte[] receiveData = new byte[acceptedSocket.SendBufferSize];
            while (true)
            {
                int bufferSize = acceptedSocket.Receive(receiveData);
                byte[] data = new byte[bufferSize];
                for (int i = 0; i < bufferSize; i++)
                {
                    data[i] = receiveData[i];
                }
                string message = Encoding.Default.GetString(data);
                Console.WriteLine(message);
                processor?.Process(message);
            }   

        }

    }
}
