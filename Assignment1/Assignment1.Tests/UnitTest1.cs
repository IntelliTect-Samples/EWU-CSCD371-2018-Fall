using Microsoft.VisualStudio.TestTools.UnitTesting;//using is equivalent to import
using System;

namespace Assignment1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string myValue = "Stoke";
            String expectedOutput = $@">>What is Your Name?
<<{myValue}
>>Hello Human: {myValue}!";//@allows string to have multiple lines
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment1.Program.Main);
        }
    }
}
