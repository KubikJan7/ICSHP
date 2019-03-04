using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    public static class MathConvertor
    {
        public static string DecToBin(int dec)
        {
            return Convert.ToString(dec, 2);
        }
        public static int BinToDec(string bin)
        {
            return Convert.ToInt32(bin, 2);
        }
        public static void DecToRoman()
        {
        }
        public static void RomanToDec()
        {
        }
    }
}
