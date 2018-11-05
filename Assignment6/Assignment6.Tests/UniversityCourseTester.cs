using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class UniversityCourseTester
    {
        private readonly int sampleCRN = 11005;
        private readonly string sampleDaysOfWeek = "Sun Mon Tues Weds Thurs Fri Sat";
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
        public void Constructor_ProperSetOfAllValues()
        {
            List<UniversityCourse.Day> validList = new List<UniversityCourse.Day>();
            validList.Add(Enum.Parse<UniversityCourse.Day>("Sun"));
            validList.Add(Enum.Parse<UniversityCourse.Day>("Mon"));
            validList.Add(Enum.Parse<UniversityCourse.Day>("Tues"));
            validList.Add(Enum.Parse<UniversityCourse.Day>("Weds"));
            validList.Add(Enum.Parse<UniversityCourse.Day>("Thurs"));
            validList.Add(Enum.Parse<UniversityCourse.Day>("Fri"));
            validList.Add(Enum.Parse<UniversityCourse.Day>("Sat"));
            
            Assert.AreEqual(sampleCRN, sampleCourse.Crn);
            Assert.IsTrue(validList.SequenceEqual(sampleCourse.CurrentSchedule.DaysOfWeek));
            Assert.AreEqual(sampleQuarter, sampleCourse.CurrentSchedule.GetQuarter());
            Assert.AreEqual(sampleStartingHour, sampleCourse.CurrentSchedule.StartTime.Hour);
            Assert.AreEqual(sampleStartingMinute, sampleCourse.CurrentSchedule.StartTime.Minute);
            Assert.AreEqual(sampleStartingSecond, sampleCourse.CurrentSchedule.StartTime.Second);
            Assert.AreEqual(sampleDurationHours, sampleCourse.CurrentSchedule.Duration.Hours);
            Assert.AreEqual(sampleDurationMinutes, sampleCourse.CurrentSchedule.Duration.Minutes);
            Assert.AreEqual(sampleDurationSeconds, sampleCourse.CurrentSchedule.Duration.Seconds);
        }
        
        [DataTestMethod]
        [DataRow("Sun Sun Mon Tues Weds Thurs Fri Sat")] // same day twice
        [DataRow("Sun Mon Tues Weds Thurs Purple Sat")] // Invalid day
        [DataRow(" ")] // no days
        [ExpectedException(typeof(InvalidDataException))]
        public void SetStructSchedule_InvalidDaysOfWeek_InvalidDataException(string daysOfWeek)
        {
            sampleCourse = new UniversityCourse(sampleCRN, daysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
        }
        
        [DataTestMethod]
        [DataRow("Sun Mon Tues Weds Thurs Fri Sat")] // pass multiple days of week
        [DataRow("Sun")] // pass single day of week
        public void SetStructSchedule_SetDaysOfWeek(string daysOfWeek)
        {
            sampleCourse = new UniversityCourse(sampleCRN, daysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
            
            List<UniversityCourse.Day> validList = new List<UniversityCourse.Day>();
            foreach (string cur in daysOfWeek.Split())
            {
                validList.Add(Enum.Parse<UniversityCourse.Day>(cur));
            }
            
            Assert.IsTrue(validList.SequenceEqual(sampleCourse.CurrentSchedule.DaysOfWeek));
        }
        
        [DataTestMethod]
        [DataRow("SummerMonths")] // Invalid Quarter
        [DataRow(" ")] // No Quarter
        [ExpectedException(typeof(InvalidDataException))]
        public void SetStructSchedule_SetWrongQuarter_InvalidDataException(string setQuarter)
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, setQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
        }
        
        [DataTestMethod]
        [DataRow("Spring")]
        [DataRow("Winter")]
        [DataRow("Summer")]
        [DataRow("Fall")]
        public void SetStructSchedule_SetValidQuarter(string setQuarter)
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, setQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
            
            Assert.AreEqual(setQuarter, sampleCourse.CurrentSchedule.GetQuarter());
        }
        
        [DataTestMethod]
        [DataRow(24, 10, 5)] // hour too high
        [DataRow(-1, 10, 5)] // hour too low
        [DataRow(1, 60, 5)] // minute too high
        [DataRow(1, -1, 5)] // minute too low
        [DataRow(1, 10, 60)] // second too high
        [DataRow(1, 10, -1)] // second too low
        [ExpectedException(typeof(InvalidDataException))]
        public void SetTimeValue_OutOfRangeValues_InvalidDataException(int testHour, int testMinute, int testSecond)
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, testHour, 
                testMinute, testSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
        }
        
        [DataTestMethod]
        [DataRow(23, 10, 5)]
        [DataRow(0, 59, 5)]
        public void SetTimeValue_ValidValues(int testHour, int testMinute, int testSecond)
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, testHour, 
                testMinute, testSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
            
            Assert.AreEqual(testHour, sampleCourse.CurrentSchedule.StartTime.Hour);
            Assert.AreEqual(testMinute, sampleCourse.CurrentSchedule.StartTime.Minute);
            Assert.AreEqual(testSecond, sampleCourse.CurrentSchedule.StartTime.Second);
        }
        
        [DataTestMethod]
        [DataRow(24, 10, 5)] // hour too high
        [DataRow(-1, 10, 5)] // hour too low
        [DataRow(1, 60, 5)] // minute too high
        [DataRow(1, -1, 5)] // minute too low
        [DataRow(1, 10, 60)] // second too high
        [DataRow(1, 10, -1)] // second too low
        [ExpectedException(typeof(InvalidDataException))]
        public void SetTimeSpan_OutOfRangeValues_InvalidDataException(int testHour, int testMinute, int testSecond)
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, testHour, 
                testMinute, testSecond);
        }
        
        [DataTestMethod]
        [DataRow(23, 10, 5)]
        [DataRow(0, 59, 5)]
        public void SetTimeSpan_ValidValues(int testHour, int testMinute, int testSecond)
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, testHour, 
                testMinute, testSecond);
            
            Assert.AreEqual(testHour, sampleCourse.CurrentSchedule.Duration.Hours);
            Assert.AreEqual(testMinute, sampleCourse.CurrentSchedule.Duration.Minutes);
            Assert.AreEqual(testSecond, sampleCourse.CurrentSchedule.Duration.Seconds);
        }
        
        [TestMethod]
        public void TryToChangeReadonlyStruct()
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
            
            // This will not compile
            //sampleCourse.CurrentSchedule = new UniversityCourse.Schedule(sampleDaysOfWeek, sampleQuarter, 
                //sampleStartingHour, sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                //sampleDurationMinutes, sampleDurationSeconds);
        }
          
        [TestMethod]
        public void DailyHoursOfHomeworkExpected_MThroughF_Return10Hours()
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
            
            Assert.AreEqual(9.0, sampleCourse.WeeklyHoursOfHomeworkExpected);
        }
        
        [TestMethod]
        public void GetSummaryInformationTest()
        {
            sampleCourse = new UniversityCourse(sampleCRN, sampleDaysOfWeek, sampleQuarter, sampleStartingHour, 
                sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                sampleDurationMinutes, sampleDurationSeconds);
            String expected = 
@"The course CRN is: 11005
The event starts at 10:0:0
It lasts for 4 hours, 30 minutes, and 0 seconds
It repeats on Sun Mon Tues Weds Thurs Fri Sat
Expect 9 hours of homework each week.";
            Assert.AreEqual(expected, sampleCourse.GetSummaryInformation());
        }
    }
}