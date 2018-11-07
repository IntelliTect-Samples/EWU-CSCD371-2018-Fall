using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntelliTect.TestTools.Console;
using static UniversityCourse.Scheduler;

namespace UniversityCourse.Tests
{
    [TestClass]
    public class SchedulerTests
    {
        public Time NewTime { get; private set; }
        public Schedule TestSchedule { get; private set; }
        public Schedule TestSchedule2 { get; private set; }

        [TestInitialize]
        public void Test_Initialize()
        {
            NewTime = new Time(12, 30, 0);
            TestSchedule = new Schedule("tuesday", "fall", NewTime, new TimeSpan(0, 12, 30, 0));
            TestSchedule2 = new Schedule("tuesday thursday friday", "winter", NewTime, new TimeSpan(0, 8, 0, 0));
        }
       
        [TestMethod]
        public void Test_Size_Schedule()
        {
            int structSize = Marshal.SizeOf(TestSchedule);
            bool rightSize = structSize <= 16;
            Console.WriteLine(structSize);
            Assert.IsTrue(rightSize);
        }
        [TestMethod]
        public void Test_Size_Time()
        {
            int structSize = Marshal.SizeOf(NewTime);
            bool rightSize = structSize <= 16;
            Console.WriteLine(structSize);
            Assert.IsTrue(rightSize);
        }

        [TestMethod]
        public void Test_Valid_Single_Day()
        {
            Assert.AreEqual("tuesday", TestSchedule.DayOfWeek.ToString().ToLower());
        }

        [TestMethod]
        public void Test_Valid_Multiple_Days()
        {
            Assert.AreEqual("tuesday, thursday, friday", TestSchedule2.DayOfWeek.ToString().ToLower());

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Invalid_Days()
        {
            Schedule testScheduleError = new Schedule("cows", "fall", NewTime, new TimeSpan(0, 12, 30, 0));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Valid_Invalid_Term()
        {
            Schedule testScheduleError = new Schedule("monday", "not-fall", NewTime, new TimeSpan(0, 12, 30, 0));
            Assert.AreEqual("tuesday, thursday, friday", TestSchedule2.DayOfWeek.ToString().ToLower());

        }
    }
}