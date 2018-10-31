using System;
using System.Collections.Generic;

namespace Assignment5
{
    public class Program
    {
        public static void Main()
        {
            // TODO: Allow user to select what event to create
            // TODO: Display list of created events
            List<Event> eventList = new List<Event>();

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
                       Console.WriteLine("In 2");
                       break;
                   case 3:
                       Console.WriteLine("Full list of events:");
                       PrintEventList(eventList);
                       break;
                    case 4:
                        Console.WriteLine("In 4");
                        Console.WriteLine("Exiting!");
                        break;
                   default:
                       Console.WriteLine("Invalid menu option!");
                       break;
                }
            } while (selection != 4);
        }

        private static int PrintMenuAndGetUserSelection()
        {
            const string toReturn = 
@"Select from the following menu options:
1. Create Event
2. Create University Course
3. Display list of events
4. Exit

Selection: ";

            Console.Write(toReturn);

            return Convert.ToInt32(Console.ReadLine());
        }

        private static void PrintEventList(List<Event> toPrint)
        {
            string fullEventList = "";
            foreach (Event cur in toPrint)
            {
                fullEventList += cur.GetSummaryInformation() + System.Environment.NewLine;
            }
            
            Console.WriteLine(fullEventList);
        }

        private static Event PromptCreateEvent(DateTime startingTime)
        {
            while (true)
            {
                try
                {
                    int endingHour = PromptUserForInt("ending hour");
                    
                    DateTime endingTime = new DateTime(startingTime.Year, startingTime.Month, startingTime.Day, endingHour, 0, 0);

                    return new Event(startingTime, endingTime);
                }
                catch (Exception) // InvalidDataException, ArgumentOutOfRangeException
                {
                    Console.WriteLine("Invalid data, try again!");
                }
            }
        }

        private static DateTime PromptCreateDateTime()
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

        private static int PromptUserForInt(string prompt)
        {
            int toReturn = 0;
            try
            {
                Console.Write($"Enter {prompt}: ");
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

            return toReturn;
        }
    }
}