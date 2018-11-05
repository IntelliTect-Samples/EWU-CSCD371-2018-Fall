using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class TestsUsingIsAsDirectCast
    {
        private DateTime _startingTime;
        private DateTime _endingTime;
        private Event _sampleEvent;
        private UniversityCourse _sampleCourse;
        private readonly List<char> _sampleCourseDays = new List<char> {'M', 'T', 'W', 'R', 'F'}; 

        [TestInitialize]
        public void Initialize()
        {
            _startingTime = CreateDateTimeAtHour(10);
            _endingTime = CreateDateTimeAtHour(22);
            _sampleEvent = new Event(_startingTime, _endingTime);
            _sampleCourse = new UniversityCourse(1115, _startingTime, _endingTime, _sampleCourseDays);
        }
        
        [TestMethod]
        public void Test_AsCast_SuperclassToSubclass()
        {
            Event castedEvent = _sampleCourse as Event;
            
            Assert.AreNotEqual(null, castedEvent);
        }
        
        [TestMethod]
        public void Test_AsCast_SubclassToSuperclass()
        {
            UniversityCourse castedCourse = _sampleEvent as UniversityCourse;
            
            Assert.AreEqual(null, castedCourse);
        }
        
        [TestMethod]
        public void Test_IsCast_True()
        {
            Assert.IsTrue(_sampleCourse is Event);
        }
        
        [TestMethod]
        public void Test_IsCast_False()
        {
            Assert.IsFalse(_sampleEvent is UniversityCourse);
        }
        
        [TestMethod]
        public void Test_DirectCast_SuperclassCastToSubclass()
        {
            // NOTE: Test will pass if exception not thrown, no Assert necessary

            Event subClass = (Event) _sampleCourse;
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Test_DirectCast_SubclassCastToSuperclass()
        {
            UniversityCourse superclass = (UniversityCourse) _sampleEvent;
        }
        
        // helper method for testing
        private DateTime CreateDateTimeAtHour(int hourToSet)
        {
            return new DateTime(2018, 1, 1, hourToSet, 0, 0);
        }
    }
}