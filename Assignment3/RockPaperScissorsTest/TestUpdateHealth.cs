using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockPaperScissorsTest
{
    //public static (int userHealth, int computerHealth) UpdateHealth((string userMove, string computerMove) roundMoves ,int damageDealt, (int userHealth, int computerHealth) playersHealth)
    
    [TestClass]
    public class TestUpdateHealth
    {
        [DataRow(100,100)]
        [DataRow(30,85)]
        [DataRow(55,30)]
        [DataTestMethod]
        public void TestUpdateHealthUserBeatsCpuWithRock(int initialUserHealth, int initialCpuHealth)
        {
            var initialPlayersHealth = (initialUserHealth, initialCpuHealth);
            var returnedHealth = RockPaperScissors.RockPaperScissors.UpdateHealth(("rock", "scissors"), 20, initialPlayersHealth);
            Assert.AreEqual(initialUserHealth, returnedHealth.userHealth);
            Assert.AreEqual(initialCpuHealth -20, returnedHealth.cpuHealth);
        }
        
        [DataRow(100,100)]
        [DataRow(30,85)]
        [DataRow(55,30)]
        [DataTestMethod]
        public void TestUpdateHealthUserBeatsCpuWithPaper(int initialUserHealth, int initialCpuHealth)
        {
            var initialPlayersHealth = (initialUserHealth, initialCpuHealth);
            var returnedHealth = RockPaperScissors.RockPaperScissors.UpdateHealth(("paper", "rock"), 10, initialPlayersHealth);
            Assert.AreEqual(initialUserHealth, returnedHealth.userHealth);
            Assert.AreEqual(initialCpuHealth -10, returnedHealth.cpuHealth);
        }
        
        [DataRow(100,100)]
        [DataRow(30,85)]
        [DataRow(55,30)]
        [DataTestMethod]
        public void TestUpdateHealthUserBeatsCpuWithScissors(int initialUserHealth, int initialCpuHealth)
        {
            var initialPlayersHealth = (initialUserHealth, initialCpuHealth);
            var returnedHealth = RockPaperScissors.RockPaperScissors.UpdateHealth(("scissors", "paper"), 15, initialPlayersHealth);
            Assert.AreEqual(initialUserHealth, returnedHealth.userHealth);
            Assert.AreEqual(initialCpuHealth -15, returnedHealth.cpuHealth);
        }
        
        
        
        [DataRow(100,100)]
        [DataRow(30,85)]
        [DataRow(55,30)]
        [DataTestMethod]
        public void TestUpdateHealthCpuBeatsUserWithRock(int initialUserHealth, int initialCpuHealth)
        {
            var initialPlayersHealth = (initialUserHealth, initialCpuHealth);
            var returnedHealth = RockPaperScissors.RockPaperScissors.UpdateHealth(("scissors", "rock"), -20, initialPlayersHealth);
            Assert.AreEqual(initialUserHealth -20, returnedHealth.userHealth);
            Assert.AreEqual(initialCpuHealth, returnedHealth.cpuHealth);
        }
        
        [DataRow(100,100)]
        [DataRow(30,85)]
        [DataRow(55,30)]
        [DataTestMethod]
        public void TestUpdateHealthCpuBeatsUserWithPaper(int initialUserHealth, int initialCpuHealth)
        {
            var initialPlayersHealth = (initialUserHealth, initialCpuHealth);
            var returnedHealth = RockPaperScissors.RockPaperScissors.UpdateHealth(("rock", "paper"), -10, initialPlayersHealth);
            Assert.AreEqual(initialUserHealth -10, returnedHealth.userHealth);
            Assert.AreEqual(initialCpuHealth, returnedHealth.cpuHealth);
        }
        
        [DataRow(100,100)]
        [DataRow(30,85)]
        [DataRow(55,30)]
        [DataTestMethod]
        public void TestUpdateHealthCpuBeatsUserWithScissors(int initialUserHealth, int initialCpuHealth)
        {
            var initialPlayersHealth = (initialUserHealth, initialCpuHealth);
            var returnedHealth = RockPaperScissors.RockPaperScissors.UpdateHealth(("paper", "scissors"), -15, initialPlayersHealth);
            Assert.AreEqual(initialUserHealth -15, returnedHealth.userHealth);
            Assert.AreEqual(initialCpuHealth, returnedHealth.cpuHealth);
        }
    }
}