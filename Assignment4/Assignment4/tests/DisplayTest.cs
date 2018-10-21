using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment4.DisplayClass;

namespace tests
{
    [TestClass]
    public class TestDisplay
    {

        private static Assignment4.Course Course { get; set; }
        private static Assignment4.Event Event {get; set;}

        
        [TestInitialize]
        public void SetUp()
        {
            Course = new Assignment4.Course("Science", "Biology", 231, 24, 3, 4);
            Event = new Assignment4.Event(2, 4, ".Net");
        }

        [TestMethod]
        public void TestValid_DisplayReturn()
        {
            Assert.AreEqual(Display(Event), Event.GetSummaryInformation());
        }

        [TestMethod]
        public void TestValid_Display()
        {
            Assert.AreEqual(Display(Course), Course.GetSummaryInformation());
        }

        [TestMethod]
        [DataRow(12.55)]
        [DataRow("someString")]
        public void TestValid_SummaryAndToString(object e)
        {
            Assert.AreEqual(e.ToString(), Display(e));
        }


        [TestMethod]
        public void TestValid_SummaryList()
        {
            StringBuilder expected = new StringBuilder();
            expected.Append(Event.GetSummaryInformation());
            expected.Append(Course.GetSummaryInformation());

            List<Assignment4.Event> actual = new List<Assignment4.Event>();
            actual.Add(Event);
            actual.Add(Course);
            Assert.AreEqual(expected.ToString(), DisplayList(actual));
        }
    }
}
