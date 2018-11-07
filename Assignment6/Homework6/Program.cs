using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;




namespace Homework6
{
    public class Program
    {
        //public static IConsole Console { get; set; }  //only uncomment when the consoleTester is to be used. 


            
        [Flags]
        public enum DayOfWeek : byte
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64
        };

        public enum Quarter : byte
        {
            Spring = 1,
            Summer,
            Fall,
            Winter
        };

        public readonly struct Time
        {
            public byte Hour { get; }
            public byte Minute { get; }
            public byte Second { get; }

            public Time(byte H, byte M, byte S)
                => (Hour, Minute, Second) = (H, M, S);
        }

        public readonly struct Schedule
        {
            public byte DayOfWeek { get; }
            public byte Quarter { get; }
            public Time StartTime { get; }
            public TimeSpan Duration { get; }
        }

        public static double ChangeMyStruct(Student.StudentStruct student)
        {
            student.GPA = 99;
            System.Console.WriteLine("Students GPA (should be 99) inside the changeMyStruct method is " + student.GPA);

            return student.GPA;
        }

        public static double ChangeMyStructByRef(ref Student.StudentStruct student)
        {
            student.GPA = 99;
            System.Console.WriteLine("Students GPA (should be 99) inside the changeMyStruct method is " + student.GPA);

            return student.GPA;
        }

        public static int ChangeMyClass(Student student)
        {

            student.Age = 55;
            return student.Age;
        }

        public static void ChangeClassReference(Student S)
        {
            S = new Student();
            S.Age = 34;
        }

        public static void ChangeInterface(IStudent istudent)
        {

            istudent.Age = 99;

        }

        static void Main(string[] args)
        {
            

            //////////////////////////////// enum and struct testing area ////////////////////////////

            object WeekDy;

            string stringWithDaysInIt = "Monday, Tuesday, Wednesday, Thursday, Friday, Saturday"; //"Monday, Tuesday, Wednesday, Thursday, Friday, Saturday"

            Enum.TryParse("Monday, Tuesday", out DayOfWeek classDays);
            
            System.Console.WriteLine("Parsed DayOfWeek Struct " + classDays.ToString());

            bool result = Enum.TryParse(typeof(DayOfWeek), stringWithDaysInIt, false, out WeekDy);
            System.Console.WriteLine("DayOfWeek = " + (byte)(DayOfWeek)WeekDy);

            Time T = new Time(12, 0, 0);

            System.Console.WriteLine("Size of Schedule Struct is: " + Marshal.SizeOf(typeof(Schedule)));


            ////////////////////////////////  ////////////////////////////


            List<UniversityCalender> EventList = new List<UniversityCalender>
            {
               // new Event("C# programming club", "CEB372 class room", "10-13-2018 1:00pm - 3:30pm"),
                new Event("Extream Nerding club", "CEB301 AV room", "11-25-2018 4:00pm - 11:30pm")
            };

            int usersMenuChoice;
            do
            {
                usersMenuChoice = DisplayUserMenu();

                if (usersMenuChoice == (int)MenuSelection.CreateEvent)
                {
                    EventList.Add(UserCreatesEvent());
                }

                if (usersMenuChoice == (int)MenuSelection.DisplayEvents)
                {
                    System.Console.WriteLine("Printing out all events...");
                    DisplayEvents(EventList);
                }
                if (usersMenuChoice == (int)MenuSelection.CheckForRoomConflicts)
                {
                    System.Console.WriteLine("Checking all Events for room conflicts...");
                    CheckForRoomConflicts(EventList);
                }
                if (usersMenuChoice == (int)MenuSelection.PublicAnnounce)
                {
                    System.Console.WriteLine("\nANNOUCING all Events...");
                    AnnounceAllEventsNames(EventList);
                }

            }
            while (usersMenuChoice != (int)MenuSelection.ExitProgram);

        }//end of main

        public static Event UserCreatesEvent()
        {
            Console.WriteLine("");
            Console.WriteLine("Lets go ahead and create a new event:");

            Console.Write("Please enter the event's name: ");
            string eventName = System.Console.ReadLine();

            Console.Write("Please enter the event's location: ");
            string eventLocation = System.Console.ReadLine();

            Console.Write("Please enter the event's start time: ");
            string eventStartTime = System.Console.ReadLine();

            Event @event = new Event(eventName, eventLocation, eventStartTime);
            return @event;
        }

        enum MenuSelection
        {
            None,
            CreateEvent,
            DisplayEvents,
            CheckForRoomConflicts,
            PublicAnnounce,
            ExitProgram
        };

        public static int DisplayUserMenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("Press 1 to create a new Calander Event");
                Console.WriteLine("Press 2 to display all Calander Events");
                Console.WriteLine("Press 3 to check all events for room conflicts - (uses IEvent interface)");
                Console.WriteLine("Press 4 to public annouce all events - (uses ext. method)");
                Console.WriteLine("Press 5 to exit");

                string input = System.Console.ReadLine();
                bool validInput = int.TryParse(input, out int userSelection);
                if (validInput == false || userSelection <= 0 || userSelection >= 6)
                {
                    System.Console.WriteLine("Invalid input, please try again.");
                }
                else
                {
                    return userSelection;
                }
            }
        }

        public static void DisplayEvents(List<UniversityCalender> eventList)
        {
            foreach (UniversityCalender UnivCalEvent in eventList)
            {
                Console.WriteLine(UnivCalEvent.Display());
            }
        }

        public static void CheckForRoomConflicts(List<UniversityCalender> eventList)
        {
            foreach (UniversityCalender UnivCalEvent in eventList)
            {
                ((Event)UnivCalEvent).RoomsRescourseValidator();
            }
        }

        public static void AnnounceAllEventsNames(List<UniversityCalender> eventList)
        {
            foreach (UniversityCalender UnivCalEvent in eventList)
            {
                ((Event)UnivCalEvent).Name.PublicAnnoucement();
            }
        }

        public static void DisplayAllEvents(Object obj)
        {
            switch (obj)
            {
                case Course course:
                    System.Console.WriteLine(course.GetSummaryInformation());
                    break;
                case Event @event:
                    System.Console.WriteLine(@event.GetSummaryInformation());
                    break;
                case null:
                    throw new ArgumentNullException(nameof(obj));
                default:
                    throw new ArgumentException("Unknown object type", nameof(obj));
            }
        }
    }
}


