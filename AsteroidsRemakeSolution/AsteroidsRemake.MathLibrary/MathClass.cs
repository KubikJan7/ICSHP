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
        /// Rotate a point around an origin
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="pointToRotate"></param>
        /// <param name="angle"></param>
        /// <returns>Rotated point</returns>
        public static Point RotatePointAroundOrigin(Point origin, Point pointToRotate, double angle)
        {
            Point result = new Point();
            double x = pointToRotate.X - origin.X;
            double y = pointToRotate.Y - origin.Y;
            result.X = (x*Math.Cos(angle))-(y*Math.Sin(angle))+origin.X;
            result.Y = (y*Math.Cos(angle))-(x*Math.Sin(angle))+origin.Y;
            return result;
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

        public static Point MovePointByGivenDistanceAndAngle(Point point, double dist, double angle)
        {
            return new Point(point.X + (Math.Sin(Math.PI / 180 * angle) * dist), point.Y + (Math.Cos(Math.PI / 180 * angle) * dist));
        }
    }
}
