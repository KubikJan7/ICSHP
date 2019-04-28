﻿using System;
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
        public Point Path { set; get; }
        public int CoveredDistance { set; get; }

        public override void Update(double lastUpdateTime)
        {
            throw new NotImplementedException();
        }
    }
}
