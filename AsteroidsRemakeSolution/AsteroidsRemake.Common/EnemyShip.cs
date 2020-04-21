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
        public bool CanVanish { get; set; }
        public EnemyShip(int size, double velocityM, double motionDirection)
        {
            Size = size;
            VelocityMultiplier = velocityM;
            MotionDirection = motionDirection;
        }
        public override void Update()
        {

        }
    }
}
