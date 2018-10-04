using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMathSolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter expression in form <integer><operator><integer>: ");
                string userInput = Console.ReadLine();
                double result = ConsoleMathSolverHelper.CalculateValue(userInput);
                Console.WriteLine($"Value is: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}