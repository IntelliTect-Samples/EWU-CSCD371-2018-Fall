using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UniversityCourse
{
    public static class UniversityCourseIo
    {
        private static IConsole MyConsole { get;} = new RealConsole();
        private static List<Event> CreatedEvents { get; } = new List<Event>();
        
        public static void Main(string[] args)
        {
            int menuChoice;
            do
            {
                DisplayMenu();
                menuChoice = GetUserMenuChoice();
                MenuLogic(menuChoice);
            } while (menuChoice != 0);
        }

        private static void DisplayMenu()
        {
            MyConsole.WriteLine(
@"Enter a menu option
1. Create event
2. Display events
0. quit
Choice: ");
        }

        private static void CreateSomeEvent()
        {
            if(GetIsCourse()) 
                CreateCourse();
            else CreateEvent();
        }

        private static void CreateEvent()
        {
            string name, location;
            DateTime startTime, endTime;
            MyConsole.WriteLine("Name:");
            name = GetNonEmptyString();
            MyConsole.WriteLine("location:");
            location = GetNonEmptyString();
            TIME:
            MyConsole.WriteLine("start time[HH:MM]:");
            startTime = GetTime();
            MyConsole.WriteLine("end time[HH:MM]:");
            endTime = GetTime();

            if (startTime > endTime)
            {
                MyConsole.WriteLine("Start time cannot be after end time!");
                goto TIME;
            }
                CreatedEvents.Add(new Event(name, location, startTime, endTime));
            
            try{CreatedEvents.Add(new Event(name, location, startTime, endTime));}
            catch (Exception e)
            {
                MyConsole.WriteLine(e.Message);
                CreateEvent();
            }

        }
        
        private static void CreateCourse()
        {
            string name, location, courseID, instructor, schedule;
            DateTime startDate, endDate;
            MyConsole.WriteLine("name:");
            name = GetNonEmptyString();
            MyConsole.WriteLine("location:");
            location = GetNonEmptyString();
            DATE:
            MyConsole.WriteLine("start date[mm/dd/yyyy]:");
            startDate = GetDate();
            MyConsole.WriteLine("end date[mm/dd/yyyy]:");
            endDate = GetDate();

            if (startDate > endDate)
            {
                MyConsole.WriteLine("Start date cannot be after end date!");
                goto DATE;
            }
            MyConsole.WriteLine("courseID [abcd123]:");
            courseID = GetNonEmptyString();
            MyConsole.WriteLine("instructor:");
            instructor = GetNonEmptyString();
            MyConsole.WriteLine("scheduled days of the week[mtwrf]:");
            schedule = GetNonEmptyString();

            try
            {
                CreatedEvents.Add(new UniversityCourse(name, location, startDate, endDate,
                    courseID, instructor, schedule));
            }
            catch (Exception e)
            {
                MyConsole.WriteLine(e.Message);
                CreateCourse();
            }
        }

        private static string GetNonEmptyString()
        {
            string input;
            do{input = MyConsole.ReadLine().Trim();} while (input.Length == 0);
            return input;
        }

        private static bool GetIsCourse()
        {
            MyConsole.WriteLine("Is this a University course? [y/n] (n will create a one time event): ");
            var input = MyConsole.ReadLine();
            if (input.Equals("y")) 
                return true;
            if (input.Equals("n"))
                return false;
            MyConsole.WriteLine("Invalid input");
            return GetIsCourse();
        }
        
        

        private static DateTime GetDate()
        {
            DateTime date;
            var input = GetNonEmptyString();
            try{ date = DateTime.Parse(input);}
            catch (Exception e)
            {
                MyConsole.WriteLine(e.Message);///////////////////////////////////////////////////////
                MyConsole.WriteLine("Invalid date, re-enter [mm/dd/yyyy]: ");
                return GetDate();
            }
            
            return date;
        }
        
        private static DateTime GetTime()
        {
            var input = GetNonEmptyString();
            string[] hrMin;
            if (new Regex("(?:[01][0-9]|[2][0-4]):(?:[0-5][0-9])").IsMatch(input) && (hrMin = input.Split(':')).Length == 2)
            {
                return new DateTime(1,1,1, int.Parse(hrMin[0]), int.Parse(hrMin[1]), 0);
            }
            else
            {
                MyConsole.WriteLine("Invalid time, re-enter [HH:MM]");
                return GetTime();
            }

        }

        private static void ListAllEvents()
        {
            foreach (var createdEvent in CreatedEvents)
            {
                StaticEventLibrary.Display(createdEvent);
            }
        }

        private static void MenuLogic(int menuChoice)
        {
            switch (menuChoice)
            {
                case 0:
                    Console.WriteLine("Goodbye...");
                    break;
                case 1:
                    CreateSomeEvent();
                    break;
                case 2:
                    ListAllEvents();
                    break;
                default:
                    throw new ArgumentException("Invalid menu option");
            }
        }

        private static int GetUserMenuChoice()
        {
            int menuChoice;
            while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice < 0 || menuChoice > 2) 
                MyConsole.WriteLine("Invalid menu option\n");
            return menuChoice;
        }
        
    }
}
