using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (LineAndCircleIntersectionExists(2, -3, 2, new Point(0.86, -1.36), new Point(3.64, -4.14)))
                Console.WriteLine("true");
        }

        public static bool LineAndCircleIntersectionExists(
            double cx, double cy, double radius,
            Point point1, Point point2)
        {
            double dx, dy, A, B, C, det;

            dx = point2.X - point1.X;
            dy = point2.Y - point1.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
            C = (point1.X - cx) * (point1.X - cx) +
                (point1.Y - cy) * (point1.Y - cy) -
                radius * radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0) || (det == 0))
            {
                // no or one intersection
                Console.WriteLine("1");

                return false;
            }
            else
            {
                // two intersections
                Console.WriteLine("2");

                return true;
            }
        }
    }
}
