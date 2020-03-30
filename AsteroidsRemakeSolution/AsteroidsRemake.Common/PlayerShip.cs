using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsteroidsRemake.Common
{
    public class PlayerShip : GameObject
    {
        public int Lives { get; set; }
        public int Score { get; set; }
        public double Velocity { get; set; }
        /// <summary>
        /// Stores value of the direction in which is the ship moving 
        /// Used to simulate the inertia motion
        /// </summary>
        public double MotionDirection { get; set; } 

        public PlayerShip(Point position)
        {
            Position = position;
        }
        public override void Update()
        {

        }
    }
}
