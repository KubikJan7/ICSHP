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
        public virtual int Size { get; set; }
        public virtual Point Position { set; get; }
        public virtual double MotionDirection { get; set; }
        public virtual bool Completed { get; set; }
        public virtual double VelocityMultiplier { get; set; }
        public abstract void Update();

    }
}
