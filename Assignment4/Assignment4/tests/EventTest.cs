using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    [TestClass]
    public class Test
    {
        private static Assignment4.Event Event { get; set; }

        [TestInitialize]
        public void SetupUnivCourse()
        {
            Event = new Assignment4.Event(3, 4, ".Net");
        }

        [TestMethod]
        public void TestValid_ReturnsValue()
        {
            Assignment4.Event temp = new Assignment4.Event(3,4,".Net");
            Assert.AreEqual(".Net", temp.Title);
        }

        [TestMethod]
        public void TestValid_TitleUpdated()
        {
            Event.Title = "P.E.";
            Assert.AreEqual("P.E.", Event.Title);
        }

        [TestMethod]
        public void TestValid_Title()
        {
            Event = new Assignment4.Event(3,4, "data structures");
            Console.WriteLine(Event.Title);
            Assert.AreEqual("data structures", Event.Title);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("        ")]
        public void TestInvalid_NoTitle(string input)
        {
            Event = new Assignment4.Event(2,3, input);
            Assert.AreEqual("No Title", Event.Title);
        }

        [TestMethod]
        public void TestValid_EventTime()
        {
            Event = new Assignment4.Event(22, 23, "math");
            Assert.AreEqual(22, Event.StartHour);
            Assert.AreEqual(23, Event.EndHour);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestInvalid_EventTime()
        {
            Event = new Assignment4.Event(22, 24, "woodshop");
            Assert.Fail();
        }

        [TestMethod]
        public void TestValid_IncrementValue()
        {
            int count = Event.EventNum;
            Event = new Assignment4.Event(5, 7, "english");
            Assert.AreEqual(count + 1, Event.EventNum);
        }

        [TestMethod]
        public void TestValid_Deconstruct()
        {
            int tempStartHour = 4;
            int tempEndHour = 3;
            String tempTitle = "School";
            Event.Deconstruct(out tempStartHour, out tempEndHour, out tempTitle);
            Assert.AreEqual(tempStartHour, Event.StartHour);
            Assert.AreEqual(tempEndHour, Event.EndHour);
            Assert.AreEqual(tempTitle, Event.Title);
        }

        [TestMethod]
        public void TestValid_SummaryOutput()
        {
            Assert.AreEqual(
                 $@"Title    : {Event.Title}{Environment.NewLine}
                         Start Hour: {Event.StartHour}{Environment.NewLine}
                         End Hour  : {Event.EndHour}{Environment.NewLine}",
                Event.GetSummaryInformation());

        }
    }
}
