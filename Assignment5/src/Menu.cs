using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Menu
    {
        private Event _Events;
        private static MyConsole myConsole = new MyConsole();
        public static void Main()
        {
            List<Event> eventList = new List<Event>();
            int userChoice = -1;

            do{
                menu();
                userChoice = getUserChoice();
                runChoice(eventList, userChoice);
            }while(userChoice != 3);
        }

        public static void menu()
        {
            MyConsole myConsole = new MyConsole();
            myConsole.WriteLine($"MENU:{Environment.NewLine}1. Add class{Environment.NewLine}2. Display Schedule{Environment.NewLine}3. Exit");
        }

        public static bool isValidChoice(int userChoice)
        {
            return userChoice >= 0 && userChoice <= 3;
        }

        public static int getUserChoice()
        {
                myConsole.Write($"Please type in choice: ");
                int hour = -1;
                while(!int.TryParse(myConsole.ReadLine(), out hour) || !isValidChoice(hour))
                {
                    myConsole.Write($"Incorrect input, please reinput a valid choice 1 2 or 3: ");
                }
                return hour;
        }

        public static void runChoice(List<Event> events, int userChoice)
        {
            switch(userChoice)
            {
                case 1: 
                    events.Add(Course.makeNewCourse());
                    break;
                case 2:
                    myConsole.WriteLine(DisplayClass.DisplayList(events));
                    break;
                case 3:
                    myConsole.WriteLine("Terminating Program");
                    break;
                default:
                    myConsole.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}