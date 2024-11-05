

namespace Simulator
{
    public abstract class Creature
    {
        private string name="Unknown";
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
        public abstract void SayHi();
       
        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }
        public void Go(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Console.WriteLine($"{Name} goes up");
                    break;
                case Direction.Right:
                    Console.WriteLine($"{Name} goes right");
                    break;
                case Direction.Down:
                    Console.WriteLine($"{Name} goes down");
                    break;
                case Direction.Left:
                    Console.WriteLine($"{Name} goes left");
                    break;


            }
        }
        public void Go(Direction[] directions)
        {
            foreach (Direction direction in directions)
            {
                Go(direction);
            }
        }

        public void Go(string directionsString)
        {
            Direction[] directions = DirectionParser.Parse(directionsString);
            Go(directions);
        }


        public abstract string Info { get; }
        
        public abstract int Power { get; }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}
