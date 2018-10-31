using System;
using UniversityCourse;

class TestableConsole : IConsole
{
    public string LastWrittenLine{ get; private set; }
        
    public void WriteLine(string line)
    {
        if (line == null) throw new ArgumentNullException(nameof(line));
        Console.WriteLine(LastWrittenLine = line);
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }
}