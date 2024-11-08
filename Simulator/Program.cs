using System.Security.Cryptography.X509Certificates;

namespace Simulator
{
    internal class Program
    {
        static void Lab5a()
        {
            Rectangle test1=new Rectangle(2, 1, 1, 2);
            Console.WriteLine(test1.ToString());
            try { Rectangle test2 = new Rectangle(1, 1, 1, 1); } 
            catch(ArgumentException ex) { Console.WriteLine(ex.Message); }
            Rectangle test4 = new Rectangle(2, 3, 3, 2);
            Console.WriteLine(test4.ToString());
            Rectangle test5 = new Rectangle(1,1,5,5);
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
       

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator! \n");
            Point p = new(10, 25);
            Console.WriteLine(p.Next(Direction.Right));
            Console.WriteLine(p.NextDiagonal(Direction.Right));
            Lab5a();
          


        }
    }
}
