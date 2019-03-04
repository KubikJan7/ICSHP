using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv03_p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLength;
            Console.WriteLine("Type in number of students");
            int.TryParse(Console.ReadLine(), out arrayLength);
            Students s = new Students(10);
        }
    }
}
