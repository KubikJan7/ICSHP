using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_01
{
    class Program
    {
        const uint DEFAULT_COUNT = 100;
        static uint GetCount(string[] args)
        {
            if (args.Length == 0) return DEFAULT_COUNT;
            uint temp;
            if (uint.TryParse(args[0], out temp))
                return temp;
            return DEFAULT_COUNT;
        }

        static void Main(string[] args)
        {
            Console.Write("Hello world!");
            Console.WriteLine("Hello world again");
            uint count = GetCount(args);
            string greetings = "Hello world ";
            //if (count != 0)
            //{
            //    for (uint i = 0; i < count; i++)
            //    {
            //        greetings += "again";
            //        if (i == count - 1)
            //            greetings += "!";
            //        else
            //            greetings += " ";
            //    }
            //}
            //else
            //    greetings += "again!";
            //Console.WriteLine(greetings);

            if (count != 0)
            {
                StringBuilder greetingsBuilder = new StringBuilder();
                greetingsBuilder.Append("Hello world again");
                for (uint i = 0; i < count; i++)
                {
                    greetingsBuilder.Append(" again");
                }
                greetingsBuilder.Append("!");
                Console.WriteLine(greetingsBuilder.ToString());
            }
        }
    }
}
