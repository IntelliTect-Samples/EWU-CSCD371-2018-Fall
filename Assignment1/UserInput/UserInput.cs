using System;

namespace Assignment1
{
    public class UserInput
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}!");
        }
    }
}
