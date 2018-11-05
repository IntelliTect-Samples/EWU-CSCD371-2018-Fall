using System;
using System.Collections.Generic;

namespace Assignment6
{
    public class Program
    {
        public static void Main()
        {
            List<IEvent> eventList = new List<IEvent>();

            int selection = 0;
            
            do
            {
                selection = PrintMenuAndGetUserSelection();
                
                switch (selection)
                {
                   case 1:
                       DateTime startingTime = PromptCreateDateTime();
                       Event createdEvent = PromptCreateEvent(startingTime);
                       Console.WriteLine("Event created!");
                       eventList.Add(createdEvent);
                       break;
                   case 2:
                       UniversityCourse createdCourse = PromptCreateUniversityCourse();
                       Console.WriteLine("UniversityCourse created!");
                       eventList.Add(createdCourse);
                       break;
                   case 3:
                       Console.WriteLine("Full list of events:");
                       PrintEventList(eventList);
                       break;
                    case 4:
                        Console.WriteLine("Exiting!");
                        break;
                   default:
                       Console.WriteLine("Invalid menu option!");
                       break;
                }
            } while (selection != 4);
        }

        public static int PrintMenuAndGetUserSelection()
        {
            const string toReturn = 
@"Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: ";

            Console.WriteLine(toReturn);

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static void PrintEventList(List<IEvent> toPrint)
        {
            string fullEventList = "";
            if (toPrint.Count > 0)
            {
                int counter = 1;
                foreach (IEvent cur in toPrint)
                {
                    fullEventList += $"{counter}. " + cur.GetSummaryInformation() + System.Environment.NewLine;
                    counter++;
                }
            }
            else
            {
                fullEventList = "List is empty!";
            }

            fullEventList = fullEventList.Trim();
            
            Console.WriteLine(fullEventList);
        }

        public static Event PromptCreateEvent(DateTime startingTime)
        {
            while (true)
            {
                try
                {
                    int endingHour = PromptUserForInt("ending hour");
                    
                    DateTime endingTime = 
                        new DateTime(startingTime.Year, startingTime.Month, startingTime.Day, endingHour, 0, 0);

                    return new Event(startingTime, endingTime);
                }
                catch (Exception) // InvalidDataException, ArgumentOutOfRangeException
                {
                    Console.WriteLine("Invalid data, try again!");
                }
            }
        }
        
        public static UniversityCourse PromptCreateUniversityCourse()
        {
            //int crn, string daysOfWeek, string quarter, int startingHour, 
            //int startingMinute, int startingSecond, int durationHours,
            //int durationMinutes, int durationSeconds
            while (true)
            {
                try
                {
                    int crnToSet = PromptUserForInt("crn");
                    
                    Console.WriteLine("Enter days of week (Mon, Tues, Weds, Thurs, Fri, Sat, Sun) separated by spaces (I.E: Mon Tues Weds): ");
                    string daysOfWeekToSet = Console.ReadLine();
                    
                    Console.WriteLine("Enter school quarter, value values: (Spring, Winter, Fall, Summer): ");
                    string quarterToSet = Console.ReadLine();

                    int startingHourToSet = PromptUserForInt("starting hour (0-23)");

                    int startingMinuteToSet = PromptUserForInt("starting minute (0-59)");

                    int startingSecondToSet = PromptUserForInt("starting second (0-59)");

                    int durationHoursToSet = PromptUserForInt("duration hours (0-23)");

                    int durationMinutesToSet = PromptUserForInt("duration minutes (0-59)");

                    int durationSecondsToSet = PromptUserForInt("duration seconds (0-59)");
                    
                    return new UniversityCourse(crnToSet, daysOfWeekToSet, quarterToSet, startingHourToSet, 
                        startingMinuteToSet, startingSecondToSet, durationHoursToSet, durationMinutesToSet, 
                        durationSecondsToSet);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid data, try again!");
                }
            }
        }

        public static DateTime PromptCreateDateTime()
        {
            while (true)
            {
                try
                {
                    // year
                    int yearToSet = PromptUserForInt("year");
                
                    // month
                    int monthToSet = PromptUserForInt("month");
                
                    // day
                    int dayToSet = PromptUserForInt("day");
                
                    // hour
                    int startingHourToSet = PromptUserForInt("starting hour");

                    return new DateTime(yearToSet, monthToSet, dayToSet, startingHourToSet, 0, 0);
                }
                catch (Exception) // InvalidDataException, ArgumentOutOfRangeException
                {
                    Console.WriteLine("Invalid data, try again!");
                }
            }
        }

        public static int PromptUserForInt(string prompt)
        {
            int toReturn = -1;

            while (toReturn == -1)
            {
                try
                {
                    Console.WriteLine($"Enter {prompt}: ");
                    toReturn = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{prompt} must be an integer!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"{prompt} is too large!");
                }
            }

            return toReturn;
        }
    }
}