using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.Common
{
    public class Shot : GameObject
    {
        public Point Target { get; set; }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public Shot(Point position, Point target)
        {
            Position = position;
            Target = target;
        }
    }
}
