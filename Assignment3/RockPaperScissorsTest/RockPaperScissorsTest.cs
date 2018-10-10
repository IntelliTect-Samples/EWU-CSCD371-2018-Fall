using IntelliTect.TestTools.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockPaperScissorsTest
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void TestGetUserMoveRock()
        {
            var expectedOutput = @">>Three. Two. One. Shoot!: <<rock";
            ConsoleAssert.Expect(expectedOutput, RockPaperScissors.RockPaperScissors.GetUserMove);
        }
    }
}