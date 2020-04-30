using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLib;

namespace Exercise03Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Conversion of decimal to binary system.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConverter.DecToBin(8));


            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Conversion of binary to decimal system.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConverter.BinToDec("0101"));


            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Conversion of decimal number to roman.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConverter.DecToRoman(3269));


            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Conversion of roman number to decimal.");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(MathConverter.RomanToDec("XLMCD"));


            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Solving of a quadratic equation.");
            Console.WriteLine("-------------------------------------------------");
            ExtraMath.SolveQuadraticEquation(1, -3, -4);

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Generation of random double.");
            Console.WriteLine("-------------------------------------------------");
            ExtraMath.GenerateRndNum(new Random(), 0.56256, 10.581254);
        }
    }
}
