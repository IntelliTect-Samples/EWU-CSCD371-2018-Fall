using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string myValue = "Graham";
            string expectedOutput = $@">>Hello, what is your name?
<<{myValue}
>>Hello {myValue}!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect("Hello, what is your name?", HelloWorld.Program.Main);
        }
    }
}
