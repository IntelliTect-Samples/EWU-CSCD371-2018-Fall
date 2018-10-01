using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMathSolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var result = ConsoleMathSolverHelper.ParseOperators("1+1");
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"size: {result.Count}");
        }
    }
}