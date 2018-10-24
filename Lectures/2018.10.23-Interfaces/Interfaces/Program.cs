using System;

namespace Interfaces
{
    public static class MyExtensions
    {
        public static string Bounce(this IProvideImperialSize box)
        {
            double howHigh = box.GetArea();
            return $"Wow {howHigh}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //IMyConsole console = new RealConsole();
            //var myClass = new MyClassToTest(console);
            //myClass.DoStuff();

            Box box = new Box();
            IProvideImperialSize imperialSize = box;
            imperialSize.Bounce();

            Console.ReadLine();
        }
    }

    public interface IProvideImperialSize
    {
        double GetArea();
    }

    public interface IProvideMetricSize
    {
        double Bounce();
    }

    public class Box : IProvideMetricSize, IProvideImperialSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        double IProvideMetricSize.Bounce()
        {
            throw new NotImplementedException();
        }

        public double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
