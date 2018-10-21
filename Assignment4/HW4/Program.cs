using System;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityCalender[] calanderEvents = {
            new Course("CSCD371", ".NET class", "Fall 2018, M-F, 2:00pm - 4:30pm", "Tom.Capal"),
            new Course("CSCD123", "JAVA class", "Fall 2018, M-F, 12:00pm - 1:00pm", "Stu.Steiner"),
            new Course("CSCD321", "Python class", "Fall 2018, T-Th, 9:00am - 10:00am", "Guy.Snake"),
            new Event("C# programming club", "CEB372 class room", "10-13-2018 1:00pm - 3:30pm"),
            new Event("Extream Nerding club", "CEB301 AV room", "11-25-2018 4:00pm - 11:30pm")};

            foreach(UniversityCalender UnivCalEvent in calanderEvents)
            {
                System.Console.WriteLine(UnivCalEvent.Display());
            }            
            System.Console.WriteLine("Total # of courses and events scheduled is: " + calanderEvents[0].getTotalCalendarItems());

            System.Console.WriteLine("\nPrinting list using pattern matching");
            foreach (UniversityCalender UnivCalEvent in calanderEvents)
            {
                DisplayAllEvents(UnivCalEvent);
            }
            System.Console.WriteLine("\nTotal # of courses and events scheduled is: " + calanderEvents[0].getTotalCalendarItems());

            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadLine();
        }//end of main

        public static void DisplayAllEvents(Object obj)
        {
            switch (obj)
            {
                case Course course:
                    System.Console.WriteLine(course.GetSummaryInformation() );                    
                    break;
                case Event @event:
                    System.Console.WriteLine(@event.GetSummaryInformation() );
                    break;
                case null:
                    throw new ArgumentNullException(nameof(obj));
                default:
                    throw new ArgumentException("Unknown object type", nameof(obj));
            }
        }
    }
}
