using System;

namespace HelloWorld
{
    public class HelloWorld
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, what is your name?");
            var username = Console.ReadLine();
            Console.WriteLine("Hello {0}", username);
        }
    }
}
