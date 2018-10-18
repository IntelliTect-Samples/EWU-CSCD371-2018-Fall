using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment4.Tests
{
    [TestClass]
    public class EventTester
    {
        [TestMethod]
        public void Constructor_TestCountInstances_Equals3()
        {
            Event myEvent = new Event();
            UniversityCourse myCourse = new UniversityCourse();
            UniversityCourse myCourse2 = new UniversityCourse();
            
            Assert.AreEqual(3, Event.courseCount);
        }
    }
}