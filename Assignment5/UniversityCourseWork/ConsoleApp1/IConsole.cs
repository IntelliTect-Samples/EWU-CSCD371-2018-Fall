using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IConsole
    {

        void WriteLine(string output);
        string ReadLine();

    }
}
