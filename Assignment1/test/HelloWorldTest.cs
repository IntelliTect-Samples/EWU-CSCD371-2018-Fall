using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.tests
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("Pizza")]
        [DataRow("Emphatic")]
        [DataRow("Octothorpe")]
        [DataRow("Malleable")]
        [DataRow("Nuanced")]
        public void TestMethod1(string inputStr)
        {
            string expectedOutput = $@">>What is your favorite word: <<{inputStr}
                >>Your favorite word is {inputStr}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, global::HelloWorld.HelloWorld.Main);
        }
    }



}
