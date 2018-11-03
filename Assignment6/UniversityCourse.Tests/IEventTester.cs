using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace UniversityCourse.Tests
{
    [TestClass]
    public class IEventTester
    {
        [TestMethod]
        public void Test_IEvent_Get_Name_Event_Success()
        {
            Event @event = new Event("My Party", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.AreEqual("My Party", @event.GetName());
        }
        
        [TestMethod]
        public void Test_IEvent_Get_Name_Event_Failure()
        {
            Event @event = new Event("My Party", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.AreNotEqual("Not my Party", @event.GetName());
        }
        
        [TestMethod]
        public void Test_IEvent_Get_Name_Course_Success()
        {
            var course = new UniversityCourse("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0),
                "CSCD272", "Paul Shimpf", "mwf");
            Assert.AreEqual("Android Development", course.GetName());
        }
        
        [TestMethod]
        public void Test_IEvent_Get_Name_Course_Failure()
        {
            var course = new UniversityCourse("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0),
                "CSCD272", "Paul Shimpf", "mwf");
            Assert.AreNotEqual("Web Application Development", course.GetName());
        }
        
        [TestMethod]
        public void Test_Event_Is_IEvent_Success()
        {
            Event @event = new Event("My Party", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            if(!(@event is IEvent))
                Assert.Fail();
        }
        
        [TestMethod]
        public void Test_UniverityCourse_Is_IEvent_Success()
        {
            var course = new UniversityCourse("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0),
                "CSCD272", "Paul Shimpf", "mwf");
            if(!(course is IEvent))
                Assert.Fail();
        }
        
        [TestMethod]
        public void Test_UniverityCourse_Extension_Method_Success()
        {
            var course = new UniversityCourse("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0),
                "CSCD272", "Paul Shimpf", "mwf");

           Assert.AreEqual(2, course.GetLength());
        }
        
        [TestMethod]
        public void Test_UniverityCourse_Extension_Method_Failure()
        {
            var course = new UniversityCourse("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 15, 0, 0, 0),
                "CSCD272", "Paul Shimpf", "mwf");

            Assert.AreNotEqual(2, course.GetLength());
        }
    }
}
