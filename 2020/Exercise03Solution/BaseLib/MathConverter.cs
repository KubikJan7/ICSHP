using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    /// <summary>
    /// Class for conversion between different mathematical systems
    /// </summary>
    public static class MathConverter
    {
        public static readonly Dictionary<char, int> RomanToNumberDictionary;
        public static readonly Dictionary<int, string> NumberToRomanDictionary;

        /// <summary>
        /// Converts decimal numbers to binary
        /// </summary>
        /// <param name="dec"></param>
        /// <returns>binary number in string</returns>
        public static string DecToBin(int dec)
        {
            return Convert.ToString(dec, 2);
        }

        /// <summary>
        /// Converts binary numbers to decimal
        /// </summary>
        /// <param name="bin"></param>
        /// <returns>number in int</returns>
        public static int BinToDec(string bin)
        {
            return Convert.ToInt32(bin, 2);
        }

        /// <summary>
        /// Converts decimal numbers to roman
        /// </summary>
        /// <param name="number"></param>
        /// <returns>roman number as string</returns>
        public static string DecToRoman(int number)
        {
            var roman = new StringBuilder();

            foreach (var item in NumberToRomanDictionary)
            {
                while (number >= item.Key)
                {
                    roman.Append(item.Value);
                    number -= item.Key;
                }
            }

            return roman.ToString();
        }

        /// <summary>
        /// Converts roman numbers to decimal
        /// </summary>
        /// <param name="roman"></param>
        /// <returns>number in string</returns>
        public static int RomanToDec(string roman)
        {
            int total = 0;

            int current, previous = 0;
            char currentRoman, previousRoman = '\0';

            for (int i = 0; i < roman.Length; i++)
            {
                currentRoman = roman[i];

                previous = previousRoman != '\0' ? RomanToNumberDictionary[previousRoman] : '\0';
                current = RomanToNumberDictionary[currentRoman];

                if (previous != 0 && current > previous)
                {
                    // previous num is multiplied by 2 because the number is already contained in total sum from previous iteration
                    total = total - (2 * previous) + current;
                }
                else
                {
                    total += current;
                }

                previousRoman = currentRoman;
            }

            return total;
        }

        /// <summary>
        /// Contains dictionaries for conversion between decimal and roman system
        /// </summary>
        static MathConverter()
        {
            RomanToNumberDictionary = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

            NumberToRomanDictionary = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };
        }

    }
}
