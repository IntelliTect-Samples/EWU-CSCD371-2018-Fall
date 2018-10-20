using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment4.Tests
{
    [TestClass]
    public class CalendarEventViewerTester
    {
        private Event _myEvent;
        private UniversityCourse _myCourse;
        
        [TestInitialize]
        public void Initialize()
        {
            _myEvent = new Event(new DateTime(2018, 1, 1, 10, 0, 0), new DateTime(2018, 1, 1, 22, 0, 0));
            _myCourse = 
                new UniversityCourse(11005, 
                    new DateTime(2018, 1, 1, 10, 0, 0), 
                    new DateTime(2018, 1, 1, 11, 0, 0),
                    new List<char> {'M', 'T', 'W', 'R', 'F'}
                    );
        }
        
        [TestMethod]
        public void TestDisplay_GivenTypeEvent_GetEventInfo()
        {
            String expected = "The event starts at 10 and ends at 22";
            
            Assert.AreEqual(expected, CalendarEventViewer.Display(_myEvent));
        }
        
        [TestMethod]
        public void TestDisplay_GivenTypeUniversityCourse_GetUniversityCourseInfo()
        {
            String expected = 
@"The course CRN is: 11005
The event starts at 10 and ends at 11
It repeats on M T W R F 
Expect 10 hours of homework each day.";
            Assert.AreEqual(expected, CalendarEventViewer.Display(_myCourse));
        }
        
        [TestMethod]
        public void TestDisplay_GivenInvalidType_InvalidDataException()
        {
            DateTime temporaryObject = new DateTime(2018, 10, 1);
            
            Assert.AreEqual(temporaryObject.ToString(), CalendarEventViewer.Display(temporaryObject));
        }
    }
}