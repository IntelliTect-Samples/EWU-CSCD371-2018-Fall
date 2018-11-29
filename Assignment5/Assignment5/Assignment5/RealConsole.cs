using System;

namespace Assignment5
{
    public class RealConsole : IConsole
    {
        public string ReadLine() => Console.ReadLine();
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}