using System;

namespace Assignment6
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