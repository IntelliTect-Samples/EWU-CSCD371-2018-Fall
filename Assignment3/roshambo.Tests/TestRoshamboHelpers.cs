using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace roshambo.Tests
{
    [TestClass]
    public class TestRoshamboHelpers
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

        [TestMethod]
        public void TestPromptPlayerAgain_y()
        {
            string userInput = "y";
            
            var saveStdin = Console.In;
            
            var newInput = new StringReader(userInput);
            Console.SetIn(newInput);

            bool result = Program.DoesUserWantToPlayAgain();
            
            Console.SetIn(saveStdin);
            
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void TestPromptPlayerAgain_n()
        {
            string userInput = "n";
            
            var saveStdin = Console.In;
            
            var newInput = new StringReader(userInput);
            Console.SetIn(newInput);

            bool result = Program.DoesUserWantToPlayAgain();
            
            Console.SetIn(saveStdin);
            
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestPromptPlayerAgain_InvalidInput()
        {
            string userInput = "something else";
            
            var saveStdin = Console.In;
            
            var newInput = new StringReader(userInput);
            Console.SetIn(newInput);

            bool result = Program.DoesUserWantToPlayAgain();
            
            Console.SetIn(saveStdin);
            
            Assert.IsFalse(result);
        }
    }
}