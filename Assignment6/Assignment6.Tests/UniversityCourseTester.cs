using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class UniversityCourseTester
    {
        // int crn, string daysOfWeek, string quarter, int startingHour, 
        //int startingMinute, int startingSecond, int durationHours, int durationMinutes, int durationSeconds

        private readonly int sampleCRN = 11005;
        private readonly string sampleDaysOfWeek = "Mon Tues Weds Thurs Fri Sat Sun";
        private readonly string sampleQuarter = "Spring";
        private readonly int sampleStartingHour = 10;
        private readonly int sampleStartingMinute = 0;
        private readonly int sampleStartingSecond = 0;
        private readonly int sampleDurationHours = 4;
        private readonly int sampleDurationMinutes = 30;
        private readonly int sampleDurationSeconds = 0;

        private UniversityCourse sampleCourse;
        
        [TestInitialize]
        public void Initialize()
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
        }
        
        [TestMethod]
        public void Constructor_SetValidValuesCRNStartTimeEndTimeDaysOfWeek()
        {
            UniversityCourse myCourse = 
                new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime, _sampleCourseDays);
            
            Assert.AreEqual(11005, myCourse.Crn);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Constructor_DaysOfWeekTooManyDays_InvalidDataException()
        {
            List<char> courseDays = new List<char> {'M', 'T', 'W', 'R', 'F', 'F'};
            UniversityCourse myCourse = 
                new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime, courseDays);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Constructor_NoDays_InvalidDataException()
        {
            List<char> courseDays = new List<char> {};
            UniversityCourse myCourse = 
                new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime, courseDays);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Constructor_InvalidDayOfWeek_InvalidDataException()
        {
            List<char> courseDays = new List<char> {'Q', 'T', 'W', 'R', 'F',};
            UniversityCourse myCourse = 
                new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime, courseDays);
        }
        
        [TestMethod]
        public void DailyHoursOfHomeworkExpected_MThroughF_Return10Hours()
        {
          UniversityCourse myCourse = 
              new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime, _sampleCourseDays);
          Assert.AreEqual(2, myCourse.DailyHoursOfHomeworkExpected);
        }
        
        [TestMethod]
        public void GetSummaryInformationTest()
        {
            UniversityCourse myCourse = 
                new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime, _sampleCourseDays);
            String expected = 
@"The course CRN is: 11005
The event starts at 10 and ends at 11
It repeats on M T W R F 
Expect 2 hours of homework each day.";
            Assert.AreEqual(expected, myCourse.GetSummaryInformation());
        }
    }
}