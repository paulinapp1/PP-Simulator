

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
        
        public string[] Go(Direction[] directions)
        {
            string[] results = new string[directions.Length];

            for (int i = 0; i < directions.Length; i++)
            {
                results[i] = Go(directions[i]);
            }

            return results;

        }

        public string[] Go(string directionsString)
        {
            Direction[] directions = DirectionParser.Parse(directionsString);
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
