using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.MathLibrary
{
    public static class MathClass
    {
        private static Random rand = new Random();
        public static Point FindCenterOfTriangle(Point p1, Point p2, Point p3)
        {
            return new Point((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3);
        }

        /// <summary>
        /// Will move a point to a coordination specified by a distance and angle
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dist"></param>
        /// <param name="angle"></param>
        /// <returns>Point with new coordination</returns>
        public static Point MovePointByGivenDistanceAndAngle(Point point, double dist, double angle)
        {
            return new Point(point.X + (Math.Sin(Math.PI / 180.0 * angle) * dist), point.Y + (Math.Cos(Math.PI / 180.0 * angle) * dist));
        }

        /// <summary>
        /// Will find difference between two angles
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns>Difference of two angles</returns>
        public static double FindDifferenceOfTwoAngles(double alpha, double beta)
        {
            double phi = Math.Abs(beta - alpha) % 360.0;
            double distance = phi > 180.0 ? 360.0 - phi : phi;
            return distance;
        }

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
        /// Returns double from interval <min;max>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>random double</returns>
        public static double GetRandomDouble(double min, double max)
        {
            return rand.NextDouble() * ((max + 1) - min) + min;
        }

        /// <summary>
        /// Returns int from interval <min;max>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>random int</returns>
        public static int GetRandomInt(int min, int max)
        {
            return rand.Next(min, max + 1);
        }
    }
}
