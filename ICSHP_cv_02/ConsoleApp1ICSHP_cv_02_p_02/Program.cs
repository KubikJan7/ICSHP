using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLib;

namespace ConsoleApp1ICSHP_cv_02_p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays array = new Arrays();
            int option = 0;
            int num;
            while (option != 7)
            {
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Enter array.");
                Console.WriteLine("2. Display array");
                Console.WriteLine("3. Sort the array in ascending order.");
                Console.WriteLine("4. Find the smallest element.");
                Console.WriteLine("5. Find the first occurence of an element.");
                Console.WriteLine("6. Find the last occurence of an element.");
                Console.WriteLine("7. Close program.");
                Console.WriteLine("\nChoose an option: ");
                int.TryParse(Console.ReadLine(), out option);
                Console.WriteLine("\n-------------------------------------------------------------");
                switch (option)
                {
                    case 1:
                        array.LoadArray();
                        break;
                    case 2:
                        array.WriteArray();
                        break;
                    case 3:
                        array.SortArrayAsc();
                        break;
                    case 4:
                        array.FindMinimum();
                        break;
                    case 5:
                        Console.WriteLine("Type in wanted number.");
                        int.TryParse(Console.ReadLine(), out num);
                        array.FindFirstOccurenceOfEl(num);
                        break;
                    case 6:
                        Console.WriteLine("Type in wanted number.");
                        int.TryParse(Console.ReadLine(), out num);
                        array.FindLasttOccurenceOfEl(num);
                        break;
                }
                Console.WriteLine("-------------------------------------------------------------");
            }
        }
    }
}
