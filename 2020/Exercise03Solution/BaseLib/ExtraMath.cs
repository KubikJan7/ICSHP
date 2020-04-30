using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    /// <summary>
    /// Contains methods for solving quadratic equations and generating random numbers
    /// </summary>
    public static class ExtraMath
    {
        /// <summary>
        /// Finds roots of quadratic equations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void SolveQuadraticEquation(double a, double b, double c)
        {
            int m;
            double r1, r2, d1;
            d1 = Math.Pow(b, 2) - 4 * a * c;
            if (a == 0)
                m = 1;
            else if (d1 > 0)
                m = 2;
            else if (d1 == 0)
                m = 3;
            else
                m = 4;
            switch (m)
            {
                case 1:
                    Console.WriteLine(@"\n Not a Quadratic equation, 
                                          Linear equation");
                    break;
                case 2:
                    Console.WriteLine("\n Roots are Real and Distinct");
                    r1 = (-b + Math.Sqrt(d1)) / (2 * a);
                    r2 = (-b - Math.Sqrt(d1)) / (2 * a);
                    Console.WriteLine("\n x1 = {0:#.##}", r1);
                    Console.WriteLine("\n x2 = {0:#.##}", r2);
                    break;
                case 3:
                    Console.WriteLine("\n Roots are Real and Equal");
                    r1 = r2 = (-b) / (2 * a);
                    Console.WriteLine("\n x1 = {0:#.##}", r1);
                    Console.WriteLine("\n x2 = {0:#.##}", r2);
                    break;
                case 4:
                    Console.WriteLine("\n Roots are Imaginary");
                    r1 = (-b) / (2 * a);
                    r2 = Math.Sqrt(-d1) / (2 * a);
                    Console.WriteLine("\n x1 = {0:#.##} + i {1:#.##}",
                                       r1, r2);
                    Console.WriteLine("\n x2 = {0:#.##} - i {1:#.##}",
                                      r1, r2);
                    break;
            }
        }

        /// <summary>
        /// Generates random double
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void GenerateRndNum(Random rnd, double min, double max)
        {
            Console.WriteLine(rnd.NextDouble() * (max - min) + min);
        }
    }
}
