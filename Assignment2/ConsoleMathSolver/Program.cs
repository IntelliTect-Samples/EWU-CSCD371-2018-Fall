using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMathSolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tempList = (ConsoleMathSolverHelper.ParseOperators("-1+-1", "+"));
            foreach (var i in tempList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(tempList.Count);
        }
    }
}