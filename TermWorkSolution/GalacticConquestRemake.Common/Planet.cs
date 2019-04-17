using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticConquestRemake.Common
{
    public class Planet : GameObject
    {
        public int UnitCount { set; get; }

        public Point ContactPoints { get; }
        public Point DodgePoints { get; }

        public const int borderPoints = 32;
        public const float contactRadius = 1.0f;
        public const float dodgeRadius = 1.4f;

        public override void Update(float lastUpdate)
        {
            throw new NotImplementedException();
        }

        public Planet(Position position, int size, string ownerColor)
        {
            this.Position = position;
            this.Size = size;
            this.OwnerColor = ownerColor;
        }
        public Planet(int size, string ownerColor)
        {
            this.Size = size;
            this.OwnerColor = ownerColor;
        }

        public void SpaceShipArrival(SpaceShip spaceShip)
        {

        }
    }
}
