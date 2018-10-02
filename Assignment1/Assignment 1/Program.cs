using System;

namespace Assignment_1
{
    public class ProgramInputOutput
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, whats your name?");
            String name = Console.ReadLine();
            Console.WriteLine($"Hello {name}!");
        }
    }
}
