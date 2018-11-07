using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityCourse.Scheduling ;

namespace UniversityCourse.Tests.ScheduleTests
{
    [TestClass]
    public class ScheduleStructTests
    {
        private Schedule MySchedule { get; set; }
        private Time MyTime { get; set; }

        [TestInitialize]
        public void Initialize_Struct()
        {
            MyTime = new Time(10, 0, 0);
            MySchedule = new Schedule(DaysOfTheWeek.Monday | DaysOfTheWeek.Wednesday | DaysOfTheWeek.Friday,
                Quarter.Fall, MyTime, new TimeSpan(1, 0, 0));
        }

        [TestMethod]
        public void Ensure_Time_Under_16_Bytes_Success()
        {
            var size = Marshal.SizeOf(MyTime);
            Assert.IsTrue(size <= 16);
        }
        
        [TestMethod]
        public void Ensure_Schedule_Under_16_Bytes_Success()
        {
            var size = Marshal.SizeOf(MySchedule);
            Assert.AreEqual(16, size);
        }
    }
}