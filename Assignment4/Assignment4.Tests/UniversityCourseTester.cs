using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment4.Tests
{
    [TestClass]
    public class UniversityCourseTester
    {
        readonly DateTime _sampleStartingTime = new DateTime(2018, 1, 1, 10, 0, 0);
        readonly DateTime _sampleEndingTime = new DateTime(2018, 1, 1, 11, 0, 0);
        private List<char> _sampleCourseDays = new List<char> {'M', 'T', 'W', 'R', 'F'}; 
        
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
          Assert.AreEqual(10, myCourse.DailyHoursOfHomeworkExpected);
        }
        
        [TestMethod]
        public void GetSummaryInformationTest()
        {
            UniversityCourse myCourse = 
                new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime, _sampleCourseDays);
            /*String expected = $"The course CRN is: 10005\n" +
                              $"The event starts at {_sampleStartingTime.Hour} and ends at {_sampleEndingTime.Hour}\n" +
                              $" It repeats on M T W T F \n" +
                              $"Expect 10 hours of homework each day.";*/
            String expected = 
@"The course CRN is: 11005
The event starts at 10 and ends at 11
It repeats on M T W R F 
Expect 10 hours of homework each day.";
            Assert.AreEqual(expected, myCourse.GetSummaryInformation());
        }
    }
}