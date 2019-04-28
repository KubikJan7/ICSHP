using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GalacticConquestRemake.Common
{
    public class Planet : GameObject
    {
        public int UnitCount { set; get; }

        public List<Point> ContactPoints { get; }
        public List<Point> DodgePoints { get; }
        public const int borderPointCount = 32;
        public const double contactRadiusMultiple = 1.0;
        public const double dodgeRadiusMultiple = 1.4;

        public override void Update(double lastUpdateTime)
        {
            int ts = Size <= 32 ? Size - 8 : Size;
            double updateTime = (Math.Log10(50 - ts) * 10) / 20;
            Sum = lastUpdateTime + updateTime;
            if (OwnerColor != "Gray" && UnitCount < Size * 3 && Sum >= ts)
            {
                UnitCount++;
                Sum = 0;
            }
        }

        public Planet(Point position, int size, string ownerColor)
        {
            this.Position = position;
            this.Size = size;
            this.OwnerColor = ownerColor;
            this.ContactPoints = InitializePointsAroundPlanet(contactRadiusMultiple);
            this.DodgePoints = InitializePointsAroundPlanet(dodgeRadiusMultiple);
        }

        public void SpaceShipArrival(SpaceShip spaceShip)
        {

        }

        private List<Point> InitializePointsAroundPlanet(double radiusMultiple)
        {
            List<Point> points = new List<Point>();
            double angle = (360.0 / borderPointCount) * Math.PI / 180.0;
            double radius = (Size / 2.0) * radiusMultiple;
            Point center = new Point(Position.X, Position.Y);
            for (int i = 0; i < borderPointCount; i++)
            {
                double x = center.X + Math.Cos(angle * i) * radius;
                double y = center.Y + Math.Sin(angle * i) * radius;
                points.Add(new Point(x, y));
            }

            return points;
        }
    }
}
