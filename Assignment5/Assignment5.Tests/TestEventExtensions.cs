using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class TestEventExtensions
    {

        [DataTestMethod]
        [DataRow(10, 22, 12)]
        [DataRow(10, 20, 10)]
        [DataRow(10, 11, 1)]
        public void GetHourRangeOfEvent_EnsureCorrectHourRangeReturned
            (int startingHour, int endingHour, int expectedDifference)
        {
            DateTime startingTime = CreateDateTimeAtHour(startingHour);
            DateTime endingTime = CreateDateTimeAtHour(endingHour);
            Event sampleEvent = new Event(startingTime, endingTime);
            
            Assert.AreEqual(expectedDifference, sampleEvent.GetHourRangeOfEvent());
        }

        // helper method for testing
        private DateTime CreateDateTimeAtHour(int hourToSet)
        {
            return new DateTime(2018, 1, 1, hourToSet, 0, 0);
        }
    }
}