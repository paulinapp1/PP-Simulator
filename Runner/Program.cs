using Simulator.Maps;
using System.Security.Cryptography.X509Certificates;
namespace Simulator
{
    internal class Program
    {
        
        static void Lab5a()
        {
            Rectangle test1 = new Rectangle(2, 1, 1, 2);
            Console.WriteLine(test1.ToString());
            try { Rectangle test2 = new Rectangle(1, 1, 1, 1); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            Rectangle test4 = new Rectangle(2, 3, 3, 2);
            Console.WriteLine(test4.ToString());
            Rectangle test5 = new Rectangle(1, 1, 5, 5);
            Console.WriteLine(test5.ToString());
            Point testPoint1 = new Point(3, 3);
            Console.WriteLine(test5.Contains(testPoint1));
            Point testPoint2 = new Point(1, 1);
            Console.WriteLine(test5.Contains(testPoint2));
            Point testPoint3 = new Point(6, 6);
            Console.WriteLine(test5.Contains(testPoint3));
            Point testPoint4 = new Point(0, 3);
            Console.WriteLine(test5.Contains(testPoint4));


        }
        static void Lab5b()
        {
            SmallSquareMap testmap1 = new SmallSquareMap(10);
            try
            {
                SmallSquareMap testmap2 = new SmallSquareMap(21);
            }
            catch (ArgumentOutOfRangeException ex) { 
                Console.WriteLine(ex.Message); 
            }
            try
            {
                SmallSquareMap testmap3 = new SmallSquareMap(4);
            }
            catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.Message);
            }
            Point testPoint1 = new Point(6, 6);
            Console.WriteLine(testmap1.Exist(testPoint1));
            Point testPoint2 = new Point(-1, 5);
            Console.WriteLine(testmap1.Exist(testPoint2));
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                Console.WriteLine($"Next method direction (invalid input): {direction} {testmap1.Next(testPoint2, direction)}");
            }
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                Console.WriteLine($"NextDiagonal method direction (invalid input): {direction} {testmap1.NextDiagonal(testPoint2, direction)}");

            }
            Point testPoint3 = new Point(5, 5);
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                Console.WriteLine($"Next method direction: {direction} {testmap1.Next(testPoint3, direction)}");
            }
            Point testPoint4 = new Point(4, 4);
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                Console.WriteLine($"NextDiagonal method direction: {direction} {testmap1.NextDiagonal(testPoint4, direction)}");
            }
          
            
           
        }






        static void Main(string[] args)
        {
            //  Console.WriteLine("Starting Simulator! \n");
            //  Point p = new(10, 25);
            //  Console.WriteLine(p.Next(Direction.Right));
             //Console.WriteLine(p.NextDiagonal(Direction.Right));
            Lab5a();
            Lab5b();



        }
    }
}


