using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    // NOTE: only methods without while(true) loops are tested
    [TestClass]
    public class TestProgram
    {

        [TestMethod]
        public void TestProgramMain_ValidData()
        {
            string expected =
$@"Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: <<1
>>
Enter year: <<2018
>>
Enter month: <<1
>>
Enter day: <<1
>>
Enter starting hour: <<10
>>
Enter ending hour: <<22
>>
Event created!
Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: <<2
>>
Enter crn: <<115
>>
Enter year: <<2018
>>
Enter month: <<1
>>
Enter day: <<1
>>
Enter starting hour: <<10
>>
Enter ending hour: <<22
>>
Enter days of week (M, T, W, T, F) separated by commas (I.E: M T W): <<M T W R
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
1. The event starts at 10 and ends at 22
2. The course CRN is: 115
The event starts at 10 and ends at 22
It repeats on M T W R 
Expect 24 hours of homework each day.

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

            List<Event> toUse = new List<Event> {sampleEvent1, sampleEvent2};

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
            List<Event> toUse = new List<Event>();

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

        [TestMethod]
        public void PromptUserForDaysOfWeek_InputValidData()
        {
            string userInput = "M T W R F";
            
            List<char> expected = new List<char>();
            expected.Add('M');
            expected.Add('T');
            expected.Add('W');
            expected.Add('R');
            expected.Add('F');
            
            StringReader stringReader = new StringReader(userInput);
            StringWriter stringWriter = new StringWriter();

            var oldIn = Console.In;
            var oldOut = Console.Out;
            
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            
            // do something
            List<char> result = Program.PromptUserForDaysOfWeek();
            
            Console.SetIn(oldIn);
            Console.SetOut(oldOut);
           
            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}