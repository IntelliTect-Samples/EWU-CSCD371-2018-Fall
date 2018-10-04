using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMathSolver.Tests
{
    [TestClass]
    public class StringTests
    {
        // remove
        // trim
        // ends with
        [TestMethod]
        [DataRow("someinsidething", "something", "inside", 4)]
        [DataRow("therehing", "thing", "here", 1)]
        [DataRow("setfirst", "first", "set", 0)]
        [DataRow("lastset", "last", "set", 4)]
        public void TestStringInsert(string expected, string toInsertInto, string insertThis, int atIndex)
        {
            Assert.AreEqual(expected, toInsertInto.Insert(atIndex, insertThis));
        }
        
                
        [TestMethod]
        [DataRow("some", "something", 4)]
        [DataRow("", "something", 0)]
        [DataRow("something", "something", 9)]
        [DataRow("fin", "finito", 3)]
        public void TestStringInsert(string expected, string toRemoveFrom, int atIndex)
        {
            Assert.AreEqual(expected, toRemoveFrom.Remove(atIndex));
        }
    }
}