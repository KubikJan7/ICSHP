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
        public virtual Point Position { set; get; }
    }
}
