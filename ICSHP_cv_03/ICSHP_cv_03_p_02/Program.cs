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
            Console.WriteLine(MathConvertor.DecToBin(8));
            Console.WriteLine(MathConvertor.BinToDec("0101"));
        }
    }
}
