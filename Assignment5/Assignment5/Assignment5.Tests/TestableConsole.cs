using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    public class TestableConsole : IConsole
    {
        public List<string> WrittenLines { get; } = new List<string>();

        public List<string> LinesToRead { get; } = new List<string>();

        private int ReadLineIndex { get; set; }

        public string ReadLine()
        {
            return LinesToRead[ReadLineIndex++];
        }

        public void WriteLine(string line)
        {
            WrittenLines.Add(line);
        }

        public void DidDisplayMenu(int startingOutputLineIndex)
        {
            Assert.AreEqual("What do you want to do?", WrittenLines[startingOutputLineIndex]);
            Assert.AreEqual("1. Create a course", WrittenLines[startingOutputLineIndex + 1]);
            Assert.AreEqual("2. Create an event", WrittenLines[startingOutputLineIndex + 2]);
            Assert.AreEqual("3. List events", WrittenLines[startingOutputLineIndex + 3]);
            Assert.AreEqual("4. Exit", WrittenLines[startingOutputLineIndex + 4]);
        }
    }
}