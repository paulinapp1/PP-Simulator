

namespace Simulator.Maps
{
    public abstract class BigMap: Map
    {
        private readonly Dictionary<Point, List<IMappable>> fields;
        protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa za duża");
            }
            if (sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Mapa za duża");
            }
            fields = new Dictionary<Point, List<IMappable>>();
        }


        public override void Add(IMappable creature, Point position)
        {
            if (!fields.TryGetValue(position, out var creatures))
            {
                creatures = new List<IMappable>();
                fields[position] = creatures;
            }

            creatures.Add(creature);
        }

        public override void Remove(IMappable creature, Point position)
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

        public override void Move(IMappable creature, Point position, Direction direction)
        {
            var newPosition = Next(position, direction);

            Remove(creature, position);

            Add(creature, newPosition);
        }

        public override List<IMappable> At(Point position)
        {
            if (fields.TryGetValue(position, out var creatures))
            {
                return new List<IMappable>(creatures); 
            }

            return new List<IMappable>(); 
        }
    }
}
