using System;

namespace HelloWorld
{
    public class HelloWorld
    {
        public static void Main(string[] args)
        {
            Console.Write("What is your favorite word: ");
            var strIn = Console.ReadLine();
            Console.WriteLine($"Your favorite word is {strIn}");
        }
    }
}
