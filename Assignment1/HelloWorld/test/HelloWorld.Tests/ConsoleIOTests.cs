using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ConsoleIOTests
    {
        [TestMethod]
        public void TestInputCaesar()
        {
            string sampleInput = "Caesar";
            string expectedOutput = $@">>Hello, please enter your name: <<{sampleInput}
            >>Hello, {sampleInput}!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloWorld.Program.Main);
        }

        [TestMethod]
        public void TestInputTesla()
        {
            string sampleInput = "Tesla";
            string expectedOutput = $@">>Hello, please enter your name: <<{sampleInput}
            >>Hello, {sampleInput}!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloWorld.Program.Main);
        }

        [TestMethod]
        public void TestInputFullName()
        {
            string sampleInput = "Bryan Caesar";
            string expectedOutput = $@">>Hello, please enter your name: <<{sampleInput}
            >>Hello, {sampleInput}!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloWorld.Program.Main);
        }
    }
}
