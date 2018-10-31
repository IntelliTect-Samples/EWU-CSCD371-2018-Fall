using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    [TestClass]
    public class IEventTest
    {
        [TestMethod]
        public void TestValid_ValidEventIsIEvent()
        {
            Assignment5.Event temp = new Assignment5.Event(3,4,".Net");
            Assert.IsTrue(temp is Assignment5.IEvent);
        }

        [TestMethod]
        public void TestValid_ValidCourseIsIEvent()
        {
            Assignment5.Course temp = new Assignment5.Course("Math385", "Math", 201, 32, 1, 2);
            Assert.IsTrue(temp is Assignment5.IEvent);
        }

        [TestMethod]
        public void TestValid_ValidEventAsIEvent()
        {
            Assignment5.Event temp = new Assignment5.Event(2,4,"Tutoring");
            Assignment5.IEvent iTemp = temp as Assignment5.IEvent;
            Assert.IsTrue(iTemp is Assignment5.IEvent);
        }

        [TestMethod]
        public void TestValid_ValidCourseAsIEvent()
        {
            Assignment5.Course temp = new Assignment5.Course("biol172", "bio", 401, 32, 1, 2);
            Assignment5.IEvent iTemp = temp as Assignment5.IEvent;
            Assert.IsTrue(iTemp is Assignment5.IEvent);
        }

        [TestMethod]
        public void TestValid_ValidCourseCastToEventIsCourse()
        {
            Assignment5.Course temp = new Assignment5.Course("biol172", "bio", 401, 32, 1, 2);
            Assignment5.Event iTemp = (Assignment5.Event) temp;
            Assert.IsTrue(iTemp is Assignment5.Course);
        }

        [TestMethod]
        public void TestValid_ValidIEventGetEventCastToEventIsEvent()
        {
            Assignment5.IEvent temp = new Assignment5.Event(2,4,"Tutoring");
            Assignment5.Event iTemp = (Assignment5.Event) temp;
            Assert.IsTrue(iTemp is Assignment5.Event);
        }
    }
}