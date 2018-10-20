using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UniversityCourseWork.Tests
{
    [TestClass]
    public class UniversityCourseTests
    {

        [TestMethod]
        public void Course_Schedule_Build_Success()
        {
            UniversityCourse UC = new UniversityCourse();

            Assert.AreEqual("Algebra.Monday.8AM"
            + "Calculus.Tuesday.10AM"
            + "Geometry.Wednesday.11AM"
            + "Statistics.Thursday.2PM", UC.Course_Schedule);
        }

        [TestMethod]
        public void Get_Summary_Success()
        {
            UniversityCourse UC = new UniversityCourse();

            Assert.AreEqual("Algebra.Monday.8AM"
            + "Calculus.Tuesday.10AM"
            + "Geometry.Wednesday.11AM"
            + "Statistics.Thursday.2PM", UC.GetSummaryInformation());
        }

    }
}
