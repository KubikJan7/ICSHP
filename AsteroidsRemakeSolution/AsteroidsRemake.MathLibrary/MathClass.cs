using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsRemake.MathLibrary
{
    public static class MathClass
    {
        public static (double, double) FindCenterOfTriangle(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            return ((x1 + x2 + x3) / 3, (y1 + y2 + y3) / 3);
        }
    }
}
