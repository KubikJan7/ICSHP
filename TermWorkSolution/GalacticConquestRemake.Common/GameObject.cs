using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GalacticConquestRemake.Common
{
    public abstract class GameObject
    {
        public virtual Position Position { set; get; }
        public virtual int Size { set; get; }
        public virtual string OwnerColor { set; get; }
        public virtual bool CompletionIndication { set; get; }

        public abstract void Update(double lastUpdateTime);
    }

    public class Position
    {
        public int X { set; get; }
        public int Y { set; get; }

        public Position(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
