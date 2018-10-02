using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloConsole.Tests
{
    [TestClass]
    public class ConsoleGreetingTest
    {
        [TestMethod]
        public void TestInitialGreeting()
        {
            // test with male response - add branch w female later
            string firstName = "Alfred";
            string lastName = "Newman";
            string expectedOutput = $@">>Hello from your friendly neighborhood console!
>>What is your first name?
<<{firstName}
>>Thanks {firstName}! What is your last name?
<<{lastName}
>>Excellent! Greetings to you, Sir {firstName} {lastName}!
>>I hope this day finds you well and productive.";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloConsole.Greeting.Main);
        }
    }
}
