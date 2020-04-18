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
        public static Point FindCenterOfTriangle(Point p1, Point p2, Point p3)
        {
            return new Point((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3);
        }

        /// <summary>
        /// Move point A closer to point B by given step
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="step"></param>
        /// <returns>Point moved by given step</returns>
        public static Point MovePointTowards(Point a, Point b, double step)
        {
            Point vector = new Point(b.X - a.X, b.Y - a.Y);
            double length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            Point unitVector = new Point(vector.X / length, vector.Y / length);
            return new Point(a.X + unitVector.X * step, a.Y + unitVector.Y * step);
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
            return new Point(point.X + (Math.Sin(Math.PI / 180 * angle) * dist), point.Y + (Math.Cos(Math.PI / 180 * angle) * dist));
        }

        /// <summary>
        /// Compare radius of circle with distance of its center from given point 
        /// </summary>
        /// <param name="circle_x"></param>
        /// <param name="circle_y"></param>
        /// <param name="radius"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Boolean</returns>
        public static bool IsPointInsideCircle(double circle_x, double circle_y, int radius, double x, double y)
        {
            if ((x - circle_x) * (x - circle_x) + (y - circle_y) * (y - circle_y) <= radius * radius)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Will find difference between two angles
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns>Difference of two angles</returns>
        public static double FindDifferenceOfTwoAngles(double alpha, double beta)
        {
            double phi = Math.Abs(beta - alpha) % 360;
            double distance = phi > 180 ? 360 - phi : phi;
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
    }
}
