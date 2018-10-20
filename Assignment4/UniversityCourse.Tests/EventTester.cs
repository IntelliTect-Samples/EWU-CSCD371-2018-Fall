using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment4.Tests
{
    [TestClass]
    public class EventTester
    {
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
        }

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

        [TestMethod]
        public void Get_EndDate_Success()
        {
        }
    }
}
