using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
        }

        protected override List<IMappable>?[,] Fields => throw new NotImplementedException();

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint;
            switch (d)
            {
                case Direction.Up:
                    nextPoint = new Point(p.X, p.Y - 1); // Ruch w górę
                    break;
                case Direction.Down:
                    nextPoint = new Point(p.X, p.Y + 1); // Ruch w dół
                    break;
                case Direction.Left:
                    nextPoint = new Point(p.X - 1, p.Y); // Ruch w lewo
                    break;
                case Direction.Right:
                    nextPoint = new Point(p.X + 1, p.Y); // Ruch w prawo
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(d), "Invalid direction.");
            }

            if (nextPoint.X < 0 || nextPoint.X >= SizeX || nextPoint.Y < 0 || nextPoint.Y >= SizeY)
            {
                switch (d)
                {
                    case Direction.Up:
                        d = Direction.Down;
                        break;
                    case Direction.Down:
                        d = Direction.Up;
                        break;
                    case Direction.Left:
                        d = Direction.Right;
                        break;
                    case Direction.Right:
                        d = Direction.Left;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(d), "Invalid direction.");
                }

                switch (d)
                {
                    case Direction.Up:
                        nextPoint = new Point(p.X, p.Y - 1);
                        break;
                    case Direction.Down:
                        nextPoint = new Point(p.X, p.Y + 1);
                        break;
                    case Direction.Left:
                        nextPoint = new Point(p.X - 1, p.Y);
                        break;
                    case Direction.Right:
                        nextPoint = new Point(p.X + 1, p.Y);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(d), "Invalid direction.");
                }

                if (nextPoint.X < 0 || nextPoint.X >= SizeX || nextPoint.Y < 0 || nextPoint.Y >= SizeY)
                {
                    return p;
                }
            }

            return nextPoint;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextPoint;
            switch (d)
            {
                case Direction.Up:
                    nextPoint = new Point(p.X - 1, p.Y - 1); // Ruch w lewo-górę
                    break;
                case Direction.Down:
                    nextPoint = new Point(p.X + 1, p.Y + 1); // Ruch w prawo-dół
                    break;
                case Direction.Left:
                    nextPoint = new Point(p.X - 1, p.Y + 1); // Ruch w lewo-dół
                    break;
                case Direction.Right:
                    nextPoint = new Point(p.X + 1, p.Y - 1); // Ruch w prawo-górę
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(d), "Invalid diagonal direction.");
            }

            if (nextPoint.X < 0 || nextPoint.X >= SizeX || nextPoint.Y < 0 || nextPoint.Y >= SizeY)
            {
                switch (d)
                {
                    case Direction.Up:
                        d = Direction.Down;
                        break;
                    case Direction.Down:
                        d = Direction.Up;
                        break;
                    case Direction.Left:
                        d = Direction.Right;
                        break;
                    case Direction.Right:
                        d = Direction.Left;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(d), "Invalid diagonal direction.");
                }

                switch (d)
                {
                    case Direction.Up:
                        nextPoint = new Point(p.X - 1, p.Y - 1);
                        break;
                    case Direction.Down:
                        nextPoint = new Point(p.X + 1, p.Y + 1);
                        break;
                    case Direction.Left:
                        nextPoint = new Point(p.X - 1, p.Y + 1);
                        break;
                    case Direction.Right:
                        nextPoint = new Point(p.X + 1, p.Y - 1);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(d), "Invalid diagonal direction.");
                }

                if (nextPoint.X < 0 || nextPoint.X >= SizeX || nextPoint.Y < 0 || nextPoint.Y >= SizeY)
                {
                    return p;
                }
            }

            return nextPoint;
        }


    }
}
