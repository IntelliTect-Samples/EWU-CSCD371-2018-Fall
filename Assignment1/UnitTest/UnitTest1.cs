using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UnitTestExpectedName()
        {
            string myValue = "Kris Veselits";
            string expectedOutput = $@">>Hello, what is your name?
<<{myValue}
>>Hello {myValue}!";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment1.UserInput.Main);
        }
    }
}
