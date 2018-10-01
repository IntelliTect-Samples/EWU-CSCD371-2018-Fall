using System;
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
            string expectedOutput =
$@"Please enter expression: <<{testVal}
>>Value is: {2}";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, ConsoleMathSolver.Program.Main);
        }
    }
}