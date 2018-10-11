using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockPaperScissorsTest
{
    [TestClass]
    public class TestInputPlayAgain
    {
        [DataRow("yes")]
        [DataRow("YES")]
        [DataRow("YES   ")]
        [DataTestMethod]
        public void TestPlayAgainYes(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            Assert.IsTrue(RockPaperScissors.RockPaperScissors.PlayAgain());
        }
        
        [DataRow("y")]
        [DataRow("Y")]
        [DataRow("Y   ")]
        [DataTestMethod]
        public void TestPlayAgainY(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            Assert.IsTrue(RockPaperScissors.RockPaperScissors.PlayAgain());
        }
        
        [DataRow("no")]
        [DataRow("NO")]
        [DataRow("NO   ")]
        [DataTestMethod]
        public void TestPlayAgainNo(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            Assert.IsFalse(RockPaperScissors.RockPaperScissors.PlayAgain());
        }
        
        [DataRow("n")]
        [DataRow("N")]
        [DataRow("N   ")]
        [DataTestMethod]
        public void TestPlayAgainN(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn));
            Assert.IsFalse(RockPaperScissors.RockPaperScissors.PlayAgain());
        }
        
        [DataRow("Nothing")]
        [DataRow("but")]
        [DataRow("_incorrect")]
        [DataRow("inputs")]
        [DataTestMethod]
        public void TestPlayAgainInvalidInput(string consoleIn)
        {
            Console.SetIn(new StringReader(consoleIn + "\ny"));                //reprompts till valid input, second string ensure method finishes
            var sw = new StringWriter();
            Console.SetOut(sw);
            RockPaperScissors.RockPaperScissors.PlayAgain();
            Assert.IsTrue(sw.ToString().Contains("Invalid input"));
        }
    }
}