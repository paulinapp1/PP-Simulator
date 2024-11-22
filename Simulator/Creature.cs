

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
        public abstract string Greeting();
       
        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }
        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
        
        public List<string> Go(List<Direction> directions)
        {
            List<string> results = new List<string>(directions.Count);

            for (int i = 0; i < directions.Count; i++)
            {
                results[i] = Go(directions[i]);
            }

            return results;

        }

        public List<string> Go(string directionsString)
        {
            List<Direction> directions = DirectionParser.Parse(directionsString);
            return Go(directions);
        }


        public abstract string Info { get; }
        
        public abstract int Power { get; }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}
