using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.Common
{
    public class EnemyShip:GameObject
    {
        public EnemyShip(Point position, int size)
        {
            Position = position;
            Size = size;
        }
        public override void Update()
        {

        }
    }
}
