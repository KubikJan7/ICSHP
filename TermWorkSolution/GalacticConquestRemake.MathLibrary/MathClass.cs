using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GalacticConquestRemake.MathLibrary
{
    public static class MathClass
    {
        /// <summary>
        /// Returns distance between 2 points
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns>distance in double</returns>
        public static double GetDistance(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
        /// <summary>
        ///Find the points of intersection.
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="radius"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>true if intersection of 2 points exits</returns>
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
                return false;
            }
            else
            {
                // two intersections
                return true;
            }
        }
        public static int GenerateRandomNumber(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }
        /// <summary>
        /// Calculate distance between all points in a given list
        /// </summary>
        /// <param name="list"></param>
        /// <returns>distance in double</returns>
        public static double GetDistanceBetweenPointsInList(List<Point> list)
        {
            double distance = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                    break;
                distance += GetDistance(list[i].X, list[i + 1].X, list[i].Y, list[i + 1].Y);
            }
            return distance;
        }
    }
}
