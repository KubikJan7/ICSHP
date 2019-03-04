using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_03.SamplesLibrary
{
    public static class OverFlowUnderFlow
    {
        public static void DoIt()
        {
            uint max = uint.MaxValue;
            uint min = uint.MinValue;

            Console.WriteLine($"max: {max}, min:{min}");
            checked
            {
                max++;
                min--;
            }
            Console.WriteLine($"max: {max}, min:{min}");
        }
    }
}
