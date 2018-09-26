using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class TestHelloWorldInOut
    {
        [TestMethod]
        public void TestConsoleUsingEmptyString()
        {
            string testVal = "";
            string expectedOutput =
$@"Please enter your first name: <<{testVal}
>>Your name is: {testVal}";

            IntelliTect.TestTools.Console.ConsoleAssert.
                Expect(expectedOutput, HelloWorld.Program.Main);
        }

        [TestMethod]
        public void TestConsoleUsingStringCameron()
        {
            string testVal = "Cameron";
            string expectedOutput =
$@"Please enter your first name: <<{testVal}
>>Your name is: {testVal}";

            IntelliTect.TestTools.Console.ConsoleAssert.
                Expect(expectedOutput, HelloWorld.Program.Main);
        }
    }
}
