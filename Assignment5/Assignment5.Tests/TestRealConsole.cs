using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class TestRealConsole
    {
        private RealConsole _consoleToUse;

        [TestInitialize]
        public void Initialize()
        {
            _consoleToUse = new RealConsole();
        }
        
        [TestMethod]
        [DataRow("test")]
        [DataRow("C#")]
        [DataRow("something with spaces")]
        [DataRow("something with special characters! % &")]
        public void IConsoleWriteLine_TestValidOutput(string toPrint)
        {
            string capturedOutput = CaptureOutput(toPrint, _consoleToUse.WriteLine);
            
            Assert.AreEqual($"{toPrint}{System.Environment.NewLine}", capturedOutput);
        }
        
        [DataTestMethod]
        [DataRow("test")]
        [DataRow("C#")]
        [DataRow("something with spaces")]
        [DataRow("something with special characters! % &")]
        public void IConsoleWriteLine_TestValidInput(string toRead)
        {
            string capturedOutput = CaptureInput(toRead, _consoleToUse.ReadLine);
            
            Assert.AreEqual($"{toRead}", capturedOutput);
        }

        private static string CaptureOutput(string toTest, Action<string> methodName)
        {
            StringWriter stringWriter = new StringWriter();

            var oldOut = Console.Out;
            
            Console.SetOut(stringWriter);

            methodName(toTest);
            
            Console.SetOut(oldOut);

            return stringWriter.ToString();
        }
        
        private static string CaptureInput(string toTest, Func<string> methodName)
        {
            StringReader stringReader = new StringReader(toTest);

            var oldIn = Console.In;
            
            Console.SetIn(stringReader);

            string toReturn = methodName();
            
            Console.SetIn(oldIn);

            return toReturn;
        }
    }
}