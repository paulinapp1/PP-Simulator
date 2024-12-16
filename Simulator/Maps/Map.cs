

using System.Drawing;

namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
   
    public abstract class Map
    {
        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public int SizeX { get; }
        public int SizeY { get; }
        private Rectangle bounds;

        private readonly Dictionary<Point, List<IMappable>> fields = new Dictionary<Point, List<IMappable>>();

        protected Map(int sizeX, int sizeY)
        {
           
            if (sizeX < 5 || sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa za mała");
            }

            SizeX = sizeX;
            SizeY = sizeY;

            bounds = new Rectangle(0, 0, this.SizeX - 1, SizeY - 1);


        }
        /// 
        public virtual bool Exist(Point p)
        {
            return bounds.Contains(p);
        }

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);
        public  void Add(IMappable creature, Point position)
        {
            if (!fields.TryGetValue(position, out var creatures))
            {
                creatures = new List<IMappable>();
                fields[position] = creatures;
            }

            creatures.Add(creature);
        }
        public  void Remove(IMappable creature, Point position)
        {
            if (fields.TryGetValue(position, out var creatures))
            {
                creatures.RemoveAll(c => c == creature);

                if (creatures.Count == 0)
                {
                    fields.Remove(position);
                }
            }
        }

        public  void Move(IMappable creature, Point position, Direction direction)
        {
            Point newPosition = position;
            if (creature is Birds bird && bird.CanFly)
            {
                newPosition = Next(position, direction);
                newPosition = Next(newPosition, direction);
            }
            else
            {
                newPosition = Next(position, direction);
            }

            Remove(creature, position);

            Add(creature, newPosition);
        }

        public  List<IMappable> At(Point position)
        {
            if (fields.TryGetValue(position, out var creatures))
            {
                return new List<IMappable>(creatures);
            }

            return new List<IMappable>();
        }
    }


}

 