

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public int Size { get; }
        private Rectangle bounds;

        public SmallSquareMap(int size)
        {
            if(size<5 || size > 20)
            {
                throw new ArgumentOutOfRangeException("Nieprawidłowy rozmiar mapy");
            }
            Size = size;
            int x1 = 0, y1 = 0;
            int x2 = size - 1;
            int y2 = size - 1;
            bounds = new Rectangle(x1, y1, x2, y2);


        }
        public override bool Exist(Point p) 
        {
            return bounds.Contains(p);
        }

        public override Point Next(Point p, Direction d)
        {
            Point next;
            if (Exist(p))
            {
                switch (d)
                {
                    case (Direction.Up):
                        next=new Point(p.X, p.Y + 1); break;
                    case (Direction.Down):
                        next= new Point(p.X, p.Y - 1); break;
                    case (Direction.Left):
                       next= new Point(p.X - 1, p.Y); break;
                    case (Direction.Right):
                       next= new Point(p.X + 1, p.Y); break;
                    default:
                        return p;

                  
                }
                if (Exist(next))
                {
                    return next;
                }
                
            }
            return p;

        }
            
                
        

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextDiagonal;
            if (Exist(p))
            {
                switch (d)
                {
                    case (Direction.Up):
                        nextDiagonal= new Point(p.X + 1, p.Y + 1); break;
                    case (Direction.Down):
                        nextDiagonal= new Point(p.X - 1, p.Y - 1); break;
                    case (Direction.Right):
                        nextDiagonal= new Point(p.X + 1,p.Y - 1); break;
                    case (Direction.Left):
                        nextDiagonal= new Point(p.X,p.Y + 1); break;
                    default:
                        return p;
                }
                if (Exist(nextDiagonal))
                {
                    return nextDiagonal;
                }

            }
            return p;
            
        }
    }
}
