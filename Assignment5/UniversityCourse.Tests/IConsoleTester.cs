using System;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversityCourse.Tests
{
    [TestClass]
    public class IConsoleTester
    {
        
        [DataRow("")]
        [DataRow("Some words")]
        [DataRow("A")]
        [DataRow("    ")]
        [DataTestMethod]
        public void Test_IConsole_Write_Success(string lineToWrite)
        {
            var myConsole = new TestableConsole();
            
            myConsole.WriteLine(lineToWrite);
            Assert.AreEqual(lineToWrite, myConsole.LastWrittenLine);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_IConsole_Write_ArgumentNullException()
        {
            var myConsole = new TestableConsole();
            
            myConsole.WriteLine(null);
            Assert.Fail();
        }
        
        [DataRow("Some data")]
        [DataRow("A whole bunch of words making it a sentence.")]
        [DataRow("")]
        [DataRow("     ")]
        [DataTestMethod]
        public void Test_IConsole_Read_Success(string input)
        {
            var myConsole = new TestableConsole();
            Console.SetIn(new StringReader(input + "\n"));
            var actualInput = myConsole.ReadLine();
            Assert.AreEqual(input, actualInput);
        }

       

    }
}