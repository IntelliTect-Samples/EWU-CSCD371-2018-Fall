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
                       UniversityCourse createdCourse = PromptCreateUniversityCourse();
                       Console.WriteLine("UniversityCourse created!");
                       eventList.Add(createdCourse);
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

        public static int PrintMenuAndGetUserSelection()
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

        public static void PrintEventList(List<Event> toPrint)
        {
            string fullEventList = "";
            foreach (Event cur in toPrint)
            {
                fullEventList += cur.GetSummaryInformation() + System.Environment.NewLine;
            }
            
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
            int crnToSet;
            DateTime startingTime;
            DateTime endingTime;
            
            while (true)
            {
                try
                {
                    //crn, starting time, ending time, days of the week
                    crnToSet = PromptUserForInt("crn");
                    startingTime = PromptCreateDateTime();
                    
                    int endingHour = PromptUserForInt("ending hour");
                    
                    endingTime = 
                        new DateTime(startingTime.Year, startingTime.Month, startingTime.Day, endingHour, 0, 0);
                    
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid data, try again!");
                }
            }
            
            while (true)
            {
                try
                {   
                    // get days of the week
                    List<char> daysOfWeek = PromptUserForDaysOfWeek();
                    
                    return new UniversityCourse(crnToSet, startingTime, endingTime, daysOfWeek);
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

        public static List<char> PromptUserForDaysOfWeek()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter days of week (M, T, W, T, F) separated by commas (I.E: M T W): ");
                    string userInput = Console.ReadLine();
                    
                    userInput = userInput.Trim();

                    string[] arrayOfSelection = userInput.Split(null);

                    List<char> toReturn = new List<char>();
                    
                    foreach (string cur in arrayOfSelection)
                    {
                        toReturn.Add(cur[0]);
                    }

                    return toReturn;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid days of week!");
                }
            }
        }
    }
}