

using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature
    {
        private string name="Unknown";
        public Map? Map { get; private set; }
        public Point Position { get; private set; }
        public string Name
        {
            get { return name; }
            init
            {
                name=Validator.Shortener(value, 3, 25, '#');
            }
        }

        private int level=1;
        public int Level
        {
            get { return level; }
            init
            {
               level= Validator.Limiter(value, 1, 10);
            }
        }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;

        }
        public Creature() { }
        public abstract string Greeting();
       
        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }
       
      
        public void Go(Direction direction)
        {
            if (Map == null)
                return; 
            Point nextPosition = Map.Next(Position, direction);
            Map.Move(this, Position, direction); 
            Position = nextPosition;
        }
      


        public abstract string Info { get; }
        
        public abstract int Power { get; }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}
