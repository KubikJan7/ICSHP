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
        public GameObject Owner { get; set; }
        public Point Target { get; set; }
        public double TraveledDistance { get; set; }
        public double MaximumDistance { get; set; }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public Shot(GameObject owner,Point position, int size, double velocityM, double maximumDistance, double motionDirection)
        {
            Owner = owner;
            Position = position;
            Size = size;
            TraveledDistance = 0;
            VelocityMultiplier = velocityM;
            MaximumDistance = maximumDistance;
            MotionDirection = motionDirection;
        }
    }
}
