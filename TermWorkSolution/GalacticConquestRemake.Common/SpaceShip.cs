using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GalacticConquestRemake.Common
{
    public class SpaceShip : GameObject
    {
        public Planet DefaultPlanet { set; get; }
        public Planet TargetPlanet { set; get; }
        public int UnitCount { set; get; }
        public List<Point> Path { set; get; }
        public int CoveredDistance { set; get; }

        private Point actualTargetPoint;
        private int targetPointIndex;
        public override void Update(double lastUpdateTime)
        {
            // space ship will be moved towards the destination by lastUpdateTime/8
            var vector = new Point(actualTargetPoint.X - Position.X, actualTargetPoint.Y - Position.Y);
            var length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            var unitVector = new Point(vector.X / length, vector.Y / length);
            Point position =  new Point(Position.X + unitVector.X * (lastUpdateTime/20), Position.Y + unitVector.Y * (lastUpdateTime/20));
            CoveredDistance += (int) Math.Round(lastUpdateTime / 20);
            Position.X = (int)Math.Round(position.X);
            Position.Y = (int)Math.Round(position.Y);

            if (Math.Round(actualTargetPoint.X) == Position.X && Math.Round(actualTargetPoint.Y) == Position.Y)
                actualTargetPoint = Path[targetPointIndex++];

            if (Position.X == Math.Round(Path.Last().X)&&Position.Y == Math.Round(Path.Last().Y))
            {
                TargetPlanet.SpaceShipArrival(this);
                CompletionIndication = true;
            }

        }

        public SpaceShip(Planet defaultPlanet, Planet targetPlanet, int unitCount, List<Point> path)
        {
            DefaultPlanet = defaultPlanet;
            TargetPlanet = targetPlanet;
            UnitCount = unitCount;
            Path = path;
            actualTargetPoint = Path[targetPointIndex];
        }
    }
}
