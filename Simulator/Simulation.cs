using Simulator.Maps;
namespace Simulator;
public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

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
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;
    private List<Direction> ParsedMoves { get; }
    private int turnIndex = 0;

    /// <summary>
    /// Icreature which will be moving current turn.
    /// </summary>
    public IMappable CurrentCreature => Creatures[turnIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => ParsedMoves.Count > turnIndex ? ParsedMoves[turnIndex].ToString().ToLower() : string.Empty;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("List of creatures cannot be empty.");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures must match the number of starting positions.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));

        ParsedMoves = Moves
            .Select(c => DirectionParser.Parse(c.ToString().ToLower()))
            .Where(d => d != null && d.Count > 0)
            .Select(d => d[0])
            .ToList();

        if (ParsedMoves.Count == 0)
        {
            throw new ArgumentException("Moves must contain at least one valid direction.");
        }

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
        if (turnIndex >= ParsedMoves.Count)
        {
            Finished = true;
            return;
        }
        Direction direction = ParsedMoves[turnIndex];
        CurrentCreature.Go(direction);
        turnIndex++;
        if (turnIndex >= ParsedMoves.Count)
        {
            Finished = true;
        }
    }
}