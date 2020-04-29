using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01Task03
{
    class Program
    {
        static private bool FindOutIfBirthNumberBelongsToWoman(string birthNum)
        {
            if (birthNum.Length != 10)
                Console.WriteLine("The birth number must contains 10 characters.");
            else if (birthNum[2] == '5' || birthNum[2] == '6')
                return true;

            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a birth certificate number.");
            string birthNum = Console.ReadLine();
            Console.Write("\n");
            if (FindOutIfBirthNumberBelongsToWoman(birthNum))
                Console.WriteLine("This birth certificate number belongs to a woman.");
            else
                Console.WriteLine("This birth certificate number belongs to a man.");
        }
    }
}
