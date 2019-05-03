using GalacticConquestRemake.MathLibrary;
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
        public double CoveredDistance { set; get; }

        public override void Update(double lastUpdateTime)
        {
            // space ship will be moved towards the destination by lastUpdateTime/8
            double finalDistance = MathClass.GetDistanceBetweenPointsInList(Path);
            CoveredDistance += lastUpdateTime / 8.0;

            SetPosition();
            if (CoveredDistance>=finalDistance&&CompletionIndication==false)
            {
                TargetPlanet.SpaceShipArrival(this);
                CompletionIndication = true;
            }
        }

        public SpaceShip(Planet defaultPlanet, Planet targetPlanet, int unitCount, List<Point> path, string ownerColor)
        {
            DefaultPlanet = defaultPlanet;
            TargetPlanet = targetPlanet;
            UnitCount = unitCount;
            Path = path;
            OwnerColor = ownerColor;
        }

        private void SetPosition()
        {
            double distance = 0;
            for (int i = 0; i < Path.Count; i++)
            {
                if (i == Path.Count - 1)
                    break;
                distance += MathClass.GetDistance(Path[i].X, Path[i + 1].X, Path[i].Y, Path[i + 1].Y);
                if(CoveredDistance<=distance)
                {
                    Position = Path[i + 1];
                    break;
                }
            }
        }
    }
}
