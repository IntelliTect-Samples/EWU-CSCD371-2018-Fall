using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class IEventMethodsTest
    {
        private DateTime _startingTime;
        private DateTime _endingTime;
        private IEvent _sampleEvent;

        [TestInitialize]
        public void Initialize()
        {
            _startingTime = CreateDateTimeAtHour(10);
            _endingTime = CreateDateTimeAtHour(22);
            _sampleEvent = new Event(_startingTime, _endingTime);
        }
        
        [DataTestMethod]
        [DataRow(10)]
        [DataRow(1)]
        [DataRow(5)]
        public void GetStartingHour_ReturnAppropriateTime(int startingHour)
        {
            RewriteEventToStartingHour(startingHour);
            
            Assert.AreEqual(startingHour, _sampleEvent.GetStartingHour());
        }
        
        [DataTestMethod]
        [DataRow(23)]
        [DataRow(22)]
        [DataRow(21)]
        public void GetEndingHour_ReturnAppropriateTime(int endingHour)
        {
            RewriteEventToEndingHour(endingHour);
            
            Assert.AreEqual(endingHour, _sampleEvent.GetEndingHour());
        }
        
        private void RewriteEventToStartingHour(int startingHour)
        {
            _startingTime = CreateDateTimeAtHour(startingHour);
            _sampleEvent = new Event(_startingTime, _endingTime);
        }

        private void RewriteEventToEndingHour(int endingHour)
        {
            _endingTime = CreateDateTimeAtHour(endingHour);
            _sampleEvent = new Event(_startingTime, _endingTime);
        }
        
        // helper method for testing
        private DateTime CreateDateTimeAtHour(int hourToSet)
        {
            return new DateTime(2018, 1, 1, hourToSet, 0, 0);
        }
    }
}