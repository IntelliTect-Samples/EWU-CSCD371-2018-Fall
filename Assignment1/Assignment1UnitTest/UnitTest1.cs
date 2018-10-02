using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1UnitTest
{
    [TestClass]
    public class UnitTestClassForAss1
    {
        [TestMethod]
        public void TestMethodInputOutput()
        {
            string myValue = "Anatoli";
            string expectedOutput = $@">>Hello, whats your name?
<<{myValue}
>>Hello {myValue}!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment_1.Program.Main);
        }
    }
    
}
