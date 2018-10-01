using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMathSolver.Tests
{
    [TestClass]
    public class ConsoleMathSolverHelperTests
    {
        [TestMethod]
        public void ParseOperators_TwoIntegersOneOnePlus()
        {
            const string input = "1+1";
            const char testOperator = '+';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, testOperator);
            
            Assert.AreEqual(new List<int> {1, 1}, res);
        }
    }
}