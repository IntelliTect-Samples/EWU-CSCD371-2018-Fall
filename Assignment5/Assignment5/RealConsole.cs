using System;

namespace Assignment5
{
    public class RealConsole : IConsole
    {
        public void WriteLine(string toWrite)
        {
            Console.WriteLine(toWrite);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}