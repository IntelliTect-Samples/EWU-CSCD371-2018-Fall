using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MockConsole myConsole = new MockConsole();
            myConsole.InputValue.Add("Hello World");
            myConsole.InputValue.Add("Hello World 2");
            
            var myClass = new Program();
            myClass.MyConsole = myConsole;

            var myTuple = myClass.SetTime();

            Assert.AreEqual("Hello World", myTuple.firstValue);
            Assert.AreEqual("Hello World 2", myTuple.secondValue);
        }
    }

    class Program
    {
        public IConsole MyConsole {get; set;}
        public (string firstValue, string secondValue) SetTime()
        {
            var firstValue = MyConsole.ReadLine();
            var secondValue = MyConsole.ReadLine();
            return (firstValue, secondValue);
        }
    }

    interface IConsole
    {
        void WriteLine(string output);
        string ReadLine();
    }

    class ConcreteConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }

    class MockConsole : IConsole
    {
        private int readLineCount = 0;
        public string ConsoleValue { get; set; }
        public List<string> InputValue = new List<string>();
        public string ReadLine()
        {
            return InputValue[readLineCount++];
        }

        public void WriteLine(string output)
        {
            ConsoleValue = output;
        }
    }
}
