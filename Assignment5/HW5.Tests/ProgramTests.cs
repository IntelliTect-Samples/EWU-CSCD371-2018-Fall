using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW5;
using System;
using System.Collections.Generic;

namespace HW5.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void DisplayEvents_OneEventDisplayed_Success()
        {
            TestableConsole testConsole = new TestableConsole();
            //var MyProgram = new Program();            
            Program.Console = testConsole;

            List<UniversityCalender> EventList = new List<UniversityCalender>
            {
                new Event("Extream Nerding club", "CEB301 AV room", "11-25-2018 4:00pm - 11:30pm")
            };

                       
            Program.DisplayEvents(EventList);            
            Assert.AreEqual("EVENT: Extream Nerding club| CEB301 AV room| 11-25-2018 4:00pm - 11:30pm", testConsole.LastWrittenLine);

        }
    }
}
