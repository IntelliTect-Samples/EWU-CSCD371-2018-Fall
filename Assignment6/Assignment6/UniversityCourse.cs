using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment6
{
    public class UniversityCourse : IEvent
    {
        public UniversityCourse(int crn, string daysOfWeek, string quarter, int startingHour, 
            int startingMinute, int startingSecond, int durationHours, int durationMinutes, int durationSeconds)
        {
            this.Crn = crn;
            CurrentSchedule = new Schedule(daysOfWeek, quarter, startingHour, startingMinute, startingSecond, 
                durationHours, durationMinutes, durationSeconds);
        }
        
        public enum Day
        {
            Sun,
            Mon,
            Tues,
            Weds,
            Thurs,
            Fri,
            Sat
        };

        public enum SchoolQuarter
        {
            Fall,
            Winter,
            Spring,
            Summer
        };

        public readonly struct TimeValue
        {
            public int Hour { get; }
            public int Minute { get; }
            public int Second { get; }

            public TimeValue(int hour, int minute, int second)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
            }
        }

        public readonly struct Schedule
        {
            // List so we can have multiple days
            public List<Day> DaysOfWeek { get; }

            public SchoolQuarter Quarter { get; }
            public TimeValue StartTime { get; }
            public TimeSpan Duration { get; }

            public Schedule(string daysOfWeek, string quarter, int startingHour, int startingMinute, 
                int startingSecond, int durationHours, int durationMinutes, int durationSeconds)
            {
                DaysOfWeek = ConvertStringToDayList(daysOfWeek);
                Quarter = ConvertStringToSchoolQuarter(quarter);

                if (IsValidTime(startingHour, startingMinute, startingSecond))
                {
                    StartTime = new TimeValue(startingHour, startingMinute, startingSecond);
                }
                else
                {
                    throw new InvalidDataException("Starting time is out of valid time range! Valid range: " +
                                                   "Hour (0-24), Minute (0-60), Seconds (0-60)");
                }

                if (IsValidTime(durationHours, durationMinutes, durationSeconds))
                {
                    Duration = new TimeSpan(durationHours, durationMinutes, durationSeconds);
                }
                else
                {
                    throw new InvalidDataException("Duration time is out of valid time range! Valid range: " +
                                                  "Hour (0-24), Minute (0-60), Seconds (0-60)");
                }
            }

            private static List<Day> ConvertStringToDayList(string spaceDelimitedDayList)
            {
                List<Day> newDayList = new List<Day>();
        
                string[] separatedDays = spaceDelimitedDayList.Split();

                foreach (string cur in separatedDays)
                {
                    if (Enum.TryParse(cur, out Day parsedDay))
                    {
                        if (!newDayList.Contains(parsedDay))
                        {
                            newDayList.Add(parsedDay);
                        }
                        else
                        {
                            throw new InvalidDataException($"{parsedDay} already exists. You cannot specify the same " +
                                                           $"day twice");
                        }
                    }
                    else
                    {
                        var validDays = Enum.GetValues(typeof(Day));
                        string validDayValues = "";

                        foreach (var enumValue in validDays)
                        {
                            validDayValues += enumValue + " ";
                        }

                        validDayValues = validDayValues.Trim();
                        throw new InvalidDataException($"{cur} is an invalid Day. Valid days are: \"{validDayValues}\"");
                    }
                }

                newDayList.Sort();
                
                return newDayList;
            }
            
            private static SchoolQuarter ConvertStringToSchoolQuarter(string schoolQuarter)
            {
                if (Enum.TryParse(schoolQuarter, out SchoolQuarter quarter))
                {
                    return quarter;
                }
                
                // if not a valid type
                var validQuarters = Enum.GetValues(typeof(SchoolQuarter));
                string validQuarterTypes = "";

                foreach (var enumValue in validQuarters)
                {
                    validQuarterTypes += enumValue + " ";
                }

                validQuarterTypes = validQuarterTypes.Trim();
                throw new InvalidDataException($"{schoolQuarter} is an invalid SchoolQuarter. Valid quarters are: \"{validQuarterTypes}\"");
            }

            private static bool IsValidTime(int hour, int minute, int second)
            {
                if (hour < 24 && hour >= 0 && minute < 60 && minute >= 0 
                    && second < 60 && second >= 0)
                {
                    return true;
                }

                return false;
            }

            public string GetQuarter()
            {
                return Quarter.ToString();
            }
        }

        public readonly Schedule CurrentSchedule;

        public void SetSchedule(string daysToSet)
        {
            List<Day> newDayList = new List<Day>();

            string[] separatedDays = daysToSet.Split();

            foreach (string cur in separatedDays)
            {
                Day parsedDay;
                if (Enum.TryParse(cur, out parsedDay))
                {
                    newDayList.Add(parsedDay);
                }
                else
                {
                    var validDays = Enum.GetValues(typeof(Day));
                    string validDayValues = "";

                    foreach (var enumValue in validDays)
                    {
                        validDayValues += enumValue + " ";
                    }

                    validDayValues = validDayValues.Trim();
                    throw new InvalidDataException($"{cur} is an invalid Day. Valid days are: \"{validDayValues}\"");
                }
            }
        }

        // Read only
        public int Crn { get; }
        
        // Calculated property
        // 2 hours of homework expected for every hour of class time
        public double WeeklyHoursOfHomeworkExpected 
            => (CurrentSchedule.Duration.Hours+(CurrentSchedule.Duration.Minutes/60.0)) * 2;

        public string GetSummaryInformation()
        {
            string daysOfWeekEventOccursOn = "";
            foreach (Day cur in CurrentSchedule.DaysOfWeek)
            {
                daysOfWeekEventOccursOn += cur + " ";
            }

            daysOfWeekEventOccursOn = daysOfWeekEventOccursOn.Trim();
            
            return 
$@"The course CRN is: {Crn}
The event starts at {CurrentSchedule.StartTime.Hour}:{CurrentSchedule.StartTime.Minute}:{CurrentSchedule.StartTime.Second}
It lasts for {CurrentSchedule.Duration.Hours} hours, {CurrentSchedule.Duration.Minutes} minutes, and {CurrentSchedule.Duration.Seconds} seconds
It repeats on {daysOfWeekEventOccursOn}
Expect {WeeklyHoursOfHomeworkExpected} hours of homework each week.";
        }

        public int GetStartingHour()
        {
            return CurrentSchedule.StartTime.Hour;
        }

        public int GetEndingHour()
        {
            int startingTimePlusDuration = CurrentSchedule.StartTime.Hour + CurrentSchedule.Duration.Hours;

            if (startingTimePlusDuration > 24)
            {
                return startingTimePlusDuration - 24;
            }

            return startingTimePlusDuration;
        }
    }
}