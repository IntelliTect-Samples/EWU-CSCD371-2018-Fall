using System;

namespace UniversityCourse
{
    public class RealConsole : IConsole
    {
        public void WriteLine(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}