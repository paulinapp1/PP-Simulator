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
                Console.WriteLine("Nie ma mapy");
                return;
            }
            Point nextPosition;
            if (CanFly)
            {
                nextPosition = Map.Next(Position, direction);
                nextPosition = Map.Next(nextPosition, direction);
            }
            else
            {
                nextPosition = Map.NextDiagonal(Position, direction);

            }
       
            Position = nextPosition;
        }

    }
}

