using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace tester
{
    [TestClass]
    public class PlayRoundTest
    {
        [TestMethod]
        public void TestRockVsPaper()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("rock", "paper"); 
            int expected =  -10;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestRockVsScissors()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("rock", "scissors"); 
            int expected =  20;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestRockVsRock()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("rock", "rock"); 
            int expected =  0;
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        public void TestScissorsVsPaper()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("scissors", "paper"); 
            int expected =  15;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestScissorsVsScissors()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("scissors", "scissors"); 
            int expected =  0;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestScissorsVsRock()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("scissors", "rock"); 
            int expected =  -20;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestPaperVsPaper()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("paper", "paper"); 
            int expected =  0;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestPaperVsScissors()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("paper", "scissors"); 
            int expected =  -15;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestPaperVsRock()
        {            
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int result = temp.PlayRound("paper", "rock"); 
            int expected =  10;
            Assert.AreEqual(result, expected);
        }
    }

    [TestClass]
    public class DeclareWinnerTest
    {
        [TestMethod]
        public void TestHumanWin()
        {       
            Ass3.Player human = new Ass3.Player(100);
            human.Score = 100;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 99;
            Ass3.Program temp = new Ass3.Program();
            String result = temp.DeclareWinner(human, ai); 
            String expected =  "User Won the Game!!!";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestHumanLose()
        {       
            Ass3.Player human = new Ass3.Player(99);
            human.Score = 99;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 100;
            Ass3.Program temp = new Ass3.Program();
            String result = temp.DeclareWinner(human, ai); 
            String expected =  "AI Won the Game!!!";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestHumanTie()
        {       
            Ass3.Player human = new Ass3.Player(100);
            human.Score = 100;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 100;
            Ass3.Program temp = new Ass3.Program();
            String result = temp.DeclareWinner(human, ai); 
            String expected =  "The Two Opponents Agreed on a Tie!!!";
            Assert.AreEqual(result, expected);
        }
    }

    [TestClass]
    public class ResetHealthTest
    {
        [TestMethod]
        public void TestResetFullHealth()
        {
            Ass3.Player human = new Ass3.Player(100);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int expected =  human.Health;

            temp.ResetHealth(human, ai); 

            int result = human.Health;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestResetNonFullHealth()
        {
            Ass3.Player human = new Ass3.Player(1);
            Ass3.Player ai = new Ass3.Player(100);
            Ass3.Program temp = new Ass3.Program();
            int expected =  100;

            temp.ResetHealth(human, ai); 

            int result = human.Health;

            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class DealDamageTest
    {
        [TestMethod]
        public void TestDealDamage()
        {       
            Ass3.Player human = new Ass3.Player(100);
            int humanOriHealth = human.Health;
            Ass3.Player ai = new Ass3.Player(100);
            int aiOriHealth = ai.Health;
            Ass3.Program temp = new Ass3.Program();
            temp.DealDamage(15, human, ai); 
            int expectedHumanHealth = 100;
            int expectedAiHealth = 85;
            Assert.AreEqual(expectedHumanHealth, humanOriHealth);
            Assert.AreEqual(expectedAiHealth, ai.Health);
        }

        [TestMethod]
        public void TestRecieveDamage()
        {       
            Ass3.Player human = new Ass3.Player(100);
            int humanOriHealth = human.Health;
            Ass3.Player ai = new Ass3.Player(100);
            int aiOriHealth = ai.Health;
            Ass3.Program temp = new Ass3.Program();
            temp.DealDamage(-15, human, ai); 
            int expectedHumanHealth = 85;
            int expectedAiHealth = 100;
            Assert.AreEqual(expectedHumanHealth, human.Health);
            Assert.AreEqual(expectedAiHealth, aiOriHealth);
        }

        [TestMethod]
        public void TestNoDamage()
        {       
            Ass3.Player human = new Ass3.Player(100);
            int humanOriHealth = human.Health;
            Ass3.Player ai = new Ass3.Player(100);
            int aiOriHealth = ai.Health;
            Ass3.Program temp = new Ass3.Program();
            temp.DealDamage(0, human, ai); 
            int expectedHumanHealth = human.Health;
            int expectedAiHealth = ai.Health;
            Assert.AreEqual(expectedHumanHealth, humanOriHealth);
            Assert.AreEqual(expectedAiHealth, aiOriHealth);
        }
    }

    [TestClass]
    public class GivePointTest
    {
        [TestMethod]
        public void TestUserHealthZero()
        {
            Ass3.Player human = new Ass3.Player(0);
            int humanScore = human.Score;
            Ass3.Player ai = new Ass3.Player(100);
            int aiScore = ai.Score;
            Ass3.Program temp = new Ass3.Program();
            temp.GivePoint(human, ai);
            int actualHumanScore = human.Score;
            int actualAiScore = ai.Score;
            Assert.AreEqual(humanScore, actualHumanScore);
            Assert.AreEqual(aiScore + 1, actualAiScore);
        }

        [TestMethod]
        public void TestAiHealthZero()
        {
            Ass3.Player human = new Ass3.Player(100);
            int humanScore = human.Score;
            Ass3.Player ai = new Ass3.Player(0);
            int aiScore = ai.Score;
            Ass3.Program temp = new Ass3.Program();
            temp.GivePoint(human, ai);
            int actualHumanScore = human.Score;
            int actualAiScore = ai.Score;
            Assert.AreEqual(humanScore + 1, actualHumanScore);
            Assert.AreEqual(aiScore, actualAiScore);
        }

        [TestMethod]
        public void TestUserHealthLessZero()
        {
            Ass3.Player human = new Ass3.Player(-15);
            int humanScore = human.Score;
            Ass3.Player ai = new Ass3.Player(100);
            int aiScore = ai.Score;
            Ass3.Program temp = new Ass3.Program();
            temp.GivePoint(human, ai);
            int actualHumanScore = human.Score;
            int actualAiScore = ai.Score;
            Assert.AreEqual(humanScore, actualHumanScore);
            Assert.AreEqual(aiScore + 1, actualAiScore);
        }

        [TestMethod]
        public void TestAiHealthLessZero()
        {
            Ass3.Player human = new Ass3.Player(100);
            int humanScore = human.Score;
            Ass3.Player ai = new Ass3.Player(-15);
            int aiScore = ai.Score;
            Ass3.Program temp = new Ass3.Program();
            temp.GivePoint(human, ai);
            int actualHumanScore = human.Score;
            int actualAiScore = ai.Score;
            Assert.AreEqual(humanScore + 1, actualHumanScore);
            Assert.AreEqual(aiScore, actualAiScore);
        }

        [TestMethod]
        public void TestBothHealthAboveZero()
        {
            Ass3.Player human = new Ass3.Player(100);
            int humanScore = human.Score;
            Ass3.Player ai = new Ass3.Player(100);
            int aiScore = ai.Score;
            Ass3.Program temp = new Ass3.Program();
            temp.GivePoint(human, ai);
            int actualHumanScore = human.Score;
            int actualAiScore = ai.Score;
            Assert.AreEqual(humanScore, actualHumanScore);
            Assert.AreEqual(aiScore, actualAiScore);
        }
    }

    [TestClass]
    public class BestOutOfTest
    {
        [TestMethod]
        public void UserLeadEqualMin()
        {
            int min = 1, max = 1;
            Ass3.Player human = new Ass3.Player(100);
            human.Score = 1;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 0;
            Ass3.Program temp = new Ass3.Program();
            var result = temp.BestOutOf(min, max, human, ai);
            Assert.AreEqual(min + 1, result.returnMin);
            Assert.AreEqual(max + 2, result.returnMax);
        }

        [TestMethod]
        public void UserLeadGreaterMin()
        {
            int min = 1, max = 1;
            Ass3.Player human = new Ass3.Player(100);
            human.Score = 2;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 0;
            Ass3.Program temp = new Ass3.Program();
            var result = temp.BestOutOf(min, max, human, ai);
            Assert.AreEqual(min + 1, result.returnMin);
            Assert.AreEqual(max + 2, result.returnMax);
        }

        [TestMethod]
        public void AiLeadEqualMin()
        {
            int min = 1, max = 1;
            Ass3.Player human = new Ass3.Player(100);
            human.Score = 0;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 1;
            Ass3.Program temp = new Ass3.Program();
            var result = temp.BestOutOf(min, max, human, ai);
            Assert.AreEqual(min + 1, result.returnMin);
            Assert.AreEqual(max + 2, result.returnMax);
        }

        [TestMethod]
        public void AiLeadGreaterMin()
        {
            int min = 1, max = 1;
            Ass3.Player human = new Ass3.Player(100);
            human.Score = 0;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 2;
            Ass3.Program temp = new Ass3.Program();
            var result = temp.BestOutOf(min, max, human, ai);
            Assert.AreEqual(min + 1, result.returnMin);
            Assert.AreEqual(max + 2, result.returnMax);
        }

        [TestMethod]
        public void NeitherLeadGreaterMin()
        {
            int min = 1, max = 1;
            Ass3.Player human = new Ass3.Player(100);
            human.Score = 0;
            Ass3.Player ai = new Ass3.Player(100);
            ai.Score = 0;
            Ass3.Program temp = new Ass3.Program();
            var result = temp.BestOutOf(min, max, human, ai);
            Assert.AreEqual(min, result.returnMin);
            Assert.AreEqual(max, result.returnMax);
        }
    }
}
