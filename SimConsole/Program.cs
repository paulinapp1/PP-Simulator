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
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Starting Simulator!\n");
            Console.WriteLine("Starting positions");

            SmallTorusMap map = new(8, 6);
            List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor"),
             new Animals("Kroliki", 8), new Birds("Orly", 14, true), new Birds("Strusie", 2, false) };
            List<Point> points = new() { new(2, 2), new(3, 1), new(4, 4), new(2, 5), new(0, 0) };
            string moves = "drulldrudldrlul";
            Simulation simulation = new(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);


            var move = 1;
            mapVisualizer.Draw();
            while (!simulation.Finished)
            {
                Console.WriteLine("Press any key to proceed to the next turn...");
                Console.ReadKey(true);
              
                Console.WriteLine($"Tura {move}");
                Console.Write($"Mappable goes {simulation.CurrentMoveName}\n");

                Console.WriteLine();
                simulation.Turn();
                mapVisualizer.Draw();
                move++;

            }



        }
    }
}
