using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.Common
{
    public class Asteroid : GameObject
    {
        public Asteroid(Point position, int size)
        {
            Position = position;
            Size = size;
        }
        public Asteroid(int size)
        {
            Size = size;
        }
        public override void Update()
        {

        }
    }
}
