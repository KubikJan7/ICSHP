using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServerExample
{
    class Program
    {

        static (string, int, bool) ProcessArgs(string[] args)
        {
            string ipAddress = "127.0.0.1";
            string portStr = "1200";
            bool showHelp = false;

            var options = new OptionSet
            {

            };

            IList<string> extra = options.Parse(args);
            if (extra.Count > 0)
                throw new ArgumentException("Illegal parameters");

            if (showHelp)
            {
                ShowHelp(options);
            }



        }

        private static void ShowHelp(OptionSet options)
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            string ipAddress = "127.0.0.1";
            string port = "1200";
            bool showHelp = false;

            try
            {
                (ipAddress, port, showHelp) = ProcessArgs(args);
                if (showHelp) return;
                StartTCPServer(ipAddress, port);
            }
            catch (OptionException e)
            {
                Console.WriteLine($"{Console.Title}:{e.Message}");
                Console.WriteLine($"Try")
            }
        }

        private static void StartTCPServer(string ipAddress, int port)
        {
            TCPServer server = new TCPServer(new ConsoleMessageProcessor(),ipAddress,port);
        }
    }
}
