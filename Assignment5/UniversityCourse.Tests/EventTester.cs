using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
/*Properties in Event class are read only
    So to check validation, values are passed to constructor*/
namespace UniversityCourse.Tests
{
    [TestClass]
    public class EventTester
    {


        /*Name*/
        [DataRow("Bake Sale")]
        [DataRow("Interview")]
        [DataRow("Hot Date")]
        [DataRow("Work")]
        [DataTestMethod]
        public void Get_Name_Constructed_Success(string name)
        {
            Event @event = new Event(name, "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.AreEqual(name, @event.Name);
        }

        [DataRow("no")]
        [DataRow("w")]
        [DataRow("654")]
        [DataRow("a")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataTestMethod]
        public void Get_Name_Constructed_ArgumentOutOfRangeException(string name)
        {
            Event @event = new Event(name, "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_Name_Constructed_ArgumentNullException()
        {
            Event @event = new Event(null, "123 N something rd", new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.Fail();
        }


        /*Location*/
        [DataRow("123 N something rd")]
        [DataRow("5 N a st")]
        [DataRow("CEB 301")]
        [DataRow("My House")]
        [DataTestMethod]
        public void Get_Location_Constructed_Success(string location)
        {
            Event @event = new Event("MyEvent", location, new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.AreEqual(location, @event.Location);
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataRow("no")]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_Location_Constructed_ArgumentOutOfRangeException(string location)
        {
            Event @event = new Event("Study Group", location, new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_Location_Constructed_ArgumentNullException()
        {
            Event @event = new Event("Study Group", null, new DateTime(2018, 7, 18, 12, 0, 0, 0), new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.Fail();
        }


        /*Start Date*/
        [TestMethod]
        public void Get_StartDate_Constructed_Success()
        {
            var startDate = new DateTime(2018, 7, 18, 12, 0, 0, 0);
            Event @event = new Event("MyEvent", "CEB301", startDate, new DateTime(2018, 7, 18, 15, 0, 0, 0));
            Assert.AreEqual(startDate, @event.DateStart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_StartDate_Constructed_ArgumentOutOfRangeException()
        {
            var startDate = new DateTime(2019, 7, 18, 12, 0, 0, 0);
            Event @event = new Event("MyEvent", "CEB301", startDate, new DateTime(2018, 7, 18, 15, 0, 0, 0));
        }


        /*End Date*/
        [TestMethod]
        public void Get_EndDate_Constructed_Success()
        {
            var endDate = new DateTime(2019, 7, 18, 12, 0, 0, 0);
            Event @event = new Event("MyEvent", "CEB301", new DateTime(2018, 7, 18, 15, 0, 0, 0), endDate);
            Assert.AreEqual(endDate, @event.DateEnd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_EndDate_Constructed_ArgumentOutOfRangeException()
        {
            var endDate = new DateTime(2010, 7, 18, 12, 0, 0, 0);
            Event @event = new Event("MyEvent", "CEB301", new DateTime(2018, 7, 18, 15, 0, 0, 0), endDate);
        }


        /*Number of Events*/
        [TestMethod]
        public void Get_Number_of_Constructed_Events_Success()
        {
            var numberOfEventsBefore = Event.NumberOfEvents;
            Event @event = new Event("MyEvent", "CEB301", new DateTime(2018, 7, 18, 15, 0, 0, 0), new DateTime(2019, 7, 18, 12, 0, 0, 0));
            Assert.AreEqual(numberOfEventsBefore + 1, Event.NumberOfEvents);
        }


        /*Get Summary Information*/

        [TestMethod]
        public void Get_Summary_Information_Success()
        {
            Event @event = new Event("MyEvent", "CEB301", new DateTime(2018, 7, 18, 15, 0, 0, 0), new DateTime(2019, 7, 18, 12, 0, 0, 0));
            var output = @event.GetSummaryInformation();
            var expectedOutput =
@"Event Name: MyEvent
Location: CEB301
Start Date: 7/18/2018 3:00:00 PM
End Date: 7/18/2019 12:00:00 PM";
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
