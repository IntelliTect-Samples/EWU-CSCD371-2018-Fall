using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment4.Tests
{
    [TestClass]
    public class EventTester
    {
        readonly DateTime _sampleStartingTime = new DateTime(2018, 1, 1, 10, 0, 0);
        readonly DateTime _sampleEndingTime = new DateTime(2018, 1, 1, 22, 0, 0);

        [TestCleanup()]
        public void Cleanup()
        {
            Event.ResetInstanceCount();
        }
        
        [TestMethod]
        public void Constructor_TestCountInstances_Equals3()
        {
            Event myEvent = new Event(new DateTime(2017), new DateTime(2018));
            UniversityCourse myCourse = new UniversityCourse(11002, _sampleStartingTime, _sampleEndingTime);
            UniversityCourse myCourse2 = new UniversityCourse(11003, _sampleStartingTime, _sampleEndingTime);
            
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
    }
}