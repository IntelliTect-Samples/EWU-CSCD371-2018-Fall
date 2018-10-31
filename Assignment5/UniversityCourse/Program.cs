using System;

namespace UniversityCourse
{
    public static class UniversityCourseIo
    {
        private static IConsole MyConsole { get;} = new RealConsole();
        
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

        private static void MenuLogic(int menuChoice)
        {
            switch (menuChoice)
            {
                case 0:
                    Console.WriteLine("Goodbye...");
                    break;
                case 1:
                    break;
                case 2:
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
