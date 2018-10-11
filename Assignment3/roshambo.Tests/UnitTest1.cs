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
        public void TestCalculateRoundLoserString(string playerOneMove, string playerTwoMove, string expectedWinner)
        {
            (string winner, int healthDeduction) returnVal = Program.CalculateRoundLoser(playerOneMove, playerTwoMove);
            Assert.AreEqual(expectedWinner, returnVal.winner);
        }

        [DataTestMethod]
        [DataRow("paper", "paper", 0)]
        [DataRow("paper", "rock", 10)]
        [DataRow("rock", "scissors", 20)]
        [DataRow("scissors", "paper", 15)]
        public void TestCalculateRoundLoserPoints(string playerOneMove, string playerTwoMove, int expectedPoints)
        {
            (string winner, int healthDeduction) returnVal = Program.CalculateRoundLoser(playerOneMove, playerTwoMove);
            Assert.AreEqual(expectedPoints, returnVal.healthDeduction);
        }
    }
}