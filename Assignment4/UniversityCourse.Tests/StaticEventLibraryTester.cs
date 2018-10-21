using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment4.Tests
{
    [TestClass]
    public class StaticEventLibraryTester
    {
        private static Event @event;
        private static UniversityCourse course;
        [TestInitialize]
        public void Get_Name_Constructed_Success()
        {
            course = new UniversityCourse("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0),
                "CSCD272", "Paul Shimpf", "mwf");

            @event = new Event("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0));
        }


        /*Display*/
        [TestMethod]
        public void Display_Course_Success()
        {
            var output = StaticEventLibrary.Display(course);
            var expectedOutput =
@"Event Name: Android Development
Location: CEB 228
Start Date: 9/18/2018 12:00:00 PM
End Date: 12/10/2018 2:00:00 PM
Course ID: CSCD272
Instructor: Paul Shimpf
Schedule: mwf
Number of Credits: 6";
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void Display_Event_Success()
        {
            var output = StaticEventLibrary.Display(@event);
            var expectedOutput =
@"Event Name: Android Development
Location: CEB 228
Start Date: 9/18/2018 12:00:00 PM
End Date: 12/10/2018 2:00:00 PM";
            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Display_Null_ArgumentNullException()
        {
            var output = StaticEventLibrary.Display(null);
            Assert.Fail();
        }

        [TestMethod]
        public void Display_Object_ArgumentException()
        {
            var myString = "This is my string";
            var output = StaticEventLibrary.Display(myString);
            var expectedOutput = myString;
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
