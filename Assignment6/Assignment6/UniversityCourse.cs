using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Assignment6
{
    public class UniversityCourse : IEvent
    {
        public UniversityCourse(int crn, string daysOfWeek, string quarter, byte startingHour, 
            byte startingMinute, byte startingSecond, int durationHours, int durationMinutes, int durationSeconds)
        {
            this.Crn = crn;
            CurrentSchedule = new Schedule(daysOfWeek, quarter, startingHour, startingMinute, startingSecond, 
                durationHours, durationMinutes, durationSeconds);
        }

        [Flags]
        public enum DaysOfWeek
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 4,
            Wednesday = 8,
            Thursday = 16,
            Friday = 32,
            Saturday = 64
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
            public byte Hour { get; }
            public byte Minute { get; }
            public byte Second { get; }

            public TimeValue(byte hour, byte minute, byte second)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
            }
        }

        public readonly struct Schedule // 24 bytes -> 5 bytes unaccounted for
        {
            public readonly DaysOfWeek ClassDays; // 4 bytes
            public readonly SchoolQuarter Quarter; // 4 bytes
            public readonly TimeValue StartTime; // 3 bytes
            public readonly TimeSpan Duration; // 8 bytes

            public Schedule(string daysOfWeek, string quarter, byte startingHour, byte startingMinute, 
                byte startingSecond, int durationHours, int durationMinutes, int durationSeconds)
            {
                this.ClassDays = ConvertStringToDayList(daysOfWeek);
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

            private static DaysOfWeek ConvertStringToDayList(string spaceDelimitedDayList)
            {
                DaysOfWeek dayList = new DaysOfWeek();
                string[] separatedDays = spaceDelimitedDayList.Split();

                foreach (string cur in separatedDays)
                {
                    if (Enum.TryParse(cur, out DaysOfWeek parsedDay))
                    {
                        dayList |= parsedDay;
                    }
                    else
                    {
                        var validDays = Enum.GetValues(typeof(DaysOfWeek));
                        string validDayValues = "";

                        foreach (var enumValue in validDays)
                        {
                            validDayValues += enumValue + " ";
                        }

                        validDayValues = validDayValues.Trim();
                        throw new InvalidDataException($"{cur} is an invalid Day. Valid days are: \"{validDayValues}\"");
                    }
                }
                
                return dayList;
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
        }

        public readonly Schedule CurrentSchedule;

        // Read only
        public int Crn { get; }
        
        // Calculated property
        // 2 hours of homework expected for every hour of class time
        public double WeeklyHoursOfHomeworkExpected 
            => (CurrentSchedule.Duration.Hours+(CurrentSchedule.Duration.Minutes/60.0)) * 2;

        public string GetSummaryInformation()
        {
            string daysOfWeekEventOccursOn = "";

            var validDays = Enum.GetValues(typeof(DaysOfWeek));

            foreach (DaysOfWeek enumValue in validDays)
            {
                if (CurrentSchedule.ClassDays.HasFlag(enumValue))
                {
                    daysOfWeekEventOccursOn += enumValue + " ";
                }
            }

            daysOfWeekEventOccursOn = daysOfWeekEventOccursOn.Trim();
            
            return 
$@"The course CRN is: {Crn}
The course starts at {CurrentSchedule.StartTime.Hour}:{CurrentSchedule.StartTime.Minute}:{CurrentSchedule.StartTime.Second}
It is during {CurrentSchedule.Quarter} quarter
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