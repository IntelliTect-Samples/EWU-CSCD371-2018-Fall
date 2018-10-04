using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMathSolver.Tests
{
    [TestClass]
    public class ConsoleMathSolverTests
    {
        [TestMethod]
        public void ImproperNumberOfOperatorsSideBySide()
        {
            string testVal = "1++1";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>String not properly operator delimited.";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void ImproperNumberOfOperatorsExtraAtFront()
        {
            string testVal = "+1+1";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>String not properly operator delimited.";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }

        [TestMethod]
        public void ImproperNumberOfOperatorsExtraAtBack()
        {
            string testVal = "1+1+";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>String not properly operator delimited.";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }

        [TestMethod]
        public void EmptyInput()
        {
            string testVal = "";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Input cannot be empty!";

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
        public void DivideByZero()
        {
            string testVal = "1/0";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Cannot divide by 0!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void FourteenPlusOneThousandFortySix()
        {
            string testVal = "14+1046";
            double expectedAnswer = 1060;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositivePlusPositive()
        {
            string testVal = "1+1";
            double expectedAnswer = 2.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativePlusPositive()
        {
            string testVal = "-1+1";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositivePlusNegative()
        {
            string testVal = "1+-1";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativePlusNegative()
        {
            string testVal = "-1+-1";
            double expectedAnswer = -2.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositiveMinusPositive()
        {
            string testVal = "1-1";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativeMinusPositive()
        {
            string testVal = "-1-1";
            double expectedAnswer = -2.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositiveMinusNegative()
        {
            string testVal = "1+-1";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativeMinusNegative()
        {
            string testVal = "-1--1";
            double expectedAnswer = 0.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositiveTimesPositive()
        {
            string testVal = "2*2";
            double expectedAnswer = 4.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativeTimesPositive()
        {
            string testVal = "-2*2";
            double expectedAnswer = -4.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositiveTimesNegative()
        {
            string testVal = "2*-2";
            double expectedAnswer = -4.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativeTimesNegative()
        {
            string testVal = "-2*-2";
            double expectedAnswer = 4.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositiveDividedByPositive()
        {
            string testVal = "2/2";
            double expectedAnswer = 1.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativeDividedByPositive()
        {
            string testVal = "-2/2";
            double expectedAnswer = -1.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void PositiveDividedByNegative()
        {
            string testVal = "2/-2";
            double expectedAnswer = -1.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
        
        [TestMethod]
        public void NegativeDividedByNegative()
        {
            string testVal = "-2/-2";
            double expectedAnswer = 1.0;
            string expectedOutput =
$@"Please enter expression in form <integer><operator><integer>: <<{testVal}
>>Value is: {expectedAnswer}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
    }
}