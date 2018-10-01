using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMathSolver.Tests
{
    [TestClass]
    public class ConsoleMathSolverHelperTests
    {
        [TestMethod]
        public void ParseOperators_OnePlusOne()
        {
            const string input = "1+1";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_TooManyOperatorsOnePlusOnePlus()
        {
            const string input = "1+1+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input);
            
            Assert.IsNull(res);
        }
        
        [TestMethod]
        public void ParseOperators_TooManyOperatorsPlusOnePlusOne()
        {
            const string input = "+1+1";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input);
            
            Assert.IsNull(res);
        }
        
        [TestMethod]
        public void ParseOperators_EmptyString()
        {
            const string input = "";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input);
            
            Assert.IsNull(res);
        }
        
        [TestMethod]
        public void ParseOperators_OperatorNoNumbers()
        {
            const string input = "+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input);
            
            Assert.IsNull(res);
        }
    }
}