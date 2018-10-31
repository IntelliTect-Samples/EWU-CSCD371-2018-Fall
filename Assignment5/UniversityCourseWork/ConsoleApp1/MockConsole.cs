using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MockConsole : IConsole
    {

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
