using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace UniversityCourse.Tests
{
    [TestClass]
    public class IsAsDirectCastTests
    {
        [TestMethod]
        public void Test_Direct_Cast_Success()
        {
            UniversityCourse course = new UniversityCourse("Casey", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), 
                new DateTime(2018, 7, 18, 15, 0, 0, 0), "CSCD371", "Mark M", "tr");
            
            Event e = (Event)course;
            if (e is null)
                Assert.Fail();
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Test_Direct_Cast_Fail()
        {
            Event @event = new Event("Casey", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            UniversityCourse u = (UniversityCourse)@event;
            Assert.Fail();

        }
        
        [TestMethod]
        public void Test_Course_Is_Event_True()
        {
            UniversityCourse course = new UniversityCourse("Casey", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), 
                new DateTime(2018, 7, 18, 15, 0, 0, 0), "CSCD371", "Mark M", "tr");
            Assert.IsTrue(course is Event);
        }
        
        [TestMethod]
        public void Test_Event_Is_Coarse_False()
        {
            Event @event = new Event("Casey", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            if (@event is UniversityCourse)
                Assert.Fail();
        }
        
        [TestMethod]
        public void Test_Course_As_Event_True()
        {
            UniversityCourse course = new UniversityCourse("Casey", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), 
                new DateTime(2018, 7, 18, 15, 0, 0, 0), "CSCD371", "Mark M", "tr");

            var e = course as Event;
            if(e == null)
                Assert.Fail();
        }
        
        [TestMethod]
        public void Test_Event_As_Coarse_False()
        {
            Event @event = new Event("Casey", "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            var u = @event as UniversityCourse;
            
            if(u != null)
                Assert.Fail();
        }
        
    }
}
