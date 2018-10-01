using System;
using System.Collections.Generic;
using System.IO;
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
            char operatorUsed = '+';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_OneMinusOne()
        {
            const string input = "1-1";
            char operatorUsed = '-';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_OneTimesOne()
        {
            const string input = "1*1";
            char operatorUsed = '*';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_OneDividedByOne()
        {
            const string input = "1/1";
            char operatorUsed = '/';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseOperators_TooManyOperatorsOnePlusOnePlus()
        {
            const string input = "1+1+";
            char operatorUsed = '+';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseOperators_TooManyOperatorsPlusOnePlusOne()
        {
            const string input = "+1+1";
            char operatorUsed = '+';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
        }
        
        [TestMethod]
        public void ParseOperators_EmptyString()
        {
            const string input = "";
            char operatorUsed = '+';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsNull(res);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseOperators_OperatorNoNumbers()
        {
            const string input = "+";
            char operatorUsed = '+';
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
        }
        
        
        
        [TestMethod]
        public void CalculateValue_List1Plus1()
        {
            List<int> testArr = new List<int> {1, 1};
            int res = ConsoleMathSolver.ConsoleMathSolverHelper.CalculateValue(testArr);
            
            Assert.AreEqual(2, res);
        }
    }
}