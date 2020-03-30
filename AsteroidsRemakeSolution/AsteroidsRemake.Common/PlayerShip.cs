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
        public double Speed { get; set; }

        public PlayerShip(Point position)
        {
            Position = position;
            Lives = 0;
            Score = 0;
            Speed = 0;
        }
        public override void Update()
        {

        }
    }
}
