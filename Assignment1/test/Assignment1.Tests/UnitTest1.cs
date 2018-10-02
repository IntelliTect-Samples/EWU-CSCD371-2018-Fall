using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment1.Tests
{
    [TestClass]
    public class TestInputOutput
    {
        [TestMethod]
        public void TestIOStringsVariableInput()
        {
            String name = "Raymond";
            String expectedOutput = $@">>Hello, what is your name?
<<{name}
>>Hello {name}!
>>Press any key to continue . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment1.Program.Main);
        }

        [TestMethod]
        public void TestIOStringsSteveInput()
        {
            String expectedOutput = $@">>Hello, what is your name?
<<Steve
>>Hello Steve!
>>Press any key to continue . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment1.Program.Main);
        }

        [TestMethod]
        public void TestIOStringsJessInput()
        {
            String expectedOutput = $@">>Hello, what is your name?
<<Jess
>>Hello Jess!
>>Press any key to continue . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment1.Program.Main);
        }
    }
    
}
