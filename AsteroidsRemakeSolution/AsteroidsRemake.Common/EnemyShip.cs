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
        public EnemyShip(int size, double motionDirection)
        {
            Size = size;
            MotionDirection = motionDirection;
        }
        public override void Update()
        {

        }
    }
}
