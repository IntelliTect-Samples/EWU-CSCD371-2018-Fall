﻿using System;

namespace Assignment6
{
    public class MyEnums
    {
        [Flags]
        public enum WeekDays
        {
            Monday = 1 << 0,
            Tuesday = 1 << 1,
            Wednesday = 1 << 2,
            Thursday = 1 << 3,
            Friday = 1 << 4,
            Saturday = 1 << 5,
            Sunday = 1 << 6 
        }

        public enum Seasons
        {
            Fall, 
            Winter,  
            Spring,  
            Summer  
        }

        public static void AddSeason(string str, Seasons season)
        {
            str = str.ToLower();
            switch (str)
            {
                case "fall":
                    season = Seasons.Fall;
                    break;
                case "winter":
                    season = Seasons.Winter;
                    break;
                case "spring":
                    season = Seasons.Spring;
                    break;
                case "summer":
                    season = Seasons.Summer;
                    break;
            }
        }
        public static void AddWeekDays(string str,  WeekDays weekDays)
        {
            str = str.ToLower();

            var strings = str.Split(" ");

            foreach (var item in strings)
            {
                switch (item)
                {
                    case "monday":
                        weekDays |= WeekDays.Monday;
                        break;
                    case "tuesday":
                        weekDays |= WeekDays.Tuesday;
                        break;
                    case "wednesday":
                        weekDays |= WeekDays.Wednesday;
                        break;
                    case "thursday":
                        weekDays |= WeekDays.Thursday;
                        break;
                    case "friday":
                        weekDays |= WeekDays.Friday;
                        break;
                    case "saturday":
                        weekDays |= WeekDays.Saturday;
                        break;
                    case "sunday":
                        weekDays |= WeekDays.Sunday;
                        break;
                }
            }
        }

        public struct Time
        {
            public int Hour { get; }
            public int Minute { get; }
            public int Second { get; }

            public Time(int hour, int minute, int second)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
            }
        }

        public struct Schedule
        {
            public WeekDays DaysOfWeek { get;}
            public Seasons Quarter { get; }
            public Time StartTime { get; }
            public TimeSpan Duration { get; }

            public Schedule(int hours, int min, int sec)
            {
                DaysOfWeek = WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday |
                             WeekDays.Friday;
                Quarter = Seasons.Fall;
                StartTime = new Time(hours, min, sec);
                Duration = new TimeSpan();
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
