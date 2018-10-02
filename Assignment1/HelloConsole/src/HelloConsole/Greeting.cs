using System;

namespace HelloConsole
{
    public class Greeting
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello from your friendly neighborhood console!");
            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine();
            Console.Write("Thanks {0}! ", firstName);
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine();
            Console.WriteLine("Excellent! Greetings to you, Sir {0} {1}!", firstName, lastName);
            Console.WriteLine("I hope this day finds you well and productive.");
        }
    }
}

