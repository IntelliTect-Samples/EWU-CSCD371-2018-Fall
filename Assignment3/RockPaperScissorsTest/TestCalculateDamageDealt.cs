using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockPaperScissorsTest
{

    /*
     * CalculateDamageDealt method returns:
     * 20 for rock win
     * 10 for paper win
     * 15 for scissors win
     * 0 for draw
     * these values are negative if cpu wins, positive if user wins
     */
    [TestClass]
    public class TestCalculateDamageDealt
    {
        //user wins
        
        [TestMethod]
        public void TestUserBeatsCpuWithRock()
        {
            Assert.AreEqual(20, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("rock", "scissors")));
        }
        
        [TestMethod]
        public void TestUserBeatsCpuWithPaper()
        {
            Assert.AreEqual(10, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("paper", "rock")));
        }
        
        [TestMethod]
        public void TestUserBeatsCpuWithScissors()
        {
            Assert.AreEqual(15, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("scissors", "paper")));
        }
        
        //cpu wins
        
        [TestMethod]
        public void TestCpuBeatsUserWithRock()
        {
            Assert.AreEqual(-20, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("scissors", "rock")));
        }
        
        [TestMethod]
        public void TestCpuBeatsUserWithPaper()
        {
            Assert.AreEqual(-10, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("rock", "paper")));
        }
        
        [TestMethod]
        public void TestCpuBeatsUserWithScissors()
        {
            Assert.AreEqual(-15, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("paper", "scissors")));
        }
        
        //draw
        
        [TestMethod]
        public void TestDrawRock()
        {
            Assert.AreEqual(0, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("rock", "rock")));
        }
        
        [TestMethod]
        public void TestDrawPaper()
        {
            Assert.AreEqual(0, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("paper", "paper")));
        }
        
        [TestMethod]
        public void TestDrawScissors()
        {
            Assert.AreEqual(0, RockPaperScissors.RockPaperScissors.CalculateDamageDealt(("scissors", "scissors")));
        }
    }

}