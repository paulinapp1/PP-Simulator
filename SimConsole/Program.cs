using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using Simulator;
using Simulator.Maps;
using Point = Simulator.Point;

namespace SimConsole
{
    internal class Program
    {


        static void Main()
        {
           


            BigBounceMap map = new BigBounceMap(8, 6);

            List<IMappable> mappables = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals("Kroliki", 8),
            new Birds("Orly", 14, true),
            new Birds("Strusie", 2, false)
        };

            List<Point> points = new List<Point>
        {
            //new Point(2, 2),
            //new Point(3, 1),
            //new Point(4, 4),
            //new Point(2, 5),
            //new Point(0, 0)
            new Point(0,0), new Point(0,1), new Point(0,2), new Point(0,3), new Point(0,4)
        };

            //string moves = "drulldrudldrlu";
            string moves = "rrrrrrrrrrrrrrrrrrrr";
            Simulation simulation = new(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);
            SimulationHistory history = new(simulation);
            LogVisualizer logVisualizer = new(history);
            int move = 1;

            mapVisualizer.Draw();


            while (!simulation.Finished)
            {
                Console.WriteLine("Press any key to proceed to the next turn...");
                Console.ReadKey(true);
              
                Console.WriteLine($"Tura {move}");
                Console.Write($"Mappable goes {simulation.CurrentMoveName}\n");


                simulation.Turn();


                mapVisualizer.Draw();
                move++;
            }

            Console.WriteLine("\nSimulation finished!");
            logVisualizer.Draw(3);
            Console.ReadKey(true);
            logVisualizer.Draw(5);
        }
    }
}


