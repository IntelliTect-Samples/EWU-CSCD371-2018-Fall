using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assignment8.Tests
{
    [TestClass]
    public class TestableDateTimeTests
    {
        [TestMethod]
        public void Test_TestableDateTime_OneDate_Success()
        {
            var dates = new List<DateTime> { new DateTime(1, 1, 1, 0, 0, 0)};
            var testableDateTime = new TestableDateTime(dates);
            Assert.AreEqual(dates[0], testableDateTime.Now());
        }

        [TestMethod]
        public void Test_TestableDateTime_ThreeDates_Success()
        {
            var dates = new List<DateTime> { new DateTime(1, 1, 1, 0, 0, 0),
                new DateTime(1, 1, 1, 0, 0, 1), new DateTime(1, 1, 1, 0, 0, 5) };
            var testableDateTime = new TestableDateTime(dates);
            var i = 0;
            while (i < dates.Count)
                Assert.AreEqual(dates[i++], testableDateTime.Now());
        }

        [TestMethod]
        public void Test_TestableDateTime_FiveDates_Success()
        {
            var dates = new List<DateTime> { new DateTime(1, 1, 1, 0, 0, 0),
                new DateTime(1, 1, 1, 0, 0, 1), new DateTime(1, 1, 1, 0, 0, 5),
                new DateTime(9, 9, 9, 10, 30, 0), new DateTime(2018, 11, 17, 4, 3, 0)};
            var testableDateTime = new TestableDateTime(dates);
            var i = 0;
            while (i < dates.Count)
                Assert.AreEqual(dates[i++], testableDateTime.Now());
        }
    }
}
