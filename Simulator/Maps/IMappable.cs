using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public interface IMappable
    {
        public char Symbol { get; }
        public string ToString();
        public Point Position { get; }
        void Go(Direction direction);
        void SetMap(Map map, Point position);
    }
}
