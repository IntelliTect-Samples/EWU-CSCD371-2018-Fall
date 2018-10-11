using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace roshambo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("rock", "rock", "tie")]
        [DataRow("rock", "paper", "PlayerTwo")]
        [DataRow("rock", "scissors", "PlayerOne")]
        [DataRow("paper", "rock", "PlayerOne")]
        [DataRow("paper", "scissors", "PlayerTwo")]
        [DataRow("scissors", "paper", "PlayerOne")]
        [DataRow("scissors", "rock", "PlayerTwo")]
        public void TestCalculateRoundLoser(string playerOneMove, string playerTwoMove, string expectedWinner)
        {
            (string winner, int healthDeduction) returnVal = Program.CalculateRoundLoser(playerOneMove, playerTwoMove);
            Assert.AreEqual(expectedWinner, returnVal.winner);
        }
    }
}