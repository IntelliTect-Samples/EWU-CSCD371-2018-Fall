using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelloWorld.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInputAndOutput()
        {
            string userInput = "Bob Ross" ;
            string expectedOutput = $@">>Please enter your name: <<{userInput}
>>Hello {userInput}!";
            
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloWorld.Program.Main);
        }
    }
}
