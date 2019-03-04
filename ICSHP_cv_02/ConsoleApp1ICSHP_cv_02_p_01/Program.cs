using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fei.BaseLib;
namespace ConsoleApp1ICSHP_cv_02_p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Reading.ReadString("Your name");
            int age = Reading.ReadInt("Your age");
            double points = Reading.ReadDouble("Points");
            char grade = Reading.ReadChar("Grade");

            Console.WriteLine('\n' + name + '\n'+ age + '\n' + points + '\n' + grade);

        }
    }
}
