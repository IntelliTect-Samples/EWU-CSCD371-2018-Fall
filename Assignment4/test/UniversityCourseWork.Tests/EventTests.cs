using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourseWork.Tests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void Event_Schedule_Build_Success()
        {
            Event EV = new Event();

            Assert.AreEqual("ColumbusDay.Monday.11AM"
           + "Thanksgiving.Thursday.2PM"
           + "Christmas.Wednesday.10AM"
           + "Easter.Sunday.8AM", EV.Event_Schedule);
        }

        [TestMethod]
        public void Get_Summary_Success()
        {
            Event EV = new Event();

            Assert.AreEqual("ColumbusDay.Monday.11AM"
           + "Thanksgiving.Thursday.2PM"
           + "Christmas.Wednesday.10AM"
           + "Easter.Sunday.8AM", EV.GetSummaryInformation());
        }
    }
}
