using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment8.Tests
{
    [TestClass]
    public class TimeManagerTests
    {
        private TestableDateTime DateTimeForTests { get; set; }

        private TimeManager TimeManagerForTests { get; set; }

        private string SetStringOnCompletion { get; set; }

        private TimeEvent SetTimeEventOnTimerStop { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            DateTimeForTests = new TestableDateTime();
        }

        [TestMethod]
        public void TestGetDate_ReturnInputtedDateTime()
        {
            DateTime firstInList = new DateTime(2018, 12, 25);

            DateTimeForTests.DateList = new List<DateTime>()
            {
                firstInList,
                new DateTime(2050, 11, 10)
            };

            Assert.AreEqual(firstInList, DateTimeForTests.GetCurrentTime());
        }

        [TestMethod]
        public void TestCreateTimeManager_EnsureManagerCreated()
        {
            TimeManagerForTests = new TimeManager(PassMethod);

            TimeManagerForTests.TimerStart();
            TimeManagerForTests.TimerStop("");

            Assert.AreEqual("success", SetStringOnCompletion);
        }

        [TestMethod]
        public void TestClockStartAtRightTime_CurrentSystemTimeEqualToTimeManagerTime()
        {
            DateTime beforeTicking = DateTime.Now;

            TimeManagerForTests = new TimeManager(PassMethod);

            Assert.AreEqual(beforeTicking.ToString(@"hh \: mm :\ ss"), TimeManagerForTests.CurrentTime);
        }

        [TestMethod]
        public void TestClockIsTicking_ClockIsEnabledReturnsTrue()
        {
            DateTime beforeTicking = DateTime.Now;

            TimeManagerForTests = new TimeManager(PassMethod);

            Assert.IsTrue(TimeManagerForTests.IsClockEnabled());
        }

        [TestMethod]
        public void TestTimerIsTicking_TimerIsEnabledReturnsTrue()
        {
            DateTime beforeTicking = DateTime.Now;

            TimeManagerForTests = new TimeManager(PassMethod);

            TimeManagerForTests.TimerStart();

            Assert.IsTrue(TimeManagerForTests.IsTimerEnabled());
        }

        [TestMethod]
        public void TestTimerNotTicking_TimerNotTickingBeforeStarted()
        {
            DateTime beforeTicking = DateTime.Now;

            TimeManagerForTests = new TimeManager(PassMethod);

            Assert.IsFalse(TimeManagerForTests.IsTimerEnabled());
        }

        [TestMethod]
        public void TestDescriptionSentToEvent_TimeEventDescriptionSet()
        {
            TimeManagerForTests = new TimeManager(MockPassedEvent);

            TimeManagerForTests.TimerStart();
            TimeManagerForTests.TimerStop("DescriptionSet");

            string setDescription = SetTimeEventOnTimerStop.Description;

            Assert.AreEqual("DescriptionSet", setDescription);
        }

        public void PassMethod(TimeEvent toUse)
        {
            SetStringOnCompletion = "success";
        }

        public void MockPassedEvent(TimeEvent toUse)
        {
            SetTimeEventOnTimerStop = toUse;
        }
    }

    class TestableDateTime : IDateTime
    {
        public List<DateTime> DateList { get; set; }
        public DateTime GetCurrentTime()
        {
            DateTime toReturn = DateList[0];
            DateList.Remove(toReturn);

            return toReturn;
        }
    }
}
