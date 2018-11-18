using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace Assignment8.Tests
{
    /// <summary>
    /// Note I could not figure out a way to test the TimeManager class 
    /// DispatcherTimer runs on another thread which makes it difficult to test because it depends on CPU timing
    /// </summary>
    [TestClass]
    public class TimeManagerTests
    {

        [TestMethod]
        public void Test_5_Seconds_Pass_Success()
        {
            var dates = new List<DateTime> { new DateTime(1, 1, 1, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 1), new DateTime(1, 1, 1, 0, 0, 5) };
            var testableDateTime = new TestableDateTime(dates);
            TimeManager timeManager = new TimeManager(new TestableDateTime(dates));

            timeManager.Start();

            timeManager.Stop();

            Assert.AreEqual(dates[dates.Count - 1] - dates[0], timeManager.ElapsedTime);

        }
    }
}