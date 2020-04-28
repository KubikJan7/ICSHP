using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_01_p_03
{
    class Program
    {
        static void FindOutGender(string birthNum)
        {
            if (birthNum.Length != 10)
            {
                Console.WriteLine("The birth number must contains 10 characters.");
                return;
            }
            if (birthNum[2] == '5' || birthNum[2] == '6')
                Console.WriteLine("This birth number belongs to a woman.");
            else
                Console.WriteLine("This birth number belongs to a man.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Type in a birth certificate number.");
            FindOutGender(Console.ReadLine());
        }
    }
}
