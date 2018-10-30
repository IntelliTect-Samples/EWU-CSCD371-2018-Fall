﻿using System;
using System.Collections.Generic;

namespace Assignment5
{
    public class Scheduler
    {
        public static void Main(string[] args)
        {
            List<Gathering> gatherings = new List<Gathering>();
            int selection = -1;

            do
            {
                PrintOptions();
                selection = GetSelection();

            } while (selection != 0);
        }

        private static void PrintOptions()
        {
            MyConsole terminal = new MyConsole();

            terminal.WriteLine("1.) Print current schedule.");
            terminal.WriteLine("2.) Add university course.");
            terminal.WriteLine("3.) Add one-time event.");
            terminal.WriteLine("0.) Exit.");
        }

        private static int GetSelection()
        {
            MyConsole terminal = new MyConsole();
            int selection = -1;
            string userInput;

            do
            {
                terminal.Write("Please enter the number of your selection: ");
                userInput = terminal.ReadLine();

                try
                {
                    selection = int.Parse(userInput);

                    if (selection < 0 || selection > 3)
                    {
                        throw new ArgumentException("Invalid Input - Number not in valid range.");
                    }
                }
                catch (FormatException)
                {
                    terminal.WriteLine("Invalid Input - Not a number.");
                }
                catch (ArgumentException e)
                {
                    terminal.WriteLine(e.Message);
                }
            } while (selection < 0 || selection > 3);

            return selection;
        }

        private static void ProcessSelection(List<Gathering> gatherings, int selection)
        {
            if (selection == 1)
            {
                foreach (Gathering gathering in gatherings)
                {
                    gathering.GetSummaryInformation();
                }
            }
            else if (selection == 2)
            {
                gatherings.Add(UniversityCourse.MakeCourse());
            }
            else if (selection == 3)
            {
                gatherings.Add(Event.MakeEvent());
            }
        }
    }
}
