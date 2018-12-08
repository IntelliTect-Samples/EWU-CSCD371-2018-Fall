using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests
{
    [TestClass]
    public class TestEventExtension
    {        
        private static Assignment5.Course MyCourse { get; set; }

        [TestInitialize]
        public void SetupUnivCourse()
        {
            MyCourse = new Assignment5.Course("Computer Science", ".net", 208, 21, 2, 4);
            MyCourse.resetCourseTotal();
        }


        [TestMethod]
        public void TestOutput_LengthOfCourse()
        {
            Assert.AreEqual(2, Assignment5.EventExtension.timeLengthOfEvent(MyCourse));
        }
    }
}