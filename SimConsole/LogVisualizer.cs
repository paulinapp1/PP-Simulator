using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole
{
    internal class LogVisualizer
    {
        SimulationHistory Log { get; }
        public LogVisualizer(SimulationHistory log)
        {
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }


        public void Draw(int turnIndex)
        {
            if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(turnIndex), "Turn index out of range.");
            }
            Console.WriteLine($"Drawing turn {turnIndex}...");
            Console.WriteLine($"Turn state: {Log.TurnLogs[turnIndex]}");

            var turnLog = Log.TurnLogs[turnIndex];
            int columns = Log.SizeX;
            int rows = Log.SizeY;
            Console.WriteLine($"Drawing turn {turnIndex}: {turnLog.Symbols.Count} symbols");

            // Wypisz symbole przed rysowaniem
            foreach (var symbol in turnLog.Symbols)
            {
                Console.WriteLine($"Symbol {symbol.Value} at {symbol.Key}");
            }
            Console.OutputEncoding = Encoding.UTF8;

            // Góra planszy
            Console.Write($"{Box.TopLeft}");
            for (int i = 0; i < columns - 1; i++)
            {
                Console.Write($"{Box.Horizontal}{Box.TopMid}");
            }
            Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

            // Wiersze mapy
            for (int row = rows - 1; row >= 0; row--)
            {
                Console.Write(Box.Vertical);
                for (int col = 0; col < columns; col++)
                {
                    var position = new Point(col, row);

                    if (turnLog.Symbols.ContainsKey(position))
                    {
                        Console.Write(turnLog.Symbols[position]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.Write(Box.Vertical);
                }
                Console.WriteLine();

                if (row > 0)
                {
                    Console.Write(Box.MidLeft);
                    for (int i = 0; i < columns - 1; i++)
                    {
                        Console.Write($"{Box.Horizontal}{Box.Cross}");
                    }
                    Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
                }
            }

            // Dół planszy
            Console.Write(Box.BottomLeft);
            for (int i = 0; i < columns - 1; i++)
            {
                Console.Write($"{Box.Horizontal}{Box.BottomMid}");
            }
            Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
        }
    }
}