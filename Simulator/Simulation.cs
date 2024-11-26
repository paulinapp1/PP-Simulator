using Simulator.Maps;
using Simulator;



public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; private set; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;



    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[turnIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            char move = char.ToLower(Moves[turnIndex]);
            switch (move)
            {
                case 'u': return "up";
                case 'r': return "right";
                case 'd': return "down";
                case 'l': return "left";
                default: return "";
            }
        }
    }
    private int turnIndex = 0;
    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
        {
            throw new ArgumentException("The creatures list cannot be empty.");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("The number of creatures must match the number of starting positions.");
        }

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            var creature = creatures[i];
            var position = positions[i];

            if (!map.Exist(position))
            {
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");
            }
            creature.SetMap(map, position);
            map.Add(creature, position);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation is already finished.");
        }

        if (Moves.Length == 0)
        {
            Finished = true;
            return;
        }

        char moveChar = Moves[turnIndex];
        var directions = DirectionParser.Parse(moveChar.ToString());

        if (directions != null && directions.Count > 0)
        {
            var direction = directions[0];
            CurrentCreature.Go(direction);
        }

        turnIndex++;

        if (turnIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}
