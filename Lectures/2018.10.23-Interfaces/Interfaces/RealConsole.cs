using System;

namespace Interfaces
{
    public class RealConsole : IMyConsole
    {
        public void WriteLine(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));
            Console.WriteLine(line);
        }

        public object GetHost()
        {
            throw new NotImplementedException();
        }
    }
}