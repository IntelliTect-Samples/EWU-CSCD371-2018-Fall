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
            string operatorUsed = "+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_NegativeOnePlusNegativeOne()
        {
            const string input = "-1+-1";
            string operatorUsed = "+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {-1, -1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_OneMinusOne()
        {
            const string input = "1-1";
            string operatorUsed = "-";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_OneTimesOne()
        {
            const string input = "1*1";
            string operatorUsed = "*";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        public void ParseOperators_OneDividedByOne()
        {
            const string input = "1/1";
            string operatorUsed = "/";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsTrue(new List<int> {1, 1}.SequenceEqual(res));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseOperators_TooManyOperatorsOnePlusOnePlus()
        {
            const string input = "1+1+";
            string operatorUsed = "+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseOperators_TooManyOperatorsPlusOnePlusOne()
        {
            const string input = "+1+1";
            string operatorUsed = "+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
        }
        
        [TestMethod]
        public void ParseOperators_EmptyString()
        {
            const string input = "";
            string operatorUsed = "+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
            
            Assert.IsNull(res);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseOperators_OperatorNoNumbers()
        {
            const string input = "+";
            string operatorUsed = "+";
            var res = ConsoleMathSolver.ConsoleMathSolverHelper.ParseOperators(input, operatorUsed);
        }
        
        
        
        [TestMethod]
        public void CalculateValue_1Plus1()
        {
            const string input = "1+1";
            int res = ConsoleMathSolver.ConsoleMathSolverHelper.CalculateValue(input);
            
            Assert.AreEqual(2, res);
        }
        
        [TestMethod]
        public void CalculateValue_2Plus1()
        {
            const string input = "2+1";
            int res = ConsoleMathSolver.ConsoleMathSolverHelper.CalculateValue(input);
            
            Assert.AreEqual(3, res);
        }
        
        [TestMethod]
        public void CalculateValue_2Times2()
        {
            const string input = "2*2";
            int res = ConsoleMathSolver.ConsoleMathSolverHelper.CalculateValue(input);
            
            Assert.AreEqual(4, res);
        }
        
        [TestMethod]
        public void CalculateValue_2TimesNegative2()
        {
            const string input = "1*-2";
            int res = ConsoleMathSolver.ConsoleMathSolverHelper.CalculateValue(input);
            
            Assert.AreEqual(-2, res);
        }
        
        [TestMethod]
        public void CalculateValue_Negative2TimesNegative2()
        {
            const string input = "-2*-2";
            int res = ConsoleMathSolver.ConsoleMathSolverHelper.CalculateValue(input);
            
            Assert.AreEqual(4, res);
        }
    }
}