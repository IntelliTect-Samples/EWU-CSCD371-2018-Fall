using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoshamboTests
{
    [TestClass]
    public class UnitTestsRoshambo
    {
        [TestMethod]
        public void TestUserInputRock()
        {
            string userInput = "rock";
            string expectedOutput = $@">>\nSelect your move (Rock/Paper/Scissors)\n-->
<<{userInput}
>>\n";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Roshambo.Roshambo.userMoveChoice, "rock");
        }
    }
}
