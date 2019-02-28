using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    public class Arrays
    {
        int length;
        int[] array;
        public int[] LoadArray()
        {
            Console.WriteLine("Type in array length: ");
            int.TryParse(Console.ReadLine(), out length);
            array = new int[length];
            Console.WriteLine("\nType in array elements: ");
            for (int i = 0; i < array.Length; i++)
            {
                int.TryParse(Console.ReadLine(), out array[i]);
            }
            return array;
        }

        public void WriteArray()
        {
            Console.WriteLine("Entered array is: ");
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public void SortArrayAsc()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        int tmp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            Console.WriteLine("The array was sorted");
        }

        public void FindMinimum()
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine("The smallest element is: " + min);
        }

        public void FindFirstOccurenceOfEl(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    Console.WriteLine("The element " + element + "  is present and his index is: " + i);
                    return;
                }

            }
            Console.WriteLine("The element is not present.");
        }

        public void FindLasttOccurenceOfEl(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[array.Length - 1 - i] == element)
                {
                    Console.WriteLine("The element " + element + " is present and his index is: " + (array.Length - 1 - i));
                    return;
                }

            }
            Console.WriteLine("The element is not present.");
        }

    }
}
