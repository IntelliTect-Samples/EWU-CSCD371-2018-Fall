using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{
    class RealConsole : IConsole
    {
        public void WriteLine(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));

            System.Console.WriteLine(line);
        }

        public void Write(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));

            System.Console.Write(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
