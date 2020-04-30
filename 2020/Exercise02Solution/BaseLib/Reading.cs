using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fei
{
    namespace BaseLib
    {
        public static class Reading
        {
            /// <summary>
            /// This method displays user command and converts user input to int
            /// </summary>
            /// <param name="command"></param>
            /// <returns>integer input</returns>
            public static int ReadInt(string command)
            {
                Console.Write(command + ": ");
                int.TryParse(Console.ReadLine(), out int number);
                return number;
            }

            /// <summary>
            /// This method displays user command and convertsuser input to double
            /// </summary>
            /// <param name="command"></param>
            /// <returns>double input</returns>
            public static double ReadDouble(string command)
            {
                Console.Write(command + ": ");
                double.TryParse(Console.ReadLine(), out double number);
                return number;
            }
            /// <summary>
            /// This method displays user command and converts user input to char
            /// </summary>
            /// <param name="command"></param>
            /// <returns>char input</returns>
            public static char ReadChar(string command)
            {
                Console.Write(command + ": ");
                char.TryParse(Console.ReadLine(), out char character);
                return character;
            }

            /// <summary>
            /// This method displays user command and get user input
            /// </summary>
            /// <param name="command"></param>
            /// <returns>string input</returns>
            public static string ReadString(string command)
            {
                string text;
                Console.Write(command + ": ");
                text = Console.ReadLine();
                return text;
            }
        }
    }
}
