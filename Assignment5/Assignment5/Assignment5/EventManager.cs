using System;
using System.Collections.Generic;

namespace Assignment5
{
    public class EventManager
    {
        private IConsole Console { get; }
        private List<IEvent> Events { get; } = new List<IEvent>();

        public EventManager(IConsole console)
        {
            Console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Create a course");
                Console.WriteLine("2. Create an event");
                Console.WriteLine("3. List events");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": 
                        CreateCourse();
                        break;
                    case "2": 
                        CreateEvent();
                        break;
                    case "3": 
                        ListEvents();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine($"'{input}' is not valid");
                        break;
                }
            }
        }

        private void CreateCourse()
        {
            string name = Console.GetString("What is the name of the course?");
            string location = Console.GetString("Where is the course being taught?");
            DateTime startDate = Console.GetDateTime($"What day does {name} start (mm/dd/yy)?");
            DateTime endDate = Console.GetDateTime($"What day does {name} end (mm/dd/yy)?");

            Events.Add(new UniversityCourse(name, location, startDate, endDate));
        }

        private void CreateEvent()
        {
            string name = Console.GetString("What is the name of the event?");
            string location = Console.GetString("Where is the event being held?");
            DateTime date = Console.GetDateTime($"When is {name} (mm/dd/yy)?");

            Events.Add(new Event(name, location, date));
        }

        private void ListEvents()
        {
            Console.WriteLine("Events:");
            foreach (IEvent @event in Events)
            {
                Console.WriteLine(@event.ToString());
            }
        }
    }
}