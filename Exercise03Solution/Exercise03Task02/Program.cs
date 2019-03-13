using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLib;

namespace ICSHP_cv_03_p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Conversion of decimal to binary system.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConvertor.DecToBin(8));
            

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Conversion of binary to decimal system.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConvertor.BinToDec("0101"));
            

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Conversion of decimal number to roman.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConvertor.DecToRoman(3269));
            

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Conversion of roman number to decimal.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConvertor.RomanToDec("XLMCD"));
            

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Solving of a quadratic equation.");
            Console.WriteLine("-------------------------------------------------");
            ExtraMath.SolveQuadraticEquation(1,-3,-4);

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Generation of random double.");
            Console.WriteLine("-------------------------------------------------");
            ExtraMath.GenerateRndNum(new Random(), 0.56256, 10.581254);
        }
    }
}
