using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class EventTester
    {
        readonly DateTime _sampleStartingTime = new DateTime(2018, 1, 1, 10, 0, 0);
        readonly DateTime _sampleEndingTime = new DateTime(2018, 1, 1, 22, 0, 0);
        
        [TestInitialize]
        public void ResetNumberOfInstances()
        {
            Event.ResetInstanceCount();
        }
        
        [TestMethod]
        public void Constructor_TestCountInstances_Equals3()
        {
            Event myEvent = new Event(new DateTime(2017), new DateTime(2018));
            Event myCourse = new Event(_sampleStartingTime, _sampleEndingTime);
            Event myCourse2 = new Event(_sampleStartingTime, _sampleEndingTime);
            
            Assert.AreEqual(3, Event.EventCount);
        }

        [TestMethod]
        public void Constructor_TestSetDateTime_10to22()
        {  
            Event myEvent = new Event(_sampleStartingTime, _sampleEndingTime);
            
            Assert.AreEqual((_sampleStartingTime, _sampleEndingTime), myEvent.TimeRange);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Constructor_EndTimeBeforeStartTime_InvalidDataException()
        {  
            Event myEvent = new Event(_sampleEndingTime, _sampleStartingTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Constructor_StartDayNotEqualToEndDay_InvalidDataException()
        {
            DateTime timeOne = new DateTime(2018, 10, 10);
            DateTime timeTwo = new DateTime(2018, 10, 11);
            
            Event myEvent = new Event(timeOne, timeTwo);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Constructor_StartMonthNotEqualToEndMonth_InvalidDataException()
        {
            DateTime timeOne = new DateTime(2018, 10, 10);
            DateTime timeTwo = new DateTime(2019, 10, 10);
            
            Event myEvent = new Event(timeOne, timeTwo);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Constructor_StartYearNotEqualToEndYear_InvalidDataException()
        {
            DateTime timeOne = new DateTime(2018, 10, 10);
            DateTime timeTwo = new DateTime(2019, 10, 10);
            
            Event myEvent = new Event(timeOne, timeTwo);
        }

        [TestMethod]
        public void GetSummaryInformation_ValidData()
        {
            string expectedResult = $"The event starts at {_sampleStartingTime.Hour} and ends at {_sampleEndingTime.Hour}";
            
            Event myEvent = new Event(_sampleStartingTime, _sampleEndingTime);
            
            Assert.AreEqual(expectedResult, myEvent.GetSummaryInformation());
        }

        [TestMethod]
        public void TestDestructor_ReductionInNumberOfInstances()
        {
            Event myEvent = new Event(_sampleStartingTime, _sampleEndingTime);
            
            myEvent.Deconstruct();
            Assert.AreEqual(0, Event.EventCount);
        }
    }
}