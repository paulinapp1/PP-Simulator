

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
        protected abstract List<Creature>?[,] Fields { get;}

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
        public void Add(Creature creature, Point position)
        {
        
            int x = position.X;
            int y = position.Y;

            if (Fields[x, y] == null)
            {
                Fields[x, y] = new List<Creature>();
            }

            Fields[x, y]!.Add(creature);
        }

        public void Remove(Creature creature, Point position)
        {
            int x = position.X;
            int y = position.Y;

            var creatures = Fields[x, y];
            if (creatures != null)
            {
                creatures.RemoveAll(c => c == creature);

                if (creatures.Count == 0)
                {
                    Fields[x, y] = null;
                }
            }
        }

        public void Move(Creature creature, Point position, Direction direction)
        {
            int x = position.X;
            int y = position.Y;

            Remove(creature, position);

         
            var newPosition = Next(position, direction);

      
            Add(creature, newPosition);
        }

        public List<Creature> At(Point position)
        {
            int x = position.X;
            int y = position.Y;

            var creaturesAtPoint = new List<Creature>();

            var creatures = Fields[x, y];
            if (creatures != null)
            {
                creaturesAtPoint.AddRange(creatures);
            }

            return creaturesAtPoint;
        }

    }
}
 