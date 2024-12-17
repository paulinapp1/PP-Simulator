using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class SimulationHistory
    {
        private Simulation _simulation { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public List<SimulationTurnLog> TurnLogs { get; } = [];
        

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ??
                throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;

            Run();
        }
        private void Run()
        {
            if (_simulation == null)
            {
                throw new InvalidOperationException("Symulacja się nie rozpoczęła");

            }

            while (!_simulation.Finished)
            {
               _simulation.Turn();
                var symbols = new Dictionary<Point, char>();
                foreach (var creature in _simulation.Creatures)
                {
                    symbols[creature.Position] = creature.Symbol;
                }
                var turnLog = new SimulationTurnLog
                {
                    Mappable = _simulation.CurrentCreature.ToString(),
                    Move = _simulation.CurrentMoveName,
                    Symbols = symbols
                };

                TurnLogs.Add(turnLog);

            }

        }

    }
}
