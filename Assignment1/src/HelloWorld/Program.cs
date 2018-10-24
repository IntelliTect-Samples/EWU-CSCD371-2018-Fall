using System;

namespace HelloWorld
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Hello, what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello {0}!", name);
        }
    }
}
