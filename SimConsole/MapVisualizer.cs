﻿using Simulator.Maps;
using Simulator;
namespace SimConsole
{

    public class MapVisualizer
    {
        private readonly Map _map;

        public MapVisualizer(Map map)
        {
            _map = map;
        }

        public void Draw()
        {
            Console.Write(Box.TopLeft);
            for (int x = 0; x < _map.SizeX; x++)
            {
                Console.Write(Box.Horizontal);
                if (x < _map.SizeX - 1) Console.Write(Box.TopMid);
            }
            Console.WriteLine(Box.TopRight);

            // Zmiana pętli - iteracja po osi Y od 0 do SizeY-1
            for (int y = 0; y < _map.SizeY; y++)
            {
                Console.Write(Box.Vertical);

                for (int x = 0; x < _map.SizeX; x++)
                {
                    var creatures = _map.At(new Point(x, y));
                    if (creatures.Count > 1)
                    {
                        Console.Write('X');
                    }
                    else if (creatures.Count == 1)
                    {
                        var creature = creatures[0];
                        Console.Write($"{creature.Symbol}");
                    }
                    else
                    {
                        Console.Write(' ');
                    }

                    if (x < _map.SizeX - 1)
                    {
                        Console.Write(Box.Vertical);
                    }
                }

                Console.WriteLine(Box.Vertical);

                if (y < _map.SizeY - 1)
                {
                    Console.Write(Box.MidLeft);
                    for (int x = 0; x < _map.SizeX; x++)
                    {
                        Console.Write(Box.Horizontal);
                        if (x < _map.SizeX - 1) Console.Write(Box.Cross);
                    }
                    Console.WriteLine(Box.MidRight);
                }
            }

            Console.Write(Box.BottomLeft);
            for (int x = 0; x < _map.SizeX; x++)
            {
                Console.Write(Box.Horizontal);
                if (x < _map.SizeX - 1) Console.Write(Box.BottomMid);
            }
            Console.WriteLine(Box.BottomRight);
        }
    }
}
// można zamienic na biblioteke linie 