using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockPaperScissorsTest
{

    [TestClass]
    public class TestIsGameOver
    {
        [DataRow(100,100)]
        [DataRow(30,85)]
        [DataRow(55,30)]
        [DataTestMethod]
        public void TestIsGameOverFalse(int initialUserHealth, int initialCpuHealth)
        {
            Assert.IsFalse(RockPaperScissors.RockPaperScissors.IsGameOver((initialUserHealth, initialCpuHealth)));
        }
        
        [DataRow(100,0)]
        [DataRow(5,0)]
        [DataRow(55,0)]
        [DataTestMethod]
        public void TestIsGameOverTrueCpuLost(int initialUserHealth, int initialCpuHealth)
        {
            Assert.IsTrue(RockPaperScissors.RockPaperScissors.IsGameOver((initialUserHealth, initialCpuHealth)));
        }
        
        [DataRow(0,55)]
        [DataRow(0,85)]
        [DataRow(0,10)]
        [DataTestMethod]
        public void TestIsGameOverTrueUserLost(int initialUserHealth, int initialCpuHealth)
        {
            Assert.IsTrue(RockPaperScissors.RockPaperScissors.IsGameOver((initialUserHealth, initialCpuHealth)));
        }
    }
}