using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MenuRunner
    {
        IConsole console;

        public List<UniversityCourse> courseList = new List<UniversityCourse>();
        public List<Event> eventList = new List<Event>();

        public MenuRunner()
        {
            console = new MockConsole();
        }

        public void Run()
        {
            string endMenu = "";

            do
            {
                console.WriteLine("Would you like to add an event/course? List an event? List a course? Or exit? (Y/LE/LC/N)");
                endMenu = console.ReadLine();
                if (endMenu.ToLower() == "y")
                {
                    string selection = UniversityEventSelection(console);
                    switch (selection)
                    {
                        case "u":
                            UniversityCourse newCourse = CreateUniversityCourse(console);
                            courseList.Add(newCourse);
                            break;
                        case "e":
                            Event newEvent = CreateEvent(console);
                            eventList.Add(newEvent);
                            break;
                    }
                }
                if(endMenu.ToLower() == "le")
                {
                    ListEvents(console);
                }

                if (endMenu.ToLower() == "lc")
                {
                    ListCourses(console);
                }
            }
            while (endMenu.ToLower() != "n");
        }
        
        public string UniversityEventSelection(IConsole console)
        {
            string endSelection = "";
            while (endSelection != "u" && endSelection != "e")
            {
                console.WriteLine("Would you like to enter a UniversityCourse or Event? (U/E)");
                endSelection = console.ReadLine().ToLower();
            }
            return endSelection;
        }

        public UniversityCourse CreateUniversityCourse(IConsole console)
        {
            List<char> days = SetDays(console);
            string title = setTitle(console);

            console.WriteLine("Please set start time");
            DateTime startTime = SetTime(console);
            console.WriteLine("Please set end time");
            DateTime endTime = SetTime(console);
            int courseNumber = SetCourseNumber(console);
            UniversityCourse newCourse = new UniversityCourse(title, courseNumber, startTime, endTime, days);

            return newCourse;
        }

        public Event CreateEvent(IConsole console)
        {
            string title = setTitle(console);

            DateTime startTime = SetEventDate(console);
            console.WriteLine("Please set start time");
            DateTime temp = SetTime(console);

            console.WriteLine("/nWhen does it End?/n");

            DateTime endTime = SetEventDate(console);
            console.WriteLine("Please set end time");
            endTime = SetTime(console);

            Event newEvent = new Event(title, startTime, endTime);

            return newEvent;
        }

        public List<char> SetDays(IConsole console)
        {
            List<char> days = new List<char> { };
            console.WriteLine("Please input what days you would like for class (MTWRF):");
            string userDays = console.ReadLine().ToUpper();
            userDays.ToCharArray();
            for (int i = 0; i < userDays.Length; i++)
            {
                days.Add(userDays[i]);
            }

            return days;
        }

        public DateTime SetTime(IConsole console)
        {
            console.WriteLine("Please enter hour:");
            string stringHour = console.ReadLine();
            int hour = int.Parse(stringHour);

            console.WriteLine("Please enter minutes:");
            string stringMinutes = console.ReadLine();
            int minutes = int.Parse(stringMinutes);

            DateTime time = new DateTime(1, 1, 1, hour, minutes, 0);
            return time;
        }

        public int SetCourseNumber(IConsole console)
        {
            console.WriteLine("Please enter course number");
            return int.Parse(console.ReadLine());
        }

        public void ListEvents(IConsole console)
        {
            if (eventList.Count > 0)
            {
                console.WriteLine($"\nEvent count: {eventList.Count}");

                foreach (Event e in eventList)
                {
                    console.WriteLine("\n" + e.title);
                    //console.WriteLine(e.GetDays());
                    console.WriteLine(e.GetSummaryInformation() + "\n");
                }
            }
            else
            {
                console.WriteLine("Error... No events have been created");
            }
        }

        public void ListCourses(IConsole console)
        {
            if (courseList.Count > 0)
            {
                console.WriteLine($"Course count: {courseList.Count}");

                foreach (UniversityCourse uC in courseList)
                {
                    console.WriteLine(uC.GetSummaryInformation());
                }
            }
            else
            {
                console.WriteLine("Error... No courses have been created");
            }
        }

        public string setTitle(IConsole console)
        {
            console.WriteLine("Please enter a title");
            return console.ReadLine();
        }

        public DateTime SetEventDate(IConsole console)
        {
            console.WriteLine("Please enter year:");
            string stringYear = console.ReadLine();
            int year = int.Parse(stringYear);

            console.WriteLine("Please enter month:");
            string stringMonth = console.ReadLine();
            int month = int.Parse(stringMonth);

            console.WriteLine("Please enter day:");
            string stringDay = console.ReadLine();
            int day = int.Parse(stringDay);

            DateTime time = new DateTime(year, month, day, 0, 0, 0);
            return time;
        }
    }
}
