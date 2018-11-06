using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    // NOTE: only methods without while(true) loops are tested
    [TestClass]
    public class TestProgram
    {

        [TestMethod]
        public void TestProgramMain_ValidData()
        {
            string expected =
@"Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: <<1
>>
Enter year: <<2018
>>
Enter month: <<10
>>
Enter day: <<10
>>
Enter starting hour: <<10
>>
Enter ending hour: <<12
>>
Event created!
Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: <<2
>>
Enter crn: <<11005
>>
Enter days of week (Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday) separated by spaces (I.E: Monday Tuesday Wednesday): <<Tuesday Thursday
>>
Enter school quarter, value values: (Spring, Winter, Fall, Summer): <<Spring
>>
Enter starting hour (0-23): <<2
>>
Enter starting minute (0-59): <<0
>>
Enter starting second (0-59): <<0
>>
Enter duration hours (0-23): <<2
>>
Enter duration minutes (0-59): <<30
>>
Enter duration seconds (0-59): <<0
>>
UniversityCourse created!
Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: <<3
>>
Full list of events:
1. The event starts at 10 and ends at 12
2. The course CRN is: 11005
The course starts at 2:0:0
It is during Spring quarter
It lasts for 2 hours, 30 minutes, and 0 seconds
It repeats on Tuesday Thursday
Expect 5 hours of homework each week.
Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: <<4
>>
Exiting!
";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expected, Program.Main);
        }
        
        [DataTestMethod]
        [DataRow("5")]
        [DataRow("1")]
        public void PrintMenuAndGetUserSelection_ValidSelection(string userInput)
        {
            StringReader stringReader = new StringReader(userInput);
            StringWriter stringWriter = new StringWriter();

            var oldIn = Console.In;
            var oldOut = Console.Out;
            
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            
            // do something
            int result = Program.PrintMenuAndGetUserSelection();
            
            Console.SetIn(oldIn);
            Console.SetOut(oldOut);
           
            Assert.AreEqual(Convert.ToInt32(userInput), result);
        }
        
        [DataTestMethod]
        [DataRow("b")]
        [DataRow("\n")]
        [DataRow(" ")]
        public void PrintMenuAndGetUserSelection_InvalidSelection(string userInput)
        {
            StringReader stringReader = new StringReader(userInput);
            StringWriter stringWriter = new StringWriter();

            var oldIn = Console.In;
            var oldOut = Console.Out;
            
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            
            // do something
            int result = Program.PrintMenuAndGetUserSelection();
            
            Console.SetIn(oldIn);
            Console.SetOut(oldOut);
           
            Assert.AreEqual(0, result);
        }
        
        [TestMethod]
        public void PrintEventList_ListSizeOf2()
        {
            Event sampleEvent1 = new Event(new DateTime(2018, 1, 1, 10, 0, 0), new DateTime(2018, 1, 1, 22, 0, 0));
            Event sampleEvent2 = new Event(new DateTime(2018, 1, 1, 11, 0, 0), new DateTime(2018, 1, 1, 21, 0, 0));

            List<IEvent> toUse = new List<IEvent> {sampleEvent1, sampleEvent2};

            string expected =
$@"1. The event starts at 10 and ends at 22
2. The event starts at 11 and ends at 21
";
            
            StringWriter stringWriter = new StringWriter();

            var oldIn = Console.In;
            var oldOut = Console.Out;
            
            Console.SetOut(stringWriter);
            
            // do something
            Program.PrintEventList(toUse);
            
            Console.SetIn(oldIn);
            Console.SetOut(oldOut);
            
            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void PrintEventList_EmptyList()
        {
            List<IEvent> toUse = new List<IEvent>();

            string expected =
                @"List is empty!
";

            StringWriter stringWriter = new StringWriter();

            var oldIn = Console.In;
            var oldOut = Console.Out;

            Console.SetOut(stringWriter);

            // do something
            Program.PrintEventList(toUse);

            Console.SetIn(oldIn);
            Console.SetOut(oldOut);

            Assert.AreEqual(expected, stringWriter.ToString());
        }
    }
}