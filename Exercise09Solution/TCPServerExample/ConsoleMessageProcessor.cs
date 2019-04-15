using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServerExample
{
    public class ConsoleMessageProcessor : IMessageProcessor
    {
        public void Process(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString()}");
        }
    }
}
