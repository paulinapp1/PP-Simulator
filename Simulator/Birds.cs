using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Birds : Animals
    {
        private bool canFly = true;
        public bool CanFly { get { return canFly; } init { value = canFly; } }
        public override char Symbol => CanFly ? 'B' : 'b';
        public Birds(string description = "Unknown Bird", int size = 3, bool canFly = true) : base(description, size)
        {
            CanFly = canFly;
        }

        public override string Info
        {
            get
            {
                string flying_skill = canFly ? "fly+" : "fly-";
                return $"{Description} {flying_skill} <{Size}>";
            }
        }
        public override void Go(Direction direction)
        {
            if (Map == null)
            {
                Console.WriteLine("Map is not set. The bird cannot move.");
                return;
            }

           
            Point nextPosition = CanFly ? Map.Next(Map.Next(Position, direction), direction)  : Map.NextDiagonal(Position, direction);            

     
            Map.Move(this, Position, direction);

            Position = nextPosition;
        }

    }
}

