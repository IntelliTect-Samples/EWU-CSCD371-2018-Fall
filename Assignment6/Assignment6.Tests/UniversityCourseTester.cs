using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class UniversityCourseTester
    {
        private readonly int _sampleCrn = 11005;
        private readonly string _sampleDaysOfWeek = "Sunday Monday Tuesday Wednesday Thursday Friday Saturday";
        private readonly string _sampleQuarter = "Spring";
        private readonly byte _sampleStartingHour = 10;
        private readonly byte _sampleStartingMinute = 0;
        private readonly byte _sampleStartingSecond = 0;
        private readonly int _sampleDurationHours = 4;
        private readonly int _sampleDurationMinutes = 30;
        private readonly int _sampleDurationSeconds = 0;

        private UniversityCourse _sampleCourse;
        
        [TestInitialize]
        public void Initialize()
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
        }

        [TestMethod]
        public void Constructor_ProperSetOfAllValues()
        {   
            Assert.AreEqual(_sampleCrn, _sampleCourse.Crn);
            
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Sunday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Monday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Tuesday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Wednesday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Thursday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Friday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Saturday));
            
            Assert.AreEqual(_sampleQuarter, GetQuarter(_sampleCourse));
            Assert.AreEqual(_sampleStartingHour, _sampleCourse.CurrentSchedule.StartTime.Hour);
            Assert.AreEqual(_sampleStartingMinute, _sampleCourse.CurrentSchedule.StartTime.Minute);
            Assert.AreEqual(_sampleStartingSecond, _sampleCourse.CurrentSchedule.StartTime.Second);
            Assert.AreEqual(_sampleDurationHours, _sampleCourse.CurrentSchedule.Duration.Hours);
            Assert.AreEqual(_sampleDurationMinutes, _sampleCourse.CurrentSchedule.Duration.Minutes);
            Assert.AreEqual(_sampleDurationSeconds, _sampleCourse.CurrentSchedule.Duration.Seconds);
        }

        [TestMethod]
        public void ScheduleStruct_CheckLessThan16Bytes()
        {
            Assert.IsTrue(16 > Marshal.SizeOf(_sampleCourse.CurrentSchedule));
        }
        
        [TestMethod]
        public void TimeValueStruct_CheckLessThan16Bytes()
        {
            Assert.IsTrue(16 > Marshal.SizeOf(_sampleCourse.CurrentSchedule.StartTime));
        }

        [DataTestMethod]
        [DataRow("Sunday Monday Tuesday Wednesday Thursday Purple Saturday")] // Invalid day
        [DataRow(" ")] // no days
        [ExpectedException(typeof(InvalidDataException))]
        public void SetStructSchedule_InvalidDaysOfWeek_InvalidDataException(string classDays)
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, classDays, _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
        }
        
        [TestMethod]
        public void SetStructSchedule_SetMultipleDaysOfWeek()
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, "Sunday Monday Tuesday Wednesday Thursday Friday Saturday",
                _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Sunday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Monday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Tuesday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Wednesday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Thursday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Friday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Saturday));
        }
        
        [TestMethod]
        public void SetStructSchedule_PassSameDayTwice()
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, "Sunday Sunday Monday Tuesday Wednesday Thursday Friday Saturday", _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Sunday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Monday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Tuesday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Wednesday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Thursday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Friday));
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Saturday));
        }
        
        [TestMethod]
        public void SetStructSchedule_PassSingleDaysOfWeek()
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, "Sunday", _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            
            Assert.IsTrue(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Sunday));
            Assert.IsFalse(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Monday));
            Assert.IsFalse(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Tuesday));
            Assert.IsFalse(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Wednesday));
            Assert.IsFalse(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Thursday));
            Assert.IsFalse(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Friday));
            Assert.IsFalse(_sampleCourse.CurrentSchedule.ClassDays.HasFlag(UniversityCourse.DaysOfWeek.Saturday));
        }
        
        [DataTestMethod]
        [DataRow("SummerMonths")] // Invalid Quarter
        [DataRow(" ")] // No Quarter
        [ExpectedException(typeof(InvalidDataException))]
        public void SetStructSchedule_SetWrongQuarter_InvalidDataException(string setQuarter)
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, setQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
        }
        
        [DataTestMethod]
        [DataRow("Spring")]
        [DataRow("Winter")]
        [DataRow("Summer")]
        [DataRow("Fall")]
        public void SetStructSchedule_SetValidQuarter(string setQuarter)
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, setQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            
            Assert.AreEqual(setQuarter, GetQuarter(_sampleCourse));
        }
        
        [DataTestMethod]
        [DataRow((byte)24, (byte)10, (byte)5)]
        [DataRow((byte)1, (byte)60, (byte)5)]
        [DataRow((byte)1, (byte)10, (byte)60)]
        [ExpectedException(typeof(InvalidDataException))]
        public void SetTimeValue_OutOfRangeValues_InvalidDataException(byte testHour, byte testMinute, byte testSecond)
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, testHour, 
                testMinute, testSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
        }
        
        [DataTestMethod]
        [DataRow((byte)23, (byte)10, (byte)5)]
        [DataRow((byte)0, (byte)59, (byte)5)]
        public void SetTimeValue_ValidValues(byte testHour, byte testMinute, byte testSecond)
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, testHour, 
                testMinute, testSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            
            Assert.AreEqual(testHour, _sampleCourse.CurrentSchedule.StartTime.Hour);
            Assert.AreEqual(testMinute, _sampleCourse.CurrentSchedule.StartTime.Minute);
            Assert.AreEqual(testSecond, _sampleCourse.CurrentSchedule.StartTime.Second);
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
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, testHour, 
                testMinute, testSecond);
        }
        
        [DataTestMethod]
        [DataRow(23, 10, 5)]
        [DataRow(0, 59, 5)]
        public void SetTimeSpan_ValidValues(int testHour, int testMinute, int testSecond)
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, testHour, 
                testMinute, testSecond);
            
            Assert.AreEqual(testHour, _sampleCourse.CurrentSchedule.Duration.Hours);
            Assert.AreEqual(testMinute, _sampleCourse.CurrentSchedule.Duration.Minutes);
            Assert.AreEqual(testSecond, _sampleCourse.CurrentSchedule.Duration.Seconds);
        }
        
        [TestMethod]
        public void TryToChangeReadonlyStruct()
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            
            // This will not compile
            //sampleCourse.CurrentSchedule = new UniversityCourse.Schedule(sampleDaysOfWeek, sampleQuarter, 
                //sampleStartingHour, sampleStartingMinute, sampleStartingSecond, sampleDurationHours, 
                //sampleDurationMinutes, sampleDurationSeconds);
        }
          
        [TestMethod]
        public void DailyHoursOfHomeworkExpected_MThroughF_Return10Hours()
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            
            Assert.AreEqual(9.0, _sampleCourse.WeeklyHoursOfHomeworkExpected);
        }
        
        [TestMethod]
        public void GetSummaryInformationTest()
        {
            _sampleCourse = new UniversityCourse(_sampleCrn, _sampleDaysOfWeek, _sampleQuarter, _sampleStartingHour, 
                _sampleStartingMinute, _sampleStartingSecond, _sampleDurationHours, 
                _sampleDurationMinutes, _sampleDurationSeconds);
            String expected = 
@"The course CRN is: 11005
The course starts at 10:0:0
It is during Spring quarter
It lasts for 4 hours, 30 minutes, and 0 seconds
It repeats on Sunday Monday Tuesday Wednesday Thursday Friday Saturday
Expect 9 hours of homework each week.";
            Assert.AreEqual(expected, _sampleCourse.GetSummaryInformation());
        }

        public static string GetQuarter(UniversityCourse toUse)
        {
            return toUse.CurrentSchedule.Quarter.ToString();
        }
    }
}