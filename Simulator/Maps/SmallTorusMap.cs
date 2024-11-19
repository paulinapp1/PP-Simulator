using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }
        private Rectangle bounds;
        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException("Nieprawidłowy rozmiar mapy");
            }
            else { 
                Size = size;
            bounds = new Rectangle(0, 0, Size-1, Size-1);
        }
            

        }
        public override bool Exist(Point p)
        {
            return bounds.Contains(p);

        }

        public override Point Next(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point(p.X, (p.Y + 1) % Size);
                case Direction.Down:
                    return new Point(p.X, (p.Y - 1 + Size) % Size);
                case Direction.Left:
                    return new Point((p.X - 1 + Size) % Size, p.Y);
                case Direction.Right:
                    return new Point((p.X + 1) % Size, p.Y);
                default:
                    throw new ArgumentException("Nieznany kierunek");
            }
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point((p.X + 1) % Size, (p.Y + 1) % Size);
                case Direction.Down:
                    return new Point((p.X - 1 + Size) % Size, (p.Y - 1 + Size) % Size);
                case Direction.Left:
                    return new Point((p.X - 1 + Size) % Size, (p.Y + 1) % Size);
                case Direction.Right:
                    return new Point((p.X + 1) % Size, (p.Y - 1 + Size) % Size);
                default:
                    throw new ArgumentException("Nieznany kierunek");
            }
        }
    }
}
