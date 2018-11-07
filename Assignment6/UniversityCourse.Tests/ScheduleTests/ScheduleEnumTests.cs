using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityCourse.Scheduling;

namespace UniversityCourse.Tests.ScheduleTests
{
    [TestClass]
    public class ScheduleEnumTests
    {
        [DataRow("Monday", DaysOfTheWeek.Monday)]
        [DataRow("Wednesday", DaysOfTheWeek.Wednesday)]
        [DataRow("Friday", DaysOfTheWeek.Friday)]
        [DataRow("Saturday", DaysOfTheWeek.Saturday)]
        [DataTestMethod]
        public void Parse_Single_Day_Success(string dayInput, DaysOfTheWeek expectedDay)
        {
            Enum.TryParse(dayInput, out DaysOfTheWeek day);
            Assert.IsTrue(day.HasFlag(expectedDay));
        }
        
        [DataRow("Wednesday", DaysOfTheWeek.Monday)]
        [DataRow("Monday", DaysOfTheWeek.Wednesday)]
        [DataRow("Saturday", DaysOfTheWeek.Friday)]
        [DataRow("Friday", DaysOfTheWeek.Saturday)]
        [DataTestMethod]
        public void Parse_Single_Day_Incorrect_Expected_Failure(string dayInput, DaysOfTheWeek expectedDay)
        {
            Enum.TryParse(dayInput, out DaysOfTheWeek day);
            Assert.IsFalse(day.HasFlag(expectedDay));
        }
        
        [DataRow("Monday, Wednesday", DaysOfTheWeek.Monday | DaysOfTheWeek.Wednesday)]
        [DataRow("Wednesday, Thursday, Friday", DaysOfTheWeek.Wednesday | DaysOfTheWeek.Thursday | DaysOfTheWeek.Friday)]
        [DataRow("Friday, Sunday", DaysOfTheWeek.Friday | DaysOfTheWeek.Sunday)]
        [DataRow("Saturday, Monday, Thursday", DaysOfTheWeek.Saturday | DaysOfTheWeek.Monday | DaysOfTheWeek.Thursday)]
        [DataRow("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday",
            DaysOfTheWeek.Monday | DaysOfTheWeek.Tuesday | DaysOfTheWeek.Wednesday | DaysOfTheWeek.Thursday |
            DaysOfTheWeek.Friday | DaysOfTheWeek.Saturday | DaysOfTheWeek.Sunday)]
        [DataTestMethod]
        public void Parse_Multiple_Days_Success(string dayInput, DaysOfTheWeek expectedDay)
        {
            Enum.TryParse(dayInput, out DaysOfTheWeek day);
            Assert.IsTrue(day.HasFlag(expectedDay));
        }
        
        [DataRow("Fall", Quarter.Fall)]
        [DataRow("Winter", Quarter.Winter)]
        [DataRow("Spring", Quarter.Spring)]
        [DataRow("Summer", Quarter.Summer)]
        [DataTestMethod]
        public void Parse_Single_Quarter_Success(string quarterInput, Quarter expectedQuarter)
        {
            Enum.TryParse(quarterInput, out Quarter quarter);
            Assert.IsTrue(quarter.HasFlag(expectedQuarter));
        }
        
        [DataRow("Fall", Quarter.Winter)]
        [DataRow("Winter", Quarter.Spring)]
        [DataRow("Spring", Quarter.Summer)]
        [DataRow("Summer", Quarter.Fall)]
        [DataTestMethod]
        public void Parse_Single_Quarter_Incorrect_Expected_Failure(string quarterInput, Quarter expectedQuarter)
        {
            Enum.TryParse(quarterInput, out Quarter quarter);
            Assert.IsFalse(quarter.HasFlag(expectedQuarter));
        }
    }
}