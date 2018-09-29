using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter your first name: ");
            string fName = Console.ReadLine();

            Console.WriteLine($"Your first name is: {fName}");
        }
    }
}
