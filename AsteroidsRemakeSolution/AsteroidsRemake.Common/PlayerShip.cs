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
        public int Score { get; set; }

        public PlayerShip(Point position, int size)
        {
            Position = position;
            Size = size;
        }
        public override void Update()
        {

        }
    }
}
