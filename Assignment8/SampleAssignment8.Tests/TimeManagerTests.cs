using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleAssignment8.Tests
{
    [TestClass]
    public class TimeManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_RequiresDateTimeInstance()
        {
            new TimeManager(null);
        }

        [TestMethod]
        public void MarkTime_TogglesRunningToNoRunning()
        {
            //Arrange
            var dateTime = new TestableDateTime();
            var timeManager = new TimeManager(dateTime);

            //Act
            Status firstStatus = timeManager.MarkTime();
            Status secondsStatus = timeManager.MarkTime();

            //Assert
            Assert.AreEqual(Status.Running, firstStatus);
            Assert.AreEqual(Status.NotRunning, secondsStatus);
        }

        [TestMethod]
        public void WhenNotRunning_EventIsRaised()
        {
            //Arrange
            var dateTime = new TestableDateTime();
            var timeManager = new TimeManager(dateTime);
            timeManager.TimeEntryCreated += TimeManagerOnTimeEntryCreated;

            TimeSpan? entry = null;

            //Act
            dateTime.Now = DateTime.Now;
            timeManager.MarkTime();
            dateTime.Now += TimeSpan.FromMinutes(5);
            timeManager.MarkTime();

            //Assert
            Assert.AreEqual(TimeSpan.FromMinutes(5), entry);


            void TimeManagerOnTimeEntryCreated(object sender, TimeEntryCreatedEventArgs e)
            {
                entry = e.Duration;
            }
        }
        
    }
}
