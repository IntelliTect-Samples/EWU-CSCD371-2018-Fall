using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2.Tests
{
    [TestClass]
    public class TestEdgeCases
    {
        [TestMethod]
        public void TestNoSymbolCase()
        {
            string expectedOuput = $@">>Please enter a calculation to perform: <<58493
>>ERROR - Please include an operator (+, -, *, /) in your input
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }
    }
}
