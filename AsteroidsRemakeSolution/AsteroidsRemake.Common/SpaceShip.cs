using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.Common
{
    public class SpaceShip : GameObject
    {
        public int Lives { get; set; }

        public SpaceShip(Point position)
        {
            Position = position;
        }
    }
}
