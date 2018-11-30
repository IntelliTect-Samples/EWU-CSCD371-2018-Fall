using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment9
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> fibSeq = PatentDataAnalyzer.NthFibonacciNumbers(2);

            Console.WriteLine(fibSeq.ElementAt(0));
            Console.WriteLine(fibSeq.ElementAt(1));
        }
    }
}