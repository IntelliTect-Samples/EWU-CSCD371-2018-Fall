using System;

namespace Assignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, what is your name?");
            String name = Console.ReadLine();

            Console.WriteLine($"Hello {name}!");
            
            Console.Write("Press any key to continue . . .");
            Console.Read();
            
        }
    }
}
