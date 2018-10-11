using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockPaperScissorsTest
{
    
    [TestClass]
    public class TestInputGetUserMove
    {

        [DataRow("rock")]
        [DataRow("ROCK")]
        [DataRow("ROCK   ")]
        [DataTestMethod]
        public void TestGetUserMoveRock(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            var strReturned = RockPaperScissors.RockPaperScissors.GetUserMove();
            Assert.AreEqual("rock", strReturned);
        }
        
        [DataRow("r")]
        [DataRow("R")]
        [DataRow("R   ")]
        [DataTestMethod]
        public void TestGetUserMoveR(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            var strReturned = RockPaperScissors.RockPaperScissors.GetUserMove();
            Assert.AreEqual("rock", strReturned);
        }
        
        [DataRow("paper")]
        [DataRow("PAPER")]
        [DataRow("PAPER   ")]
        [DataTestMethod]
        public void TestGetUserMovePaper(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            var strReturned = RockPaperScissors.RockPaperScissors.GetUserMove();
            Assert.AreEqual("paper", strReturned);
        }
        
        [DataRow("p")]
        [DataRow("P")]
        [DataRow("P   ")]
        [DataTestMethod]
        public void TestGetUserMoveP(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            var strReturned = RockPaperScissors.RockPaperScissors.GetUserMove();
            Assert.AreEqual("paper", strReturned);
        }
        
        [DataRow("scissors")]
        [DataRow("SCISSORS")]
        [DataRow("SCISSORS   ")]
        [DataTestMethod]
        public void TestGetUserMoveScissors(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            var strReturned = RockPaperScissors.RockPaperScissors.GetUserMove();
            Assert.AreEqual("scissors", strReturned);
        }
        
        [DataRow("s")]
        [DataRow("S")]
        [DataRow("S   ")]
        [DataTestMethod]
        public void TestGetUserMoveS(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            var strReturned = RockPaperScissors.RockPaperScissors.GetUserMove();
            Assert.AreEqual("scissors", strReturned);
        }
        
        [DataRow("Nothing")]
        [DataRow("but")]
        [DataRow("_incorrect")]
        [DataRow("inputs")]
        [DataTestMethod]
        public void TestGetUserMoveInvalidInput(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn + "\nrock"));                //reprompts till valid input, second string ensure method finishes
            var sw = new StringWriter();
            Console.SetOut(sw);
            RockPaperScissors.RockPaperScissors.GetUserMove();
            Assert.IsTrue(sw.ToString().Contains("Invalid input"));
        }
    }
}