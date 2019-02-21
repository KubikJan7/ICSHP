using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_01_p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(100);
            int guess;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Guess generated number");
                int.TryParse(Console.ReadLine(), out guess);
                if (guess == rndNum)
                {
                    Console.WriteLine("You are right, the number is " + rndNum + ".");
                    return;
                }if(guess>rndNum)
                    Console.WriteLine("The number is lower." + "Attempts left: " + (9-i));
                else
                    Console.WriteLine("The number is higher." + "Attempts left: " + (9 - i));
            }
            Console.WriteLine("Game lost. You do not have any more attempts.");
        }
    }
}
