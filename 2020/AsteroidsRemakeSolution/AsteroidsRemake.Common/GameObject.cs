using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.Common
{
    public abstract class GameObject
    {
        public int Size { get; set; }
        public Point Position { set; get; }
        public double MotionDirection { get; set; }
        public bool HadCollision { get; set; }
        public double VelocityMultiplier { get; set; }
        public GameObject CollidedWith { get; set; }
    }
}
