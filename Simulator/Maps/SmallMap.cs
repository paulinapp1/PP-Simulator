using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        private readonly List<IMappable>?[,] fields;
        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa za duża");
            }
            if (sizeY > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Mapa za duża");
            }
            fields = new List<IMappable>?[sizeX, sizeY];
        }
        protected override List<IMappable>?[,] Fields => fields;

        public override void Add(IMappable creature, Point position)
        {

            int x = position.X;
            int y = position.Y;

            if (Fields[x, y] == null)
            {
                Fields[x, y] = new List<IMappable>();
            }

            Fields[x, y]!.Add(creature);
        }

        public  override void Remove(IMappable creature, Point position)
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

        public override void Move(IMappable creature, Point position, Direction direction)
        {
            int x = position.X;
            int y = position.Y;
            var newPosition = Next(position, direction);

            Remove(creature, position);





            Add(creature, newPosition);
        }

        public override List<IMappable> At(Point position)
        {
            int x = position.X;
            int y = position.Y;

            var creaturesAtPoint = new List<IMappable>();

            var creatures = Fields[x, y];
            if (creatures != null)
            {
                creaturesAtPoint.AddRange(creatures);
            }

            return creaturesAtPoint;
        }



    }
}
