using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string userInput;

            Console.Write("Please enter your name: ");
            userInput = Console.ReadLine();
            Console.WriteLine($"Hello {userInput}!");
        }
    }
}
