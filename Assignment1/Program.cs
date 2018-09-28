using System;

namespace Assignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("What is Your Name?");
            string userInput = Console.ReadLine();
            Console.WriteLine("Hello Human: {0}!", userInput);
            //Console.WriteLine($@"Hello {userInput}!");
        }
    }
}
