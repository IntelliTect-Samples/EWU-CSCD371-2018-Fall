using System;

namespace ConsoleMathSolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var result = ConsoleMathSolverHelper.ParseOperators("1+1+", '+');
            Console.WriteLine($"res: {result}");
        }
    }
}