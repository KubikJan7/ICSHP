using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01Task04
{
    class Program
    {
        static private int GenerateNumber()
        {
            Random rand = new Random();
            return rand.Next(0, 101);
        }

        static private bool EvaluateGuesses(int generatedNum)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Please type in your guess.");
                int.TryParse(Console.ReadLine(), out int guess);

                if (guess == generatedNum)
                    return true;
                else if (guess > generatedNum)
                    Console.WriteLine("The searched number is lower. Attempts left: " + (9 - i));
                else
                    Console.WriteLine("The searched number is higher. Attempts left: " + (9 - i));

                Console.WriteLine();
            }
            return false;
        }

        static void Main(string[] args)
        {
            int rndNum;
            char confirmChar;

            do
            {
                rndNum = GenerateNumber();
                if(!EvaluateGuesses(rndNum))
                {
                    Console.WriteLine("You did not guess the number. You lost.");
                    return;
                }
                else
                {
                    Console.WriteLine("Congratulations. You have guessed the number. Do you want to continue with another round? y/n");
                    confirmChar = Console.ReadLine()[0];
                }
            } while (confirmChar == 'y');
            Console.WriteLine();
        }
    }
}
