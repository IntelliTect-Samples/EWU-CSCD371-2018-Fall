using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment4.Tests
{
    [TestClass]
    public class UniversityCourseTester
    {
        readonly DateTime _sampleStartingTime = new DateTime(2018, 1, 1, 10, 0, 0);
        readonly DateTime _sampleEndingTime = new DateTime(2018, 1, 1, 22, 0, 0);

        [TestCleanup()]
        public void Cleanup()
        {
            Event.ResetInstanceCount();
        }
        
        [TestMethod]
        public void UniversityCourse_TestConstructor_11005()
        {
            UniversityCourse myCourse = new UniversityCourse(11005, _sampleStartingTime, _sampleEndingTime);
            Assert.AreEqual(11005, myCourse.Crn);
        }
    }
}