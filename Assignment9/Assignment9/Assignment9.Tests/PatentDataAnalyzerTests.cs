using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class PatentDataAnalyzerTests
    {
        [DataTestMethod]
        [DataRow("USA", 6)]
        [DataRow("UK", 1)]
        [DataRow("SE", 0)]    
        public void Get_Inventor_Name_By_Country_Success(string country, int expectedCount)
        {
            IEnumerable<string> query = PatentDataAnalyzer.GetInventorNames(country);
            int count = 0;
            foreach (var name in query) count++;
            Assert.AreEqual(expectedCount, count);
        }
    }
}