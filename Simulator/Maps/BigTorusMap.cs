using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigTorusMap : BigMap
    {
        private readonly int sizeX;
        private readonly int sizeY;

        public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
        public override Point Next(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point(p.X, (p.Y + 1) % sizeY);
                case Direction.Down:
                    return new Point(p.X, (p.Y - 1 + sizeY) % sizeY);
                case Direction.Left:
                    return new Point((p.X - 1 + sizeX) % sizeX, p.Y);
                case Direction.Right:
                    return new Point((p.X + 1) % sizeX, p.Y);
                default:
                    throw new ArgumentException("Nieznany kierunek");
            }
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point((p.X + 1) % sizeX, (p.Y + 1) % sizeY);
                case Direction.Down:
                    return new Point((p.X - 1 + sizeX) % sizeX, (p.Y - 1 + sizeY) % sizeY);
                case Direction.Left:
                    return new Point((p.X - 1 + sizeX) % sizeX, (p.Y + 1) % sizeY);
                case Direction.Right:
                    return new Point((p.X + 1) % sizeX, (p.Y - 1 + sizeY) % sizeY);
                default:
                    throw new ArgumentException("Nieznany kierunek");
            }
        }
    }
}
