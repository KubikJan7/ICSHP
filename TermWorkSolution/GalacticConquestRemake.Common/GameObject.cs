﻿using System;
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
        public virtual Point Position { set; get; }
        public virtual int Size { set; get; }
        public virtual string OwnerColor { set; get; }
        public virtual bool CompletionIndication { set; get; }

        public abstract void Update(double lastUpdateTime);
        public virtual double Sum { set; get; }
    }
}
