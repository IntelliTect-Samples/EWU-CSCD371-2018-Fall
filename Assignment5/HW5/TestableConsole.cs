using System;
using System.Collections.Generic;
using System.Text;
using HW5;

namespace HW5
{
    public class TestableConsole : IConsole
    {
        public string LastWrittenLine { get; private set; }
        public string LastWrite { get; private set; }
        public string LastReadLine { private get; set; }

        public void WriteLine(string line)
            => LastWrittenLine = line;

        public void Write(string line)
            => LastWrittenLine = line;

        public string ReadLine()
        {
            return LastReadLine;
        }
       
    }
}
