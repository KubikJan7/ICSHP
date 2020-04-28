using System;
using System.Collections.Generic;
using System.Windows;

namespace GalacticConquestRemake.Common
{
    public class SpaceShip : GameObject
    {
        public Planet DefaultPlanet { set; get; }
        public Planet TargetPlanet { set; get; }
        public int UnitCount { set; get; }
        public List<Point> Path { set; get; }

        public override void Update(double lastUpdateTime)
        {
            if (Math.Round(Path[Path.Count-1].X) == Math.Round(Position.X)&& Math.Round(Path[Path.Count - 1].Y) == Math.Round(Position.Y)  && CompletionIndication==false)
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
    }
}
