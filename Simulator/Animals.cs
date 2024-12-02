

using Simulator.Maps;

namespace Simulator
{

    public class Animals : IMappable
    {
        public Map? Map { get; private set; }
        public Point Position { get; set; }
        public virtual char Symbol => 'A';
       
        public void SetMap(Map map, Point position)
        {

            Map = map;
            Position = position;
        }



        public virtual void Go(Direction direction)
        {
            if (Map == null)
                return;

            Point nextPosition = Map.Next(Position, direction);

   
            Map.Move((IMappable)this, Position, direction);  

            Position = nextPosition;
        }




        private string description = "Unknown";
        public  string Description
        {
            get { return description; }
            init
            {
                description = Validator.Shortener(value, 3, 15, '#');
            }
        }

        public Animals(string description, int size)
        {
            Description = description;
            Size = size;
        }


        public int Size { get; set; } = 3;

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }

      
     

        public virtual string Info
        {
            get { return $"{Description} <{Size}>"; }
        }
    }


}
