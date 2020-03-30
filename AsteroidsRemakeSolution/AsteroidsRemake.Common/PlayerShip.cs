using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.Common
{
    public class PlayerShip : GameObject
    {
        public int Lives { get; set; }

        public PlayerShip(Point position)
        {
            Position = position;
        }
        public override void Update()
        {

        }
    }
}
