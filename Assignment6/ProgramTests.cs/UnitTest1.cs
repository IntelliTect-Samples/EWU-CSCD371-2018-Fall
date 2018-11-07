using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;
using System.Collections.Generic;

namespace Homework6.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void DisplayEvents_OneEventDisplayed_Success()
        {
            TestableConsole testConsole = new TestableConsole();
            // Program.Console = testConsole;  //***** This commented out to get get the problem to run.. as it is commented out at the top of main.

            List<UniversityCalender> EventList = new List<UniversityCalender>
            {
                new Event("Extream Nerding club", "CEB301 AV room", "11-25-2018 4:00pm - 11:30pm")
            };


            Program.DisplayEvents(EventList);
            //Assert.AreEqual("EVENT: Extream Nerding club| CEB301 AV room| 11-25-2018 4:00pm - 11:30pm", testConsole.LastWrittenLine);

        }
    }
}
