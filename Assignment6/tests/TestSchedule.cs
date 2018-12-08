using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment6;
using System.Runtime.InteropServices;
namespace tests
{
    [TestClass]
    public class TestSchedule
    {
        private Schedule _TestingSchedule
        {
            get;
            set;
        }

        [TestInitialize]
        public void SetupSchedule()
        {
            Days day = Days.Monday;
            Quarters quarter = Quarters.Fall;
            Time time = new Time(3,21,22);
            TimeSpan timeSpan = new TimeSpan(0,21,00);
            _TestingSchedule = new Schedule(day,quarter, time, timeSpan);
        }

        [TestMethod]
        public void StructureLessThan16ByteTestValid()
        {
            Assert.IsTrue(Marshal.SizeOf(_TestingSchedule) <= 16);
            //could get down to 24 byte, not 16 byte
            //I undestand bitwise operator as shown in lecture is possible solution,
            //but when attempting I was getting incorrecto valuess for enum
        }

        [TestMethod]
        [DataRow("Friday", Days.Friday)]
        [DataRow("Saturday", Days.Saturday)]
        public void ParseDayTestValid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Days>(input, out Days day);
            Assert.IsTrue(day.HasFlag(expectedFlag));

        }

        [TestMethod]
        [DataRow("Sunday, Monday", Days.Sunday | Days.Monday)]
        [DataRow("Tuesday, Wednesday, Thursday", Days.Wednesday | Days.Tuesday | Days.Thursday)]
        public void ParseMultipleDayTestValid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Days>(input, out Days day);
            Assert.IsTrue(day.HasFlag(expectedFlag));
        }

        [TestMethod]
        [DataRow("Friday", Days.Saturday)]
        [DataRow("Saturday", Days.Friday)]
        public void ParseDayTestInvalid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Days>(input, out Days day);
            Assert.IsFalse(day.HasFlag(expectedFlag));

        }

        [TestMethod]
        [DataRow("Sunday, Monday", Days.Friday | Days.Tuesday)]
        [DataRow("Tuesday, Wednesday, Thursday", Days.Monday | Days.Friday | Days.Thursday)]
        public void ParseMultipleDayTestInvalid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Days>(input, out Days day);
            Assert.IsFalse(day.HasFlag(expectedFlag));
        }


        [TestMethod]
        [DataRow("Summer", Quarters.Summer)]
        [DataRow("Fall", Quarters.Fall)]
        public void ParseQuarterTestValid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Quarters>(input, out Quarters outputQuarter);
            Assert.IsTrue(outputQuarter.HasFlag(expectedFlag));
        }

        [TestMethod]
        [DataRow("Winter, Spring", Quarters.Winter | Quarters.Spring)]
        [DataRow("Summer, Fall, Winter", Quarters.Summer | Quarters.Fall | Quarters.Winter)]
        public void ParseMultipleQuarterTestValid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Quarters>(input, out Quarters outputQuarter);
            Assert.IsTrue(outputQuarter.HasFlag(expectedFlag));
        }

        [TestMethod]
        [DataRow("Fall", Quarters.Summer)]
        [DataRow("Summer", Quarters.Fall)]
        public void ParseQuarterTestInvalid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Quarters>(input, out Quarters outputQuarter);
            Assert.IsFalse(outputQuarter.HasFlag(expectedFlag));
        }

        [TestMethod]
        [DataRow("Winter, Spring", Quarters.Fall | Quarters.Summer)]
        [DataRow("Summer, Fall, Winter", Quarters.Spring)]
        public void ParseMultipleQuarterTestInvalid(string input, Enum expectedFlag)
        {
            Enum.TryParse<Quarters>(input, out Quarters outputQuarter);
            Assert.IsFalse(outputQuarter.HasFlag(expectedFlag));
        }
    }
}
