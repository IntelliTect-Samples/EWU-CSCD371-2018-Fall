using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMathSolver.Tests
{
    [TestClass]
    public class ConsoleMathSolverHelperTests
    {
        [TestMethod]
        public void TestParseTwoIntegersOneOne()
        {
            const string input = "1+1";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input);
            
            Assert.AreEqual(new List<object> {1, 1}, res);
        }
    }
}