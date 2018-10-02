using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Hello, please enter your name: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Hello, {input}!");
        }
    }
}
