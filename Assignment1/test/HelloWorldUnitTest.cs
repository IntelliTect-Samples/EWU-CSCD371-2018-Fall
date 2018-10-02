using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldTest
{
    [TestClass]
    public class HelloWorldUnitTest
    {
        [TestMethod]
        public void TestHelloWorldSuceed()
        {
            var name = "Joe";
            var expectedOutput =
$@">>Hello, what is your name?
<<{name}
>>Hello {name}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloWorld.HelloWorld.Main);
        }
    }

}