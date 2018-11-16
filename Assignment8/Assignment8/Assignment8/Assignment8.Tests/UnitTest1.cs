using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Threading;

namespace Assignment8.Tests
{
    [TestClass]
    public class TimeManagerTests
    {

        [TestMethod]
        public void Test_5_Seconds_Pass_Success()
        {
            var dates = new List<DateTime> { new DateTime(1, 1, 1, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 1), new DateTime(1, 1, 1, 0, 0, 5) };
            TimeManager timeManager = new TimeManager(new TestableDateTime(dates));
            timeManager.Start();
            Thread.Sleep(100);
  
            timeManager.Stop();

            Assert.AreEqual(dates[dates.Count - 1] - dates[0], timeManager.ElapsedTime);
        }

        private string DateTimeToString(DateTime date)
        {
            return date.ToString("HH:MM:ss");
        }
    }


}