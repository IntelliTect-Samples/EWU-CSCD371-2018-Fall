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
            _currentSchedule = new Schedule(daysOfWeek, quarter, startingHour, startingMinute, startingSecond, 
                durationHours, durationMinutes, durationSeconds);
        }
        
        private enum Day
        {
            Sun,
            Mon,
            Tues,
            Weds,
            Thurs,
            Fri,
            Sat
        };

        private enum SchoolQuarter
        {
            Fall,
            Winter,
            Spring,
            Summer
        };

        readonly struct TimeValue
        {
            public int Hour { get; }
            public int _minute { get; }
            public int _second { get; }

            public TimeValue(int hour, int minute, int second)
            {
                Hour = hour;
                _minute = minute;
                _second = second;
            }
        }

        readonly struct Schedule
        {
            // List so we can have multiple days
            public List<Day> DaysOfWeek { get; }
            public SchoolQuarter Quarter { get; }
            public TimeValue StartTime { get; }
            public TimeSpan Duration { get; }
            
            public Schedule(List<Day> daysOfWeek, SchoolQuarter quarter, TimeValue startTime, TimeSpan duration)
            {
                DaysOfWeek = daysOfWeek;
                Quarter = quarter;
                StartTime = startTime;
                Duration = duration;
            }

            public Schedule(string daysOfWeek, string quarter, int startingHour, int startingMinute, 
                int startingSecond, int durationHours, int durationMinutes, int durationSeconds)
            {
                DaysOfWeek = ConvertStringToDayList(daysOfWeek);
                Quarter = ConvertStringToSchoolQuarter(quarter);

                if (startingHour <= 24 && startingHour > 0 && startingMinute < 60 && startingMinute >= 0 
                    && startingSecond < 60 && startingSecond >= 0)
                {
                    StartTime = new TimeValue(startingHour, startingMinute, startingSecond);
                }
                else
                {
                    throw new InvalidDataException("Starting time is out of valid time range! Valid range: " +
                                                   "Hour (0-24), Minute (0-60), Seconds (0-60)");
                }
                
                Duration = new TimeSpan(durationHours, durationMinutes, durationSeconds);
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
        }

        private readonly Schedule _currentSchedule;

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
        public int DailyHoursOfHomeworkExpected 
            => (_currentSchedule.Duration.Hours+(_currentSchedule.Duration.Minutes/60)) * 2;

        public string GetSummaryInformation()
        {
            string daysOfWeekEventOccursOn = "";
            foreach (Day cur in _currentSchedule.DaysOfWeek)
            {
                daysOfWeekEventOccursOn += cur + " ";
            }
            
            return 
$@"The course CRN is: {Crn}
It starts at {_currentSchedule.StartTime.Hour}:{_currentSchedule.StartTime._minute}:{_currentSchedule.StartTime._second} 
It lasts for {_currentSchedule.Duration.Hours} hours {_currentSchedule.Duration.Minutes} minutes and {_currentSchedule.Duration.Seconds} seconds
It repeats on {daysOfWeekEventOccursOn}
Expect {DailyHoursOfHomeworkExpected} hours of homework each day.";
        }

        public int GetStartingHour()
        {
            return _currentSchedule.StartTime.Hour;
        }

        public int GetEndingHour()
        {
            int startingTimePlusDuration = _currentSchedule.StartTime.Hour + _currentSchedule.Duration.Hours;

            if (startingTimePlusDuration > 24)
            {
                return startingTimePlusDuration - 24;
            }

            return startingTimePlusDuration;
        }
    }
}