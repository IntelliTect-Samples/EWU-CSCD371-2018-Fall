using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class UnitTestName
    {
        [TestMethod]
        public void TestInput()
        {
            string myValue = "Graham";
            string expectedOutput = $@">>Hello, what is your name?
<<{myValue}
>>Hello {myValue}!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloWorld.UserInputName.Main);
        }
    }
}
