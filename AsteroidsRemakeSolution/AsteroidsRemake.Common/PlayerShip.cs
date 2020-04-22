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

        public PlayerShip(Point position, int size, int lives)
        {
            Position = position;
            Size = size;
            Lives = lives;
        }
        public override void Update()
        {

        }
    }
}
