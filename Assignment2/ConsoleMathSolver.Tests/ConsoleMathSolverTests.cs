using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMathSolver.Tests
{
    [TestClass]
    public class ConsoleMathSolverTests
    {
        [TestMethod]
        public void Test1Plus1()
        {
            string testVal = "1+1";
            double expectedAnswer = 2.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void EmptyInput()
        {
            string testVal = "";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void MaxIntPlusMaxInt()
        {
            int firstNumber = int.MaxValue;
            int secondNumber = int.MaxValue;
            string testVal = firstNumber + "+" + secondNumber;
            double expectedAnswer = 4294967294;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void MinIntPlusMinInt()
        {
            int firstNumber = int.MinValue;
            int secondNumber = int.MinValue;
            string testVal = firstNumber + "+" + secondNumber;
            double expectedAnswer = -4294967296;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            string testVal = "1/0";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
    }
}