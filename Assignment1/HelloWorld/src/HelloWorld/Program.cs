using System;

namespace HelloWorld
{
    public class UserInputName
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}!");
        }
    }
}
